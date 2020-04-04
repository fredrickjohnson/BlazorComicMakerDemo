using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ComicMaker.Blazor.Client.Models
{
    public class Graphic
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Xs { get; set; } = "10px";
        public string Ys { get; set; } = "10px";

        public string CSS { get; set; } = "width: 50px; height: 100px; position: relative; top: 10px; left: 10px;";

        

        public int Width { get; set; } = 100;
        public int Height { get; set; } = 100;

        public void Update()
        {
            Xs = X + "px";
            Ys = Y + "px";
        }
    }
}
