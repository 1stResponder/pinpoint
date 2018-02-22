using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Positioning;
using log4net;
using System.Timers;
using EMS.NIEM.NIEMCommon;
using EMS.NIEM.EMLC;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace PinPoint
{
  public class GPSHandler
  {
    private NmeaInterpreter nmeaInterpreter;
    private string gpsName;
    private static ILog log;
    private bool hasGPS = false;
    private bool hasFix = false;
    private LocationCylinder currentLocation;
    private static readonly object locLock = new object();
    private static readonly object namelock = new object();
    private System.Timers.Timer detectTimer;
    public bool HasGPS
    {
      get { return hasGPS; }
    }

    public bool HasFix
    {
      get { return hasFix; }
    }

    public LocationCylinder CurrentLocation
    {
      get
      {
        lock (locLock)
        {
          return currentLocation;
        }
      }
      private set
      {
        lock (locLock)
        {
          currentLocation = value;
        }
      }
    } 

    public string GPSName
    {
      get
      {
        lock (namelock)
        {
          return gpsName;
        }
      }
      private set
      {
        lock(namelock)
        {
          gpsName = value;
        }

      }
    }

    public GPSHandler()
    {
    }

    public GPSHandler(ILog logpass, EventHandler<DeviceEventArgs> onConnect, EventHandler<DeviceEventArgs> onFix, EventHandler<DeviceEventArgs> onFixLost, EventHandler<PositionEventArgs> onPosition)
    {
      this.GPSName = string.Empty;
      Application.ThreadException += this.Application_ThreadException;
      AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
      Devices.DeviceDetectionAttempted += this.Devices_DeviceDetectionAttempted;
      Devices.DeviceDetectionAttemptFailed += this.Devices_DeviceDetectionAttemptFailed;
      Devices.DeviceDetectionStarted += this.Devices_DeviceDetectionStarted;
      Devices.DeviceDetectionCompleted += this.Devices_DeviceDetectionCompleted;
      Devices.DeviceDetectionCanceled += this.Devices_DeviceDetectionCanceled;
      Devices.DeviceDetected += this.Devices_DeviceDetected;
      Devices.DeviceDetected += onConnect;
      Devices.FixAcquired += new EventHandler<DeviceEventArgs>(Devices_FixAcquired);
      Devices.FixAcquired += onFix;
      Devices.FixLost += new EventHandler<DeviceEventArgs>(Devices_FixLost);
      Devices.FixLost += onFixLost;
      Devices.PositionChanged += new EventHandler<PositionEventArgs>(Devices_PositionChanged);
      this.nmeaInterpreter = new NmeaInterpreter();
      this.nmeaInterpreter.IsFilterEnabled = false;
      this.nmeaInterpreter.Starting += new EventHandler<DeviceEventArgs>(this.nmeaInterpreter_Starting);
      this.nmeaInterpreter.Started += new EventHandler(this.nmeaInterpreter_Started);
      this.nmeaInterpreter.Stopping += new EventHandler(this.nmeaInterpreter_Stopping);
      this.nmeaInterpreter.Stopped += new EventHandler(this.nmeaInterpreter_Stopped);
      this.nmeaInterpreter.Paused += new EventHandler(this.nmeaInterpreter_Paused);
      this.nmeaInterpreter.Resumed += new EventHandler(this.nmeaInterpreter_Resumed);
      this.nmeaInterpreter.ConnectionLost += new EventHandler<ExceptionEventArgs>(nmeaInterpreter_ConnectionLost);
      this.nmeaInterpreter.FixAcquired += new EventHandler(nmeaInterpreter_FixAcquired);
      this.nmeaInterpreter.FixLost += new EventHandler(nmeaInterpreter_FixLost);
      this.nmeaInterpreter.PositionReceived += new EventHandler<PositionEventArgs>(this.nmeaInterpreter_PositionRecieved);
      this.nmeaInterpreter.PositionReceived += onPosition;
      //this.nmeaInterpreter.PositionChanged += new EventHandler<PositionEventArgs>(this.nmeaInterpreter_PositionChanged);
      Devices.AllowBluetoothConnections = false;
      this.detectTimer = new System.Timers.Timer();
      this.detectTimer.Interval = 5000;
      this.detectTimer.Elapsed += new ElapsedEventHandler(this.detectTimer_Tick);
      this.detectTimer.Start();
      //this.detectTimer.SynchronizingObject = this;
      log = logpass;
      log.Info("Handler initialized");
      
    }

    private void detectTimer_Tick(object sender, ElapsedEventArgs e)
    {
      log.Info("Detect Timer tick");
      detectTimer.Stop();
      Devices.BeginDetection();
    }


    #region GPS Device Detection Events

    /// <summary>
    /// Handles the DeviceDetectionCanceled event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetectionCanceled(object sender, EventArgs e)
    {
      log.Warn("Device detection canceled!");
      this.detectTimer.Start();
    }

    /// <summary>
    /// Handles the DeviceDetected event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.DeviceEventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetected(object sender, DeviceEventArgs e)
    {
      log.Info("There are GPS devices plugged in");
      try
      {
        IList<Device> foo = Devices.GpsDevices;
        bool deviceFound = false;
        foreach (Device dev in foo)
        {
          if (!deviceFound)
          {
            if (dev.IsGpsDevice)
            {
              deviceFound = true;
              this.GPSName = dev.Name;
            }
          }
          else
          {
            dev.Close();
          }
        }
        this.hasGPS = true;
        this.detectTimer.Stop();
        this.nmeaInterpreter.Start();
      }
      catch (Exception ex)
      {
        log.Error("Error Starting NMEA Interpreter", ex);
      }
      log.Info("Device Detected: " + e.Device.Name);
    }

    /// <summary>
    /// Handles the DeviceDetectionCompleted event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetectionCompleted(object sender, EventArgs e)
    {
      log.Info("Device detection complete");
      if(!hasGPS)
      {
        this.detectTimer.Start();
      }
    }

    /// <summary>
    /// Handles the DeviceDetectionStarted event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetectionStarted(object sender, EventArgs e)
    {
      log.Info("Detecting GPS Devices...");
    }

    /// <summary>
    /// Handles the DeviceDetectionAttemptFailed event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.DeviceDetectionExceptionEventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetectionAttemptFailed(object sender, DeviceDetectionExceptionEventArgs e)
    {
      log.Warn("Device detection failed: " + e.Device.Name, e.Exception);
    }

    /// <summary>
    /// Handles the DeviceDetectionAttempted event of the Devices control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.DeviceEventArgs"/> instance containing the event data.</param>
    private void Devices_DeviceDetectionAttempted(object sender, DeviceEventArgs e)
    {
      log.Info("Device Detection Attempt: " + e.Device.Name);
    }

    #endregion

    #region GPS Device Generic Events

    /// <summary>
    /// Event Fired when Position Changes
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    void Devices_PositionChanged(object sender, PositionEventArgs e)
    {
      log.Debug("Device Position Changed!");
    }

    /// <summary>
    /// Event Fired when GPS Fix is Lost
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    void Devices_FixLost(object sender, DeviceEventArgs e)
    {
      log.Warn("Device Fix Lost!");
      hasFix = false;
    }

    /// <summary>
    /// Event Fired when GPS Fix is Acquired
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    void Devices_FixAcquired(object sender, DeviceEventArgs e)
    {
      log.Info("Device Fix Acquired!");
      hasFix = true;
    }

    #endregion

    #region NmeaInterpreter Events

    /// <summary>
    /// Handles the Paused event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Paused(object sender, EventArgs e)
    {
      log.Info("NMEA Pause");
    }

    /// <summary>
    /// Handles the Resumed event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Resumed(object sender, EventArgs e)
    {
      log.Info("NMEA Resume");
    }

    /// <summary>
    /// Handles the Starting event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.DeviceEventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Starting(object sender, DeviceEventArgs e)
    {
      log.Info("NMEA Starting");
    }

    /// <summary>
    /// Handles the Started event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Started(object sender, EventArgs e)
    {
      log.Info("NMEA Started");
    }

    /// <summary>
    /// Handles the Stopping event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Stopping(object sender, EventArgs e)
    {
      log.Info("NMEA Stopping");
    }

    /// <summary>
    /// Handles the Stopped event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_Stopped(object sender, EventArgs e)
    {
      log.Info("NMEA Stopped");
    }

    /// <summary>
    /// Handles the PositionChanged event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.PositionEventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_PositionChanged(object sender, PositionEventArgs e)
    {
      log.Debug("NMEA Pos Delta");
      if (hasFix)
      {
        LocationCylinder currentloc = new LocationCylinder();
        currentloc.CodeValue = LocationCreationCodeList.MACHINE_GPS;

        try
        {
          log.Debug("Updating position object");
          if (!e.Position.IsInvalid && !e.Position.IsEmpty)
          {
            currentloc.LocationPoint.Point.Lat = e.Position.Latitude.DecimalDegrees;
            currentloc.LocationPoint.Point.Lon = e.Position.Longitude.DecimalDegrees;
            currentloc.LocationPoint.Point.Height = nmeaInterpreter.Altitude.ToMeters().Value;
            this.CurrentLocation = currentloc;
          }
          else
          {
            log.Error("Position contain no value or is invalid.");
          }
        }
        catch (Exception ex)
        {
          log.Error("Could not update position object", ex);
        }
      }
    }

    /// <summary>
    /// Handles the PositionRecieved event of the nmeaInterpreter control.
    /// </summary>
    /// <param name="TxSender">The source of the event.</param>
    /// <param name="e">The <see cref="DotSpatial.Positioning.PositionEventArgs"/> instance containing the event data.</param>
    private void nmeaInterpreter_PositionRecieved(object TxSender, PositionEventArgs e)
    {
      log.Debug("Got NMEA Sentance");
      if (hasFix)
      {
        LocationCylinder currentloc = new LocationCylinder();
        currentloc.CodeValue = LocationCreationCodeList.MACHINE_GPS;
        try
        {
          log.Debug("Updating position object");
          if (!e.Position.IsInvalid && !e.Position.IsEmpty)
          {
            currentloc.LocationPoint.Point.Lat = e.Position.Latitude.DecimalDegrees;
            currentloc.LocationPoint.Point.Lon = e.Position.Longitude.DecimalDegrees;
            currentloc.LocationPoint.Point.Height = nmeaInterpreter.Altitude.ToMeters().Value;
            this.CurrentLocation = currentloc;
            log.Debug("Lat: " + currentloc.LocationPoint.Point.Lat + "\tLon: " + currentloc.LocationPoint.Point.Lat + "\tHeight: " + currentloc.LocationPoint.Point.Height);
          }
          else
          {
            log.Error("Position contain no value or is invalid.");
          }
        }
        catch (Exception ex)
        {
          log.Error("Could not update position object", ex);
        }
      }
    }

    void nmeaInterpreter_FixLost(object sender, EventArgs e)
    {
      log.Warn("NMEA Fix Lost");
      hasFix = false;
    }

    void nmeaInterpreter_FixAcquired(object sender, EventArgs e)
    {
      log.Info("NMEA Fix Acquired");
      hasFix = true;
    }

    void nmeaInterpreter_ConnectionLost(object sender, ExceptionEventArgs e)
    {
      log.Warn("NMEA Connection Lost");
      hasFix = false;
    }

    #endregion

    #region Unhandled Exception Events

    /// <summary>
    /// Handles the UnhandledException event of the CurrentDomain control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      Exception ex = (Exception)e.ExceptionObject;
      NotifyOfUnhandledException(ex);
    }

    /// <summary>
    /// Handles the ThreadException event of the Application control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
    private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      NotifyOfUnhandledException(e.Exception);
    }

    /// <summary>
    /// Logs an unhandled exception and displays a message box alerting the user to the error.
    /// </summary>
    /// <param name="exception">The unhandled exception.</param>
    private void NotifyOfUnhandledException(Exception exception)
    {
      try
      {
        // Log the exception (and all of its inner exceptions)
        Exception innerException = exception;
        while (innerException != null)
        {
          Trace.TraceError(innerException.ToString());
          innerException = innerException.InnerException;
        }

        // Stop the interpreter
        nmeaInterpreter.Stop();
      }
      finally
      {
        log.Error("Unhandled notification", exception);
        // Display the error to the user
        MessageBox.Show(
            "An unexpected error has occurred.\n\n" + exception.GetType() + ": " + exception.Message,
            Application.ProductName,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }
    }

    #endregion

  }
}
