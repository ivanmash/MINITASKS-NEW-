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
    public partial class Form3 : Form
    {
        public event JUST_RESIZE_IT eventus;
        public Form3()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(trackBar1.Value);
            if (eventus != null)
            {
                eventus(this, new RadiusEventArgs(i));
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
        }
    }
    public delegate void JUST_RESIZE_IT(object sender, RadiusEventArgs e);
    public class RadiusEventArgs : EventArgs
    {
        public int Radius_Change { set; get; }
        
        public RadiusEventArgs(int R)
        {
            Radius_Change = R;
        }
    }
}
