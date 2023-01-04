using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_package
{
    public partial class Form2 : Form
    {
        int xCoordinates, yCoordinates;
        bool twice = false;
        int x1=0, y1=0, x2=0, y2=0;

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(Color.DarkRed);
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            xCoordinates = e.X;
            yCoordinates = e.Y;
        }

        private void panel1_Click(object sender, EventArgs e)
        {

            int n = Convert.ToInt32(textBox1.Text);
            int radius = Convert.ToInt32(textBox2.Text);
            int distance = Convert.ToInt32(textBox3.Text);

            void drawShapes(int noOfSides,int radiusOfPolygon,int xCenter,int yCenter) {
                Graphics draw = panel1.CreateGraphics();
                Brush brush = new SolidBrush(Color.Black);
                Pen redBrush = new Pen(brush, 2);
                Point p1, p2;
                double x1, x2, y1, y2;
                for (int i = 0; i < noOfSides; i++)
                {
                    x1 = radiusOfPolygon * Math.Cos(Math.PI * 2 * i / n);
                    y1 = radiusOfPolygon * Math.Sin(Math.PI * 2 * i / n);
                    p1 = new Point(xCenter+radiusOfPolygon + (int)x1, yCenter+radiusOfPolygon + (int)y1);
                    x2 = radiusOfPolygon * Math.Cos(Math.PI * 2 * (i + 1) / n);
                    y2 = radiusOfPolygon * Math.Sin(Math.PI * 2 * (i + 1) / n);
                    p2 = new Point(xCenter+radiusOfPolygon + (int)x2, yCenter+radiusOfPolygon + (int)y2);
                    draw.DrawLine(redBrush, p1, p2);
                }

            }




            if (twice == false)
            {
                x1 = xCoordinates;
                y1 = yCoordinates;
                twice = true;
            }
            else
            {
                x2 = xCoordinates;
                y2 = yCoordinates;

                int dx = x2 - x1;
                int dy = y2 - y1;

                int steps=10;
                float xIncrement, yIncrement;

                if (Math.Abs(dx) > Math.Abs(dy)) steps = dx;
                else steps = dy;

                steps /= distance;
                if (x2 - x1 < 0)
                {
                    xIncrement = -1*Math.Abs(dx / (float)steps);
                }
                else
                {
                    xIncrement = Math.Abs(dx / (float)steps);
                }
                if (y2 - y1 < 0)
                {
                    yIncrement = -1*Math.Abs(dy / (float)steps);
                }
                else
                {
                    yIncrement =Math.Abs(dy / (float)steps);
                }
                float x = x1,y=y1;
                

                for(int k = 0; k < steps; k++)
                {
                    x += xIncrement;
                    y += yIncrement;
                    drawShapes(n, radius, (int)x, (int)y);
                    
                 
                }

                

                twice = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
