namespace PinPoint
{
  partial class PinPointMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinPointMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusPictureBox = new System.Windows.Forms.PictureBox();
            this.enableButt = new System.Windows.Forms.Button();
            this.disableButt = new System.Windows.Forms.Button();
            this.sentLabel = new System.Windows.Forms.Label();
            this.sentTextBox = new System.Windows.Forms.TextBox();
            this.gmsgLabel = new System.Windows.Forms.Label();
            this.gpsMsgTextBox = new System.Windows.Forms.TextBox();
            this.gpsLabel = new System.Windows.Forms.Label();
            this.fixLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.initConfigGroup = new System.Windows.Forms.GroupBox();
            this.unitTime = new System.Windows.Forms.ComboBox();
            this.initRate = new System.Windows.Forms.NumericUpDown();
            this.missingErrorLabel = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.initUnitType = new System.Windows.Forms.ComboBox();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.initUnitId = new System.Windows.Forms.TextBox();
            this.lblUnitId = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.initConfigGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initRate)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(300, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.pushToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // pushToolStripMenuItem
            // 
            this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
            this.pushToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.pushToolStripMenuItem.Text = "Push";
            this.pushToolStripMenuItem.Click += new System.EventHandler(this.pushToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusLabel.Location = new System.Drawing.Point(12, 37);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(143, 24);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "AvL Initializing";
            // 
            // statusPictureBox
            // 
            this.statusPictureBox.Location = new System.Drawing.Point(248, 28);
            this.statusPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.statusPictureBox.Name = "statusPictureBox";
            this.statusPictureBox.Size = new System.Drawing.Size(32, 32);
            this.statusPictureBox.TabIndex = 12;
            this.statusPictureBox.TabStop = false;
            // 
            // enableButt
            // 
            this.enableButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableButt.Location = new System.Drawing.Point(11, 80);
            this.enableButt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.enableButt.Name = "enableButt";
            this.enableButt.Size = new System.Drawing.Size(106, 59);
            this.enableButt.TabIndex = 13;
            this.enableButt.Text = "Enable";
            this.enableButt.UseVisualStyleBackColor = true;
            this.enableButt.EnabledChanged += new System.EventHandler(this.enableButt_EnabledChanged);
            this.enableButt.Click += new System.EventHandler(this.enableButt_Click);
            // 
            // disableButt
            // 
            this.disableButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableButt.Location = new System.Drawing.Point(174, 80);
            this.disableButt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.disableButt.Name = "disableButt";
            this.disableButt.Size = new System.Drawing.Size(106, 59);
            this.disableButt.TabIndex = 14;
            this.disableButt.Text = "Disable";
            this.disableButt.UseVisualStyleBackColor = true;
            this.disableButt.Click += new System.EventHandler(this.disableButt_Click);
            // 
            // sentLabel
            // 
            this.sentLabel.AutoSize = true;
            this.sentLabel.Location = new System.Drawing.Point(4, 58);
            this.sentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sentLabel.Name = "sentLabel";
            this.sentLabel.Size = new System.Drawing.Size(186, 17);
            this.sentLabel.TabIndex = 15;
            this.sentLabel.Text = "Position Messages Sent:";
            // 
            // sentTextBox
            // 
            this.sentTextBox.Location = new System.Drawing.Point(212, 57);
            this.sentTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sentTextBox.Name = "sentTextBox";
            this.sentTextBox.ReadOnly = true;
            this.sentTextBox.Size = new System.Drawing.Size(42, 23);
            this.sentTextBox.TabIndex = 16;
            this.sentTextBox.TabStop = false;
            this.sentTextBox.Text = "0000";
            // 
            // gmsgLabel
            // 
            this.gmsgLabel.AutoSize = true;
            this.gmsgLabel.Location = new System.Drawing.Point(4, 26);
            this.gmsgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gmsgLabel.Name = "gmsgLabel";
            this.gmsgLabel.Size = new System.Drawing.Size(195, 17);
            this.gmsgLabel.TabIndex = 17;
            this.gmsgLabel.Text = "GPS Messaged Received:";
            // 
            // gpsMsgTextBox
            // 
            this.gpsMsgTextBox.Location = new System.Drawing.Point(212, 26);
            this.gpsMsgTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gpsMsgTextBox.Name = "gpsMsgTextBox";
            this.gpsMsgTextBox.ReadOnly = true;
            this.gpsMsgTextBox.Size = new System.Drawing.Size(42, 23);
            this.gpsMsgTextBox.TabIndex = 18;
            this.gpsMsgTextBox.TabStop = false;
            this.gpsMsgTextBox.Text = "0000";
            // 
            // gpsLabel
            // 
            this.gpsLabel.AutoSize = true;
            this.gpsLabel.Location = new System.Drawing.Point(92, 29);
            this.gpsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gpsLabel.Name = "gpsLabel";
            this.gpsLabel.Size = new System.Drawing.Size(65, 17);
            this.gpsLabel.TabIndex = 19;
            this.gpsLabel.Text = "No GPS";
            // 
            // fixLabel
            // 
            this.fixLabel.AutoSize = true;
            this.fixLabel.Location = new System.Drawing.Point(92, 59);
            this.fixLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fixLabel.Name = "fixLabel";
            this.fixLabel.Size = new System.Drawing.Size(53, 17);
            this.fixLabel.TabIndex = 20;
            this.fixLabel.Text = "No Fix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gpsLabel);
            this.groupBox1.Controls.Add(this.fixLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(268, 90);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPS Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "GPS Fix:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "GPS Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gmsgLabel);
            this.groupBox2.Controls.Add(this.gpsMsgTextBox);
            this.groupBox2.Controls.Add(this.sentLabel);
            this.groupBox2.Controls.Add(this.sentTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 252);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(268, 99);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "In/Out";
            // 
            // initConfigGroup
            // 
            this.initConfigGroup.BackColor = System.Drawing.SystemColors.Control;
            this.initConfigGroup.Controls.Add(this.unitTime);
            this.initConfigGroup.Controls.Add(this.initRate);
            this.initConfigGroup.Controls.Add(this.missingErrorLabel);
            this.initConfigGroup.Controls.Add(this.lblRate);
            this.initConfigGroup.Controls.Add(this.btnSave);
            this.initConfigGroup.Controls.Add(this.label3);
            this.initConfigGroup.Controls.Add(this.initUnitType);
            this.initConfigGroup.Controls.Add(this.lblUnitType);
            this.initConfigGroup.Controls.Add(this.initUnitId);
            this.initConfigGroup.Controls.Add(this.lblUnitId);
            this.initConfigGroup.Location = new System.Drawing.Point(0, 27);
            this.initConfigGroup.Name = "initConfigGroup";
            this.initConfigGroup.Size = new System.Drawing.Size(300, 333);
            this.initConfigGroup.TabIndex = 19;
            this.initConfigGroup.TabStop = false;
            this.initConfigGroup.Visible = false;
            this.initConfigGroup.VisibleChanged += new System.EventHandler(this.initConfigGroup_VisibleChanged);
            // 
            // unitTime
            // 
            this.unitTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitTime.FormattingEnabled = true;
            this.unitTime.Items.AddRange(new object[] {
            "seconds",
            "minutes"});
            this.unitTime.Location = new System.Drawing.Point(188, 114);
            this.unitTime.MaxDropDownItems = 10;
            this.unitTime.Name = "unitTime";
            this.unitTime.Size = new System.Drawing.Size(66, 21);
            this.unitTime.TabIndex = 16;
            // 
            // initRate
            // 
            this.initRate.Location = new System.Drawing.Point(122, 114);
            this.initRate.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.initRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.initRate.Name = "initRate";
            this.initRate.Size = new System.Drawing.Size(60, 20);
            this.initRate.TabIndex = 14;
            this.initRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.initRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.initRate.ValueChanged += new System.EventHandler(this.initRate_ValueChanged);
            // 
            // missingErrorLabel
            // 
            this.missingErrorLabel.AutoSize = true;
            this.missingErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.missingErrorLabel.Location = new System.Drawing.Point(20, 166);
            this.missingErrorLabel.Name = "missingErrorLabel";
            this.missingErrorLabel.Size = new System.Drawing.Size(149, 13);
            this.missingErrorLabel.TabIndex = 13;
            this.missingErrorLabel.Text = "All Settings Are Required";
            this.missingErrorLabel.Visible = false;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(28, 117);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(79, 13);
            this.lblRate.TabIndex = 11;
            this.lblRate.Text = "Reporting Rate";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(179, 161);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.submitInit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Setup";
            // 
            // initUnitType
            // 
            this.initUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.initUnitType.FormattingEnabled = true;
            this.initUnitType.Location = new System.Drawing.Point(87, 82);
            this.initUnitType.MaxDropDownItems = 100;
            this.initUnitType.Name = "initUnitType";
            this.initUnitType.Size = new System.Drawing.Size(167, 21);
            this.initUnitType.TabIndex = 8;
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.Location = new System.Drawing.Point(28, 85);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(53, 13);
            this.lblUnitType.TabIndex = 7;
            this.lblUnitType.Text = "Unit Type";
            // 
            // initUnitId
            // 
            this.initUnitId.Location = new System.Drawing.Point(87, 50);
            this.initUnitId.Name = "initUnitId";
            this.initUnitId.Size = new System.Drawing.Size(167, 20);
            this.initUnitId.TabIndex = 6;
            this.initUnitId.Validating += new System.ComponentModel.CancelEventHandler(this.initUnitId_Validating);
            // 
            // lblUnitId
            // 
            this.lblUnitId.AutoSize = true;
            this.lblUnitId.Location = new System.Drawing.Point(28, 53);
            this.lblUnitId.Name = "lblUnitId";
            this.lblUnitId.Size = new System.Drawing.Size(38, 13);
            this.lblUnitId.TabIndex = 5;
            this.lblUnitId.Text = "Unit Id";
            // 
            // PinPointMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 372);
            this.ControlBox = false;
            this.Controls.Add(this.initConfigGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.disableButt);
            this.Controls.Add(this.enableButt);
            this.Controls.Add(this.statusPictureBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PinPointMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pinpoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PinPointMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.initConfigGroup.ResumeLayout(false);
            this.initConfigGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pushToolStripMenuItem;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.PictureBox statusPictureBox;
    private System.Windows.Forms.Button enableButt;
    private System.Windows.Forms.Button disableButt;
    private System.Windows.Forms.Label sentLabel;
    private System.Windows.Forms.TextBox sentTextBox;
    private System.Windows.Forms.Label gmsgLabel;
    private System.Windows.Forms.TextBox gpsMsgTextBox;
    private System.Windows.Forms.Label gpsLabel;
    private System.Windows.Forms.Label fixLabel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox initConfigGroup;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox initUnitType;
        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.TextBox initUnitId;
        private System.Windows.Forms.Label lblUnitId;
        private System.Windows.Forms.NumericUpDown initRate;
        private System.Windows.Forms.ComboBox unitTime;
        private System.Windows.Forms.Label missingErrorLabel;
    }
}