using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;

namespace MyGameCollection.Model
{
    public class Gallery
    {
        private static readonly Regex ApprovedExenstions;
        private static readonly string PhysicalUploadCoverPath;
        private static readonly Regex SantizePath;

        static Gallery()
        {
            PhysicalUploadCoverPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Covers");
            ApprovedExenstions = new Regex(@"^.*\.(gif|jpg|png)$");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));


        }

        public IEnumerable<FileData> GetImagesNames(int id)
        {

            var di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Pictures\" + id));

            return (from fi in di.GetFiles()
                    select new FileData
                    {
                        Name = "Pictures\\" + id + "/" + fi.Name,
                    }
                        ).AsEnumerable();
        }

        public string SaveImage(Stream stream, string fileName, int id)
        {
            var image = System.Drawing.Image.FromStream(stream);

            if (!IsValidImage(image))
            {
                throw new ArgumentException();
            }

            var counter = 2;
            var end = fileName.Substring(fileName.Length - 4);
            while (ImageExists(fileName, id))
            {
                if (counter > 2)
                {
                    fileName = fileName.Remove(fileName.Length - 7) + "(" + counter + ")" + end;
                }
                else
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "(" + counter + ")" + end;
                }
                counter++;
            }

            image.Save(Path.Combine(Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Pictures\" + id), fileName));

            return fileName;
        }

        static bool ImageExists(string name, int id)
        {
            return File.Exists(Path.Combine(Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Pictures\" + id), name));
        }

        bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
        }

        public void SaveCover(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);

            if (!IsValidImage(image))
            {
                throw new ArgumentException();
            }

            //var counter = 2;
            //var end = fileName.Substring(fileName.Length - 4);
            //while (ImageExists(fileName))
            //{
            //    if (counter > 2)
            //    {
            //        fileName = fileName.Remove(fileName.Length - 7) + "(" + counter + ")" + end;
            //    }
            //    else
            //    {
            //        fileName = Path.GetFileNameWithoutExtension(fileName) + "(" + counter + ")" + end;
            //    }
            //    counter++;
            //}

            image.Save(Path.Combine(PhysicalUploadCoverPath, fileName));
        }
    }
}