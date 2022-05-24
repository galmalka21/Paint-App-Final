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
        public bool Selected = false;

        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos) {}
        public virtual void Move(Graphics g, Point Start, Point End) { }
        public virtual void DrawOutline(Graphics g, Point Start, Point End){ }
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
        public override void Draw(Color c, Graphics g, MouseEventArgs e, Point startPos)
        {
            SolidBrush b = new SolidBrush(color);
            Point p = new Point(e.X, e.Y);
            Start = p;
            int count = pencilList.Count;
            pencilList.Add(count, p);
            g.FillRectangle(b, e.X, e.Y, thickness, thickness);
        }
        public void Draw(Color c, Graphics g, Point p)
        {
            SolidBrush b = new SolidBrush(c);
            for (int i = 0; i < pencilList.Count; ++i)
            {
                g.FillRectangle(b, p.X, p.Y, thickness, thickness);
            }

        }
        ~Pencil() { }

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


            //Remove the pencil brush pixel by pixel if its in the list
            for (int i = 0; i < ct; ++i)
            {
                for(int j = 0; j < thickness; j++)
                {
                    Point area = e.Location;
                    if (fl[i].pencilList.ContainsValue(area))
                    {
                        fl[i].pencilList.RemoveAt(fl[i].pencilList.IndexOfValue(area));
                        g.FillRectangle(b, area.X, area.Y, thickness*10, thickness*10);
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
        ~Eraser() { }
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
            Start = s;
            End = e;
            Pen pen = new Pen(c, thickness);
            g.DrawEllipse(pen, s.X, s.Y, e.X - s.X, e.Y - s.Y);

        }

        public void Move(Graphics g, Point NewLocation)
        {
            if (Selected)
            {
                Pen pen = new Pen(color, 1);
                Pen penWhite = new Pen(Color.White, 1);
                DrawOutline(Color.White, g, Start, End);
                g.DrawEllipse(penWhite, Start.X, Start.Y, Scale.X, Scale.Y);
                Start = new Point(NewLocation.X - (Scale.X / 2), NewLocation.Y - (Scale.Y / 2));
                End = new Point(Start.X + (Scale.X), (Start.Y) + (Scale.Y));
                g.DrawEllipse(pen, NewLocation.X - (Scale.X / 2), NewLocation.Y - (Scale.Y / 2), Scale.X, Scale.Y);
                Selected = false;

            }

        }
        public void DrawOutline(Color c,Graphics g, Point Start, Point End)
        {
            if (Selected)
            {
                Pen pen = new Pen(c, 1);

                int X, Y, Width, Height;
                X = Start.X - 3;
                Y = Start.Y - 3;
                Width = End.X - Start.X + 6;
                Height = End.Y - Start.Y + 6;
                g.DrawEllipse(pen, X, Y, Width, Height);
            }
        }
        public override bool isOn(Point endPoint, Point startPos,Point p)
        {
            return p.X <= Math.Max(End.X, Start.X) &&
                p.X >= Math.Min(End.X, Start.X) &&
                p.Y <= Math.Max(Start.Y, End.Y) &&
                p.Y >= Math.Min(Start.Y, End.Y);
        }
        ~Circle() { }
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
        public void DrawOutline(Color c,Graphics g, Point Start, Point End)
        {
            if (Selected)
            {
                Pen pen = new Pen(c, 1);
                int X, Y, Width, Height;
                X = Start.X - 3;
                Y = Start.Y - 3;
                Width = End.X - Start.X + 6;
                Height = End.Y - Start.Y + 6 ;
                g.DrawRectangle(pen, X, Y, Width, Height);
            }
        }
        public void Move(Graphics g, Point NewLocation) {
            if (Selected)
            {
                Pen pen = new Pen(color, 1);
                Pen penWhite = new Pen(Color.White, 1);
                DrawOutline(Color.White, g, Start, End);
                g.DrawRectangle(penWhite, Start.X, Start.Y, Scale.X, Scale.Y);
                Start = new Point(NewLocation.X - (Scale.X / 2), NewLocation.Y - (Scale.Y / 2));
                End = new Point(Start.X + (Scale.X), (Start.Y) + (Scale.Y));
                g.DrawRectangle(pen, NewLocation.X - (Scale.X / 2), NewLocation.Y - (Scale.Y / 2), Scale.X, Scale.Y);
                Selected = false;
                
            }
            
        }
        public override bool isOn(Point endPoint, Point startPos, Point p)
        {
            return p.X <= Math.Max(End.X, Start.X) &&
                p.X >= Math.Min(End.X, Start.X) &&
                p.Y <= Math.Max(Start.Y, End.Y) &&
                p.Y >= Math.Min(Start.Y, End.Y);

            
        }
        ~Retrangle() { }
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

        public void DrawOutline(Color c, Graphics g, Point Start, Point End)
        {
            if (Selected)
            {
                SolidBrush b = new SolidBrush(c);

                int X, Y, Width, Height;
                X = Start.X;
                Y = Start.Y;

                g.FillRectangle(b, X, Y, 4, 4);
                g.FillRectangle(b, End.X, End.Y, 4, 4);
            }
        }
        public void Move(Graphics g, Point NewLocation)
        {
            if (Selected)
            {
                Pen pen = new Pen(color, 1);
                Pen penWhite = new Pen(Color.White, 1);
                DrawOutline(Color.White, g, Start, End);
                Scale.X = End.X - Start.X;
                Scale.Y = End.Y - Start.Y;
                g.DrawLine(penWhite, Start.X, Start.Y, End.X, End.Y);
                Start = new Point(NewLocation.X - (Scale.X / 2), NewLocation.Y - (Scale.Y / 2));
                End = new Point(NewLocation.X + (Scale.X / 2), NewLocation.Y + (Scale.Y / 2));
                g.DrawLine(pen, Start.X, Start.Y, End.X, End.Y);
                Selected = false;

            }

        }
        ~Line() { }
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
        ~FigureList() { }
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
        ~ShapeList() { }
    }
}
