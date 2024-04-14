namespace Fuel
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.rollingNumber1 = new RollingNumber();
            this.btnDown = new System.Windows.Forms.Button();
            this.rollingNumber2 = new RollingNumber();
            this.rollingNumber3 = new RollingNumber();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Fuel.Properties.Resources.Fuel_Pump_Readout;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(126, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 540);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(13, 49);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(81, 28);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // rollingNumber1
            // 
            this.rollingNumber1.BackColor = System.Drawing.Color.Black;
            this.rollingNumber1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber1.Location = new System.Drawing.Point(379, 71);
            this.rollingNumber1.Name = "rollingNumber1";
            this.rollingNumber1.Size = new System.Drawing.Size(48, 62);
            this.rollingNumber1.TabIndex = 3;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(13, 135);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(81, 28);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // rollingNumber2
            // 
            this.rollingNumber2.BackColor = System.Drawing.Color.Black;
            this.rollingNumber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber2.Location = new System.Drawing.Point(316, 71);
            this.rollingNumber2.Name = "rollingNumber2";
            this.rollingNumber2.Size = new System.Drawing.Size(48, 62);
            this.rollingNumber2.TabIndex = 5;
            // 
            // rollingNumber3
            // 
            this.rollingNumber3.BackColor = System.Drawing.Color.Black;
            this.rollingNumber3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber3.Location = new System.Drawing.Point(253, 71);
            this.rollingNumber3.Name = "rollingNumber3";
            this.rollingNumber3.Size = new System.Drawing.Size(48, 62);
            this.rollingNumber3.TabIndex = 6;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(557, 59);
            this.trackBar1.Maximum = 250;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(164, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.rollingNumber3);
            this.Controls.Add(this.rollingNumber2);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.rollingNumber1);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUp;
        private RollingNumber rollingNumber1;
        private System.Windows.Forms.Button btnDown;
        private RollingNumber rollingNumber2;
        private RollingNumber rollingNumber3;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}