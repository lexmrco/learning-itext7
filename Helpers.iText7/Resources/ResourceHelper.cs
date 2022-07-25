using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helpers.iText7.Resources
{
    public class ResourceHelper
    {
        public static PdfReader GetTemplate(PdfTemplate template)
        {
            try
            {
                return new PdfReader(new MemoryStream(DocsResource.ResourceManager.GetObject(template.ToString()) as byte[]));
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public static string GetText(string textName)
        {
            try
            {
                return TextsResource.ResourceManager.GetString(textName);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static Image FindImage(string imageName, int? index = null)
        {
            Image result = null;
            if (index.HasValue)
                imageName += index.ToString();
           
            if (!(ImagesResource.ResourceManager.GetObject(imageName) is System.Drawing.Bitmap bitmap))
                throw new Exception("Unavailable image");
            bitmap.MakeTransparent(System.Drawing.Color.Aqua);

            ImageData imageData = ImageDataFactory.Create(ConvertToImage(bitmap), false);
            result = new Image(imageData);
            return result;
        }

        public static byte[] ConvertToImage(System.Drawing.Bitmap bitmap)
        {
            byte[] result;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();
                bitmap.Dispose();
                result = stream.ToArray();
            }
            return result;
        }
    }
}
