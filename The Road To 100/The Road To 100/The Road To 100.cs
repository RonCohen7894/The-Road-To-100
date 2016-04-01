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
using System.Globalization;
using System.Media;

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
            {
                DirectoryInfo di = Directory.CreateDirectory(@"C:\The Road To 100");
                di.Create();
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            }
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
        private int num_sets;
        string week;
        string day;
        int Weekcontent;
        bool repetWeek;

        //workout
        private bool moved = false;
        private bool workout_done = false;
        private bool Workout_Timer_start = false;
        private int set_ToDo = 1;
        private bool rest_done = false;
        string content_W;

        int sec = 0;
        int min = 0;
        int houres = 0;
        #endregion

        #region main Menu

        private void MainMenuButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            knowledge_center popup = new knowledge_center();

            if (button.Name == "Bintroduction")
                popup.textBox1.Text = @"If you're serious about increasing your strength,
follow this six week training program and you'll soon be on your way to completing 100 consecutive push ups!


No doubt some of you can already do 50 consecutive push ups,
but let's face it, you're in a big minority. 
Most of you reading this won't even be able to manage 20 pushups. Actually, 
I'm sure many of you can't even do 10.



However, it really doesn't matter which group you fall into. 
If you follow the progressive push ups training program, 
I'm positive you'll soon be able to do 100 push ups!";

            else if (button.Name == "Bwhypushups")
                popup.textBox1.Text = @"Push ups are one of the basic and most common exercises for the human body.
Push ups are not only great for your chest,
but do a tremendous job of defining your abs, triceps, shoulders and torso.

Push ups can be performed no matter where you are, and best of all, 
they are completely free - no expensive equipment or annual gym fees required! 
If you're looking to develop a great chest and shoulders, 
you could do much worse than follow along with the hundred push ups plan. 
Your core strength will also go through the roof too!

To improve your strength, fitness and general health all you need to do is
commit about 30 minutes of your time per week, and follow the push ups training program 
as closely as you can. I promise you will feel much better about yourself and much more 
confident after just a few short workouts.";

            else if (button.Name == "Bwhatisapushup")
                popup.textBox1.Text = @"According to Wikipedia, a push-up (USA English), or a press-up (UK English), 
is ""a common strength training exercise performed in a prone position:

lying horizontal and face down, raising and lowering the body using the arms.""

