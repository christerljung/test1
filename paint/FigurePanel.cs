using System;
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
    class FigurePanel : Panel
    {
       protected Point startPos;      // mouse-down position
       protected Point currentPos;    // current mouse position
       protected bool drawing;        // busy drawing
       protected List<Rectangle> rectangles = new List<Rectangle>();  // previous rectangles

        public FigurePanel()
        {
            this.BackColor = Color.Azure;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //if (drawing)
            //{
            //    drawing = false;
            //    var rc = getRectangle();
            //    if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
            //    this.Invalidate();
            //}
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (rectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
            //if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }
    }
}
