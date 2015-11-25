namespace The_Road_To_100
{
    partial class Good_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Good_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Boktoclose = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.PictureBox();
            this.down = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.down)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Boktoclose);
            this.panel1.Controls.Add(this.up);
            this.panel1.Controls.Add(this.down);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 294);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // Boktoclose
            // 
            this.Boktoclose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Boktoclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Boktoclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Boktoclose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Boktoclose.FlatAppearance.BorderSize = 3;
            this.Boktoclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boktoclose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Boktoclose.Location = new System.Drawing.Point(188, 237);
            this.Boktoclose.Name = "Boktoclose";
            this.Boktoclose.Size = new System.Drawing.Size(111, 45);
            this.Boktoclose.TabIndex = 4;
            this.Boktoclose.Text = "OK";
            this.Boktoclose.UseVisualStyleBackColor = false;
            this.Boktoclose.Click += new System.EventHandler(this.Boktoclose_Click);
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.SpringGreen;
            this.up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("up.BackgroundImage")));
            this.up.Location = new System.Drawing.Point(0, 0);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(480, 210);
            this.up.TabIndex = 5;
            this.up.TabStop = false;
            this.up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.SpringGreen;
            this.down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("down.BackgroundImage")));
            this.down.Location = new System.Drawing.Point(0, 0);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(480, 210);
            this.down.TabIndex = 6;
            this.down.TabStop = false;
            this.down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // Good_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(480, 294);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Good_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Good_Form";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.down)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button Boktoclose;
        public System.Windows.Forms.PictureBox up;
        public System.Windows.Forms.PictureBox down;
    }
}