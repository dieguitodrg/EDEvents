using System.Windows.Forms;

namespace EDCrew
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbArduinoCOM = new System.Windows.Forms.ComboBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cbWS = new System.Windows.Forms.CheckBox();
            this.cbCommands = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbVoice = new System.Windows.Forms.CheckBox();
            this.cbNPC = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFaccion = new System.Windows.Forms.TextBox();
            this.nContadorFaccion = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nContadorCombate = new System.Windows.Forms.NumericUpDown();
            this.nContador = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOverlays = new System.Windows.Forms.CheckBox();
            this.cbsystemmessages = new System.Windows.Forms.CheckBox();
            this.cbLED = new System.Windows.Forms.CheckBox();
            this.cbConfiguracion = new System.Windows.Forms.CheckBox();
            this.cbMFDx52 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cbCsharp = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nContadorFaccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContadorCombate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContador)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbArduinoCOM);
            this.groupBox1.Controls.Add(this.cbEnabled);
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(314, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arduino";
            // 
            // cbArduinoCOM
            // 
            this.cbArduinoCOM.BackColor = System.Drawing.Color.SandyBrown;
            this.cbArduinoCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArduinoCOM.ForeColor = System.Drawing.Color.Sienna;
            this.cbArduinoCOM.FormattingEnabled = true;
            this.cbArduinoCOM.Location = new System.Drawing.Point(28, 70);
            this.cbArduinoCOM.Margin = new System.Windows.Forms.Padding(6);
            this.cbArduinoCOM.Name = "cbArduinoCOM";
            this.cbArduinoCOM.Size = new System.Drawing.Size(274, 32);
            this.cbArduinoCOM.TabIndex = 1;
            this.cbArduinoCOM.SelectedIndexChanged += new System.EventHandler(this.cbArduinoCOM_SelectedIndexChanged);
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(28, 30);
            this.cbEnabled.Margin = new System.Windows.Forms.Padding(6);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(104, 28);
            this.cbEnabled.TabIndex = 0;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // cbWS
            // 
            this.cbWS.AutoSize = true;
            this.cbWS.Location = new System.Drawing.Point(22, 231);
            this.cbWS.Margin = new System.Windows.Forms.Padding(6);
            this.cbWS.Name = "cbWS";
            this.cbWS.Size = new System.Drawing.Size(152, 28);
            this.cbWS.TabIndex = 1;
            this.cbWS.Text = "Servidor Web";
            this.cbWS.UseVisualStyleBackColor = true;
            this.cbWS.CheckedChanged += new System.EventHandler(this.cbWS_CheckedChanged);
            // 
            // cbCommands
            // 
            this.cbCommands.AutoSize = true;
            this.cbCommands.Location = new System.Drawing.Point(22, 274);
            this.cbCommands.Margin = new System.Windows.Forms.Padding(6);
            this.cbCommands.Name = "cbCommands";
            this.cbCommands.Size = new System.Drawing.Size(197, 28);
            this.cbCommands.TabIndex = 2;
            this.cbCommands.Text = "Comandos por voz";
            this.cbCommands.UseVisualStyleBackColor = true;
            this.cbCommands.CheckedChanged += new System.EventHandler(this.cbCommands_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 737);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbVoice
            // 
            this.cbVoice.AutoSize = true;
            this.cbVoice.Location = new System.Drawing.Point(22, 316);
            this.cbVoice.Margin = new System.Windows.Forms.Padding(6);
            this.cbVoice.Name = "cbVoice";
            this.cbVoice.Size = new System.Drawing.Size(160, 28);
            this.cbVoice.TabIndex = 5;
            this.cbVoice.Text = "Avisos por voz";
            this.cbVoice.UseVisualStyleBackColor = true;
            this.cbVoice.CheckedChanged += new System.EventHandler(this.cbVoice_CheckedChanged);
            // 
            // cbNPC
            // 
            this.cbNPC.AutoSize = true;
            this.cbNPC.Location = new System.Drawing.Point(22, 401);
            this.cbNPC.Margin = new System.Windows.Forms.Padding(6);
            this.cbNPC.Name = "cbNPC";
            this.cbNPC.Size = new System.Drawing.Size(153, 28);
            this.cbNPC.TabIndex = 6;
            this.cbNPC.Text = "Mensajes NPC";
            this.cbNPC.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtFaccion);
            this.groupBox2.Controls.Add(this.nContadorFaccion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nContadorCombate);
            this.groupBox2.Controls.Add(this.nContador);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(337, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(924, 203);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contadores";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(823, 133);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "mARCAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFaccion
            // 
            this.txtFaccion.Location = new System.Drawing.Point(412, 133);
            this.txtFaccion.Margin = new System.Windows.Forms.Padding(6);
            this.txtFaccion.Name = "txtFaccion";
            this.txtFaccion.Size = new System.Drawing.Size(406, 30);
            this.txtFaccion.TabIndex = 6;
            // 
            // nContadorFaccion
            // 
            this.nContadorFaccion.Location = new System.Drawing.Point(180, 133);
            this.nContadorFaccion.Margin = new System.Windows.Forms.Padding(6);
            this.nContadorFaccion.Name = "nContadorFaccion";
            this.nContadorFaccion.Size = new System.Drawing.Size(220, 30);
            this.nContadorFaccion.TabIndex = 5;
            this.nContadorFaccion.ValueChanged += new System.EventHandler(this.nContadorFaccion_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Facción";
            // 
            // nContadorCombate
            // 
            this.nContadorCombate.Location = new System.Drawing.Point(180, 85);
            this.nContadorCombate.Margin = new System.Windows.Forms.Padding(6);
            this.nContadorCombate.Name = "nContadorCombate";
            this.nContadorCombate.Size = new System.Drawing.Size(220, 30);
            this.nContadorCombate.TabIndex = 3;
            this.nContadorCombate.ValueChanged += new System.EventHandler(this.nContadorCombate_ValueChanged);
            // 
            // nContador
            // 
            this.nContador.Location = new System.Drawing.Point(180, 37);
            this.nContador.Margin = new System.Windows.Forms.Padding(6);
            this.nContador.Name = "nContador";
            this.nContador.Size = new System.Drawing.Size(220, 30);
            this.nContador.TabIndex = 2;
            this.nContador.ValueChanged += new System.EventHandler(this.nContador_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Combate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Global:";
            // 
            // cbOverlays
            // 
            this.cbOverlays.AutoSize = true;
            this.cbOverlays.Location = new System.Drawing.Point(22, 359);
            this.cbOverlays.Margin = new System.Windows.Forms.Padding(6);
            this.cbOverlays.Name = "cbOverlays";
            this.cbOverlays.Size = new System.Drawing.Size(111, 28);
            this.cbOverlays.TabIndex = 8;
            this.cbOverlays.Text = "Overlays";
            this.cbOverlays.UseVisualStyleBackColor = true;
            // 
            // cbsystemmessages
            // 
            this.cbsystemmessages.AutoSize = true;
            this.cbsystemmessages.Location = new System.Drawing.Point(22, 444);
            this.cbsystemmessages.Margin = new System.Windows.Forms.Padding(6);
            this.cbsystemmessages.Name = "cbsystemmessages";
            this.cbsystemmessages.Size = new System.Drawing.Size(190, 28);
            this.cbsystemmessages.TabIndex = 9;
            this.cbsystemmessages.Text = "Mensajes Sistema";
            this.cbsystemmessages.UseVisualStyleBackColor = true;
            // 
            // cbLED
            // 
            this.cbLED.AutoSize = true;
            this.cbLED.Location = new System.Drawing.Point(22, 487);
            this.cbLED.Margin = new System.Windows.Forms.Padding(6);
            this.cbLED.Name = "cbLED";
            this.cbLED.Size = new System.Drawing.Size(128, 28);
            this.cbLED.TabIndex = 16;
            this.cbLED.Text = "Tira LED";
            this.cbLED.UseVisualStyleBackColor = true;
            this.cbLED.Checked = true;
            this.cbLED.CheckedChanged += new System.EventHandler(this.cbLED_CheckedChanged);
            // 
            // cbConfiguracion
            // 
            this.cbConfiguracion.AutoSize = true;
            this.cbConfiguracion.Location = new System.Drawing.Point(354, 231);
            this.cbConfiguracion.Margin = new System.Windows.Forms.Padding(6);
            this.cbConfiguracion.Name = "cbConfiguracion";
            this.cbConfiguracion.Size = new System.Drawing.Size(213, 28);
            this.cbConfiguracion.TabIndex = 10;
            this.cbConfiguracion.Text = "Modo Configuración";
            this.cbConfiguracion.UseVisualStyleBackColor = true;
            // 
            // cbMFDx52
            // 
            this.cbMFDx52.AutoSize = true;
            this.cbMFDx52.Location = new System.Drawing.Point(354, 271);
            this.cbMFDx52.Margin = new System.Windows.Forms.Padding(6);
            this.cbMFDx52.Name = "cbMFDx52";
            this.cbMFDx52.Size = new System.Drawing.Size(99, 28);
            this.cbMFDx52.TabIndex = 11;
            this.cbMFDx52.Text = "MFD X52";
            this.cbMFDx52.UseVisualStyleBackColor = true;
            this.cbMFDx52.CheckedChanged += new System.EventHandler(this.cbMFDx52_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.SandyBrown;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Sienna;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(648, 231);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(613, 32);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.SandyBrown;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ForeColor = System.Drawing.Color.Sienna;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(648, 275);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(613, 32);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.SandyBrown;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.ForeColor = System.Drawing.Color.Sienna;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(648, 319);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(613, 32);
            this.comboBox3.TabIndex = 14;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cbCsharp
            // 
            this.cbCsharp.AutoSize = true;
            this.cbCsharp.Location = new System.Drawing.Point(352, 316);
            this.cbCsharp.Margin = new System.Windows.Forms.Padding(6);
            this.cbCsharp.Name = "cbCsharp";
            this.cbCsharp.Size = new System.Drawing.Size(188, 28);
            this.cbCsharp.TabIndex = 15;
            this.cbCsharp.Text = "Eventos a CSHARP";
            this.cbCsharp.UseVisualStyleBackColor = true;
            this.cbCsharp.CheckedChanged += new System.EventHandler(this.cbCsharp_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(1283, 783);
            this.Controls.Add(this.cbCsharp);
            this.Controls.Add(this.cbLED);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cbMFDx52);
            this.Controls.Add(this.cbConfiguracion);
            this.Controls.Add(this.cbsystemmessages);
            this.Controls.Add(this.cbOverlays);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbNPC);
            this.Controls.Add(this.cbVoice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbCommands);
            this.Controls.Add(this.cbWS);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Euro Caps", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Orange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ED Crew";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nContadorFaccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContadorCombate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbArduinoCOM;
        private CheckBox cbEnabled;
        private CheckBox cbWS;
        private CheckBox cbCommands;
        private Button button1;
        private Timer timer1;
        private CheckBox cbVoice;
        private CheckBox cbNPC;
        private GroupBox groupBox2;
        private NumericUpDown nContadorCombate;
        private NumericUpDown nContador;
        private Label label2;
        private Label label1;
        private CheckBox cbOverlays;
        private CheckBox cbsystemmessages;
        private TextBox txtFaccion;
        private NumericUpDown nContadorFaccion;
        private Label label3;
        private CheckBox cbConfiguracion;
        private CheckBox cbMFDx52;
        private Button button2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private CheckBox cbCsharp;
        private CheckBox cbLED;
    }
}