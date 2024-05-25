using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using Cosmos.Core.Memory;
using Cosmos.System;
using PrismAPI.Graphics;

namespace pshoosh.ShooshG
{
    internal class shutdownselect
    {
        public static bool operatin = false;
        public static string TextSelect = "Select the operation.";
        [ManifestResourceStream(ResourceName = "pshoosh.ShooshG.Img.StartMenu.operation.bmp")] private readonly static byte[] Operatiob;
        public static Canvas OperationSelect = Image.FromBitmap(Operatiob);

        public static void Run()
        {
            Shooshg.Visib = false;
            Shooshg.Canvas.Clear(Color.Black);
            Shooshg.Canvas.DrawImage(185, 195, OperationSelect);
            Shooshg.Canvas.DrawString(5, 5, $"{TextSelect}", default, Color.White);
            Cursor.Run();
            Shooshg.Canvas.Update();
            Heap.Collect();
            if (MouseManager.X >= 185 && MouseManager.Y >= 195 && MouseManager.X <= 185 + 100 && MouseManager.Y <= 195 + 100)
            {
                Cursor.CurSprite = "Link";
                TextSelect = "Shutdown PC";
                if (MouseManager.MouseState == MouseState.Left)
                {
                    Sys.Power.Shutdown();
                }
            }
            else if (MouseManager.X >= 294 && MouseManager.Y >= 195 && MouseManager.X <= 294 + 100 && MouseManager.Y <= 195 + 100)
            {
                Cursor.CurSprite = "Link";
                TextSelect = "(TODO) Restart PC and boot in ShooshG";
                if (MouseManager.MouseState == MouseState.Left)
                {
                    Sys.Power.Reboot();
                }
            }
            else if (MouseManager.X >= 404 && MouseManager.Y >= 195 && MouseManager.X <= 404 + 100 && MouseManager.Y <= 195 + 100)
            {
                Cursor.CurSprite = "Link";
                TextSelect = "Cancel";
                if (MouseManager.MouseState == MouseState.Left)
                {
                    operatin = false;
                    Shooshg.Visib = true;
                    Cursor.CurSprite = "Normal";
                }
            }
            else if (MouseManager.X >= 514 && MouseManager.Y >= 195 && MouseManager.X <= 514 + 100 && MouseManager.Y <= 195 + 100)
            {
                Cursor.CurSprite = "Link";
                TextSelect = "Restart PC and boot in Progressor Shoosh Kernel";
                if (MouseManager.MouseState == MouseState.Left)
                {
                    Sys.Power.Reboot();
                }
            }
            else
            {
                Cursor.CurSprite = "Normal";
                TextSelect = "";
            }
        }
    }
}
    
