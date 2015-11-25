using System;
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
    public partial class Good_Form : Form
    {
        bool stillRuning = true;

        public Good_Form()
        {
            InitializeComponent();
            show_good_goodForm();
            
        }

        public async void show_good_goodForm()
        {
            while (stillRuning == true)
            {
                await Task.Delay(500);
                up.SendToBack();
                await Task.Delay(500);
                up.BringToFront();
            }
        }

        #region dragform
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void Boktoclose_Click(object sender, EventArgs e)
        {
            stillRuning = false;
        }
    }
}
