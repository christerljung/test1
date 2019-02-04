using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace paint
{
    public partial class Form1 : Form
    {
        bool draw = false;
        int pX = -1;
        int pY = -1;
        Color color1 = new Color();
        int penSize =7;
        Bitmap drawing;
        bool redo = false;
        PaintPanelCircles circles = new PaintPanelCircles();
        PaintPanelRect rn = new PaintPanelRect();

        public Form1()
        {
            InitializeComponent();
            drawing = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            color1 = Color.Black;
            this.Controls.Add(circles);
            circles.Left = 200;
            circles.Top = 300;
            this.Controls.Add(rn);
           rn.Left = 200;
            rn.Top = 100;
        }
       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        List<int> dotsX = new List<int>();
        List<int> dotsY = new List<int>();
        int ix;
        int iy;
        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                dotsX.Add(e.X);
                dotsY.Add(e.Y);
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(color1, penSize);

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;

                panel.DrawLine(pen, pX, pY,  e.X, e.Y);

                panel1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }

            if(redo)
            {
                if (ix > dotsX.Count)
                    redo = false;
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(color1, penSize);

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;

                panel.DrawLine(pen, pX, pY, dotsX[ix++], dotsY[iy++]);

                panel1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }

            pX = e.X;
            pY = e.Y;

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            draw = true;

            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                color1 = colorDialog1.Color;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            penSize = int.Parse(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics.FromImage(drawing).Clear(Color.White);
            panel1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            redo = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
