using System;
using System.Threading;
using System.Threading.Tasks;
using RtspClientSharp;
using RtspClientSharp.RawFrames;
using RtspClientSharp.RawFrames.Video;

namespace RtspStreamToVideo
{
    class Program
    {
        private static DateTime _startDateTime;
        static async Task Main(string[] args)
        {
            var serverUri = new Uri("rtsp://184.72.239.149/vod/mp4:BigBuckBunny_115k.mov");
            var connectionParameters = new ConnectionParameters(serverUri)
            {
                RtpTransport = RtpTransportProtocol.TCP
            };

            var cts = new CancellationTokenSource();

            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += FrameReceived;
                await rtspClient.ConnectAsync(cts.Token);
                _startDateTime = DateTime.Now;
                await rtspClient.ReceiveAsync(cts.Token);
            }
        }

        private static void FrameReceived(object sender, RawFrame rawFrame)
        {
            switch (rawFrame)
            {
                case RawH264IFrame h264IFrame:
                    Console.WriteLine($"{(DateTime.Now - _startDateTime):g}: H.264 I frame received");
                    break;
                case RawH264PFrame h264PFrame:
                    Console.WriteLine($"{(DateTime.Now - _startDateTime):g}: H.264 P frame received");
                    break;
            }
        }
    }
}
