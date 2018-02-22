namespace PinPoint
{
  partial class SettingsForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.lblUnitId = new System.Windows.Forms.Label();
            this.txbUnitId = new System.Windows.Forms.TextBox();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.cbxUnitType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.numberErrorLabel = new System.Windows.Forms.Label();
            this.nuRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cxbTimeUnit = new System.Windows.Forms.ComboBox();
            this.missingErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nuRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitId
            // 
            this.lblUnitId.AutoSize = true;
            this.lblUnitId.Location = new System.Drawing.Point(12, 13);
            this.lblUnitId.Name = "lblUnitId";
            this.lblUnitId.Size = new System.Drawing.Size(38, 13);
            this.lblUnitId.TabIndex = 1;
            this.lblUnitId.Text = "Unit Id";
            // 
            // txbUnitId
            // 
            this.txbUnitId.Location = new System.Drawing.Point(96, 9);
            this.txbUnitId.Name = "txbUnitId";
            this.txbUnitId.Size = new System.Drawing.Size(163, 20);
            this.txbUnitId.TabIndex = 2;
            this.txbUnitId.Validating += new System.ComponentModel.CancelEventHandler(this.txbUnitId_Validating);
            this.txbUnitId.Validated += new System.EventHandler(this.txbUnitId_Validated);
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.Location = new System.Drawing.Point(12, 38);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(53, 13);
            this.lblUnitType.TabIndex = 3;
            this.lblUnitType.Text = "Unit Type";
            // 
            // cbxUnitType
            // 
            this.cbxUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnitType.FormattingEnabled = true;
            this.cbxUnitType.Location = new System.Drawing.Point(96, 35);
            this.cbxUnitType.Name = "cbxUnitType";
            this.cbxUnitType.Size = new System.Drawing.Size(163, 21);
            this.cbxUnitType.TabIndex = 4;
            this.cbxUnitType.SelectionChangeCommitted += new System.EventHandler(this.cbxUnitType_SelectionChangeCommitted);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 115);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(184, 115);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // numberErrorLabel
            // 
            this.numberErrorLabel.AutoSize = true;
            this.numberErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.numberErrorLabel.Location = new System.Drawing.Point(12, 87);
            this.numberErrorLabel.Name = "numberErrorLabel";
            this.numberErrorLabel.Size = new System.Drawing.Size(48, 13);
            this.numberErrorLabel.TabIndex = 10;
            this.numberErrorLabel.Text = "Danger";
            this.numberErrorLabel.Visible = false;
            // 
            // nuRate
            // 
            this.nuRate.Location = new System.Drawing.Point(96, 62);
            this.nuRate.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nuRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuRate.Name = "nuRate";
            this.nuRate.Size = new System.Drawing.Size(60, 20);
            this.nuRate.TabIndex = 17;
            this.nuRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nuRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuRate.ValueChanged += new System.EventHandler(this.nuRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reporting Rate";
            // 
            // cxbTimeUnit
            // 
            this.cxbTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cxbTimeUnit.FormattingEnabled = true;
            this.cxbTimeUnit.Items.AddRange(new object[] {
            "seconds",
            "minutes"});
            this.cxbTimeUnit.Location = new System.Drawing.Point(174, 61);
            this.cxbTimeUnit.Name = "cxbTimeUnit";
            this.cxbTimeUnit.Size = new System.Drawing.Size(84, 21);
            this.cxbTimeUnit.TabIndex = 18;
            this.cxbTimeUnit.SelectionChangeCommitted += new System.EventHandler(this.nuRate_ValueChanged);
            // 
            // missingErrorLabel
            // 
            this.missingErrorLabel.AutoSize = true;
            this.missingErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.missingErrorLabel.Location = new System.Drawing.Point(12, 87);
            this.missingErrorLabel.Name = "missingErrorLabel";
            this.missingErrorLabel.Size = new System.Drawing.Size(149, 13);
            this.missingErrorLabel.TabIndex = 19;
            this.missingErrorLabel.Text = "All Settings Are Required";
            this.missingErrorLabel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(270, 143);
            this.ControlBox = false;
            this.Controls.Add(this.missingErrorLabel);
            this.Controls.Add(this.cxbTimeUnit);
            this.Controls.Add(this.nuRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberErrorLabel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxUnitType);
            this.Controls.Add(this.lblUnitType);
            this.Controls.Add(this.txbUnitId);
            this.Controls.Add(this.lblUnitId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nuRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUnitId;
    private System.Windows.Forms.TextBox txbUnitId;
    private System.Windows.Forms.Label lblUnitType;
    private System.Windows.Forms.ComboBox cbxUnitType;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label numberErrorLabel;
        private System.Windows.Forms.NumericUpDown nuRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cxbTimeUnit;
        private System.Windows.Forms.Label missingErrorLabel;
    }
}