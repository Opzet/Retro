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
            this.btnDown = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.rollingNumber3 = new RollingNumber();
            this.rollingNumber2 = new RollingNumber();
            this.rollingNumber1 = new RollingNumber();
            this.flipper3 = new Flipper();
            this.flipper2 = new Flipper();
            this.flipper1 = new Flipper();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Fuel.Properties.Resources.Fuel_Pump_Readout;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(189, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 831);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(20, 75);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(122, 43);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(20, 208);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(122, 43);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(836, 91);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(246, 69);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // rollingNumber3
            // 
            this.rollingNumber3.AnimationDelay = 50;
            this.rollingNumber3.BackColor = System.Drawing.Color.Black;
            this.rollingNumber3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber3.Location = new System.Drawing.Point(380, 109);
            this.rollingNumber3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rollingNumber3.Name = "rollingNumber3";
            this.rollingNumber3.Size = new System.Drawing.Size(71, 94);
            this.rollingNumber3.TabIndex = 6;
            // 
            // rollingNumber2
            // 
            this.rollingNumber2.AnimationDelay = 50;
            this.rollingNumber2.BackColor = System.Drawing.Color.Black;
            this.rollingNumber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber2.Location = new System.Drawing.Point(474, 109);
            this.rollingNumber2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rollingNumber2.Name = "rollingNumber2";
            this.rollingNumber2.Size = new System.Drawing.Size(71, 94);
            this.rollingNumber2.TabIndex = 5;
            // 
            // rollingNumber1
            // 
            this.rollingNumber1.AnimationDelay = 50;
            this.rollingNumber1.BackColor = System.Drawing.Color.Black;
            this.rollingNumber1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollingNumber1.Location = new System.Drawing.Point(568, 109);
            this.rollingNumber1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rollingNumber1.Name = "rollingNumber1";
            this.rollingNumber1.Size = new System.Drawing.Size(71, 94);
            this.rollingNumber1.TabIndex = 3;
            // 
            // flipper3
            // 
            this.flipper3.AutoSize = true;
            this.flipper3.FlipperStyle = Flipper.Style.Hour;
            this.flipper3.Location = new System.Drawing.Point(953, 236);
            this.flipper3.Name = "flipper3";
            this.flipper3.Size = new System.Drawing.Size(150, 150);
            this.flipper3.TabIndex = 13;
            // 
            // flipper2
            // 
            this.flipper2.FlipperStyle = Flipper.Style.Second;
            this.flipper2.Location = new System.Drawing.Point(1265, 236);
            this.flipper2.Name = "flipper2";
            this.flipper2.Size = new System.Drawing.Size(150, 150);
            this.flipper2.TabIndex = 12;
            // 
            // flipper1
            // 
            this.flipper1.FlipperStyle = Flipper.Style.Minute;
            this.flipper1.Location = new System.Drawing.Point(1109, 236);
            this.flipper1.Name = "flipper1";
            this.flipper1.Size = new System.Drawing.Size(150, 150);
            this.flipper1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1656, 862);
            this.Controls.Add(this.flipper3);
            this.Controls.Add(this.flipper2);
            this.Controls.Add(this.flipper1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.rollingNumber3);
            this.Controls.Add(this.rollingNumber2);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.rollingNumber1);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private Flipper flipper3;
        private Flipper flipper2;
        private Flipper flipper1;
    }
}