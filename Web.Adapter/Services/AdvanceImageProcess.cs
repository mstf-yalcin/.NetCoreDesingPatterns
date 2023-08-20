using LazZiya.ImageResize;
using System.Drawing;

namespace Web.Adapter.Services
{
    public class AdvanceImageProcess : IAdvanceImageProcess
    {
        public void AddWaterMark(string text, string fileName, Stream imgStream, Color color, Color outlineColor)
        {
            using (var img = Image.FromStream(imgStream)) 
            {
                var tOps = new TextWatermarkOptions
                {
                    // Change text color and opacity
                    // Text opacity range depends on Color's alpha channel (0 - 255)
                    TextColor = color,

                    // Add text outline
                    // Outline color opacity range depends on Color's alpha channel (0 - 255)
                    OutlineColor = outlineColor
                };

                img.AddTextWatermark(text, tOps)
                   .SaveAs(fileName);
            }
        }
    }
}
