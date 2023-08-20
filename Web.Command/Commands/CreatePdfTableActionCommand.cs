using Microsoft.AspNetCore.Mvc;

namespace Web.Command.Commands
{
    public class CreatePdfTableActionCommand<T> : ITableActionCommand
    {
        public readonly PdfFile<T> _pdfFile; //ToDo: Strategy...

        public CreatePdfTableActionCommand(PdfFile<T> pdfFile)
        {
            _pdfFile = pdfFile;
        }

        public IActionResult Execute()
        {
            var pdfMemoryStream = _pdfFile.Create();
            return new FileContentResult(pdfMemoryStream.ToArray(), _pdfFile.FileType)
            {
                FileDownloadName = _pdfFile.FileName,
            };
        }
    }
}
