using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace paint
{
    class PaintPanelPen: Panel
    {
        bool draw = false;
        int pX = -1;
        int pY = -1;
        Color color1 = new Color();
        int penSize = 7;
        Bitmap drawing;
        bool redo = false;

        public PaintPanelPen()
        {
            this.BackColor = Color.Azure;
            drawing = new Bitmap(this.Width, this.Height, this.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            color1 = Color.Black;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            draw = false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            draw = true;
            pX = e.X;
            pY = e.Y;        
        }
        protected override void OnMouseMove (MouseEventArgs e)
        {
            if (draw)
            {             
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(color1, penSize);
                SolidBrush solidbrush = new SolidBrush(Color.Magenta);
                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;
                panel.FillRectangle(solidbrush,
                           Math.Min(pX, e.X), // Left
                           Math.Min(pY, e.Y), // Top
                           Math.Abs(e.X - pX), // Width
                           Math.Abs(e.Y - pY)); // Height
               // panel.DrawLine(pen, pX, pY, e.X, e.Y);

                this.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }           

            pX = e.X;
            pY = e.Y;

            
            base.OnMouseEnter(e);
        }
       
    }
}
