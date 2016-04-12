﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Road_To_100
{
    public partial class WorkoutPlan : Form
    {
        public WorkoutPlan()
        {
            InitializeComponent();
        }

        #region drag form
        // Code From the Internet
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        public void setSets()
        {
            The_Road_To_100 trt = new The_Road_To_100();
            int num_sets = trt.sets[9];
            Label[] lb = { Cset1, Cset2, Cset3, Cset4, Cset5, Cset6, Cset7, Cset8, label10, label6, label7, label8 };
            int[] sets = { trt.sets[0], trt.sets[1], trt.sets[2], trt.sets[3], trt.sets[4], trt.sets[5], trt.sets[6], trt.sets[7] };
            lb[0].Text = sets[0].ToString();

            if (sets[7] == 0)
                for (int i = 0; i <= 4; i++)
                {
                    lb[i].Text = sets[i].ToString();
                    if (i == 4) lb[i].Text = String.Format("max (at least  {0})", trt.sets[8].ToString());
                }
            else
            {
                foreach (Label LB in lb)
                    LB.Visible = true;
                for (int i = 0; i <= 8; i++)
                {
                    lb[i].Text = sets[i].ToString();
                    if (i == 8) lb[i].Text = String.Format("max (at least  {0})", trt.sets[8].ToString());
                }
            }
                
        }
    }
}
