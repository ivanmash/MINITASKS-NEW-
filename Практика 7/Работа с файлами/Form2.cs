using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа_с_файлами
{
    public partial class Form2 : Form
    {
        public event PAUSE_CHANGE time;
        public Form2()
        {
            InitializeComponent();
            Form1 form12 = new Form1();
            trackBar1.Value = form12.Return_the_time;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(trackBar1.Value);
            if (time != null)
            {
                time(this, new TimeEventArgs(i));
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
    public delegate void PAUSE_CHANGE(object sender, TimeEventArgs e);
    public class TimeEventArgs : EventArgs
    {
        public int Pause_Change { set; get; }
        public TimeEventArgs(int T)
        {
            Pause_Change = T;
        }
    }
}

        