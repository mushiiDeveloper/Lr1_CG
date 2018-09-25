using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lr1_CG
{
    public partial class Form1 : Form
    {
        Parallelogram pr = new Parallelogram(1,2,3,4,5,6,7,8,0);
        Pen pen = new Pen(Color.Black, 1);
        Bitmap image;

        int size = 440;
        int onePieceSize = 20;
        int multiplier = 10;

        List<Parallelogram> _listOfParallelog = new List<Parallelogram>();
        public Form1()
        {
            InitializeComponent();
            Cleaner();
        }

        public void Cleaner()
        {
            image = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Drawing.Graphics.FromImage(image).Clear(Color.White);
            pictureBox1.Image = image;
            pen.StartCap = LineCap.ArrowAnchor;

            System.Drawing.Graphics.FromImage(image).DrawLine(pen, size / 2, 0, size / 2, size);
            System.Drawing.Graphics.FromImage(image).DrawLine(pen, size, size / 2, 0, size / 2);

            PointF[] PointArr = new PointF[3];
            PointF A = new PointF(size / 2, 0);
            PointF B = new PointF(size / 2 + 5, 10);
            PointF C = new PointF(size / 2 - 5, 10);
            PointArr[0] = A;
            PointArr[1] = B;
            PointArr[2] = C;
            
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            System.Drawing.Graphics.FromImage(image).FillPolygon(drawBrush, PointArr);
            
            PointF D = new PointF(size, size / 2);
            PointF E = new PointF(size - 10, size / 2 + 5);
            PointF F = new PointF(size - 10, size / 2 - 5);
            PointArr[0] = D;
            PointArr[1] = E;
            PointArr[2] = F;

            System.Drawing.Graphics.FromImage(image).FillPolygon(drawBrush, PointArr);
           
            for (var i = 1; i <= size / onePieceSize; i++)
            {
                System.Drawing.Graphics.FromImage(image).DrawRectangle(pen, size / 2 - 1, i * onePieceSize - 1, 2, 1);
                System.Drawing.Graphics.FromImage(image).DrawRectangle(pen, size - (onePieceSize * i), size / 2 - 1, 1, 2);

                // Create string to draw.
                var num = size * multiplier / (2 * onePieceSize) - i * multiplier;
                var forMinus = "";

                if (num < 0)
                {
                    num = Math.Abs(num);
                    forMinus = "-";
                }
                String drawString = Convert.ToString(num) + forMinus;

                // Create font and brush.
                Font drawFont = new Font("Arial", 7);

                // Create point for upper-left corner of drawing.
                var forMargin = 20;
                if (forMinus == "" && num < 10) forMargin = 14;
                if (forMinus != "" && num < 10) forMargin = 15;
                if (forMinus == "" && num >= 10) forMargin = 15;
                PointF drawPointVert = new PointF(size / 2 + forMargin, i * onePieceSize - 3);
                PointF drawPointHor = new PointF(size - (onePieceSize * i) + 5, size / 2 + 5);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                // Draw string to screen.
                System.Drawing.Graphics.FromImage(image).DrawString(drawString, drawFont, drawBrush, drawPointVert, drawFormat);

                if (num != 0) System.Drawing.Graphics.FromImage(image).DrawString(drawString, drawFont, drawBrush, drawPointHor, drawFormat);
            } 
        }

        public void Drawing(Parallelogram par)
        {
            pen.StartCap = LineCap.ArrowAnchor;
            pictureBox1.Image = image;
            Point point1 = new Point(par.x1 * 20 + size / 2, par.y1 * 20 + size / 2);
            Point point2 = new Point(par.x2 * 20 + size / 2, par.y2 * 20 + size / 2);
            Point point3 = new Point(par.x3 * 20 + size / 2, par.y3 * 20 + size / 2);
            Point point4 = new Point(par.x4 * 20 + size / 2, par.y4 * 20 + size / 2);
            Point[] curPoint =
            {
                point1,
                point2,
                point3,
                point4
            };
            System.Drawing.Graphics.FromImage(image).DrawPolygon(pen, curPoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(richTextBox1.Text);
            int y1 = Convert.ToInt32(richTextBox2.Text);

            int x2 = Convert.ToInt32(richTextBox3.Text);
            int y2 = Convert.ToInt32(richTextBox4.Text);

            int x3 = Convert.ToInt32(richTextBox5.Text);
            int y3 = Convert.ToInt32(richTextBox6.Text);

            int x4 = Convert.ToInt32(richTextBox7.Text);
            int y4 = Convert.ToInt32(richTextBox8.Text);

            Parallelogram par = new Parallelogram(x1,y1,x2,y2,x3,y3,x4,y4,0);
            Drawing(par);
            //_listOfParallelog.Add(new Parallelogram(x1,y1,x2,y2,x3,y3,x4,y4,1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cleaner();
        }
    }
}
