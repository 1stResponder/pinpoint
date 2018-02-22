namespace PinPoint
{
  partial class LocationPush
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
      this.lblLat = new System.Windows.Forms.Label();
      this.txbLat = new System.Windows.Forms.TextBox();
      this.lblLon = new System.Windows.Forms.Label();
      this.txbLon = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblLat
      // 
      this.lblLat.AutoSize = true;
      this.lblLat.Location = new System.Drawing.Point(20, 25);
      this.lblLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblLat.Name = "lblLat";
      this.lblLat.Size = new System.Drawing.Size(67, 20);
      this.lblLat.TabIndex = 1;
      this.lblLat.Text = "Latitude";
      // 
      // txbLat
      // 
      this.txbLat.Location = new System.Drawing.Point(110, 20);
      this.txbLat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbLat.Name = "txbLat";
      this.txbLat.Size = new System.Drawing.Size(148, 26);
      this.txbLat.TabIndex = 3;
      // 
      // lblLon
      // 
      this.lblLon.AutoSize = true;
      this.lblLon.Location = new System.Drawing.Point(20, 66);
      this.lblLon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblLon.Name = "lblLon";
      this.lblLon.Size = new System.Drawing.Size(80, 20);
      this.lblLon.TabIndex = 4;
      this.lblLon.Text = "Longitude";
      // 
      // txbLon
      // 
      this.txbLon.Location = new System.Drawing.Point(110, 55);
      this.txbLon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbLon.Name = "txbLon";
      this.txbLon.Size = new System.Drawing.Size(148, 26);
      this.txbLon.TabIndex = 5;
      // 
      // btnSend
      // 
      this.btnSend.Location = new System.Drawing.Point(20, 108);
      this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(240, 35);
      this.btnSend.TabIndex = 6;
      this.btnSend.Text = "Send";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // LocationPush
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(279, 158);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.txbLon);
      this.Controls.Add(this.lblLon);
      this.Controls.Add(this.txbLat);
      this.Controls.Add(this.lblLat);
      this.Name = "LocationPush";
      this.Text = "Location Push";
      this.Load += new System.EventHandler(this.LocationPush_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblLat;
    private System.Windows.Forms.TextBox txbLat;
    private System.Windows.Forms.Label lblLon;
    private System.Windows.Forms.TextBox txbLon;
    private System.Windows.Forms.Button btnSend;
  }
}