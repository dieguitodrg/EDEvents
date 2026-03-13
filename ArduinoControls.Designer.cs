namespace EDCrew
{
    partial class ArduinoControls
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
            this.arduinobuttonscontrol = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // arduinobuttonscontrol
            // 
            this.arduinobuttonscontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arduinobuttonscontrol.Location = new System.Drawing.Point(5, 6);
            this.arduinobuttonscontrol.Name = "arduinobuttonscontrol";
            this.arduinobuttonscontrol.Size = new System.Drawing.Size(787, 549);
            this.arduinobuttonscontrol.TabIndex = 0;
            // 
            // ArduinoControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.arduinobuttonscontrol);
            this.Name = "ArduinoControls";
            this.Text = "ArduinoControls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel arduinobuttonscontrol;
    }
}