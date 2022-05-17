using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Paint_App_OOP
{
    abstract class Figures
    {
        public Point Start,Scale,End;
       
        public int count = 1;
        public int thickness = 1;
        public int index;
       
        //public Point Y
        //{
        //    get
        //    {
        //        return y;
        //    }
        //    set
        //    {
        //        y = value;
        //    }
        //}
        public abstract void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos);
        public virtual bool isOn(Point startPoint, Point endPoint, Point p)
        {
            return false;
        }
    }
    class Pencil : Figures
    {
        int index = 1;
        public SortedList pencilList;
        public Pencil()
        {
            pencilList = new SortedList();

        }
        public Point this[int index]
        {
            get
            {
                return (Point)pencilList.GetByIndex(index);
            }
            set
            {
                if (index <= pencilList.Count)
                    pencilList[index] = value;
            }
        }
        public override void Draw(Color c, Graphics g, MouseEventArgs e,Point startPos)
        {
            SolidBrush b = new SolidBrush(c);
            Point p = new Point(e.X, e.Y);
            Start = p;
            int count = pencilList.Count;
            pencilList.Add(count, p);
            g.FillRectangle(b, e.X, e.Y, thickness, thickness);
        }
        public void Draw(Color c,Graphics g)
        {
            SolidBrush b = new SolidBrush(c);
            for(int i = 0;i < pencilList.Count; ++i)
            {
                g.FillRectangle(b, Start.X, Start.Y, thickness, thickness);
            }
            
        }

    }
    class Eraser : Figures
    {
        int index = 2;
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            SolidBrush b = new SolidBrush(c);
            g.FillRectangle(b, e.X, e.Y, thickness*10, thickness*10);

        }
        public void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos,FigureList fl,ShapeList sl)
        {
            //**
            SolidBrush b = new SolidBrush(c);
            int ct = fl.firgueList.Count; ;
            for(int i = 0; i < ct; ++i)
            {

               {
                    for(int j = 0; j < thickness*5; j++)
                    {
                        Point area = e.Location;
                        if (fl[i].pencilList.ContainsValue(area))
                        {
                            fl[i].pencilList.RemoveAt(fl[i].pencilList.IndexOfValue(area));
                            g.FillRectangle(b, area.X, area.Y, thickness, thickness);
                        }

                    }   
               }    
            }


            Pen pen = new Pen(Color.Red, 1);
            int radiusX,radiusY;

            for (int i =0;i < sl.shapeList.Count; ++i)
            {
                if (sl[i, 0].isOn(sl[i, 0].End, sl[i, 0].Start, e.Location))
                {
                    int scaleX = sl[i, 0].End.X - sl[i,0].Start.X ;
                    int scaleY = sl[i, 0].End.Y - sl[i, 0].Start.Y;
                    for (int k = 0;k < scaleX; ++k)
                    {
                        g.FillRectangle(b, sl[i, 0].Start.X + k, sl[i, 0].Start.Y, 1, 1);
                        g.FillRectangle(b, sl[i, 0].Start.X + k, sl[i, 0].End.Y, 1, 1);
                    }
                    for (int k = 0; k < scaleY; ++k)
                    {
                        g.FillRectangle(b, sl[i, 0].Start.X , sl[i, 0].Start.Y +k, 1, 1);
                        g.FillRectangle(b, sl[i, 0].End.X, sl[i, 0].Start.Y + k, 1, 1);
                    }
                    sl.shapeList.RemoveAt(i);
                    return;
                }
                try {
                    if (sl[i].isOn(sl[i].End, sl[i].Start, e.Location))
                        radiusX = (sl[i].End.X - sl[i].Start.X) / 2;
                    radiusY = (sl[i].End.Y - sl[i].Start.Y) / 2;

                    {
                        for (int j = 0; j < sl[i].Scale.Y; j++)
                        {
                            g.FillRectangle(b, sl[i].Start.X + j, sl[i].Start.Y + j, thickness * 3, thickness * 3);
                        }
                        for (int j = 0; j < sl[i].Scale.X; j++)
                        {
                            g.FillRectangle(b, sl[i].Start.X - j, sl[i].Start.Y - j, thickness * 3, thickness * 3);
                        }
                        sl.shapeList.RemoveAt(i);
                    }
                } catch
                {

                }
                
            }


            for(int i = 0; i < ct; ++i)
            {
                try
                {
                    if (fl[i].pencilList.Count == 0)
                    {
                        fl.firgueList.RemoveAt(i);
                    }
                }
                catch { }
            }
        }
    }
    class Circle : Figures
    {
        int index = 3;
        Point Start, Scale,End;
        public Circle()
        {

        }
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            Start = startPos;
            Scale.X = e.X - Start.X;
            Scale.Y = e.Y - Start.Y;
            End = e.Location;
            Pen pen = new Pen(c, 1);
            g.DrawEllipse(pen, Start.X, Start.Y, Scale.X, Scale.Y);
        }
        public void Draw(Color c,Graphics g,Point s,Point e)
        {
            Pen pen = new Pen(c, thickness);
            g.DrawEllipse(pen, s.X, s.Y, e.X, e.Y);

        }
        public override bool isOn(Point endPoint, Point startPos,Point p)
        {
            return ((p.X - startPos.X) ^ 2 / (endPoint.X - startPos.X) ^ 2 + (p.Y - startPos.Y) ^ 2 / (endPoint.Y - startPos.Y) ^ 2) <= 1;
        }
    }

    class Retrangle : Figures
    {
        int index = 4;
        Point Start, Scale, End;
        public Retrangle()
        {

        }
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            Start = startPos;
            End = e.Location;
            Scale.X = End.X - Start.X;
            Scale.Y = End.Y - Start.Y;
            if(Scale.X < 0)
            {
                Scale.X = Scale.X * (-1);
            }
            if (Scale.Y < 0)
            {
                Scale.Y = Scale.Y * (-1);
            }

            Pen pen = new Pen(c, 1);
            g.DrawRectangle(pen, Start.X, Start.Y, Scale.X, Scale.Y);
        }
        public override bool isOn(Point endPoint, Point startPos, Point p)
        {
            if (p.X <= endPoint.X && p.X >= startPos.X && p.Y <= endPoint.Y && p.Y >= startPos.Y)
            {
                return true;
            } else
            {
                return false;
            }

            
        }
    }
    class Line : Figures
    {
        int index = 5;

        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {

        }

        
    }
    class FigureList
    {
        public SortedList firgueList;
        public FigureList()
        {
            firgueList = new SortedList();
        }
        public Pencil this[int index]
        {
            get
            {
                if (index >= firgueList.Count)
                    return (Pencil)null;
                return (Pencil)firgueList.GetByIndex(index);
            }
            set
            {
                if (index <= firgueList.Count)
                    firgueList[index] = value;
            }
        }
        public Figures this[int index,int e]
        {
            get
            {
                if (index >= firgueList.Count)
                    return (Figures)null;
                return (Figures)firgueList.GetByIndex(index);
            }
            set
            {
                if (index <= firgueList.Count)
                    firgueList[index] = value;
            }
        }
    }

    class ShapeList
    {
        public SortedList shapeList;
        public ShapeList()
        {
            shapeList = new SortedList();
        }
        public Circle this[int index]
        {
            get
            {
                if (index >= shapeList.Count)
                    return (Circle)null;
                return (Circle)shapeList.GetByIndex(index);
            }
            set
            {
                if (index <= shapeList.Count)
                    shapeList[index] = value;
            }
        }
        public Retrangle this[int index,int key = 0]
        {
            get
            {
                if (index >= shapeList.Count)
                    return (Retrangle)null;
                return (Retrangle)shapeList.GetByIndex(index);
            }
            set
            {
                if (index <= shapeList.Count)
                    shapeList[index] = value;
            }
        }
        public void Remove(int element)
        {
            if (element >= 0 && element < shapeList.Count)
            {
                for (int i = element; i < shapeList.Count - 1; i++)
                    shapeList[i] = shapeList[i + 1];
                shapeList.RemoveAt(shapeList.Count - 1);
            }
        }
    }
}
