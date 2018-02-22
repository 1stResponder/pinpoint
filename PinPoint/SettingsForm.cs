using System;
using System.Windows.Forms;

namespace PinPoint
{
    public partial class SettingsForm : Form
    {
        private string currentId;
        private string currentType;
        private int currentRate;

        private string newId = String.Empty;
        private string newType = String.Empty;
        private int newRate = 1;

        public SettingsForm()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            // Populating drop down 
            this.cbxUnitType.DataSource = PinPointConstants.UNIT_TYPES;
            this.cxbTimeUnit.SelectedIndex = 0;

            // Getting init values + setting values for form  
            txbUnitId.Text = newId = currentId = PinPointConfig.UnitID;
            nuRate.Value = newRate = currentRate = PinPointConfig.PostIntervalSeconds;
            newType = currentType = PinPointConfig.UnitType;
    
            this.cbxUnitType.SelectedIndex = PinPointConstants.NIEM_TYPES.IndexOf(currentType);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(this.newId))
            {
                string messageBoxText = "All Unit Settings need to be completed.";
                string caption = "Setting";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            PinPointConfig.UnitID = this.newId;
            PinPointConfig.PostIntervalSeconds = this.newRate;
            PinPointConfig.UnitType = this.newType;
            PinPointConfig.SaveSettings();
            Close();
        }   

        /// <summary>
        /// Determines whether this instance is dirty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is dirty; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDirty()
        {
            this.Text = "PinPoint Settings";

            if ((this.currentType != this.newType) || (this.currentId != this.newId) || (this.currentRate != this.newRate))
            {
                this.newId = this.txbUnitId.Text;
                this.Text += "*";
                return true;
            }

            return false;
        }

        //--- Event Handlers

        private void cbxUnitType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            newType = PinPointConstants.NIEM_TYPES[this.cbxUnitType.SelectedIndex];
            IsDirty();
        }

        private void nuRate_ValueChanged(object sender, EventArgs e)
        {
            this.nuRate.Value = Convert.ToInt32(this.nuRate.Value);

            switch (this.cxbTimeUnit.SelectedIndex)
            {
                case 0:
                    newRate = Convert.ToInt32(this.nuRate.Value);
                    break;
                case 1:
                    newRate = Convert.ToInt32(this.nuRate.Value * 60);
                    break;
            }

            IsDirty();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void txbUnitId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If the field is empty, indicate an error
            if (String.IsNullOrEmpty(this.txbUnitId.Text))
            {
                this.lblUnitId.ForeColor = System.Drawing.Color.Red;
                this.btnSave.Enabled = false;
                this.missingErrorLabel.Visible = true;
                e.Cancel = true;
                return;
            }

            // Resetting Error
            this.lblUnitId.ForeColor = new System.Drawing.Color();
            this.btnSave.Enabled = true;
            this.missingErrorLabel.Visible = false;
        }

        private void txbUnitId_Validated(object sender, EventArgs e)
        {
            newId = this.txbUnitId.Text;
            IsDirty();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (IsDirty())
            {
              string messageBoxText = "There are unsaved changes are you sure you want to close?";
              string caption = "Setting";
              MessageBoxButtons button = MessageBoxButtons.YesNo;
              MessageBoxIcon icon = MessageBoxIcon.Warning;
              DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);
              if (result == DialogResult.No)
              {
                e.Cancel = true;
              }
            }*/
        }
    }
}
