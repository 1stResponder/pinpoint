using DotSpatial.Positioning;
using log4net;
using System;
using System.Windows.Forms;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace PinPoint
{
    public partial class PinPointMain : Form
    {
        /// <summary>
        /// Log4net logging object
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private delegate void DeviceDel(object sender, DeviceEventArgs e);
        private delegate void PositionDel(object sender, PositionEventArgs e);
        private delegate void EventDel(object sender, EventArgs e);
        private delegate void UIDel();
        private EventHandler<DeviceEventArgs> gpsConnect, fixAcquired, fixLost;
        private EventHandler<PositionEventArgs> positionMessage;
        private GPSHandler gpsManager;
        private HTTPSender sender;
        private bool enabled = false;
        private int gmsg, sent;

        public PinPointMain()
        {
            InitializeComponent();

            string currentUTCTime = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            log.Info(currentUTCTime + " >>> OnStart");

            // Init component values
            this.initUnitType.DataSource = PinPointConstants.UNIT_TYPES;
            this.unitTime.SelectedIndex = 0;

            // Loading Config
            PinPointConfig.LoadSettings();
            if (PinPointConfig.DebugMode)
            {
                pushToolStripMenuItem.Visible = true;
            }
            else
            {
                pushToolStripMenuItem.Visible = false;
            }

            // If there are missing values, bring up settings overlay
            if(PinPointConfig.isInitSettingRequired())
            {
                initConfigGroup.Visible = true;
            }
            else
            {
                initializeGPS();
            }         
        }

        private void initializeGPS()
        {
            // initializing objects
            gpsConnect = new EventHandler<DeviceEventArgs>(this.OnGPSConnect);
            fixAcquired = new EventHandler<DeviceEventArgs>(this.OnFixAcquired);
            fixLost = new EventHandler<DeviceEventArgs>(this.OnFixLost);
            positionMessage = new EventHandler<PositionEventArgs>(this.OnGPSMessage);
            gpsManager = new GPSHandler(log, gpsConnect, fixAcquired, fixLost, positionMessage);
            this.gpsLabel.Text = "Searching for GPS";
            this.statusLabel.Text = "Searching for GPS";
            sender = new HTTPSender(gpsManager);
            sender.Sent += this.OnSent;
            if (PinPointConfig.AutoEnable)
            {
                this.enableButt_Click(null, null);
            }
            else
            {
                this.disableButt_Click(null, null);
            }
        }

        private void OnGPSConnect(object sender, DeviceEventArgs e)
        {
            if (gpsLabel.InvokeRequired)
            {
                // this is worker thread
                DeviceDel del = new DeviceDel(this.OnGPSConnect);
                gpsLabel.Invoke(del, new object[] { sender, e });
            }
            else
            {
                gpsLabel.Text = "GPS: " + gpsManager.GPSName;
                statusLabel.Text = "Waiting for GPS Fix";
                TryEnableAvl();
            }
        }

        private void OnFixAcquired(object sender, DeviceEventArgs e)
        {
            if (fixLabel.InvokeRequired)
            {
                // this is worker thread
                DeviceDel del = new DeviceDel(this.OnFixAcquired);
                fixLabel.Invoke(del, new object[] { sender, e });
            }
            else
            {
                fixLabel.Text = "GPS Fix";
                TryEnableAvl();
            }
        }

        private void OnFixLost(object sender, DeviceEventArgs e)
        {
            if (fixLabel.InvokeRequired)
            {
                // this is worker thread
                DeviceDel del = new DeviceDel(this.OnFixLost);
                fixLabel.Invoke(del, new object[] { sender, e });
            }
            else
            {
                fixLabel.Text = "No Fix";
                TryEnableAvl();
            }
        }

        private void OnGPSMessage(object sender, PositionEventArgs e)
        {
            if (gpsMsgTextBox.InvokeRequired)
            {
                // this is worker thread
                PositionDel del = new PositionDel(this.OnGPSMessage);
                enableButt.Invoke(del, new object[] { sender, e });
            }
            else
            {
                // this is UI thread
                this.gmsg++;
                this.gpsMsgTextBox.Text = gmsg.ToString();
            }
        }

        private void OnSent(object sender, EventArgs e)
        {
            if (sentTextBox.InvokeRequired)
            {
                // this is worker thread
                EventDel del = new EventDel(this.OnSent);
                sentTextBox.Invoke(del, new object[] { sender, e });
            }
            else
            {
                // this is UI thread
                this.sent++;
                this.sentTextBox.Text = sent.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void pushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LocationPush().ShowDialog();
        }

        private void enableButt_Click(object sender, EventArgs e)
        {
            log.Debug("Got Enable Button Click");
            this.enabled = true;
            TryEnableAvl();
        }

        private void disableButt_Click(object sender, EventArgs e)
        {
            log.Debug("Got Disable Button Click");
            this.enabled = false;
            TryEnableAvl();
        }

        private void PinPointMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info("Form Closing...");
        }

        /// <summary>
        /// Enables the send.
        /// </summary>
        private void EnableSend()
        {
            if (enableButt.InvokeRequired)
            {
                // this is worker thread
                UIDel del = new UIDel(this.EnableSend);
                enableButt.Invoke(del, new object[] { });
            }
            else
            {
                // this is UI thread
                this.enableButt.Enabled = false;

                statusLabel.Text = "Reporting Enabled";
                this.sender.Start();
                this.statusPictureBox.Image = Properties.Resources.Green_Ball;
                gpsLabel.Text = this.gpsManager.GPSName;
                log.Info("Sending Enabled");
            }
        }

        /// <summary>
        /// Validate that the required values are set
        /// </summary>
        /// <returns></returns>
        private Boolean validateSettingForm()
        {
            // Checking that unitID is not null or empty and confirming the post interval is not 0
            if (String.IsNullOrEmpty(this.initUnitId.Text))
            {
                string messageBoxText = "All Unit Settings need to be completed.";
                string caption = "Setting";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return false;
            }

            return true;
        }

        private void submitInit_Click(object sender, EventArgs e)
        {

            // Validating Input
            if (String.IsNullOrEmpty(this.initUnitId.Text))
            {
                lblUnitId.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Setting Values
            int interval = 0;

            // If the interval is in seconds
            if (this.unitTime.SelectedIndex == 0)
            {
                interval = Convert.ToInt32(this.initRate.Value);
            }

            // If the interval is in minutes
            if (this.unitTime.SelectedIndex == 1)
            {
                interval = Convert.ToInt32(this.initRate.Value * 60);
            }

            PinPointConfig.UnitID = initUnitId.Text;
            PinPointConfig.UnitType = PinPointConstants.NIEM_TYPES[this.initUnitType.SelectedIndex];
            PinPointConfig.PostIntervalSeconds = interval;
            PinPointConfig.SaveSettings();

            // Hiding settings pane and re-enabling options
            initConfigGroup.Visible = false;
            optionsToolStripMenuItem.Enabled = true;
            initializeGPS();
        }

        private void initRate_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nd = (NumericUpDown)sender;
            nd.Value = Convert.ToInt32(nd.Value);
        }

        private void enableButt_EnabledChanged(object sender, EventArgs e)
        {
            if(this.enableButt.Enabled)
            {
                this.optionsToolStripMenuItem.Enabled = true;
                this.disableButt.Enabled = false;

            } else
            {
                this.optionsToolStripMenuItem.Enabled = false;
                this.disableButt.Enabled = true;
            }
        }

        private void initConfigGroup_VisibleChanged(object sender, EventArgs e)
        {
            if(initConfigGroup.Visible)
            {
                optionsToolStripMenuItem.Enabled = false;
            } else
            {
                optionsToolStripMenuItem.Enabled = true;
            }            
        }

        private void initUnitId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If the field is empty, indicate an error
            if (String.IsNullOrEmpty(this.initUnitId.Text))
            {
                this.lblUnitId.ForeColor = System.Drawing.Color.Red;
                this.btnSave.Enabled = false;
                this.missingErrorLabel.Visible = true;
                return;
            }

            // Resetting Error
            this.lblUnitId.ForeColor = new System.Drawing.Color();
            this.btnSave.Enabled = true;
            this.missingErrorLabel.Visible = false;
        }

        /// <summary>
        /// Disables the send UI.
        /// </summary>
        private void DisableSendUI()
        {
            if (this.enableButt.InvokeRequired)
            {
                UIDel del = new UIDel(this.DisableSendUI);
                enableButt.Invoke(del, new object[] { });
            }
            else
            {
                this.enableButt.Enabled = true;

                this.statusPictureBox.Image = Properties.Resources.Red_Ball;
                gpsLabel.Text = this.gpsManager.GPSName;
                statusLabel.Text = "Reporting Disabled";
            }
        }

        /// <summary>
        /// Disables the send.
        /// </summary>
        private void DisableSend()
        {
            this.sender.Stop();
            log.Info("Sending Disabled");
        }

        private void TryEnableAvl()
        {
            if (enableButt.InvokeRequired)
            {
                // this is worker thread
                UIDel del = new UIDel(this.TryEnableAvl);
                enableButt.Invoke(del, new object[] { });
            }
            else
            {
                if (this.enabled)
                {
                    if (this.gpsManager.HasGPS && this.gpsManager.HasFix)
                    {
                        EnableSend();
                    }
                    else
                    {
                        this.enableButt.Enabled = false;
                        this.statusPictureBox.Image = Properties.Resources.Orange_Ball;
                        if (!this.gpsManager.HasGPS)
                        {
                            this.statusLabel.Text = "Waiting for GPS";
                        }
                        DisableSend();
                    }
                }
                else
                {
                    this.enableButt.Enabled = false;
                    DisableSend();
                    DisableSendUI();
                }
            }
        }
    }
}
