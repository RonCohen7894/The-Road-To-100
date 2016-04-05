using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace The_Road_To_100
{
    public partial class knowledge_center : Form
    {
        public knowledge_center()
        {
            InitializeComponent();
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

        private void knowledge_center_MouseHover(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        public void GetContent(string content)
        {
            if (content == null || content == "")
                throw new Exception("Content can not be null");
            textBox1.Text = content;
        }
    }
}
