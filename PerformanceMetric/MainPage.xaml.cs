using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PerformanceMetric
{
    public partial class MainPage : ContentPage
    {
        const int ListenPort = 8000;
        UdpClient udpClient;
        public MainPage()
        {
            InitializeComponent();
            StartListening();
        }
        private void StartListening()
        {
            Task.Run(async () =>
            {
                try
                {
                    udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, ListenPort));
                    Console.WriteLine("UDP server listening on port 8000");
                    while (true)
                    {
                        var receiveTask = udpClient.ReceiveAsync();
                            UdpReceiveResult result = receiveTask.Result;
                            ParseOscBundle(result.Buffer);
                    }
                }
                catch (SocketException sockEx)
                {
                    Console.WriteLine(sockEx);
                }
            });
        }
        void ParseOscBundle(byte[] data)
        {
            int index = 0;

            //read a 4-byte integer from  the byte array (big-endian format)
            int ReadInt()
            {
                byte[] intBytes = new byte[4];
                Array.Copy(data, index, intBytes, 0, 4);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                index += 4;
                return BitConverter.ToInt32(intBytes, 0);
            }

            string ReadString()
            {
                int startIndex = index;
                while (data[index] != 0) index++;

                int finalIndex = index - startIndex;
                string convertedString = Encoding.ASCII.GetString(data, startIndex, finalIndex);
                index++;

                while (index % 4 != 0)
                    index++;
                return convertedString;
            }

            float ReadFloat()
            {
                byte[] floatBytes = new byte[4];
                Array.Copy(data, index, floatBytes, 0, 4);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(floatBytes);
                index += 4;
                return BitConverter.ToSingle(floatBytes, 0);
            }

            //start parsing the bundle
            string bundleTag = ReadString(); //should return "#bundle"
            index += 8; //skipping the 8-byte time tag


            //loop over all the messages in the bundle
            while (index < data.Length)
            {
                int messageSize = ReadInt(); // read the size of this message in bytes
                int messageStart = index;

                string address = ReadString();//the size of the message in bytes
                string typeTag = ReadString(); //",f" = float value

                if (typeTag == ",f")
                {
                    float value = ReadFloat(); // read the float value

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        switch (address)
                        {
                            case "/met/attention":
                                AttentionLabel.Text = $"Attention: {value:F2}"; break;
                            case "/met/engagement":
                                EngagementLabel.Text = $"Engagement: {value:F2}"; break;
                            case "/met/excitement":
                                ExcitementLabel.Text = $"Excitement: {value:F2}"; break;
                            case "/met/interest":
                                InterestLabel.Text = $"Interest: {value:F2}"; break;
                            case "/met/relaxation":
                                RelaxationLabel.Text = $"Relaxation: {value:F2}"; break;
                            case "/met/stress":
                                StressLabel.Text = $"Stress: {value:F2}"; break;
                        }
                    }
                        );

                }
                index = messageStart + messageSize;
            }
        }
    }
}
