using System.Drawing;

namespace Web.Adapter.Services
{
    public class AdvanceImageProcessAdapter : IImageProcess
    {
        private readonly IAdvanceImageProcess _process;

        public AdvanceImageProcessAdapter(IAdvanceImageProcess process)
        {
            _process = process;
        }

        public void AddWaterMark(Stream stream, string text, string fileName)
        {
            _process.AddWaterMark(text,fileName,stream,Color.FromArgb(128,255,255,255),Color.FromArgb(0,255,255,255));
        }
    }
}
