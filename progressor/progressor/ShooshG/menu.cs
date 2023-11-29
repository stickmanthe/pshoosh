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
using System.Threading;

namespace pshoosh.ShooshG
{
    internal class Menu
    {
        public static bool menubopen = false;
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.StartMenu.shutdown.bmp")] private readonly static byte[] Shutdownb;
        public static Canvas ShutdownButton = Image.FromBitmap(Shutdownb);
        public static void Run()
        {
            Shooshg.Canvas.DrawFilledRectangle(590, 585, 210, 15, 0, Color.LightGray);
            if (MouseManager.MouseState == MouseState.Left && MouseManager.X >= 590 && MouseManager.Y >= 585 && MouseManager.X <= 590 + 210 && MouseManager.Y <= 585 + 15)
            {
                menubopen = true;
            }
            if (menubopen == true)
            {
                Shooshg.Canvas.DrawFilledRectangle(590, 237, 210, 348, 0, Color.Black);
                Shooshg.Canvas.DrawImage(612, 532, ShutdownButton);
                Shooshg.Canvas.DrawFilledRectangle(781, 237, 19, 19, 0, Color.Red);
                if (MouseManager.MouseState == MouseState.Left && MouseManager.X >= 781 && MouseManager.Y >= 237 && MouseManager.X <= 781 + 19 && MouseManager.Y <= 237 + 19)
                {
                    menubopen = false;
                }
                if (MouseManager.MouseState == MouseState.Left && MouseManager.X >= 612 && MouseManager.Y >= 532 && MouseManager.X <= 612 + 81 && MouseManager.Y <= 532 + 27)
                {
                    shutdownselect.operatin = true;
                    while (shutdownselect.operatin == true)
                    {
                        shutdownselect.Run();
                    }
                }
            }
        }
    }
}
