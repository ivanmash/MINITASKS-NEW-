using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сериализация
{
    public partial class Form2 : Form
    {
        public event JUST_RESIZE_IT eventus;
        int i;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
       
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            i = Convert.ToInt32(trackBar1.Value);
            if (eventus != null)
            {
                eventus(this, new RadiusEventArgs(i));
            }
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
