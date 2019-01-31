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
    class PaintPanelRect : Panel
    {
        int _pressedLocationX;
        int _pressedLocationY;
        int _releasedLocationX;
        int _releasedLocationY;

        public PaintPanelRect()
        {
            this.BackColor = Color.Azure;
         
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _releasedLocationX = e.X;
            _releasedLocationY = e.Y;

            using (Graphics graphics = base.CreateGraphics())
            using (SolidBrush solidbrush = new SolidBrush(Color.Magenta))
            using (Pen pen = new Pen(Color.DarkRed))
            {
                graphics.Clear(SystemColors.Control);
                string choise = "Filled Square";
                switch (choise)
                {
                    case "Filled Square":
                        graphics.FillRectangle(solidbrush,
                            Math.Min(_pressedLocationX, _releasedLocationX), // Left
                            Math.Min(_pressedLocationY, _releasedLocationY), // Top
                            Math.Abs(_releasedLocationX - _pressedLocationX), // Width
                            Math.Abs(_releasedLocationY - _pressedLocationY)); // Height
                        break;

                    case "Filled Circle":
                        graphics.FillEllipse(solidbrush,
                            Math.Min(_pressedLocationX, _releasedLocationX), // Left
                            Math.Min(_pressedLocationY, _releasedLocationY), // Top
                            Math.Abs(_releasedLocationX - _pressedLocationX), // Width
                            Math.Abs(_releasedLocationY - _pressedLocationY)); // Height
                        break;
                    case "Line Square":
                        graphics.DrawRectangle(pen,
                            Math.Min(_pressedLocationX, _releasedLocationX), // Left
                            Math.Min(_pressedLocationY, _releasedLocationY), // Top
                            Math.Abs(_releasedLocationX - _pressedLocationX), // Width
                            Math.Abs(_releasedLocationY - _pressedLocationY)); // Height
                        break;

                    case "Line Circle":
                        graphics.DrawEllipse(pen,
                            Math.Min(_pressedLocationX, _releasedLocationX), // Left
                            Math.Min(_pressedLocationY, _releasedLocationY), // Top
                            Math.Abs(_releasedLocationX - _pressedLocationX), // Width
                            Math.Abs(_releasedLocationY - _pressedLocationY)); // Height
                        break;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _pressedLocationX = e.X;
            _pressedLocationY = e.Y;
            base.OnClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

         


            base.OnMouseEnter(e);
        }

    }
}
