using System.Drawing;

namespace Web.Adapter.Services
{
    public interface IAdvanceImageProcess
    {
        void AddWaterMark(string text, string fileName, Stream imgStream, Color color, Color outlineColor);
    }
}
