namespace Web.Adapter.Services
{
    public interface IImageProcess
    {
        void AddWaterMark(Stream stream, string text, string fileName);
    }
}
