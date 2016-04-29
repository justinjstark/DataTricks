using System.Collections.Generic;
using System.Text;

namespace ZipArchive
{
    public class Examples
    {
        public void ZipFiles1()
        {
            var file1 = new FileToZip { Name = "test1.txt", Contents = Encoding.UTF8.GetBytes("This is test1.") };
            var file2 = new FileToZip { Name = "test2.txt", Contents = Encoding.UTF8.GetBytes("This is test2.") };

            var zippedFileContents = new Zipper().ZipFiles(new List<FileToZip> { file1, file2 });
        }

        public void ZipFiles2()
        {
            var file1 = new FileToZip { Directory = "test", Name = "test1.txt", Contents = Encoding.UTF8.GetBytes("This is test1.") };
            var file2 = new FileToZip { Name = "test2.txt", Contents = Encoding.UTF8.GetBytes("This is test2.") };

            var zippedFileContents = new Zipper().ZipFiles(new List<FileToZip> { file1, file2 });
        }
    }
}
