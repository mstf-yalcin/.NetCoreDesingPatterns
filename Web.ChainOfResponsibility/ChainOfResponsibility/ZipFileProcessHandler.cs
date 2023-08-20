using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace Web.ChainOfResponsibility.ChainOfResponsibility
{
    public class ZipFileProcessHandler<T>: ProcessHandler
    {

        public override object Handle(object o)
        {
            var excelMemoryStream = o as MemoryStream;

            excelMemoryStream.Position = 0;


            using (var zipMemoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Create,true))
                {
                        var zipFile = archive.CreateEntry($"{typeof(T).Name}.xlsx");

                        using (var zipEntryStream = zipFile.Open())
                        {
                            excelMemoryStream.CopyTo(zipEntryStream);
                        }
                }

                return base.Handle(zipMemoryStream);
            }
        }
    }
}
