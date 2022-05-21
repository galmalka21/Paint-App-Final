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
    [Serializable]
    abstract class Figures
    {
        public Color color { get; set; }
        public int count = 1;
        public int thickness = 1;
        public int index;

        public abstract void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos);
    }

    [Serializable]
    class Shapes : Figures
    {
        public Point Start, Scale, End;

        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            
        }
        public virtual bool isOn(Point startPoint, Point endPoint, Point p)
        {
            return false;
        }
    }
    [Serializable]
    class Pencil : Figures
    {
        Point Start;
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
            SolidBrush b = new SolidBrush(color);
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
    [Serializable]
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
            Pen pen = new Pen(c, 1);
            int ct = fl.firgueList.Count; ;
            float radiusX = 0, radiusY = 0;
            double distance = 0;


            //Remove the pencil brush pixel by pixel if its in the list
            for (int i = 0; i < ct; ++i)
            {
               {
                    for(int j = 0; j < thickness; j++)
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

            //Check if one of the shapes is on the bitmap, if yes deletes the whole shape
            for (int i =0;i < sl.shapeList.Count; ++i)
            {
                //Retangles
                try
                {
                    if (sl[i, 0].isOn(sl[i, 0].End, sl[i, 0].Start, e.Location))
                    {
                        int scaleX = Math.Abs(sl[i, 0].End.X - sl[i, 0].Start.X);
                        int scaleY = Math.Abs(sl[i, 0].End.Y - sl[i, 0].Start.Y);

                        for (int k = Math.Min(sl[i, 0].Start.X, sl[i, 0].End.X); k <= Math.Max(sl[i, 0].Start.X, sl[i, 0].End.X); ++k)
                        {
                            g.FillRectangle(b, k, sl[i, 0].Start.Y, 1, 1);
                            g.FillRectangle(b, k, sl[i, 0].End.Y, 1, 1);
                        }
                        for (int k = Math.Min(sl[i, 0].Start.Y, sl[i, 0].End.Y); k <= Math.Max(sl[i, 0].Start.Y, sl[i, 0].End.Y); ++k)
                        {
                            g.FillRectangle(b, sl[i, 0].Start.X, k, 1, 1);
                            g.FillRectangle(b, sl[i, 0].End.X, k, 1, 1);
                        }
                        sl.shapeList.RemoveAt(i);
                        return;
                    }
                } catch (Exception error)
                {

                }
                
                //Circles
                try {
                    if (sl[i].isOn(sl[i].End, sl[i].Start, e.Location))
                    {
                        g.DrawEllipse(pen, sl[i].Start.X, sl[i].Start.Y, sl[i].End.X - sl[i].Start.X, (sl[i].End.Y - sl[i].Start.Y));
                        sl.shapeList.RemoveAt(i);
                        return;
                    }
                } catch (Exception error)
                {

                }
                //Lines
                try
                {
                    if (sl[i, 0, 0].isOn(sl[i, 0, 0].End, sl[i, 0, 0].Start, e.Location))
                    {
                        g.DrawLine(pen, sl[i,0,0].Start.X, sl[i,0,0].Start.Y, sl[i,0,0].End.X, sl[i,0,0].End.Y);
                        sl.shapeList.RemoveAt(i);
                        return;
                    }
                }
                catch(Exception error)
                {
                    
                }
            }

            //Remove the figure from the list if its count = 0
            for(int i = 0; i < ct; ++i)
            {
                try
                {
                    if (fl[i].pencilList.Count == 0)
                    {
                        fl.firgueList.Remove(i);
                    }
                }
                catch { }
            }
        }
    }
    [Serializable]
    class Circle : Shapes
    {
        int index = 3;
        public Circle()
        {

        }
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            Start = startPos;
            Scale.X = e.X - Start.X;
            Scale.Y = e.Y - Start.Y;
            End = e.Location;
            Pen pen = new Pen(color, 1);
            g.DrawEllipse(pen, Start.X, Start.Y, Scale.X, Scale.Y);
        }
        public void Draw(Color c,Graphics g,Point s,Point e)
        {
            Pen pen = new Pen(c, thickness);
            g.DrawEllipse(pen, s.X, s.Y, e.X - s.X, e.Y - s.Y);

        }
       
        public override bool isOn(Point endPoint, Point startPos,Point p)
        {
            return ((p.X - startPos.X) ^ 2 / (endPoint.X - startPos.X) ^ 2 + (p.Y - startPos.Y) ^ 2 / (endPoint.Y - startPos.Y) ^ 2) <= 1;
        }
    }
    [Serializable]
    class Retrangle : Shapes
    {
        int index = 4;
        public Retrangle()
        {

        }
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            Start = startPos;
            End = e.Location;
            Scale.X = Math.Abs(End.X - Start.X);
            Scale.Y = Math.Abs(End.Y - Start.Y);
            Pen pen = new Pen(color, 1);
            g.DrawRectangle(pen, Math.Min(Start.X,End.X), Math.Min(Start.Y,End.Y), Scale.X, Scale.Y);
        }

        public void Draw(Color c, Graphics g, Point s, Point e)
        {
            Scale.X = Math.Abs(e.X - s.X);
            Scale.Y = Math.Abs(e.Y - s.Y);
            Pen pen = new Pen(color, thickness);
            g.DrawRectangle(pen, Math.Min(Start.X, End.X), Math.Min(Start.Y, End.Y), Scale.X, Scale.Y);

        }
        public override bool isOn(Point endPoint, Point startPos, Point p)
        {
            return p.X <= Math.Max(End.X, Start.X) &&
                p.X >= Math.Min(End.X, Start.X) &&
                p.Y <= Math.Max(Start.Y, End.Y) &&
                p.Y >= Math.Min(Start.Y, End.Y);

            
        }
    }
    [Serializable]
    class Line : Shapes
    {
        int index = 5;

        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            Pen pen = new Pen(color, thickness);
            End = e.Location;
            g.DrawLine(pen, startPos.X, startPos.Y, e.X, e.Y);
        }

        public void Draw(Color c, Graphics g, Point endPos, Point startPos)
        {
            Pen pen = new Pen(color, thickness);
            g.DrawLine(pen, startPos.X, startPos.Y, endPos.X, endPos.Y);
        }
        public override bool isOn(Point startPoint, Point endPoint, Point p)
        {
            return p.X <= Math.Max(End.X, Start.X) &&
                p.X >= Math.Min(End.X, Start.X) &&
                p.Y <= Math.Max(Start.Y, End.Y) &&
                p.Y >= Math.Min(Start.Y, End.Y);
        }


    }
    [Serializable]
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
        public void Remove(int element)
        {
            if (element >= 0 && element < firgueList.Count)
            {
                for (int i = element; i < firgueList.Count - 1; i++)
                    firgueList[i] = firgueList[i + 1];
                firgueList.RemoveAt(firgueList.Count - 1);
            }
        }
    }
    [Serializable]
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
        public Line this[int index, int key = 0,int t = 0]
        {
            get
            {
                if (index >= shapeList.Count)
                    return (Line)null;
                return (Line)shapeList.GetByIndex(index);
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
