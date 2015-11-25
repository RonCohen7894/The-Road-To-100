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
using System.IO;
using System.Text.RegularExpressions;

namespace The_Road_To_100
{
    public partial class The_Road_To_100 : Form
    {
        public The_Road_To_100()
        {
            InitializeComponent();
            PmainManu.BringToFront();
            PmainManu.Dock = DockStyle.Fill;
            organizeMenu();

            if (Directory.Exists(@"C:\The Road To 100\user.ID 1"))
            {
                setPersonal_Screen();
                getRank();
                Bcontinue.Enabled = true;
            }

            else
                System.IO.Directory.CreateDirectory(@"C:\The Road To 100");
        }

        #region Variables
        //main menu
        public static string Buttonname;
        public static string content;

        //new user
        string New_name;
        string New_lastName;
        int New_age;
        int intailTest_results;
        public string userFileSavePath;
        public bool fileCreate = false;

        //personal screen
        public static string data_set;
        public int Rank;
        private int Age;
        private int intail_Test;
        private int Level;
        private int set_1;
        private int set_2;
        private int set_3;
        private int set_4;
        private int set_5;
        private int set_6;
        private int set_7;
        private int set_8;
        private int set_9;
        private int set_max;
        private int rest;
        #endregion

        #region main Manu

        private void MainMenuButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            knowledge_center popup = new knowledge_center();

            if (button.Name == "Bintroduction")
                Buttonname = "IntorductionTXT.txt";

            else if (button.Name == "Bwhypushups")
                Buttonname = "why_push_upsTXT.txt";

            else if (button.Name == "Bwhatisapushup")
                Buttonname = "what_is_a_push-upTXT.txt";

            ReadFileTXT();
            popup.textBox1.Text = content;


            DialogResult dialogresult = popup.ShowDialog();
        }

        private void properForm_ButtonClick(object sender, EventArgs e)
        {
            Good_Form popup = new Good_Form();
            DialogResult dialogresult = popup.ShowDialog();
        }

