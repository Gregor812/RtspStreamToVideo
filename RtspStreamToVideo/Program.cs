using System;
using System.Threading;
using System.Threading.Tasks;
using RtspClientSharp;
using RtspClientSharp.RawFrames;
using RtspClientSharp.RawFrames.Video;
using RtspStreamToVideo.RawFramesReceiving;

namespace RtspStreamToVideo
{
    class Program
    {
        private static readonly RealtimeVideoSource _realtimeVideoSource = new RealtimeVideoSource();
        private static RawFramesSource _rawFramesSource;

        private static void Main(string[] args)
        {
            var serverUri = new Uri("rtsp://184.72.239.149/vod/mp4:BigBuckBunny_115k.mov");
            var connectionParameters = new ConnectionParameters(serverUri)
            {
                RtpTransport = RtpTransportProtocol.TCP
            };

            Start(connectionParameters);

            Console.ReadLine();

            Stop();
        }

        public static void Start(ConnectionParameters connectionParameters)
        {
            if (_rawFramesSource != null)
                return;

            _rawFramesSource = new RawFramesSource(connectionParameters);
            
            _realtimeVideoSource.SetRawFramesSource(_rawFramesSource);
            _rawFramesSource.Start();
        }

        public static void Stop()
        {
            if (_rawFramesSource == null)
                return;
            
            _rawFramesSource.Stop();
            _realtimeVideoSource.SetRawFramesSource(null);
            _rawFramesSource = null;
        }
    }
}
