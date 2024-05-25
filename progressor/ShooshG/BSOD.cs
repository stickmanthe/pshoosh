using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using PrismAPI.Graphics;
using System.Threading;

namespace pshoosh.ShooshG
{
    internal class BSOD
    {
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.AO.BSOD.bmp")] private readonly static byte[] Bsodb;
        public static Canvas Bsod = Image.FromBitmap(Bsodb);
        public static void Run()
        {
            Shooshg.Visib = false;
            Shooshg.Canvas.Clear(Color.ClassicBlue);
            Shooshg.Canvas.DrawImage(89, 26, Bsod);
            Shooshg.Canvas.DrawString(58, 314, "A problem has been detected on this computer and system has had to shut down.", default, Color.White);
            Shooshg.Canvas.DrawString(58, 330, $"CRITICAL ERROR: {progressor.Kernel.BSODError}", default, Color.White);
            Shooshg.Canvas.DrawString(58, 410, "The computer will restart in the next 5 seconds...", default, Color.White);
            Shooshg.Canvas.Update();
            Thread.Sleep(5000);
            Sys.Power.Reboot();
        }
    }
}
