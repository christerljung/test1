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
    class PaintPanelCircles : Panel
    {
        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;        // busy drawing
        List<Rectangle> rectangles = new List<Rectangle>();  // previous rectangles

        public PaintPanelCircles()
        {
            this.BackColor = Color.Azure;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        protected override void OnMouseDown( MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;
        }
        protected override void OnMouseMove( MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();
        }
        protected override void OnMouseUp( MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                this.Invalidate();
            }
        }
        protected override void OnPaint( PaintEventArgs e)
        {
            if (rectangles.Count > 0)
            {
                foreach (Rectangle r in rectangles)
                    e.Graphics.DrawEllipse(Pens.Red, r);
            }              
            if (drawing) e.Graphics.DrawEllipse(Pens.Red, getRectangle());// pX - 150, pY - 150, 300, 300);             
        }
    }
}
