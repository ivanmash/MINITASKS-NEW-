using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.Serialization.Formatters.Binary;

namespace Сериализация
{
    [Serializable]
    class Rectangle
    {
        //[NonSerialized]
        int x;
        int y;
        int R;
        public Rectangle()
        {
            this.x = 300;
            this.y = 100;
            this.R = 30;
        }
        public int Xchange
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        public int Ychange
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }
        public int Rchange
        {
            set
            {
                R = value;
            }
            get
            {
                return R;
            }
        }
        public void DrawFigure(Graphics graf)
        {
            graf.FillRectangle(new SolidBrush(Color.Red), x - R / 2, y - R / 2, R, R + 20);
        }
    }
}
