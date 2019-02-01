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
    class PaintPanelRect: FigurePanel
    {  
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (rectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }
    }
}
