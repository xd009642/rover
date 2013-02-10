using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace ServerLib
{
    public class TCPClient : ClientBase
    {
        //Net.Sockets client class
        TcpClient theClient;
        //Thread that runs the asynchronous client communications
        Thread commThread;

        public override int Port
        {
            get
            {
                return base.Port;
            }
            protected set
            {
                base.Port = value;
            }
        }

        /// <summary>
        /// Public constructor (not really needed)
        /// </summary>
        public TCPClient()
        {
        }

        /// <summary>
        /// Connection function
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="port"></param>
        public override void ConnectToServer(string serverIP, int port)
        {
            //Instantiates the TCP client variable
            theClient = new TcpClient();
            //Connects the client to the specified IP address and Port
            theClient.Connect(serverIP, port);
            //Sets the isConnected variable to true (used for checking status of client connection)
            isConnected = true;
            
            //Instantiate communication thread
            commThread = new Thread(HandleClientComm);
            //Start thread
            commThread.Start();
        }


        /// <summary>
        /// Send data to the comm device
        /// </summary>
        /// <param name="address">The address of the device eg. 000001</param>
        /// <param name="command">The command id of the message</param>
        /// <param name="data">The message payload</param>
        /// <returns>The result of the transmission</returns>
        public override Boolean SendData(CommandID command, Array data)
        {
            //Attempt to send data to the sepecified server
            try
            {
                //Create a new and local network stream for communication
                NetworkStream serverStream = theClient.GetStream();

                //make a new array based on the amount of data to be sent + necessary command bytes
                byte[] message = new byte[data.Length + 3];

                //Set value of necessary bytes
                //0xff packet header
                message.SetValue((byte)255, 0);
                //Number of remaining bytes in packet
                message.SetValue((byte)(data.Length + 1), 1);
                //command byte
                message.SetValue((byte)command, 2);

                //Copy all data into message array previously defined
                for (int idx = 0; idx < data.Length; idx++)
                {
                    message.SetValue(data.GetValue(idx), idx + 3);
                }

                //Write array to server stream
                serverStream.Write(message, 0, message.Length);
                serverStream.Flush();

                //return A-OK
                return true;
            }
            catch
            {
                //If there were any errors return false
                return false;
            }
        }

        /// <summary>
        /// Send data to the comm device
        /// </summary>
        /// <param name="address">The address of the device eg. 000001</param>
        /// <param name="command">The command id of the message</param>
        /// <returns>The result of the transmission</returns>
        public override Boolean SendData(CommandID Command)
        {
            //Send blank array with defined command byte
            return SendData(Command, new byte[] { });
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleClientComm()
        {
            //Create a new and local network stream for communication
            NetworkStream serverStream = theClient.GetStream();

            //Create large array to acommodate any data received from the server
            byte[] message = new byte[10025];
            //Local variable to identify how many bytes were read from the server
            int bytesRead;

            //Infinite loop, should not impact the running on the program as it is running in a separate thread
            while (true)
            {
                //Reset number of bytes read from server stream
                bytesRead = 0;

                //Attempt to read data from the server
                try
                {
                    //blocks until a client sends a message
                    bytesRead = serverStream.Read(message, 0, (int)theClient.ReceiveBufferSize);

                    byte[] rcv = new byte[bytesRead];

                    //Copy received data into apropriately sized buffer
                    for (int cnt = 0; cnt < bytesRead; cnt++)
                    {
                        rcv[cnt] = message[cnt];
                    }

                    //Fire off message received event
                    _ClientMessageReceivedEvent(rcv);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
            }

            //If this loop ends for any reason close the client
            theClient.Close();
        }

        /// <summary>
        /// Disconnection routine
        /// </summary>
        public override void Disconnect()
        {
            //Set isConnected to false and close the client connection
            isConnected = false;
            commThread.Abort();
            theClient.Close();
        }
    
    }
}
