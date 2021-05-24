namespace Wether_Station
{
    partial class Form1
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Temperature = new System.Windows.Forms.TextBox();
            this.Pressure = new System.Windows.Forms.TextBox();
            this.Humidity = new System.Windows.Forms.TextBox();
            this.Light_Intensity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.CausesValidation = false;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            label1.Name = "label1";
            // 
            // Temperature
            // 
            this.Temperature.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.Temperature, "Temperature");
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            // 
            // Pressure
            // 
            this.Pressure.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.Pressure, "Pressure");
            this.Pressure.Name = "Pressure";
            this.Pressure.ReadOnly = true;
            // 
            // Humidity
            // 
            this.Humidity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.Humidity, "Humidity");
            this.Humidity.Name = "Humidity";
            this.Humidity.ReadOnly = true;
            // 
            // Light_Intensity
            // 
            this.Light_Intensity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.Light_Intensity, "Light_Intensity");
            this.Light_Intensity.Name = "Light_Intensity";
            this.Light_Intensity.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // Connect
            // 
            resources.ApplyResources(this.Connect, "Connect");
            this.Connect.Name = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.Light_Intensity);
            this.Controls.Add(this.Humidity);
            this.Controls.Add(this.Pressure);
            this.Controls.Add(this.Temperature);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Temperature;
        private System.Windows.Forms.TextBox Pressure;
        private System.Windows.Forms.TextBox Humidity;
        private System.Windows.Forms.TextBox Light_Intensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

