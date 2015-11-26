namespace The_Road_To_100
{
    partial class knowledge_center
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
            this.POPUPmainmanue = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Boktoclose = new System.Windows.Forms.Button();
            this.POPUPmainmanue.SuspendLayout();
            this.SuspendLayout();
            // 
            // POPUPmainmanue
            // 
            this.POPUPmainmanue.BackColor = System.Drawing.Color.PaleTurquoise;
            this.POPUPmainmanue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.POPUPmainmanue.Controls.Add(this.textBox1);
            this.POPUPmainmanue.Controls.Add(this.Boktoclose);
            this.POPUPmainmanue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POPUPmainmanue.Location = new System.Drawing.Point(0, 0);
            this.POPUPmainmanue.Name = "POPUPmainmanue";
            this.POPUPmainmanue.Size = new System.Drawing.Size(364, 415);
            this.POPUPmainmanue.TabIndex = 0;
            this.POPUPmainmanue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Azure;
            this.textBox1.Location = new System.Drawing.Point(11, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(340, 349);
            this.textBox1.TabIndex = 2;
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            // 
            // Boktoclose
            // 
            this.Boktoclose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Boktoclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Boktoclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Boktoclose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Boktoclose.FlatAppearance.BorderSize = 3;
            this.Boktoclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boktoclose.Location = new System.Drawing.Point(125, 363);
            this.Boktoclose.Name = "Boktoclose";
            this.Boktoclose.Size = new System.Drawing.Size(111, 45);
            this.Boktoclose.TabIndex = 1;
            this.Boktoclose.Text = "OK";
            this.Boktoclose.UseVisualStyleBackColor = false;
            // 
            // knowledge_center
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 415);
            this.Controls.Add(this.POPUPmainmanue);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "knowledge_center";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "knowledge_center";
            this.MouseHover += new System.EventHandler(this.knowledge_center_MouseHover);
            this.POPUPmainmanue.ResumeLayout(false);
            this.POPUPmainmanue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel POPUPmainmanue;
        public System.Windows.Forms.Button Boktoclose;
        public System.Windows.Forms.TextBox textBox1;
    }
}