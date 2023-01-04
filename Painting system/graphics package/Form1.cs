using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_package
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static void multiply(int[,] mat1,
                        int[,] mat2, int[,] res)
        {
            int N = 3;
            int i, j, k;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    res[i, j] = 0;
                    for (k = 0; k < N; k++)
                        res[i, j] += mat1[i, k]
                                     * mat2[k, j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            lineDDA(x1, y1, x2, y2);

        }

        private void ddaPlotPoints(float x, float y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 172 + x, 154 - y, 2, 2);

        }

        void lineDDA(int x0, int y0, int xEnd, int yEnd)

        {
            int xInitial = x0, yInitial = y0, xFinal = xEnd, yFinal = yEnd;
            int dx = xFinal - xInitial, dy = yFinal - yInitial, steps, k;
            float xIncrement, yIncrement, x = xInitial, y = yInitial;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);

            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                try
                {
                    ddaPlotPoints(x, y);

                }
                catch (InvalidOperationException)
                {
                    return;
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //   e.Graphics.TranslateTransform(200.0F, 200.0F, MatrixOrder.Append);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox5.Text);
            int y1 = Convert.ToInt32(textBox6.Text);
            int x2 = Convert.ToInt32(textBox7.Text);
            int y2 = Convert.ToInt32(textBox8.Text);


            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            if (dx > dy)
            {
                bresenhamLine(x1, y1, x2, y2, dx, dy, 0);
            }
            else
            {
                bresenhamLine(y1, x1, y2, x2, dx, dy, 1);
            }


            drawAxis();
        }
        private void BLAPlotPoints(int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();


            g.FillRectangle(aBrush, 172 + x, 154 - y, 2, 2);


        }

        private void bresenhamLine(int x1, int y1, int x2, int y2, int dx, int dy, int decide)
        {
            int pk = 2 * dy - dx;
            for (int i = 0; i <= dx - 1; i++)
            {
                if (x1 < x2) x1++;
                else x1--;

                if (pk < 0)
                {
                    if (decide == 0)
                    {
                        BLAPlotPoints(x1, y1);
                        pk = pk + 2 * dy;
                    }
                    else
                    {
                        BLAPlotPoints(y1, x1);
                        pk = pk + 2 * dy;
                    }
                }
                else
                {
                    if (y1 < y2) y1++;
                    else y1--;
                    if (decide == 0)
                    {

                        BLAPlotPoints(x1, y1);
                    }
                    else
                    {
                        BLAPlotPoints(y1, x1);
                    }
                    pk = pk + 2 * dy - 2 * dx;
                }
            }
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox9.Text);
            int y1 = Convert.ToInt32(textBox10.Text);
            int radiusss = Convert.ToInt32(textBox11.Text);
            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            circleMidpoint(x1, y1, radiusss);
        }
        private void drawAxis()
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            for (int i = 0; i < 344; i++)
            {
                g.FillRectangle(aBrush, i, 154, 2, 2);
            } //x axis drawing
            for (int j = 0; j < 308; j++)
            {
                g.FillRectangle(aBrush, 172, j, 1, 1);
            } //y axis drawing
        }
        void circleMidpoint(int xCenter, int yCenter, int radius)
        {
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            circlePlotPoints(xCenter, yCenter, x, y);
            while (x < y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                circlePlotPoints(xCenter, yCenter, x, y);
            }
        }
        void circlePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + y), 154 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - y), 154 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + y), 154 - (yCenter - x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - y), 154 - (yCenter - x), 2, 2);

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int xradius = Convert.ToInt32(textBox14.Text);
            int yradius = Convert.ToInt32(textBox15.Text);
            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            ellipseMidpoint(x1, y1, xradius, yradius);
        }



        void ellipseMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;

            ellipsePlotPoints(xCenter, yCenter, x, y);
            /* Region 1 */
            p = Convert.ToInt32(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
            /* Region 2 */
            p = Convert.ToInt32(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);

            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
        }
        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter - y), 2, 2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);



            Point p1 = new Point(x1 + 172, 154 - y1);
            Point p2 = new Point(x2 + 172, 154 - y2);
            Point p3 = new Point(x3 + 172, 154 - y3);
            Point p4 = new Point(x4 + 172, 154 - y4);


            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);
            this.Refresh();
            panel1.Controls.Clear();
            draw.DrawLine(redBrush, p1, p2);
            draw.DrawLine(redBrush, p1, p3);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p3, p4);
            
            drawAxis();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);

            int y1dash = 0;
            int y2dash = 0;
            int y3dash = 0;
            int y4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };


            int[,] newtMat1 = { {1,0,x1 },
                                {0,1,y1dash },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2 },
                                {0,1,y2dash },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3 },
                                {0,1,y3dash },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4 },
                                {0,1,y4dash },
                                {0,0,1} };


            int[,] reflectMat = { {1,0,0 },
                                  {0,-1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);




            
            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Yellow);
            Pen redBrush = new Pen(brush, 2);
            draw.DrawLine(redBrush, x1 + 172, 154 - newtMat1[1, 2], x2 + 172, 154 - newtMat2[1, 2]);
            draw.DrawLine(redBrush, x1 + 172, 154 - newtMat1[1, 2], x3 + 172, 154 - newtMat3[1, 2]);
            draw.DrawLine(redBrush, x2 + 172, 154 - newtMat2[1, 2], x4 + 172, 154 - newtMat4[1, 2]);
            draw.DrawLine(redBrush, x3 + 172, 154 - newtMat3[1, 2], x4 + 172, 154 - newtMat4[1, 2]);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);

            int x1dash = 0;
            int x2dash = 0;
            int x3dash = 0;
            int x4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };


            int[,] newtMat1 = { {1,0,x1dash },
                                {0,1,y1 },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2dash },
                                {0,1,y2 },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3dash },
                                {0,1,y3 },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4dash },
                                {0,1,y4 },
                                {0,0,1} };


            int[,] reflectMat = { {-1,0,0 },
                                  {0,1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);





            Graphics draw = panel1.CreateGraphics();

            Brush brush = new SolidBrush(Color.Yellow);
            Pen redBrush = new Pen(brush, 2);
            drawAxis();
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - y1, newtMat2[0, 2] + 172, 154 - y2);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - y1, newtMat3[0, 2] + 172, 154 - y3);
            draw.DrawLine(redBrush, newtMat2[0, 2] + 172, 154 - y2, newtMat4[0, 2] + 172, 154 - y4);
            draw.DrawLine(redBrush, newtMat3[0, 2] + 172, 154 - y3, newtMat4[0, 2] + 172, 154 - y4);

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);

            int x1dash = 0;
            int y1dash = 0;
            int x2dash = 0;
            int y2dash = 0;
            int x3dash = 0;
            int y3dash = 0;
            int x4dash = 0;
            int y4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };

            int[,] newtMat1 = { {1,0,x1dash },
                                {0,1,y1dash },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2dash },
                                {0,1,y2dash },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3dash },
                                {0,1,y3dash },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4dash },
                                {0,1,y4dash },
                                {0,0,1} };


            int[,] reflectMat = { {-1,0,0 },
                                  {0,-1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);





            Graphics draw = panel1.CreateGraphics();

            Brush brush = new SolidBrush(Color.Yellow);
            Pen redBrush = new Pen(brush, 2);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - newtMat1[1, 2], newtMat2[0, 2] + 172, 154 - newtMat2[1, 2]);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - newtMat1[1, 2], newtMat3[0, 2] + 172, 154 - newtMat3[1, 2]);
            draw.DrawLine(redBrush, newtMat2[0, 2] + 172, 154 - newtMat2[1, 2], newtMat4[0, 2] + 172, 154 - newtMat4[1, 2]);
            draw.DrawLine(redBrush, newtMat3[0, 2] + 172, 154 - newtMat3[1, 2], newtMat4[0, 2] + 172, 154 - newtMat4[1, 2]);
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }



        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox22.Text);
            int y = Convert.ToInt32(textBox23.Text);
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);

            int xdash = x1 + x;
            int ydash = y1 + y;
            int xdash2 = x2 + x;
            int ydash2 = y2 + y;
            int xdash3 = x3 + x;
            int ydash3 = y3 + y;
            int xdash4 = x4 + x;
            int ydash4 = y4 + y;

            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        }
        private void Translate(int xdash, int ydash, int xdash2, int ydash2, int xdash3, int ydash3, int xdash4, int ydash4)
        {

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Yellow);
            Pen redBrush = new Pen(brush, 2);
            Point p1 = new Point(xdash + 172, 154 - ydash);
            Point p2 = new Point(xdash2 + 172, 154 - ydash2);
            Point p3 = new Point(xdash3 + 172, 154 - ydash3);
            Point p4 = new Point(xdash4 + 172, 154 - ydash4);
            draw.DrawLine(redBrush, p1, p2);
            draw.DrawLine(redBrush, p1, p3);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p3, p4);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox22.Text);
            int y = Convert.ToInt32(textBox23.Text);
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);

            int xdash = x1 * x;
            int xdash2 = x2 * x;
            int xdash3 = x3 * x;
            int xdash4 = x4 * x;


            int ydash = y1 * y;
            int ydash2 = y2 * y;
            int ydash3 = y3 * y;
            int ydash4 = y4 * y;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }

        private void button11_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);
            double angle = Convert.ToDouble(textBox24.Text);
            
            double xdash1 = (Math.Cos(angle) * x1) + (-Math.Sin(angle) * y1);
            double ydash1 = (Math.Sin(angle) * x1) + (Math.Cos(angle) * y1);
            double xdash2 = (Math.Cos(angle) * x2) + (-Math.Sin(angle) * y2);
            double ydash2 = (Math.Sin(angle) * x2) + (Math.Cos(angle) * y2);
            double xdash3 = (Math.Cos(angle) * x3) + (-Math.Sin(angle) * y3);
            double ydash3 = (Math.Sin(angle) * x3) + (Math.Cos(angle) * y3);
            double xdash4 = (Math.Cos(angle) * x4) + (-Math.Sin(angle) * y4);
            double ydash4 = (Math.Sin(angle) * x4) + (Math.Cos(angle) * y4);
            Translate((int)xdash1, (int)ydash1, (int)xdash2, (int)ydash2, (int)xdash3, (int)ydash3, (int)xdash4, (int)ydash4);



        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(Color.DarkRed);
        }

        
        private void button13_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);
            int sx = Convert.ToInt32(textBox25.Text);




            int xdash = x1 + sx * y1;
            int xdash2 = x2 + sx * y2;
            int xdash3 = x3 + sx * y3;
            int xdash4 = x4 + sx * y4;

            int ydash = y1;
            int ydash2 = y2;
            int ydash3 = y3;
            int ydash4 = y4;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }
        
        private void button14_Click(object sender, EventArgs e)
        {


            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox27.Text);
            int y4 = Convert.ToInt32(textBox28.Text);
            int sy = Convert.ToInt32(textBox26.Text);
            




            int xdash = x1;
            int xdash2 = x2;
            int xdash3 = x3;
            int xdash4 = x4;

            int ydash = y1 + sy * x1;
            int ydash2 = y2 + sy * x2;
            int ydash3 = y3 + sy * x3;
            int ydash4 = y4 + sy * x4;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int rad = Convert.ToInt32(textBox29.Text);
            int xCenter = Convert.ToInt32(textBox37.Text);
            int yCenter = Convert.ToInt32(textBox38.Text);
            int n = 3;
            double time = Convert.ToDouble(textBox44.Text);
            double timeInMillisecond = time * 1000;

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);


            Point p1, p2;
            double x1, x2, y1, y2;
            int times;

            this.Refresh();
            panel1.Controls.Clear();
            drawAxis();

            if (timeInMillisecond == 0) times = 1;
            else times = 16;

            for (int i = 1; i <= times; i++)
            {


                for (int j = 0; j < n; j++)
                {
                    x1 = rad * Math.Cos(Math.PI * 2 * j / n);
                    y1 = rad * Math.Sin(Math.PI * 2 * j / n);
                    p1 = new Point(xCenter + 172 + rad + (int)x1, yCenter + 154 - rad - (int)y1);
                    x2 = rad * Math.Cos(Math.PI * 2 * (j + 1) / n);
                    y2 = rad * Math.Sin(Math.PI * 2 * (j + 1) / n);
                    p2 = new Point(xCenter + 172 + rad + (int)x2, yCenter + 154 - rad - (int)y2);
                    draw.DrawLine(redBrush, p1, p2);
                    if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / n);
                }
                if (i != 16 && times != 1)
                {
                    this.Refresh();
                    panel1.Controls.Clear();
                    drawAxis();
                    Thread.Sleep((int)timeInMillisecond / 16);
                    xCenter += 10;
                }
            }



        }

        private void button16_Click(object sender, EventArgs e)
        {
            int rad = Convert.ToInt32(textBox30.Text);
            int xCenter = Convert.ToInt32(textBox39.Text);
            int yCenter = Convert.ToInt32(textBox40.Text);
            int n = 4;

            double time = Convert.ToDouble(textBox45.Text);
            double timeInMillisecond = time * 1000;

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);


            Point p1, p2;
            double x1, x2, y1, y2;
            int times;

            this.Refresh();
            panel1.Controls.Clear();
            drawAxis();

            if (timeInMillisecond == 0) times = 1;
            else times = 16;

            for (int i = 1; i <= times; i++)
            {


                for (int j = 0; j < n; j++)
                {
                    x1 = rad * Math.Cos(Math.PI * 2 * j / n);
                    y1 = rad * Math.Sin(Math.PI * 2 * j / n);
                    p1 = new Point(xCenter + 172 + rad + (int)x1, yCenter + 154 - rad - (int)y1);
                    x2 = rad * Math.Cos(Math.PI * 2 * (j + 1) / n);
                    y2 = rad * Math.Sin(Math.PI * 2 * (j + 1) / n);
                    p2 = new Point(xCenter + 172 + rad + (int)x2, yCenter + 154 - rad - (int)y2);
                    draw.DrawLine(redBrush, p1, p2);
                    if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / n);
                }
                if (i != 16 && times != 1)
                {
                    this.Refresh();
                    panel1.Controls.Clear();
                    drawAxis();
                    Thread.Sleep((int)timeInMillisecond / 16);
                    xCenter += 10;
                }
            }



        }

        private void button17_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(textBox31.Text);
            int height = Convert.ToInt32(textBox32.Text);
            int xCenter = Convert.ToInt32(textBox41.Text);
            int yCenter = Convert.ToInt32(textBox42.Text);

            double time = Convert.ToDouble(textBox46.Text);
            double timeInMillisecond = time * 1000;

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);


            Point p1, p2;
            int times;

            this.Refresh();
            panel1.Controls.Clear();
            drawAxis();

            if (timeInMillisecond == 0) times = 1;
            else times = 16;

            for (int i = 1; i <= times; i++)
            {


                p1 = new Point(xCenter + 172, 154 - yCenter);
                p2 = new Point(xCenter + 172 + width, 154 - yCenter);
                draw.DrawLine(redBrush, p1, p2);

                if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / 4);

                p1 = new Point(xCenter + 172, 154 - yCenter);
                p2 = new Point(xCenter + 172, 154 - yCenter - height);
                draw.DrawLine(redBrush, p1, p2);

                if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / 4);

                p1 = new Point(xCenter + 172, 154 - yCenter - height);
                p2 = new Point(xCenter + 172 + width, 154 - yCenter - height);
                draw.DrawLine(redBrush, p1, p2);

                if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / 4);

                p1 = new Point(xCenter + 172 + width, 154 - yCenter - height);
                p2 = new Point(xCenter + 172 + width, 154 - yCenter);
                draw.DrawLine(redBrush, p1, p2);

                if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / 4);


                if (i != 16 && times != 1)
                {
                    this.Refresh();
                    panel1.Controls.Clear();
                    drawAxis();
                    Thread.Sleep((int)timeInMillisecond / 16);
                    xCenter += 10;
                }
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox33.Text);
            int rad = Convert.ToInt32(textBox34.Text);
            int xCenter = Convert.ToInt32(textBox35.Text);
            int yCenter = Convert.ToInt32(textBox36.Text);
            double time = Convert.ToDouble(textBox43.Text);
            double timeInMillisecond = time * 1000;

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);


            Point p1, p2;
            double x1, x2, y1, y2;
            int times;

            this.Refresh();
            panel1.Controls.Clear();
            drawAxis();

            if (timeInMillisecond == 0) times = 1;
            else times = 16;

            for (int i = 1; i <= times; i++)
            {


                for (int j = 0; j < n; j++)
                {
                    x1 = rad * Math.Cos(Math.PI * 2 * j / n);
                    y1 = rad * Math.Sin(Math.PI * 2 * j / n);
                    p1 = new Point(xCenter + 172 + rad + (int)x1, yCenter + 154 - rad - (int)y1);
                    x2 = rad * Math.Cos(Math.PI * 2 * (j + 1) / n);
                    y2 = rad * Math.Sin(Math.PI * 2 * (j + 1) / n);
                    p2 = new Point(xCenter + 172 + rad + (int)x2, yCenter + 154 - rad - (int)y2);
                    draw.DrawLine(redBrush, p1, p2);
                    if (i == 1) Thread.Sleep((int)timeInMillisecond / 16 / n);
                }
                if (i != 16 && times != 1)
                {
                    this.Refresh();
                    panel1.Controls.Clear();
                    drawAxis();
                    Thread.Sleep((int)timeInMillisecond / 16);
                    xCenter += 10;
                }
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox47.Text);
            int y1 = Convert.ToInt32(textBox48.Text);
            int x2 = Convert.ToInt32(textBox49.Text);
            int y2 = Convert.ToInt32(textBox50.Text);

            int x_min = Convert.ToInt32(textBox51.Text);
            int x_max = Convert.ToInt32(textBox52.Text);
            int y_min = Convert.ToInt32(textBox53.Text);
            int y_max = Convert.ToInt32(textBox54.Text);

            Point p1 = new Point(172 + x1, 154 - y1);
            Point p2 = new Point(172 + x2, 154 - y2);

            Point p3 = new Point(172 + x_min, 154 - y_min);
            Point p4 = new Point(172 + x_min, 154 - y_max);
            Point p5 = new Point(172 + x_max, 154 - y_max);
            Point p6 = new Point(172 + x_max, 154 - y_min);

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);

            Brush brush2 = new SolidBrush(Color.White);
            Pen rectBrush = new Pen(brush2, 2);


            this.Refresh();
            panel1.Controls.Clear();
            draw.DrawLine(redBrush, p1, p2);

            draw.DrawLine(rectBrush, p3, p4);
            draw.DrawLine(rectBrush, p4, p5);
            draw.DrawLine(rectBrush, p5, p6);
            draw.DrawLine(rectBrush, p6, p3);


            drawAxis();


        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox47.Text);
            double y1 = Convert.ToDouble(textBox48.Text);
            double x2 = Convert.ToDouble(textBox49.Text);
            double y2 = Convert.ToDouble(textBox50.Text);

            double x1Clipped = 0, y1Clipped = 0, x2Clipped = 0, y2Clipped = 0;

            int x_min = Convert.ToInt32(textBox51.Text);
            int y_min = Convert.ToInt32(textBox53.Text);
            int x_max = Convert.ToInt32(textBox52.Text);
            int y_max = Convert.ToInt32(textBox54.Text);


            Point p3 = new Point(172 + x_min, 154 - y_min);
            Point p4 = new Point(172 + x_min, 154 - y_max);
            Point p5 = new Point(172 + x_max, 154 - y_max);
            Point p6 = new Point(172 + x_max, 154 - y_min);








            const int INSIDE = 0; // 0000
            const int LEFT = 1; // 0001
            const int RIGHT = 2; // 0010
            const int BOTTOM = 4; // 0100
            const int TOP = 8; // 1000

            int computeCode(double x, double y)
            {

                int code = INSIDE;

                if (x < x_min)
                    code |= LEFT;
                else if (x > x_max)
                    code |= RIGHT;
                if (y < y_min)
                    code |= BOTTOM;
                else if (y > y_max)
                    code |= TOP;

                return code;
            }

            void cohenSutherlandClip(double x11, double y11, double x22, double y22)
            {

                int code1 = computeCode(x11, y11);
                int code2 = computeCode(x22, y22);


                bool accept = false;

                while (true)
                {
                    if ((code1 == 0) && (code2 == 0))
                    {

                        accept = true;
                        break;
                    }
                    else if ((code1 & code2) != 0)
                    {

                        break;
                    }
                    else
                    {

                        int code_out;
                        double x = 0.0;
                        double y = 0.0;


                        if (code1 != 0)
                            code_out = code1;
                        else
                            code_out = code2;


                        if ((code_out & TOP) != 0)
                        {
                            x = x11 + (x22 - x11) * (y_max - y11) / (y22 - y11);
                            y = y_max;
                        }
                        else if ((code_out & BOTTOM) != 0)
                        {

                            x = x11 + (x22 - x11) * (y_min - y11) / (y22 - y11);
                            y = y_min;
                        }
                        else if ((code_out & RIGHT) != 0)
                        {

                            y = y11 + (y22 - y11) * (x_max - x11) / (x22 - x11);
                            x = x_max;
                        }
                        else if ((code_out & LEFT) != 0)
                        {

                            y = y11 + (y22 - y11) * (x_min - x11) / (x22 - x11);
                            x = x_min;
                        }


                        if (code_out == code1)
                        {
                            x11 = x;
                            y11 = y;
                            code1 = computeCode(x11, y11);
                        }
                        else
                        {
                            x22 = x;
                            y22 = y;
                            code2 = computeCode(x22, y22);
                        }
                    }
                }
                if (accept)
                {
                    x1Clipped = x11;
                    y1Clipped = y11;
                    x2Clipped = x22;
                    y2Clipped = y22;
                }


            }

            cohenSutherlandClip(x1, y1, x2, y2);
            Point p1 = new Point(172 + (int)x1Clipped, 154 - (int)y1Clipped);
            Point p2 = new Point(172 + (int)x2Clipped, 154 - (int)y2Clipped);


            this.Refresh();
            panel1.Controls.Clear();

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Pen redBrush = new Pen(brush, 2);

            Brush brush2 = new SolidBrush(Color.White);
            Pen rectBrush = new Pen(brush2, 2);


            draw.DrawLine(redBrush, p1, p2);

            draw.DrawLine(rectBrush, p3, p4);
            draw.DrawLine(rectBrush, p4, p5);
            draw.DrawLine(rectBrush, p5, p6);
            draw.DrawLine(rectBrush, p6, p3);



            drawAxis();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}

