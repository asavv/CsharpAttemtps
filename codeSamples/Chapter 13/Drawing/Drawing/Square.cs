﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;


namespace Drawing
{
    class Square : DrawingShape, IDraw, IColor
    {
        public Square(int sideLength) : base(sideLength)
        {
            //empty constructor, because the base calss constructor is performing the initialization required.
        }



       
        public override void Draw(Canvas canvas)
        {
            if (this.shape != null)
            {
                canvas.Children.Remove(this.shape);
            }
            else
            {
                this.shape = new Rectangle();
            }

            base.Draw(canvas);

        }
        
    }
}
