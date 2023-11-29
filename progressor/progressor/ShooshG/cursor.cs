using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using Cosmos.Core.Memory;
using Cosmos.System;
using PrismAPI.Hardware.GPU;
using PrismAPI.Graphics;
using PrismAPI.UI;
using PrismAPI.UI.Controls;
using System.Dynamic;
using System.Runtime.InteropServices;
using IL2CPU.API.Attribs;
using Cosmos.HAL.BlockDevice.Registers;

namespace pshoosh.ShooshG
{
    internal class Cursor
    {

        public static string CurSprite = "Normal";
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.Cursor.Normal.bmp")] private readonly static byte[] CurNormalb;
        public static Canvas Curs = Image.FromBitmap(CurNormalb);
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.Cursor.Working.bmp")] private readonly static byte[] CurWaitb;
        public static Canvas CursWait = Image.FromBitmap(CurWaitb);
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.Cursor.Link.bmp")] private readonly static byte[] CurLinkb;
        public static Canvas CursLink = Image.FromBitmap(CurLinkb);

        public static void Run()
        {
            MouseManager.ScreenWidth = 800;
            MouseManager.ScreenHeight = 600;
            if (CurSprite == "Normal")
            {
                Shooshg.Canvas.DrawImage((int)MouseManager.X, (int)MouseManager.Y, Curs);
            }
            if (CurSprite == "Waiting")
            {
                Shooshg.Canvas.DrawImage((int)MouseManager.X, (int)MouseManager.Y, CursWait);
            }
            if (CurSprite == "Link")
            {
                Shooshg.Canvas.DrawImage((int)MouseManager.X, (int)MouseManager.Y, CursLink);
            }
        }
    }
}
