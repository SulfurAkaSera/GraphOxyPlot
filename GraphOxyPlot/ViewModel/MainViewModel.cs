using GraphOxyPlot.Models;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphOxyPlot.ViewModel
{
    public class MainViewModel
    {
        public PlotModel Model { get; set; }
        private double _x;
        private double _y;
        private List<Point> _points = new List<Point>();

        public MainViewModel()
        {
            Model = new PlotModel { Title = "F(x) = e^-x"};
            Init();
        }

        void Init()
        {
            var line = new OxyPlot.Series.LineSeries
            {
                Title = $"Series 1",
                Color = OxyColors.DarkRed,
                StrokeThickness = 1,
            };
            Function();
            foreach(var point in _points)
            {
                line.Points.Add(new DataPoint(point.X, point.Y));
            }
            Model.Series.Add(line);
        }

        void Function()
        {
            for (int i = 0; i < 10; i++)
            {
                _x += 0.1;
                _y = Math.Pow(_x, 3);
                _points.Add(new Point { X = _x, Y = _y });
            }
        }
    }
}
