using BinarySearchTree;
using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace App
{
    public class BSTGraphic<T> where T : GraphicNodeValue
    {
        /// <summary>
        /// the backgroung image of each nodes, the size of this bitmap affects the quality of output image
        /// </summary>
        private static Bitmap _nodeBg = new Bitmap(30, 25);
        /// <summary>
        /// the free space between nodes on the drawed image, 
        /// </summary>
        private static Size _freeSpace = new Size(_nodeBg.Width / 8, (int)(_nodeBg.Height * 1.3f));
        /// <summary>
        /// a value which is used, (on drawing the Value of the nodes), in order to make sure the drawed image would be the same for any size of _nodeBg.<see cref="_nodeBg"/>
        /// </summary>
        private static readonly float Coef = _nodeBg.Width / 40f;

        private static Font font = new Font("Tahoma", 14f * Coef);
        
        static BSTGraphic()
        {
            var g = Graphics.FromImage(_nodeBg);                                    // get a Graphics from _nodeBg bitmap, 
            g.SmoothingMode = SmoothingMode.HighQuality;                            // set the smoothing mode
            var rcl = new Rectangle(1, 1, _nodeBg.Width - 2, _nodeBg.Height - 2);   // get a rectangle of drawer
            g.FillRectangle(Brushes.White, rcl);
            //g.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(10, 10), Color.Goldenrod, Color.Black), rcl);
            g.DrawEllipse(new Pen(Color.Black, 1.2f), rcl);                          // draw ellipse, you could also comment this line, and uncomment the above line as another option for background image
        }
        /// <summary>
        /// Draw the node and it's childs
        /// </summary>
        /// <param name="center">the location of the node on the top of the drawed image.</param>
        /// <returns>the image representing the current node and it's childs</returns>
        public Image DrawNode(Node<T> root, out int center)
        {
            GC.Collect();
            center = 0;
            if (root.IsEmpty())
                return null;
            ValuableNode<T> valNode = (ValuableNode<T>)root;
            GraphicNodeValue val = (GraphicNodeValue)valNode.Value;
            center = val.LastImageLocationOfStarterNode;
            if (!valNode.IsChanged) // if the current node and it's childs are up to date, just return the last drawed image.
                return val.LastImage;

            var lCenter = 0;
            var rCenter = 0;

            Image lNodeImg = null, rNodeImg = null;
            if (!valNode.Left.IsEmpty())       // draw left node's image
                lNodeImg = DrawNode(valNode.Left, out lCenter);
            if (!valNode.Right.IsEmpty())      // draw right node's image
                rNodeImg = DrawNode(valNode.Right, out rCenter);

            // draw current node and it's childs (left node image and right node image)
            var lSize = new Size();
            var rSize = new Size();
            var under = (lNodeImg != null) || (rNodeImg != null);// if true the current node has childs
            if (lNodeImg != null)
                lSize = lNodeImg.Size;
            if (rNodeImg != null)
                rSize = rNodeImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            if (lSize.Width <= 0)
                lSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;
            if (rSize.Width <= 0)
                rSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;

            var resSize = new Size
            {
                Width = lSize.Width + rSize.Width + _freeSpace.Width,
                Height = _nodeBg.Size.Height + (under ? maxHeight + _freeSpace.Height : 0)
            };

            var result = new Bitmap(resSize.Width, resSize.Height);
            var g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));
            g.DrawImage(_nodeBg, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2, 0);
            var str = valNode.Value.GetValue().ToString();
            g.DrawString(str, font, Brushes.Black, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0)) * Coef, _nodeBg.Height / 2f - 12 * Coef);


            center = lSize.Width + _freeSpace.Width / 2;
            var pen = new Pen(Brushes.Black, 1.2f * Coef)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };


            float x1 = center;
            float y1 = _nodeBg.Height;
            float y2 = _nodeBg.Height + _freeSpace.Height;
            float x2 = lCenter;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lNodeImg != null)
            {
                g.DrawImage(lNodeImg, 0, _nodeBg.Size.Height + _freeSpace.Height);
                var points1 = new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + _freeSpace.Width, _nodeBg.Size.Height + _freeSpace.Height);
                x2 = rCenter + lSize.Width + _freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                                 {
                                     new PointF(x1, y1),
                                     new PointF(x1 + w/6, y1 + h/3.5f),
                                     new PointF(x2 - w/6, y2 - h/3.5f),
                                     new PointF(x2, y2)
                                 };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }

            valNode.IsChanged = false; // root has been drawn
            val.LastImage = result;
            val.LastImageLocationOfStarterNode = center;
            return result;
        }
    }
}
