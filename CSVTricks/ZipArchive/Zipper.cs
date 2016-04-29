using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ZipArchive
{
    public class FileToZip
    {
        public string Directory { get; set; }
        public string Name { get; set; }
        public byte[] Contents { get; set; }
    }

    public class Zipper
    {
        public byte[] ZipFiles(IEnumerable<FileToZip> files)
        {
            MemoryStream memoryStream;

            using (memoryStream = new MemoryStream())
            using (var zipArchive = new System.IO.Compression.ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in files)
                {
                    var newFile = zipArchive.CreateEntry(Path.Combine(file.Directory ?? "", file.Name));

                    using (var newFileStream = newFile.Open())
                    using (var binaryWriter = new BinaryWriter(newFileStream))
                    {
                        binaryWriter.Write(file.Contents);
                    }
                }
            }

            return memoryStream.ToArray();
        }
    }
}
