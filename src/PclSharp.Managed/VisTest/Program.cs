using PclSharp;
using PclSharp.IO;
using PclSharp.Vis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cloud = new PointCloudOfXYZ())
            //using (var cloud = new PointCloudOfXYZRGBA())
            {
                using (var reader = new PCDReader())
                    reader.Read("../../../table_scene_lms400.pcd", cloud);

                using (var visualizer = new Visualizer("a window"))
                {
                    visualizer.AddPointCloud(cloud);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.PointSize, 2);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.Opacity, 0.95);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.Color, 255,0,0);

                    while (!visualizer.WasStopped)
                        visualizer.SpinOnce(100);
                }
            }
        }

        public static string DataPath(string path)
            => Path.Combine("..", "..", "..", "..", "data", path);
    }
}
