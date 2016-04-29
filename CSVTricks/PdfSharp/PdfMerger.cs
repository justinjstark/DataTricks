using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfSharp
{
    public class FileToMerge
    {
        public string Name { get; set; }
        public byte[] Contents { get; set; }
    }

    public class PdfMerger
    {
        public byte[] MergePdfs(IEnumerable<FileToMerge> files)
        {
            byte[] mergedPdfContents;

            using (var mergedPdfDocument = new PdfDocument())
            {
                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream(file.Contents))
                    {
                        var inputPdfDocument = PdfReader.Open(memoryStream, PdfDocumentOpenMode.Import);

                        var pageCount = inputPdfDocument.PageCount;
                        for (var pageNumber = 0; pageNumber < pageCount; pageNumber++)
                        {
                            var page = inputPdfDocument.Pages[pageNumber];
                            mergedPdfDocument.AddPage(page);
                        }
                    }
                }

                using (var mergedPdfStream = new MemoryStream())
                {
                    mergedPdfDocument.Save(mergedPdfStream);

                    mergedPdfContents = mergedPdfStream.ToArray();
                }
            }

            return mergedPdfContents;
        }
    }
}
