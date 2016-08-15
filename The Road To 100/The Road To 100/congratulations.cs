using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace The_Road_To_100
{
    public partial class congratulations : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public congratulations()
        {
            InitializeComponent();
            ss.SpeakAsync("good job");
            ss.SpeakAsync("see you in 2 days");
        }
    }
}
