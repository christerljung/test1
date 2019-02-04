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
       protected List<Rectangle> Figures = new List<Rectangle>();  // previous Figures

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
            //    if (rc.Width > 0 && rc.Height > 0) Figures.Add(rc);
            //    this.Invalidate();
            //}
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (Figures.Count > 0) e.Graphics.DrawFigures(Pens.Black, Figures.ToArray());
            //if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }
    }
}
