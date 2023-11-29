using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.Core.Memory;
using Cosmos.System;
using PrismAPI.Hardware.GPU;
using PrismAPI.Graphics;
using PrismAPI.UI;
using PrismAPI.UI.Controls;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace pshoosh.ShooshG
{
    internal class Shooshg
    {
        public static Display Canvas = null!;
        public static bool Visib = false;
        public static void BeforeRun()
        {
            Visib = true;
            Canvas = Display.GetDisplay(800, 600);
            Canvas.Clear(Color.DeepGray);
        }
        public static void Run()
        {
            Canvas.Clear(Color.DeepGray);
            WindowManager.Update(Canvas);
            Canvas.DrawFilledRectangle(0, 585, 800, 15, 0, Color.Black);
            Canvas.DrawString(8, 583, $"{DateTime.Now.ToString("HH:mm:ss")} - {DateTime.Now.ToString("dd.MM.yyyy")} - {Canvas.GetFPS()} FPS", default, Color.White);
            Menu.Run();
            Cursor.Run();
            Canvas.Update();
            Heap.Collect();
        }
    }
}
