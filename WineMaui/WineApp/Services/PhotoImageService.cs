﻿using Microsoft.Maui.Graphics.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineApp.Services
{
    public class PhotoImageService
    {
        private const int ImageMaxSizeBytes = 4194304;
        private const int ImageMaxResolution = 1024;

        public static async Task<byte[]> ResizePhotoStreamAsync(FileResult photo)
        {
            byte[]? result = null;
            if (photo == null)
            {
                return Array.Empty<byte>();
            }
            using (var stream = await photo.OpenReadAsync())
            {
                if (stream.Length > ImageMaxSizeBytes)
                {
                    var image = PlatformImage.FromStream(stream);
                    if (image != null)
                    {
                        var newImage = image.Downsize(ImageMaxResolution, true);
                        result = newImage.AsBytes();
                    }
                }
                else
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        result = binaryReader.ReadBytes((int)stream.Length);
                    }
                }
            }

            return result!;
        }
    }
}
