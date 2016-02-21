using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Road_To_100
{
    public partial class Exhaustion_test : Form
    {
        public Exhaustion_test()
        {
            InitializeComponent();
            using (StreamReader readWeek = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                switch (readWeek.ReadToEnd())
                {
                    case "3":
                        Cex_testNum.Text = "1";
                        break;
                    case "4":
                        Cex_testNum.Text = "2";
                        break;
                    case "5":
                        Cex_testNum.Text = "3";
                        break;
                    case "6":
                        Cex_testNum.Text = "4";
                        break;
                }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int content = int.Parse(TBtest.Text);
                creatFiles("Exhaustion test", "", content);
                Close();
            }
            catch (Exception)
            {

                Status.Visible = true;
                Status.Text = "You must write a number.";
            }
            
            
        }

        private void creatFiles(string fileName, string TXTCONTANT, int NUMCONTANT)
        {
            string TXTcontant = TXTCONTANT;
            int Numcontant = NUMCONTANT;

            using (StreamWriter fw = new StreamWriter(@"C:\The Road To 100\" + "user.ID 1" + @"\" + fileName + ".txt"))
            {
                if (TXTcontant != "")
                {
                    fw.Write(TXTcontant);
                    fw.Close();
                }
                else if (Numcontant != 0)
                {
                    fw.Write(Numcontant);
                    fw.Close();
                }
            }
        }
    }
}
