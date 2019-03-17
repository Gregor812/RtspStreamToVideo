using System;

namespace RtspStreamToVideo.RawFramesDecoding
{
    static class ImageUtils
    {
        public static int GetBitsPerPixel(this PixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case PixelFormat.Grayscale:
                    return 8;
                case PixelFormat.Bgr24:
                    return 24;
                case PixelFormat.Abgr32:
                    return 32;
            }

            throw new ArgumentOutOfRangeException(nameof(pixelFormat));
        }
        
        public static int GetStride(int width, PixelFormat pixelFormat)
        {
            int bitsPerPixel = pixelFormat.GetBitsPerPixel();
            return ((width * bitsPerPixel + 31) & ~31) >> 3;
        }
    }
}
