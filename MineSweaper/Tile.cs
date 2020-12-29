using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MineSweaper
{
    class Tile : Canvas
    {
        int SIZE = 20;
        int BORD = 2;

        public Tile(int n)
        {
            Polygon poly = new Polygon();

            poly.Points = new PointCollection(new Point[]
            {
                new Point(0,0), new Point(SIZE, 0), new Point(SIZE-BORD, BORD),
                new Point(BORD, BORD), new Point(BORD, SIZE-BORD), new Point(0,SIZE)
            });
            poly.Fill = SystemColors.ControlLightLightBrush;
            Children.Add(poly);

            poly = new Polygon();
            poly.Points = new PointCollection(new Point[]
            {
                new Point(SIZE,0), new Point(SIZE,SIZE), new Point(0,SIZE),
                new Point(BORD, SIZE-BORD), new Point(SIZE-BORD, SIZE-BORD), new Point(SIZE-BORD, BORD)
            });
            poly.Fill = SystemColors.ControlDarkBrush;
            Children.Add(poly);

            TextBlock re = new TextBlock();
            re.Width = SIZE - 2 * BORD;
            re.Height = SIZE - 2 * BORD;
            if(n==100)
            {
                re.Background = SystemColors.ControlLightBrush;
            }

            else if(n==-1)
            {
                re.Background = Brushes.Coral;
                re.TextAlignment = TextAlignment.Center;
                re.Text = n.ToString();
                re.FontSize = 14;
                re.FontWeight = FontWeights.Bold;
            }

            Children.Add(re);
            Canvas.SetLeft(re, BORD);
            Canvas.SetTop(re, BORD);
        }
    }
}
