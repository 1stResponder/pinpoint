using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using EMS.EDXL.DE;
using EMS.EDXL.DE.v1_0;
using EMS.NIEM.EMLC;
using EMS.NIEM.NIEMCommon;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Net;
using EMS.NIEM.Resource;
using log4net;

namespace PinPoint
{
  public class HTTPSender
  {
    // private PinPointConfig config;
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private Timer sendTimer;
    private bool sending;
    private GPSHandler gpsManager;
    public event EventHandler Sent;
    public bool Sending
    {
      get { return sending; }
    }

    public HTTPSender(GPSHandler _manager)
    {
     // config = _config;
      gpsManager = _manager;
      this.sendTimer = new Timer();
    }

    public void Start()
    {
      this.sendTimer.Interval = PinPointConfig.PostInterval;
      this.sendTimer.Elapsed += new ElapsedEventHandler(this.sendTimer_Tick);
      this.sending = true;
      this.sendTimer.Start();
    }

    public void Stop()
    {
      this.sendTimer.Stop();
    }

    protected virtual void OnSent(EventArgs e)
    {
      EventHandler handler = Sent;
      if(handler!=null)
      {
        handler(this, e);
      }
    }

    private void sendTimer_Tick(object sender, ElapsedEventArgs e)
    {
      this.sendTimer.Stop();
      DEv1_0 de = new DEv1_0();
      de.CombinedConfidentiality = "U";
      de.DateTimeSent = DateTime.UtcNow;
      de.DistributionID = PinPointConfig.UnitID;
      de.SenderID = "pinpoint@pscloud.org";
      de.DistributionReference.Add(PinPointConfig.UnitID + "," + de.SenderID + ",1753-01-01T00:00:00.0000000Z");
      de.DistributionStatus = StatusValue.Actual;
      de.DistributionType = TypeValue.Update;
      de.Language = "en-US";
      
      Event emlc = new Event();
      emlc.EventID = PinPointConfig.UnitID;
      LocationCylinder loc = new LocationCylinder();
      loc.CodeValue = gpsManager.CurrentLocation.CodeValue;
      loc.LocationCylinderHalfHeightValue = -99999;
      loc.LocationCylinderRadiusValue = -99999;
      loc.LocationPoint.Point.Height = gpsManager.CurrentLocation.LocationPoint.Point.Height;
      loc.LocationPoint.Point.Lat = gpsManager.CurrentLocation.LocationPoint.Point.Lat;
      loc.LocationPoint.Point.Lon = gpsManager.CurrentLocation.LocationPoint.Point.Lon;
      loc.LocationPoint.Point.srsName = "http://metadata.ces.mil/mdr/ns/GSIP/crs/WGS84E_3D";
      emlc.EventLocation.LocationCylinder = loc;
      emlc.EventMessageDateTime = DateTime.UtcNow;
      emlc.EventTypeDescriptor.CodeValue = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), PinPointConfig.UnitType);
      emlc.EventTypeDescriptor.EventTypeDescriptorExtension.Add(emlc.EventTypeDescriptor.CodeValue.ToString().Replace("_","."));
      emlc.EventValidityDateTimeRange.StartDate = emlc.EventMessageDateTime;
      emlc.EventValidityDateTimeRange.EndDate = emlc.EventMessageDateTime.AddMinutes(30);

      ResourceDetail resourceDetail = new ResourceDetail();
      resourceDetail.Status = new ResourceStatus();
      TextStatus textStatus = new TextStatus();
      textStatus.Description = "Foo";
      textStatus.SourceID = "VA.LCFR";
      resourceDetail.Status.SecondaryStatus = new List<AltStatus>();
      resourceDetail.Status.SecondaryStatus.Add(textStatus);

      //Log.Info(@"Type: " + unitStatus + " and the file is at " + UNITSTATPATH);
      resourceDetail.setPrimaryStatus(ResourcePrimaryStatusCodeList.Available);
      emlc.Details = resourceDetail;



      List<string> keywords = new List<string>();
      keywords.Add("PinPoint AvL");
      keywords.Add(PinPointConfig.UnitID);
      keywords.Add(emlc.EventTypeDescriptor.CodeValue.ToString().Replace("_", "."));
      ContentObject co = new ContentObject("http://edxlsharp.codeplex.com/ValueLists/ContentKeywords", keywords);
      co.XMLContent = new XMLContentType();
      co.XMLContent.EmbeddedXMLContent = new List<XElement>();
      string str = emlc.ToString();
      XElement xe = XElement.Parse(str);
      co.XMLContent.AddEmbeddedXML(xe);
      co.ContentDescription = "PinPoint AvL";
      de.ContentObjects.Add(co);
      XmlSerializer x = new XmlSerializer(de.GetType());
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.OmitXmlDeclaration = true;

      using (var stream = new StringWriter())
      using (var writer = XmlWriter.Create(stream, xsettings))
      {
        x.Serialize(writer, de);
        str = stream.ToString();
      }
      HttpWebRequest request;
      HttpWebResponse resp;
      //WebProxy proxy;
      string requesturi = PinPointConfig.PostURL;
      request = (HttpWebRequest)WebRequest.Create(requesturi);
      request.KeepAlive = true;
      request.Method = "POST";
      request.ContentType = "text/xml";
      request.AllowAutoRedirect = true;
      request.ContentLength = Encoding.UTF8.GetByteCount(str);
      /*if (!String.IsNullOrWhiteSpace(proxyHostName) && !String.IsNullOrWhiteSpace(proxyPort))
      {
        proxy = new WebProxy();
        proxy.Address = new Uri("http://" + proxyHostName + ":" + proxyPort);
        if (!string.IsNullOrWhiteSpace(proxyUsername) && !string.IsNullOrEmpty(proxyPassword))
        {
          proxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
        }
        request.Proxy = proxy;
      }*/
      try
      {
        SetBody(request, str);
        resp = (HttpWebResponse)request.GetResponse();
        resp.Close();
      }
      catch(Exception ex)
      {
        log.Error("Error in HTTPSender: " + ex.ToString());
      }
      OnSent(EventArgs.Empty);
      this.sendTimer.Start();
    }

    /// <summary>
    /// Set Body of Request 
    /// </summary>
    /// <param name="request">The Request Data</param>
    /// <param name="requestBody">Request Body</param>
    private static void SetBody(HttpWebRequest request, string requestBody)
    {
      if (requestBody.Length > 0)
      {
        Stream requestStream = request.GetRequestStream();
        StreamWriter writer = new StreamWriter(requestStream);
        writer.AutoFlush = true;
        writer.Write(requestBody);
        writer.Flush();
        writer.Close();
        requestStream.Flush();
        requestStream.Close();
      }
    }
  }
}
