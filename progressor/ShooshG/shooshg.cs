using System;
using Cosmos.Core.Memory;
using PrismAPI.Hardware.GPU;
using PrismAPI.Graphics;
using PrismAPI.UI;

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