Push ups are a basic exercise used in civilian athletic training or physical education and,
especially, in military physical training and will develop the pectoral muscles and triceps,
with ancillary benefits to the deltoids, serratus anterior,
coracobrachialis and the midsection as a whole.";





            DialogResult dialogresult = popup.ShowDialog();
        }

        private void properForm_ButtonClick(object sender, EventArgs e)
        {
            Good_Form popup = new Good_Form();
            DialogResult dialogresult = popup.ShowDialog();
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

            using (StreamReader fr_week = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
            {
                char[] readWeek = fr_week.ReadToEnd().ToCharArray();
                string week_ex = readWeek[0].ToString();

                using (StreamReader fr_Day = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt"))
                {
                    char[] readDay = fr_Day.ReadToEnd().ToCharArray();
                    string Day = readDay[0].ToString();

                    if (!File.Exists(@"C:\The Road To 100\user.ID 1\FirstTime.txt"))
                    {
                        if (week_ex == "3" || week_ex == "5" || week_ex == "6")
                            if (Day == "1")
                            {
                                Exhaustion_test popup = new Exhaustion_test();
                                DialogResult dialogresult = popup.ShowDialog();
                            }
                    }
                    else if (File.Exists(@"C:\The Road To 100\user.ID 1\FirstTime.txt") && Day != "1")
                        File.Delete(@"C:\The Road To 100\user.ID 1\FirstTime.txt");

                    using (StreamReader readTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Initial Test.txt"))
                        if (week_ex == "1" || week_ex == "2" && !File.Exists(@"C:\The Road To 100\user.ID 1\repetOneWeek.txt"))
                            getLevel(int.Parse(readTest.ReadToEnd()), null, null, null);


                    if (File.Exists(@"C:\The Road To 100\user.ID 1\Exhaustion test.txt"))
                        using (StreamReader fr_exTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Exhaustion test.txt"))
                        {
                            if (File.Exists(@"C:\The Road To 100\user.ID 1\repetOneWeek.txt"))
                            {
                                getLevel(int.Parse(fr_exTest.ReadToEnd()), null, null, null);

                                if (Day == "3")
                                    File.Delete(@"C:\The Road To 100\user.ID 1\repetOneWeek.txt");
                            }

                            switch (week_ex)
                            {
                                case "3":
                                    getLevel(null, int.Parse(fr_exTest.ReadToEnd()), null, null);
                                    break;

                                case "4":
                                    getLevel(null, int.Parse(fr_exTest.ReadToEnd()), null, null);
                                    break;

                                case "5":
                                    getLevel(null, null, int.Parse(fr_exTest.ReadToEnd()), null);
                                    break;

                                case "6":
                                    getLevel(null, null, null, int.Parse(fr_exTest.ReadToEnd()));
                                    break;
                            }
                        }


                    DateTime thisDate = DateTime.Today;
                    if (File.Exists(@"C:\The Road To 100\user.ID 1\First_Day.txt") || File.Exists(@"C:\The Road To 100\user.ID 1\FirstTime.txt"))
                    {
                        try
                        {
                            using (StreamReader fr_FirstDay = new StreamReader(@"C:\The Road To 100\user.ID 1\First_Day.txt"))
                                if (thisDate.Day.ToString() != fr_FirstDay.ReadToEnd())
                                    button1.Enabled = true;
                        }
                        catch (Exception)
                        {
                            button1.Enabled = true;
                        }
                    }

                    using (StreamReader fr_week2 = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                        if (fr_week2.ReadToEnd() == "7")
                        {
                            button1.Enabled = false;
                            pictureBox1.Visible = true;
                            pictureBox1.BringToFront();
                        }
                }
            }

            if (repetWeek == true)
                Repet_oneWeek();

            findeWorkoutParameters(Level);
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
                    Directory.Delete(@"C:\The Road To 100\user.ID 1", true);
                    Directory.CreateDirectory(@"C:\The Road To 100\user.ID 1");

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
            PictureBox[] pb = { pr1, pr2, pr3, pr4, pr5, pr6 };

            string colorcode = "#E3D93C";
            int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
            Color clr = Color.FromArgb(argb);

            using (StreamReader sr = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Week.txt"))
            {
                switch (sr.ReadToEnd())
                {
                    case "1":
                        pb[0].BackColor = Color.AliceBlue;
                        break;
                    case "2":
                        pb[0].BackColor = Color.AliceBlue;
                        pb[1].BackColor = Color.AliceBlue;
                        break;
                    case "3":
                        for (int i = 0; i <= 2; i++)
                            pb[i].BackColor = Color.AliceBlue;
                        break;
                    case "4":
                        for (int i = 0; i <= 3; i++)
                            pb[i].BackColor = Color.AliceBlue;
                        break;
                    case "5":
                        for (int i = 0; i <= 4; i++)
                            pb[i].BackColor = Color.AliceBlue;
                        break;
                    case "6":
                        foreach (PictureBox PB in pb)
                            PB.BackColor = Color.AliceBlue;
                        break;
                    case "7":
                        foreach (PictureBox PB in pb)
                            PB.BackColor = Color.Gold;
                        break;


                }
            }


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
                creatFiles("Exhaustion test", "", intailTest_results);
                creatFiles("FirstTime", "True", 0);
                createWorkoutPlanFiles("Week");
                createWorkoutPlanFiles("Day");



                using (StreamReader readWeek = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                    if (readWeek.ReadToEnd() == "3")
                    {
                        Cweek.Text = "3";
                        QustionMark.Visible = true;
                    }

                button1.Enabled = true;
                using (StreamReader readTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Initial Test.txt"))
                    getLevel(int.Parse(readTest.ReadToEnd()), null, null, null);
                findeWorkoutParameters(Level);
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

            using (StreamWriter fw = new StreamWriter(@"C:\The Road To 100\" + "user.ID 1" + @"\" + fileName + ".txt"))
            {
                if (TXTcontant != "")
                {
                    fw.Write(TXTcontant);
                    fw.Close();
                    fw.Dispose();
                }
                else if (Numcontant != 0)
                {
                    fw.Write(Numcontant);
                    fw.Close();
                    fw.Dispose();
                }
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

                New_age = int.Parse(TBage.Text);
                if (New_age <= 0)
                {
                    SnewAge.Visible = true;
                    SnewAge.Text = "You must your real age";
                }

            }
            catch (Exception e)
            {
                SnewAge.Visible = true;
                SnewAge.Text = "You must write a number";
            }

            try
            {
                intailTest_results = int.Parse(TBintailtest_results.Text);

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

            using (StreamReader readWeek = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Week.txt"))
            {
                Cweek.Text = readWeek.ReadToEnd();
                readWeek.Close();
                readWeek.Dispose();
            }
            using (StreamReader readDay = new StreamReader(@"C:\The Road To 100\" + @"user.ID 1\Day.txt"))
            {
                Cday.Text = readDay.ReadToEnd();
                readDay.Close();
                readDay.Dispose();
            }
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

        // Also change the sets here
        private void Bplan_Click(object sender, EventArgs e)
        {
            WorkoutPlan popup = new WorkoutPlan();
            using (StreamReader readTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Initial Test.txt"))
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
            using (StreamReader sr = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
            {
                char[] x = (sr.ReadToEnd()).ToCharArray();
                string week = x[0].ToString();

                if (test1 < 20 && week == "1" || week == "2")
                {
                    if (test1 <= 5) { Level = 1; }
                    else if (test1 >= 6 && test1 <= 10) { Level = 2; }
                    else if (test1 >= 11 && test1 <= 20) { Level = 3; }
                }

                else if (test1 >= 20 || week == "3" || week == "4")
                {
                    if (test2 >= 16 && test2 <= 20 || test1 >= 16 && test1 <= 20) { Level = 1; }
                    else if (test2 >= 21 && test2 <= 25 || test1 >= 21 && test1 <= 25) { Level = 2; }
                    else if (test2 > 25 || test1 > 25) { Level = 3; }
                    else
                        repetWeek = true;
                }

                else if (week == "5")
                {
                    if (test3 >= 31 && test3 <= 35) { Level = 1; }
                    else if (test3 >= 36 && test3 <= 40) { Level = 2; }
                    else if (test3 > 40) { Level = 3; }
                    else
                        repetWeek = true;
                }

                else if (week == "6")
                {
                    if (test4 >= 46 && test4 <= 50) { Level = 1; }
                    else if (test4 >= 51 && test4 <= 60) { Level = 2; }
                    else if (test4 > 60) { Level = 3; }
                    else
                        repetWeek = true;
                }
                sr.Close();
                sr.Dispose();
            }

        }

        private void Repet_oneWeek()
        {
            Sorry popup = new Sorry();
            DialogResult dialogresult = popup.ShowDialog();

            string c = get_content(@"C:\The Road To 100\user.ID 1\Week.txt");
            using (StreamWriter fw_week = new StreamWriter(@"C:\The Road To 100\user.ID 1\Week.txt"))
                fw_week.Write(int.Parse(c) - 1);

            using (StreamReader fr_week = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                if (File.Exists(@"C:\The Road To 100\user.ID 1\Exhaustion test.txt"))
                    using (StreamReader fr_exTest = new StreamReader(@"C:\The Road To 100\user.ID 1\Exhaustion test.txt"))
                        switch (fr_week.ReadToEnd())
                        {
                            case "2":
                                getLevel(int.Parse(fr_exTest.ReadToEnd()), null, null, null);
                                creatFiles("repetOneWeek", "true", 0);
                                break;

                            case "3":
                                getLevel(null, int.Parse(fr_exTest.ReadToEnd()), null, null);
                                break;

                            case "4":
                                getLevel(null, int.Parse(fr_exTest.ReadToEnd()), null, null);
                                break;

                            case "5":
                                getLevel(null, null, int.Parse(fr_exTest.ReadToEnd()), null);
                                break;

                            case "6":
                                getLevel(null, null, null, int.Parse(fr_exTest.ReadToEnd()));
                                break;
                            default:
                                int o;
                                break;
                        }
            using (StreamReader fr_week = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                Cweek.Text = fr_week.ReadToEnd();
        }

        private string get_content(string path)
        {
            using (StreamReader fr_Week = new StreamReader(path))
                return fr_Week.ReadToEnd();

        }

        private void findeWorkoutParameters(int level)
        {
            using (StreamReader y = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
            {
                char[] readWeek = y.ReadToEnd().ToCharArray();
                week = readWeek[0].ToString();
            }


            using (StreamReader x = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt"))
            {
                char[] readDay = x.ReadToEnd().ToCharArray();
                day = readDay[0].ToString();
            }


            #region week 1
            if (week == "1")
            {
                #region day 1
                if (day == "1")
                {
                    rest = 60;
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 5;
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
                    num_sets = 8;
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
                    num_sets = 8;
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
                    num_sets = 5;
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
                        set_4 = 25;
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
                    num_sets = 9;
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
                    num_sets = 9;
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


        }

        private void createWorkoutPlanFiles(string name)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\The Road To 100\user.ID 1\" + name + ".txt"))
            {
                switch (name)
                {
                    case "Week":
                        if (int.Parse(TBintailtest_results.Text) > 20)
                            sw.Write("3");
                        else
                            sw.Write("1");
                        sw.Close();
                        sw.Dispose();
                        break;

                    case "Day":
                        sw.Write("1");
                        sw.Close();
                        sw.Dispose();
                        break;
                }
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

        private void BstartTraining(object sender, EventArgs e)
        {
            setPworkout();
            Pworkout.Dock = DockStyle.Fill;
            Pworkout.BringToFront();

        }

        #endregion

        #region Workout

        private void BstartWorkout_Click(object sender, EventArgs e)
        {

            workout_done = false;

            if (moved == false)
            {
                #region set control
                Pginfo.Top = Pworkout.Top + 570;
                Pginfo.Left = Pworkout.Left + 1095;

                BstartWorkout.Width = 71;
                BstartWorkout.Height = 67;
                BstartWorkout.Text = "Quit";
                BstartWorkout.Top = Pworkout.Top + 645;
                BstartWorkout.Left = Pworkout.Left + 1000;

                Cdoset.Text = set_1.ToString();
                Tstatment.Visible = true;

                button4.Visible = false;
                button4.Enabled = false;
                #endregion
                moved = true;

                #region timer
                Label[] lb = { Hours, label28, Minutes, label29, Seconds };
                foreach (Label LB in lb)
                    LB.Visible = true;

                Workout_Timer.Enabled = true;
                Workout_Timer_start = true;
                #endregion

                Finish.Top -= 150;
                Finish.Visible = true;


            }
            else if (moved == true)
            {
                #region set control                                    

                if (workout_done == false && MessageBox.Show("You have not completed today's workout, Are you sure you want to quit?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    Reset_Pworkout();

                #endregion
            }
        }

        private void setPworkout()
        {
            //set total push ups of the day
            int totalPushUpsToday = set_1 + set_2 + set_3 + set_4 + set_5 + set_6 + set_7 + set_8 + set_max;
            Ctodayspushups.Text = totalPushUpsToday.ToString();

            //set rest time
            CrestTime.Text = String.Format("{0} seconds", rest).ToString();

            //set week
            using (StreamReader readWeek = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                C_week.Text = readWeek.ReadToEnd();

            //set day
            using (StreamReader readDay = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt"))
                C_Day.Text = readDay.ReadToEnd();

            #region set Sets

            if (num_sets == 5)
            {
                Label[] lb2 = { Cset1, Cset2, Cset3, Cset4 };
                int[] lb3 = { set_1, set_2, set_3, set_4 };
                for (int i = 0; i <= 3; i++)
                    lb2[i].Text = lb3[i].ToString();
                Cset5.Text = String.Format("max (at least  {0})", set_max.ToString());
            }
            else if (num_sets == 8)
            {
                Label[] lb1 = { Cset6, Cset7, Cset8, Lset_6, Lset_7, Lset_8 };
                foreach (Label LB in lb1)
                    LB.Visible = true;
                Label[] lb2 = { Cset1, Cset2, Cset3, Cset4, Cset5, Cset6, Cset7 };
                int[] lb3 = { set_1, set_2, set_3, set_4, set_5, set_6, set_7 };
                for (int i = 0; i <= 6; i++)
                    lb2[i].Text = lb3[i].ToString();
                Cset8.Text = String.Format("max (at least  {0})", set_max.ToString());
            }
            else if (num_sets == 9)
            {
                Label[] lb = { Cset6, Cset7, Cset8, Cset9, Lset_6, Lset_7, Lset_8, Lset_9 };
                foreach (Label LB in lb)
                    LB.Visible = true;
                Label[] lb2 = { Cset1, Cset2, Cset3, Cset4, Cset5, Cset6, Cset7, Cset8 };
                int[] lb3 = { set_1, set_2, set_3, set_4, set_5, set_6, set_7, set_8 };
                for (int i = 0; i <= 7; i++)
                    lb2[i].Text = lb3[i].ToString();
                Cset9.Text = String.Format("max (at least  {0})", set_max.ToString());
            }
            #endregion


        }

        private void Finish_Click(object sender, EventArgs e)
        {
            #region rest
            rest_done = false;
            if (workout_done == false)
            {
                if (rest_done == false)
                {
                    Finish.Enabled = false;
                    Lrest.Visible = true;
                    Crest.Visible = true;

                    Crest.Text = (rest).ToString();
                    Rest_Timer.Start();
                }
            }

            #endregion

            #region Arrows
            if (workout_done == false)
                set_ToDo += 1;

            if (num_sets == 5)
            {
                Arrow1.Top += 39;
                if (set_ToDo == 5)
                    Arrow1.Left += 85;
                else if (set_ToDo > 5)
                {
                    Finished_workout();
                    button1.Enabled = false;
                }

                if (workout_done == false)
                    SET_setToDo();
            }

            else if (num_sets == 8)
            {
                if (set_ToDo <= 5)
                    Arrow1.Top += 39;

                else if (set_ToDo > 5)
                {
                    if (set_ToDo == 6)
                    {
                        Arrow1.Visible = false;
                        Arrow2.Visible = true;
                    }

                    if (set_ToDo > 6)
                    {
                        if (set_ToDo > 8)
                        {
                            Finished_workout();
                            button1.Enabled = false;
                        }


                        Arrow2.Top += 37;
                    }
                }
                if (workout_done == false)
                    SET_setToDo();
            }

            else if (num_sets == 9)
            {
                if (set_ToDo <= 5)
                    Arrow1.Top += 39;

                else if (set_ToDo > 5)
                {
                    if (set_ToDo == 6)
                    {
                        Arrow1.Visible = false;
                        Arrow2.Visible = true;
                    }

                    if (set_ToDo > 6)
                    {
                        if (set_ToDo > 9)
                        {
                            Finished_workout();
                            button1.Enabled = false;
                        }


                        Arrow2.Top += 37;
                    }
                }
                if (workout_done == false)
                    SET_setToDo();
            }
            #endregion              
        }

        private void Finished_workout()
        {
            //show Finish workout's messege
            Ppersonal_Screen.BringToFront();
            Ppersonal_Screen.Dock = DockStyle.Fill;

            congratulations popup = new congratulations();
            popup.Ltime.Text = string.Format("{0} Minuts and {1} Seconds", min, sec);
            popup.Lpushups.Text = string.Format("{0} Push Ups", Ctodayspushups.Text);
            DialogResult dr = popup.ShowDialog();

            //Change day and (if needed) change week
            Change_Day();

            using (StreamWriter fw_push = new StreamWriter(@"C:\The Road To 100\user.ID 1\Total Push ups Done.txt"))
                fw_push.Write(int.Parse(Ctotal_push_done.Text) + int.Parse(Ctodayspushups.Text));
            int c = int.Parse(Ctotal_push_done.Text);
            Ctotal_push_done.Text = (c + int.Parse(Ctodayspushups.Text)).ToString();

            //Reset the workout screen
            Reset_Pworkout();

            //get the date
            DateTime thisDate = DateTime.Today;
            File.Delete(@"C:\The Road To 100\user.ID 1\First_Day.txt");
            creatFiles("First_Day", "", thisDate.Day);
        }

        private void Reset_Pworkout()
        {

            Pginfo.Top = Pworkout.Top + 160;
            Pginfo.Left = (Pworkout.Width / 2) - (Pginfo.Width / 2) - 40;

            BstartWorkout.Width = 279;
            BstartWorkout.Height = 103;
            BstartWorkout.Text = "Start Workout";
            BstartWorkout.Top = Pworkout.Top + 55;
            BstartWorkout.Left = (Pworkout.Width / 2) - (BstartWorkout.Width / 2) - 26;

            Tstatment.Visible = false;

            Arrow1.Visible = true;
            Arrow2.Visible = false;


            if (num_sets == 5)
            {
                while (Arrow1.Top != 70)
                    Arrow1.Top -= 39;
                if (set_ToDo > 5)
                    Arrow1.Left -= 85;
            }

            else if (num_sets == 8 || set_ToDo == 9)
            {
                while (Arrow1.Top != 70)
                    Arrow1.Top -= 39;
                while (Arrow2.Top != 70)
                    Arrow2.Top -= 37;
            }


            Label[] lb = { Hours, label28, Minutes, label29, Seconds };
            foreach (Label LB in lb)
                LB.Visible = false;
            lb[0].Text = "0";
            lb[2].Text = "0";
            lb[4].Text = "0";
            lb[1].Text = ":";
            lb[3].Text = ":";

            sec = 0;
            min = 0;
            houres = 0;

            set_ToDo = 1;

            Workout_Timer.Enabled = false;
            Workout_Timer_start = false;

            Rest_Timer.Enabled = false;
            rest_done = false;
            Lrest.Visible = false;
            Crest.Visible = false;
            Crest.Text = "0";


            Finish.Top += 150;
            Finish.Visible = false;
            Finish.Enabled = true;

            button4.Visible = true;
            button4.Enabled = true;



            moved = false;
            workout_done = true;
        }

        private void SET_setToDo()
        {
            int[] sets = { set_1, set_2, set_3, set_4, set_5, set_6, set_7, set_8 };
            for (int i = 0; i <= num_sets; i++)
            {
                if (set_ToDo == num_sets)
                {
                    Cdoset.Text = set_max.ToString();
                    break;
                }
                else if (!(set_ToDo >= num_sets))
                    Cdoset.Text = sets[set_ToDo - 1].ToString();
            }
        }

        private void Bback(object sender, EventArgs e)
        {
            Ppersonal_Screen.BringToFront();
            Ppersonal_Screen.Dock = DockStyle.Fill;
        }

        private void Workout_Timer_Tick(object sender, EventArgs e)
        {
            if (Workout_Timer_start == true)
            {
                if (sec < 59)
                {
                    sec += 1;
                    Seconds.Text = sec.ToString();
                }
                else
                {
                    sec = 0;
                    Seconds.Text = sec.ToString();
                    min += 1;

                    if (min < 59)
                    {
                        Minutes.Text = min.ToString();
                    }
                    else
                    {
                        min = 0;
                        Minutes.Text = min.ToString();
                        houres += 1;

                        if (houres > 24)
                        {
                            sec = 0;
                            min = 0;
                            houres = 0;
                        }
                        else
                            Workout_Timer_start = false;
                    }
                }
            }
        }

        private void Rest_Timer_Tick(object sender, EventArgs e)
        {
            while (int.Parse(Crest.Text) > 0)
            {
                int time_Left = int.Parse(Crest.Text);
                time_Left--;
                Crest.Text = time_Left.ToString();
                if (Crest.Text == "0")
                {
                    SystemSounds.Hand.Play();
                    rest_done = true;
                }

                break;
            }

            if (rest_done == true)
            {
                Finish.Enabled = true;
                Lrest.Visible = false;
                Crest.Visible = false;
            }

        }

        private void Change_Day()
        {
            using (StreamReader fr = new StreamReader(@"C:\The Road To 100\user.ID 1\Day.txt"))
            {
                char[] readDay = fr.ReadToEnd().ToCharArray();
                string day;
                day = readDay[0].ToString();

                if (day == "1")
                {
                    fr.Close();
                    fr.Dispose();
                    using (StreamWriter fw = new StreamWriter(@"C:\The Road To 100\user.ID 1\Day.txt"))
                        fw.Write("2");

                }
                else if (day == "2")
                {
                    fr.Close();
                    fr.Dispose();
                    using (StreamWriter fw = new StreamWriter(@"C:\The Road To 100\user.ID 1\Day.txt"))
                        fw.Write("3");

                }
                else if (day == "3")
                {
                    fr.Close();
                    fr.Dispose();

                    using (StreamReader Week_R = new StreamReader(@"C:\The Road To 100\user.ID 1\Week.txt"))
                    {
                        content_W = Week_R.ReadToEnd();
                        Week_R.Close();
                        Week_R.Dispose();
                    }

                    if (int.Parse(content_W) < 7)
                    {
                        using (StreamWriter fw_W = new StreamWriter(@"C:\The Road To 100\user.ID 1\Week.txt"))
                        {
                            fw_W.Write(int.Parse(content_W) + 1);
                            fw_W.Close();
                            fw_W.Dispose();
                        }

                        using (StreamWriter fw_D = new StreamWriter(@"C:\The Road To 100\user.ID 1\Day.txt"))
                        {
                            fw_D.Write("1");
                            fw_D.Close();
                            fw_D.Dispose();
                        }
                    }
                }
            }
        }

        #endregion
    }
}