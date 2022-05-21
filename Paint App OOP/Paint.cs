﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Paint_App_OOP
{
    public partial class Paint : Form
    {

        public Paint()
        {
            InitializeComponent();
            board = new Bitmap(panel_board.Width, panel_board.Height);
            g = Graphics.FromImage(board);
            g.Clear(Color.White);
            panel_board.Image = board;
            fl = new FigureList();
            sl = new ShapeList();
        }


        //Shapes
        FigureList fl;
        ShapeList sl;
        Circle circle;
        Retrangle retrangle;
        Line line;
        Pencil pencil;
        Pen pen;

        //Board
        Bitmap board;
        Graphics g;
        bool paint = false;
        Color color = Color.Black;
        Color old_color;
        
        //Variables
        Point endPoint, startPoint;
        int index , count;
        bool load = false;
        

        //User Left Click 
        private void panel_board_MouseDown(object sender, MouseEventArgs e)
        {
            count = fl.firgueList.Count;
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    pencil = new Pencil();
                    pencil.color = color;
                    fl.firgueList[fl.firgueList.Count] = pencil;
                    break;
                case 2:
                    break;
                case 3:
                    circle = new Circle();
                    circle.color = color;
                    circle.Start = e.Location;
                    break;
                case 4:
                    retrangle = new Retrangle();
                    retrangle.color = color;
                    retrangle.Start = e.Location;
                    break;
                case 5:
                    line = new Line();
                    line.color = color;
                    line.Start = e.Location;
                    break;
            }

            paint = true;
            startPoint = e.Location;

        }

        //User Release Left Click
        private void panel_board_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            switch (index)
            {
                case 3:
                    circle.End = e.Location;
                    circle.Draw(color, g, e, startPoint);
                    sl.shapeList[sl.shapeList.Count] = circle;
                    
                    break;
                case 4:
                    retrangle.End = e.Location;
                    retrangle.Draw(color, g, e, startPoint);
                    sl.shapeList[sl.shapeList.Count] = retrangle;
                    break;
                case 5:
                    line.End = e.Location;
                    line.Draw(color, g, e, startPoint);
                    sl.shapeList[sl.shapeList.Count] = line;
                    break;
            }

            endPoint = e.Location;
            panel_board.Invalidate();
        }


        //Mouse Movement On Board
        private void panel_board_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                switch (index)
                {
                    case 1:
                        pencil.thickness = bar_thickness.Value;
                        pencil.Draw(color, g, e, startPoint);
                        break;
                    case 2:
                        Eraser er = new Eraser();
                        er.thickness = bar_thickness.Value;
                        er.Draw(Color.White, g, e, startPoint, fl,sl);
                        break;
                }
            }
            endPoint = e.Location;
            panel_board.Invalidate();

        }

        private void bar_thickness_Scroll(object sender, EventArgs e)
        {
            
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            index = 0;
        }

        private void panel_board_Paint(object sender, PaintEventArgs e)
        {
            //Draw the figure on the panel
            Graphics g = e.Graphics;
            int ScaleX = Math.Abs(endPoint.X - startPoint.X);
            int ScaleY = Math.Abs(endPoint.Y - startPoint.Y);
            pen = new Pen(color, 1);
            if (paint) {
                switch (index)
                {
                    case 3:
                        g.DrawEllipse(pen, Math.Min(startPoint.X,endPoint.X), Math.Min(startPoint.Y,endPoint.Y), ScaleX, ScaleY);
                        break;
                    case 4:
                        g.DrawRectangle(pen, Math.Min(startPoint.X,endPoint.X), Math.Min(startPoint.Y,endPoint.Y), ScaleX, ScaleY);
                        break;
                    case 5:
                        g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                        break;
                }
            }
            if (load == true)
            {
                reDraw();
            }
            load = false;
            //Refresh Panel and fill all the points
        }

        public void reDraw()
        {
            for (int i = 0; i < sl.shapeList.Count; i++)
            {
                //Circles
                try
                {
                    sl[i].Draw(sl[i].color, g, sl[i].End, sl[i].Start);
                }
                catch
                {

                }
                //Retangles
                try
                {
                    sl[i,0].Draw(sl[i,0].color, g, sl[i,0].End, sl[i,0].Start);
                }
                catch
                {

                }
                //Lines
                try
                {
                    sl[i, 0,0].Draw(sl[i, 0, 0].color, g, (Point)sl[i,0,0].End, sl[i, 0, 0].Start);
                }
                catch
                {

                }
            }
            for(int j = 0;j < fl.firgueList.Count; j++)
            {
                try
                {
                    fl[j].Draw(fl[j].color, g);
                }
                catch
                {

                }
            }
        }
        private void btn_pencil_Click(object sender, EventArgs e)
        {
            bar_thickness.Value = 1;
            index = 1;
        }
        private void btn_eraser_Click(object sender, EventArgs e)
        {
            bar_thickness.Value = 3;
            index = 2;
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            bar_thickness.Value = 1;
            index = 5;
        }
        private void btn_fill_Click(object sender, EventArgs e)
        {
            index = 6;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < fl.firgueList.Count; i++)
            {
                fl.firgueList.RemoveAt(i);
            }
            for(int j = 0; j < sl.shapeList.Count; j++)
            {
                sl.shapeList.RemoveAt(j);
            }

            g.Clear(Color.White);
        }
        static Point setPoint(PictureBox pb,Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }
        private void panel_colorpicker_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = setPoint(panel_colorpicker, e.Location);
            color = ((Bitmap)panel_colorpicker.Image).GetPixel(p.X,p.Y);
            btn_selected.BackColor = color;
        }

        

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bm.GetPixel(x, y);
            if(cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, color);
            }
        }

        public void Fill(Bitmap bm,int x,int y,Color new_color)
        {
            old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_color);
            if (old_color == new_color) return;

            while(pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if(pt.X > 0 && pt.Y >0 && pt.X <bm.Width -1 && pt.Y < bm.Height - 1){
                    validate(bm, pixel, pt.X - 1, pt.Y - 1, old_color, new_color);
                    validate(bm, pixel, pt.X , pt.Y - 1, old_color, new_color);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_color);
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, fl);
                    formatter.Serialize(stream, sl);
                }
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            load = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                fl = (FigureList)binaryFormatter.Deserialize(stream);
                sl = (ShapeList)binaryFormatter.Deserialize(stream);
                panel_board.Invalidate();
            }
        }

        private void panel_board_MouseClick(object sender, MouseEventArgs e)
        {
            if(index == 6)
            {
                Point p = setPoint(panel_board, e.Location);
                Fill(board, p.X, p.Y, color);
            }
        }
    }
}
