using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
        Pen pen = new Pen(Color.Black, 1);
        FigureList fl;
        ShapeList sl;
        Bitmap board;
        Graphics g;
        bool paint = false;
        Point endPoint, startPoint;
        Circle circle;
        Retrangle retrangle;
        Pencil pencil;
        int index , mmx,mmy;
        int count;

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
                    fl.firgueList[fl.firgueList.Count] = pencil;
                    break;
                case 2:
                    break;
                case 3:
                    circle = new Circle();
                    circle.Start = e.Location;
                    break;
                case 4:
                    retrangle = new Retrangle();
                    retrangle.Start = e.Location;
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
                    circle.Draw(Color.Black, g, e, startPoint);
                    sl.shapeList.Add(sl.shapeList.Count, circle);
                    break;
                case 4:
                    retrangle.End = e.Location;
                    retrangle.Draw(Color.Black, g, e, startPoint);
                    sl.shapeList.Add(sl.shapeList.Count, retrangle);
                    break;
                case 5:
                    break;
            }

            endPoint = e.Location;
            panel_board.Invalidate();
            label1.Text = sl.shapeList.Count.ToString();
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
                        pencil.Draw(Color.Black, g, e, startPoint);
                        break;
                    case 2:
                        Eraser er = new Eraser();
                        er.thickness = bar_thickness.Value;
                        er.Draw(Color.White, g, e, startPoint, fl,sl);
                        break;
                }
            }
            mmx = e.X;
            mmy = e.Y;
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
            if (paint) {
                switch (index)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }
            //Refresh Panel and fill all the points
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
