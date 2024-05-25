using Cosmos.System;
using PrismAPI.Graphics;
using IL2CPU.API.Attribs;


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
