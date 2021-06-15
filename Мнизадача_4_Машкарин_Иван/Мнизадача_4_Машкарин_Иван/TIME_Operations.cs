using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Мнизадача_4_Машкарин_Иван
{
    public abstract class TIME_Operations
    {
        public abstract void Undo(List<Вершины> spis1);
        public abstract void Redo(List<Вершины> spis1);
    }
    class Color_fixation : TIME_Operations
    {
        Color temporary;
        Color new_one;
        public Color_fixation(Color a) : base()
        {
            this.temporary = a;
        }
        public override void Undo(List<Вершины> spis1)
        {
            new_one = Вершины.Changecolor;
            Вершины.Changecolor = temporary;
        }
        public override void Redo(List<Вершины> spis)
        {
            temporary = Вершины.Changecolor;
            Вершины.Changecolor = new_one;
        }
    }
    class Radius_fixation : TIME_Operations
    {
        int delta;
        public Radius_fixation(int a) : base()
        {
            delta = a;
        }
        public override void Undo(List<Вершины> spis1)
        {
            Вершины.Radius -= delta;
        }
        public override void Redo(List<Вершины> spis2)
        {
            Вершины.Radius += delta;
        }
    }
 }
