using System.Drawing;

namespace Web.Adapter.Services
{
    public class ImageProcess : IImageProcess
    {
        public void AddWaterMark(Stream stream, string text, string fileName)
        {

            using var img = Image.FromStream(stream);
            using var graphic = Graphics.FromImage(img);

            var font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);

            var textSize=graphic.MeasureString(text, font);

            var color = Color.FromArgb(128, 255, 255, 255);

            var brush = new SolidBrush(color);

            var position = new Point(img.Width - ((int)textSize.Width + 30), img.Height - ((int)textSize.Height + 30));

            graphic.DrawString(text,font,brush,position);

            img.Save("wwwroot/watermarks/" + fileName);

            img.Dispose();
            graphic.Dispose();

             
        }
    }
}
