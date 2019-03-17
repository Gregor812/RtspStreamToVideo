using System;
using RtspClientSharp.RawFrames;

namespace RtspStreamToVideo.RawFramesReceiving
{
    interface IRawFramesSource
    {
        EventHandler<RawFrame> FrameReceived { get; set; }
        EventHandler<string> ConnectionStatusChanged { get; set; }
    }
}
