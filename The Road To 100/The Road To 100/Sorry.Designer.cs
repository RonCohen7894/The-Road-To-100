namespace The_Road_To_100
{
    partial class Sorry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Boktoclose = new System.Windows.Forms.Button();
            this.Linfo_intailtest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Boktoclose);
            this.panel1.Controls.Add(this.Linfo_intailtest);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 262);
            this.panel1.TabIndex = 0;
            // 
            // Boktoclose
            // 
            this.Boktoclose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Boktoclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Boktoclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Boktoclose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Boktoclose.FlatAppearance.BorderSize = 3;
            this.Boktoclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boktoclose.ForeColor = System.Drawing.Color.Azure;
            this.Boktoclose.Location = new System.Drawing.Point(272, 212);
            this.Boktoclose.Name = "Boktoclose";
            this.Boktoclose.Size = new System.Drawing.Size(111, 45);
            this.Boktoclose.TabIndex = 5;
            this.Boktoclose.Text = "OK";
            this.Boktoclose.UseVisualStyleBackColor = false;
            this.Boktoclose.Click += new System.EventHandler(this.Boktoclose_Click);
            // 
            // Linfo_intailtest
            // 
            this.Linfo_intailtest.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Linfo_intailtest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Linfo_intailtest.Cursor = System.Windows.Forms.Cursors.Default;
            this.Linfo_intailtest.Enabled = false;
            this.Linfo_intailtest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linfo_intailtest.ForeColor = System.Drawing.Color.Azure;
            this.Linfo_intailtest.Location = new System.Drawing.Point(11, 69);
            this.Linfo_intailtest.Multiline = true;
            this.Linfo_intailtest.Name = "Linfo_intailtest";
            this.Linfo_intailtest.ReadOnly = true;
            this.Linfo_intailtest.Size = new System.Drawing.Size(673, 137);
            this.Linfo_intailtest.TabIndex = 4;
            this.Linfo_intailtest.Text = "You can\'t do enough pushups to progress to the next week of your training,\r\nYou w" +
    "ill need to repeat the last week until you became stronger in order to progress " +
    "further into your training.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "We are sorry but:";
            // 
            // Sorry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 262);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sorry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sorry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Linfo_intailtest;
        public System.Windows.Forms.Button Boktoclose;
        private System.Windows.Forms.Label label1;
    }
}