        public static void ReadFileTXT()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Buttonname))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(e.Message);
            }
        }

        public void organizeMenu()
        {
            Menuheadline.Left = PmainManu.Width / 2 - Menuheadline.Width / 2;

            Bintroduction.Top = PmainManu.Top + 100;
            Bwhypushups.Top = PmainManu.Top + 250;
            Bwhatisapushup.Top = PmainManu.Top + 400;
            Bproperform.Top = PmainManu.Top + 550;

            Bcontinue.Top = PmainManu.Top + 100;
            Bnewworksheet.Top = PmainManu.Top + 250;

            Pintro.Left = PmainManu.Width / 2 - Pintro.Width / 2;
        }

        private void Bcontinue_Click(object sender, EventArgs e)
        {
            PmainManu.Dock = DockStyle.None;
            Ppersonal_Screen.Dock = DockStyle.Fill;
            Ppersonal_Screen.BringToFront();

            getWorkoutOfTheDay();
            setPR();
        }

        private void CloseButtoon(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bnewworksheet_Click(object sender, EventArgs e)
        {
            if (Bcontinue.Enabled == true)
            {
                if (MessageBox.Show("There is already a regitered user, \nDo you want to overwrite it?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    PmainManu.Dock = DockStyle.None;
                    PmainManu.SendToBack();

                    Pnew_user.Dock = DockStyle.Fill;
                    Pnew_user.BringToFront();
                }
                else
                    Bcontinue.PerformClick();
            }
            else
            {
                PmainManu.Dock = DockStyle.None;
                PmainManu.SendToBack();

                Pnew_user.Dock = DockStyle.Fill;
                Pnew_user.BringToFront();
            }
        }

        private void backToMainMenu(object sender, EventArgs e)
        {
            this.Dock = DockStyle.None;
            PmainManu.Dock = DockStyle.Fill;
            PmainManu.BringToFront();
        }

        private void setPR()
        {
            StreamReader sr = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Week.txt");
            switch (sr.ReadToEnd())
            {
                case "1":
                    pr1.BackColor = Color.AliceBlue;
                    break;

                case "2":
                    pr1.BackColor = Color.AliceBlue;
                    pr2.BackColor = Color.AliceBlue;
                    break;

                case "3":
                    pr1.BackColor = Color.AliceBlue;
                    pr2.BackColor = Color.AliceBlue;
                    pr3.BackColor = Color.AliceBlue;
                    break;

                case "4":
                    pr1.BackColor = Color.AliceBlue;
                    pr2.BackColor = Color.AliceBlue;
                    pr3.BackColor = Color.AliceBlue;
                    pr4.BackColor = Color.AliceBlue;
                    break;

                case "5":
                    pr1.BackColor = Color.AliceBlue;
                    pr2.BackColor = Color.AliceBlue;
                    pr3.BackColor = Color.AliceBlue;
                    pr4.BackColor = Color.AliceBlue;
                    pr5.BackColor = Color.AliceBlue;
                    break;

                case "6":
                    pr1.BackColor = Color.AliceBlue;
                    pr2.BackColor = Color.AliceBlue;
                    pr3.BackColor = Color.AliceBlue;
                    pr4.BackColor = Color.AliceBlue;
                    pr5.BackColor = Color.AliceBlue;
                    pr6.BackColor = Color.AliceBlue;
                    break;
                
            }
            sr.Close();
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

        #endregion

        #region New User

        private void PICsignup_Click(object sender, EventArgs e)
        {
            New_name = TBname.Text;
            New_lastName = TBlastname.Text;
            // New_age = TBage.text
            // intailTest_results = TBintailtest_results.Text
            Checking_TB();

            if (!SnewName.Visible == true && !SnewLastName.Visible == true && !SnewAge.Visible == true && !Sintailtest_results.Visible == true)
            {
                Directory.CreateDirectory(@"C:\The Road To 100\" + "user.ID 1");
                creatFiles("First Name", New_name, 0);
                creatFiles("Last Name", New_lastName, 0);
                creatFiles("Age", "", New_age);
                creatFiles("Initial Test", "", intailTest_results);
                creatFiles("Total Push ups Done", "", intailTest_results);
                createWorkoutPlanFiles("Week");
                createWorkoutPlanFiles("Day");

                getWorkoutOfTheDay();

                fileCreate = true;
                getRank();
                setPersonal_Screen();
                setPR();
                Bcontinue.Enabled = true;
            }

            if (fileCreate == true)
            {
                Pnew_user.Dock = DockStyle.None;
                Ppersonal_Screen.Dock = DockStyle.Fill;
                Ppersonal_Screen.BringToFront();
            }
        }

        private void creatFiles(string fileName, string TXTCONTANT, int NUMCONTANT)
        {
            string TXTcontant = TXTCONTANT;
            int Numcontant = NUMCONTANT;

            StreamWriter fw = new StreamWriter(@"C:\The Road To 100\" + "user.ID 1" + @"\" + fileName + ".txt");

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

        private void Checking_TB()
        {
            if (TBname.Text == "")
            {
                SnewName.Text = "You must write your name";
                SnewName.Visible = true;
            }

            if (TBlastname.Text == "")
            {
                SnewLastName.Text = "You must write your last name";
                SnewLastName.Visible = true;
            }

            #region try_catch
            try
            {
                New_age = Int32.Parse(TBage.Text);

            }
            catch (Exception e)
            {
                SnewAge.Visible = true;
                SnewAge.Text = "You must write a number";
            }

            try
            {
                intailTest_results = Int32.Parse(TBintailtest_results.Text);

            }
            catch (Exception e)
            {
                Sintailtest_results.Visible = true;
                Sintailtest_results.Text = "You must write a number";
            }
            #endregion
        }

        #region TB_text changed

        private void TBage_TextChanged(object sender, EventArgs e)
        {
            if (SnewAge.Visible == true)
            {
                SnewAge.Visible = false;
            }
        }

        private void TBintailtest_results_TextChanged(object sender, EventArgs e)
        {
            if (Sintailtest_results.Visible == true)
            {
                Sintailtest_results.Visible = false;
            }
        }

        private void TBname_TextChanged(object sender, EventArgs e)
        {
            SnewName.Visible = false;
        }

        private void TBlastname_TextChanged(object sender, EventArgs e)
        {
            SnewLastName.Visible = false;
        }

        #endregion

        public void setPersonal_Screen()
        {
            getdata("First Name");
            getdata("Age");
            getdata("Total Push ups Done");

            StreamReader readWeek = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Week.txt");
            StreamReader readDay = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Day.txt");

            Cweek.Text = readWeek.ReadToEnd();               
            Cday.Text = readDay.ReadToEnd();

            readWeek.Close();
            readDay.Close();


        }

        public void getdata(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\The Road To 100\" + "user.ID 1" + @"\" + filename + ".txt"))
                {
                    data_set = sr.ReadToEnd();
                    if (filename == "First Name")
                    {
                        CHname.Text = data_set;
                        Cname.Text = data_set;
                    }

                    else if (filename == "Age")
                    {
                        Cage.Text = data_set;
                    }

                    else if (filename == "Total Push ups Done")
                    {
                        Ctotal_push_done.Text = data_set;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(e.Message);
            }
        }

        public void getRank()
        {
            using (StreamReader sr = new StreamReader(@"C:\The Road To 100\" + "user.ID 1" + @"\Age.txt"))
            {
                Age = Int32.Parse(sr.ReadToEnd());
            }
            using (StreamReader sr = new StreamReader(@"C:\The Road To 100\" + "user.ID 1" + @"\Initial Test.txt"))
            {
                intail_Test = Int32.Parse(sr.ReadToEnd());
            }

            if (Age <= 40)
            {
                if (intail_Test >= 0 && intail_Test <= 5)
                    Rank = 1;
                else if (intail_Test >= 6 && intail_Test <= 14)
                    Rank = 2;
                else if (intail_Test >= 15 && intail_Test <= 29)
                    Rank = 3;
                else if (intail_Test >= 30 && intail_Test <= 49)
                    Rank = 4;
                else if (intail_Test >= 50 && intail_Test <= 99)
                    Rank = 5;
                else
                    Rank = 10;
            }
            else if (Age >= 40 && Age <= 55)
            {
                if (intail_Test >= 0 && intail_Test <= 5)
                    Rank = 1;
                else if (intail_Test >= 6 && intail_Test <= 12)
                    Rank = 2;
                else if (intail_Test >= 13 && intail_Test <= 24)
                    Rank = 3;
                else if (intail_Test >= 25 && intail_Test <= 44)
                    Rank = 4;
                else if (intail_Test >= 45 && intail_Test <= 74)
                    Rank = 5;
                else
                    Rank = 10;
            }
            else if (Age >= 55)
            {
                if (intail_Test >= 0 && intail_Test <= 5)
                    Rank = 1;
                else if (intail_Test >= 6 && intail_Test <= 10)
                    Rank = 2;
                else if (intail_Test >= 11 && intail_Test <= 19)
                    Rank = 3;
                else if (intail_Test >= 20 && intail_Test <= 34)
                    Rank = 4;
                else if (intail_Test >= 35 && intail_Test <= 64)
                    Rank = 5;

                else
                    Rank = 10;
            }
            else
                MessageBox.Show("Rank files cannot be read");

            if (Rank == 10)
            {
                Crank.Text = "Don't mess with the program files!";
                Ctotal_push_done.Text = "Don't mess with the program files!";
            }
            else
                Crank.Text = Rank.ToString();
        }

        #endregion

        #region Personal Screen

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bplan_Click(object sender, EventArgs e)
        {
            WorkoutPlan popup = new WorkoutPlan();
            StreamReader readTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Initial Test.txt");

            getLevel(int.Parse(readTest.ReadToEnd()), null, null, null);
            findeWorkoutParameters(Level);

            if (set_8 == 0)
            {
                popup.Cset1.Text = set_1.ToString();
                popup.Cset2.Text = set_2.ToString();
                popup.Cset3.Text = set_3.ToString();
                popup.Cset4.Text = set_4.ToString();
                popup.Cset5.Text = String.Format("max (at least  {0})", set_max.ToString());
            }

            else
            {
                popup.Cset6.Visible = true;
                popup.Cset7.Visible = true;
                popup.Cset8.Visible = true;
                popup.Cset9.Visible = true;
                popup.label6.Visible = true;
                popup.label7.Visible = true;
                popup.label8.Visible = true;
                popup.label10.Visible = true;

                popup.Cset1.Text = set_1.ToString();
                popup.Cset2.Text = set_2.ToString();
                popup.Cset3.Text = set_3.ToString();
                popup.Cset4.Text = set_4.ToString();
                popup.Cset5.Text = set_5.ToString();
                popup.Cset6.Text = set_6.ToString();
                popup.Cset7.Text = set_7.ToString();
                popup.Cset8.Text = set_8.ToString();
                popup.Cset9.Text = String.Format("max (at least  {0})", set_max.ToString());
            }

            DialogResult dialogresult = popup.ShowDialog();
        }

        private void getLevel(int? test1, int? test2, int? test3, int? test4)
        {
            StreamReader sr = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt");
            char[] x = (sr.ReadToEnd()).ToCharArray();
            string week = x[0].ToString();

            if (test1 < 20 && week == "1" || week == "2")
            {
                if (test1 <= 5) { Level = 1; }
                else if (test1 >= 6 && test1 <= 10) { Level = 2; }
                else if (test1 >= 11 && test1 <= 20) { Level = 3; }
            }

            else if (test1 > 20 || week == "3" || week == "4")
            {
                if (test2 >= 16 && test2 <= 20 || test1 >= 16 && test1 <= 20) { Level = 1; }
                else if (test2 >= 21 && test2 <= 25 || test1 >= 21 && test1 <= 25) { Level = 2; }
                else if (test2 > 25 || test1 > 25) { Level = 3; }
            }

            else if (week == "5")
            {
                if (test3 >= 31 && test3 <= 35) { Level = 1; }
                else if (test3 >= 36 && test3 <= 40) { Level = 2; }
                else if (test3 > 40) { Level = 3; }
            }

            else if (week == "6")
            {
                if (test4 >= 46 && test4 <= 50) { Level = 1; }
                else if (test4 >= 51 && test4 <= 60) { Level = 2; }
                else if (test4 > 60) { Level = 3; }
            }
            sr.Close();
        }

        private void findeWorkoutParameters(int level)
        {
            StreamReader y = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt");
            char[] readWeek = y.ReadToEnd().ToCharArray();
            string week;
            week = readWeek[0].ToString();

            StreamReader x = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt");
            char[] readDay = x.ReadToEnd().ToCharArray();
            string day = readDay[0].ToString();

            #region week 1
            if (week == "1")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 2;
                        set_2 = 3;
                        set_3 = 2;
                        set_4 = 2;
                        set_max = 3;
                    }

                    else if (level == 2)
                    {
                        set_1 = 6;
                        set_2 = 6;
                        set_3 = 4;
                        set_4 = 4;
                        set_max = 5;
                    }

                    else if (level == 3)
                    {
                        set_1 = 10;
                        set_2 = 12;
                        set_3 = 7;
                        set_4 = 7;
                        set_max = 9;
                    }
                }
                #endregion

                #region day 2 
                else if (day == "2")
                {
                    rest = 90;
                    if (level == 1)
                    {
                        set_1 = 3;
                        set_2 = 4;
                        set_3 = 2;
                        set_4 = 3;
                        set_max = 4;
                    }

                    else if (level == 2)
                    {
                        set_1 = 6;
                        set_2 = 8;
                        set_3 = 6;
                        set_4 = 6;
                        set_max = 7;
                    }

                    else if (level == 3)
                    {
                        set_1 = 10;
                        set_2 = 12;
                        set_3 = 8;
                        set_4 = 8;
                        set_max = 12;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 120;
                    if (level == 1)
                    {
                        set_1 = 4;
                        set_2 = 5;
                        set_3 = 4;
                        set_4 = 4;
                        set_max = 5;
                    }

                    else if (level == 2)
                    {
                        set_1 = 8;
                        set_2 = 10;
                        set_3 = 7;
                        set_4 = 7;
                        set_max = 10;
                    }

                    else if (level == 3)
                    {
                        set_1 = 11;
                        set_2 = 15;
                        set_3 = 9;
                        set_4 = 9;
                        set_max = 13;
                    }
                }
                #endregion
            }
            #endregion

            #region week 2
            else if (week == "2")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 4;
                        set_2 = 6;
                        set_3 = 4;
                        set_4 = 4;
                        set_max = 6;
                    }

                    else if (level == 2)
                    {
                        set_1 = 9;
                        set_2 = 11;
                        set_3 = 8;
                        set_4 = 8;
                        set_max = 11;
                    }

                    else if (level == 3)
                    {
                        set_1 = 14;
                        set_2 = 14;
                        set_3 = 10;
                        set_4 = 10;
                        set_max = 15;
                    }
                }
                #endregion

                #region day 2
                else if (day == "2")
                {
                    rest = 90;
                    if (level == 1)
                    {
                        set_1 = 5;
                        set_2 = 6;
                        set_3 = 4;
                        set_4 = 4;
                        set_max = 7;
                    }

                    else if (level == 2)
                    {
                        set_1 = 10;
                        set_2 = 12;
                        set_3 = 9;
                        set_4 = 9;
                        set_max = 13;
                    }

                    else if (level == 3)
                    {
                        set_1 = 14;
                        set_2 = 16;
                        set_3 = 12;
                        set_4 = 12;
                        set_max = 17;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 120;
                    if (level == 1)
                    {
                        set_1 = 5;
                        set_2 = 7;
                        set_3 = 5;
                        set_4 = 5;
                        set_max = 8;
                    }

                    else if (level == 2)
                    {
                        set_1 = 12;
                        set_2 = 13;
                        set_3 = 10;
                        set_4 = 10;
                        set_max = 15;
                    }

                    else if (level == 3)
                    {
                        set_1 = 16;
                        set_2 = 17;
                        set_3 = 14;
                        set_4 = 14;
                        set_max = 20;
                    }
                }
                #endregion
            }
            #endregion

            #region week 3 
            else if (week == "3")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 10;
                        set_2 = 12;
                        set_3 = 7;
                        set_4 = 7;
                        set_max = 9;
                    }

                    else if (level == 2)
                    {
                        set_1 = 12;
                        set_2 = 17;
                        set_3 = 13;
                        set_4 = 13;
                        set_max = 17;
                    }

                    else if (level == 3)
                    {
                        set_1 = 14;
                        set_2 = 18;
                        set_3 = 14;
                        set_4 = 14;
                        set_max = 20;
                    }
                }
                #endregion

                #region day 2
                else if (day == "2")
                {
                    rest = 90;
                    if (level == 1)
                    {
                        set_1 = 10;
                        set_2 = 12;
                        set_3 = 8;
                        set_4 = 8;
                        set_max = 12;
                    }

                    else if (level == 2)
                    {
                        set_1 = 14;
                        set_2 = 19;
                        set_3 = 14;
                        set_4 = 14;
                        set_max = 19;
                    }

                    else if (level == 3)
                    {
                        set_1 = 20;
                        set_2 = 25;
                        set_3 = 15;
                        set_4 = 15;
                        set_max = 25;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 120;
                    if (level == 1)
                    {
                        set_1 = 11;
                        set_2 = 13;
                        set_3 = 9;
                        set_4 = 9;
                        set_max = 13;
                    }

                    else if (level == 2)
                    {
                        set_1 = 16;
                        set_2 = 21;
                        set_3 = 15;
                        set_4 = 15;
                        set_max = 21;
                    }

                    else if (level == 3)
                    {
                        set_1 = 22;
                        set_2 = 30;
                        set_3 = 20;
                        set_4 = 20;
                        set_max = 28;
                    }
                }
                #endregion
            }
            #endregion

            #region week 4
            else if (week == "4")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 12;
                        set_2 = 14;
                        set_3 = 11;
                        set_4 = 10;
                        set_max = 16;
                    }

                    else if (level == 2)
                    {
                        set_1 = 18;
                        set_2 = 22;
                        set_3 = 16;
                        set_4 = 16;
                        set_max = 25;
                    }

                    else if (level == 3)
                    {
                        set_1 = 21;
                        set_2 = 25;
                        set_3 = 21;
                        set_4 = 21;
                        set_max = 32;
                    }
                }
                #endregion

                #region day 2
                else if (day == "2")
                {
                    rest = 90;
                    if (level == 1)
                    {
                        set_1 = 14;
                        set_2 = 16;
                        set_3 = 12;
                        set_4 = 12;
                        set_max = 18;
                    }

                    else if (level == 2)
                    {
                        set_1 = 20;
                        set_2 = 25;
                        set_3 = 20;
                        set_4 = 20;
                        set_max = 28;
                    }

                    else if (level == 3)
                    {
                        set_1 = 25;
                        set_2 = 29;
                        set_3 = 25;
                        set_4 = 25;
                        set_max = 36;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 120;
                    if (level == 1)
                    {
                        set_1 = 16;
                        set_2 = 18;
                        set_3 = 13;
                        set_4 = 13;
                        set_max = 20;
                    }

                    else if (level == 2)
                    {
                        set_1 = 23;
                        set_2 = 28;
                        set_3 = 23;
                        set_4 = 23;
                        set_max = 33;
                    }

                    else if (level == 3)
                    {
                        set_1 = 29;
                        set_2 = 33;
                        set_3 = 29;
                        set_4 = 29;
                        set_max = 40;
                    }
                }
                #endregion
            }
            #endregion

            #region week 5
            else if (week == "5")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 17;
                        set_2 = 19;
                        set_3 = 15;
                        set_4 = 15;
                        set_max = 20;
                    }

                    else if (level == 2)
                    {
                        set_1 = 28;
                        set_2 = 35;
                        set_3 = 25;
                        set_4 = 22;
                        set_max = 35;
                    }

                    else if (level == 3)
                    {
                        set_1 = 36;
                        set_2 = 40;
                        set_3 = 30;
                        set_4 = 24;
                        set_max = 40;
                    }
                }
                #endregion

                #region day 2
                else if (day == "2")
                {
                    rest = 45;
                    if (level == 1)
                    {
                        set_1 = 10;
                        set_2 = 10;
                        set_3 = 13;
                        set_4 = 13;
                        set_5 = 10;
                        set_6 = 10;
                        set_7 = 9;
                        set_max = 25;
                    }

                    else if (level == 2)
                    {
                        set_1 = 18;
                        set_2 = 18;
                        set_3 = 20;
                        set_4 = 20;
                        set_5 = 14;
                        set_6 = 14;
                        set_7 = 16;
                        set_max = 40;
                    }

                    else if (level == 3)
                    {
                        set_1 = 19;
                        set_2 = 19;
                        set_3 = 22;
                        set_4 = 22;
                        set_5 = 18;
                        set_6 = 18;
                        set_7 = 22;
                        set_max = 45;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 45;
                    if (level == 1)
                    {
                        set_1 = 13;
                        set_2 = 13;
                        set_3 = 15;
                        set_4 = 15;
                        set_5 = 12;
                        set_6 = 12;
                        set_7 = 10;
                        set_max = 30;
                    }

                    else if (level == 2)
                    {
                        set_1 = 18;
                        set_2 = 18;
                        set_3 = 20;
                        set_4 = 20;
                        set_5 = 17;
                        set_6 = 17;
                        set_7 = 20;
                        set_max = 45;
                    }

                    else if (level == 3)
                    {
                        set_1 = 20;
                        set_2 = 20;
                        set_3 = 24;
                        set_4 = 24;
                        set_5 = 20;
                        set_6 = 20;
                        set_7 = 22;
                        set_max = 50;
                    }
                }
                #endregion
            }
            #endregion

            #region week 6
            else if (week == "6")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    if (level == 1)
                    {
                        set_1 = 25;
                        set_2 = 30;
                        set_3 = 20;
                        set_4 = 15;
                        set_max = 40;
                    }

                    else if (level == 2)
                    {
                        set_1 = 40;
                        set_2 = 50;
                        set_3 = 25;
                        set_5 = 25;
                        set_max = 50;
                    }

                    else if (level == 3)
                    {
                        set_1 = 45;
                        set_2 = 55;
                        set_3 = 35;
                        set_4 = 30;
                        set_max = 55;
                    }
                }
                #endregion

                #region day 2
                else if (day == "2")
                {
                    rest = 45;
                    if (level == 1)
                    {
                        set_1 = 14;
                        set_2 = 14;
                        set_3 = 15;
                        set_4 = 15;
                        set_5 = 14;
                        set_6 = 14;
                        set_7 = 10;
                        set_8 = 10;
                        set_max = 44;
                    }

                    else if (level == 2)
                    {
                        set_1 = 20;
                        set_2 = 20;
                        set_3 = 23;
                        set_4 = 23;
                        set_5 = 20;
                        set_6 = 20;
                        set_7 = 18;
                        set_8 = 18;
                        set_max = 53;
                    }

                    else if (level == 3)
                    {
                        set_1 = 22;
                        set_2 = 22;
                        set_3 = 30;
                        set_4 = 30;
                        set_5 = 24;
                        set_6 = 24;
                        set_7 = 18;
                        set_8 = 18;
                        set_max = 58;
                    }
                }
                #endregion

                #region day 3
                else if (day == "3")
                {
                    rest = 45;
                    if (level == 1)
                    {
                        set_1 = 13;
                        set_2 = 13;
                        set_3 = 17;
                        set_4 = 17;
                        set_5 = 16;
                        set_6 = 16;
                        set_7 = 14;
                        set_8 = 14;
                        set_max = 50;
                    }

                    else if (level == 2)
                    {
                        set_1 = 22;
                        set_2 = 22;
                        set_3 = 30;
                        set_4 = 30;
                        set_5 = 25;
                        set_6 = 25;
                        set_7 = 18;
                        set_8 = 18;
                        set_max = 55;
                    }

                    else if (level == 3)
                    {
                        set_1 = 26;
                        set_2 = 26;
                        set_3 = 33;
                        set_4 = 33;
                        set_5 = 26;
                        set_6 = 26;
                        set_7 = 22;
                        set_8 = 22;
                        set_max = 60;
                    }
                }
                #endregion
            }
            #endregion

            y.Close();
            x.Close();
        }

        private void createWorkoutPlanFiles(string name)
        {
            StreamWriter sw = new StreamWriter(@"C:\The Road To 100\user.ID 1\" + name + ".txt");

            switch (name)
            {
                case "Week":
                    if (int.Parse(TBintailtest_results.Text) > 20)
                        sw.Write("3");
                    else
                        sw.Write("1");
                    sw.Close();
                    break;

                case "Day":
                    sw.Write("1");
                    sw.Close();
                    break;
            }

        }

        private void QustionMark_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void QustionMark_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
        }

        private void getWorkoutOfTheDay()
        {
            StreamReader readTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Initial Test.txt");
            StreamReader readWeek = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt");


            getLevel(int.Parse(readTest.ReadToEnd()), null, null, null);
            findeWorkoutParameters(Level);
            if (readWeek.ReadToEnd() == "3")
            {
                Cweek.Text = "3";
                QustionMark.Visible = true;
                setPR();
            }
            readWeek.Close();
            readTest.Close();
        }

        #endregion

        #region Workout

        private void BstartTraining(object sender, EventArgs e)
        {
            setPworkout();
            Pworkout.Dock = DockStyle.Fill;
            Pworkout.BringToFront();

        }

        private void setPworkout()
        {
            //set total push ups of the day
            int totalPushUpsToday = set_1 + set_2 + set_3 + set_4 + set_5 + set_6 + set_7 + set_8 + set_max;
            Ctodayspushups.Text = totalPushUpsToday.ToString();
            CrestTime.Text = String.Format("{0} seconds", rest).ToString();
            
            //set week
            StreamReader readWeek = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt");
            C_week.Text = readWeek.ReadToEnd();

            //set day
            StreamReader readDay = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt");
            C_Day.Text = readDay.ReadToEnd();

            #region set Sets

            if (set_8 == 0)
            {
                Cset1.Text = set_1.ToString();
                Cset2.Text = set_2.ToString();
                Cset3.Text = set_3.ToString();
                Cset4.Text = set_4.ToString();
                Cset5.Text = String.Format("max (at least  {0})", set_max.ToString());
            }

            else
            {
                Cset6.Visible = true;
                Cset7.Visible = true;
                Cset8.Visible = true;
                Cset9.Visible = true;
                Lset_6.Visible = true;
                Lset_7.Visible = true;
                Lset_8.Visible = true;
                Lset_9.Visible = true;

                Cset1.Text = set_1.ToString();
                Cset2.Text = set_2.ToString();
                Cset3.Text = set_3.ToString();
                Cset4.Text = set_4.ToString();
                Cset5.Text = set_5.ToString();
                Cset6.Text = set_6.ToString();
                Cset7.Text = set_7.ToString();
                Cset8.Text = set_8.ToString();
                Cset9.Text = String.Format("max (at least  {0})", set_max.ToString());
            }
            #endregion

            readWeek.Close();
            readDay.Close();
        }

        private void Bback(object sender, EventArgs e)
        {
            Ppersonal_Screen.BringToFront();
            Ppersonal_Screen.Dock = DockStyle.Fill;
        }

        #endregion

    }
}