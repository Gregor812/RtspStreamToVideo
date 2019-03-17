using System;
using RtspStreamToVideo.RawFramesDecoding.DecodedFrames;

namespace RtspStreamToVideo
{
    public interface IVideoSource
    {
        event EventHandler<IDecodedVideoFrame> FrameReceived;

        void SetVideoSize(int width, int height);
    }
}
