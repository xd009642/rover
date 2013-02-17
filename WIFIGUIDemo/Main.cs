using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ServerLib;
using System.IO;

namespace WIFIGUIDemo
{
    public partial class Main : Form
    {
        #region PRIVATE DATA MEMBERS
        //variable to use inputDialog box
        bool useDialog = true;

        //TCP Client variable from 
        TCPClient theClient;
        #endregion
        Timer myTimer;
        StreamWriter writer;
        bool exp = true;
        int photodiodeValue = 0, LmotorPos=0, LmotorVel=0,
            RmotorPos=0, RmotorVel=0;
        /// <summary>
        /// Main Form Constructor
        /// </summary>
        public Main()
        {
            this.KeyPreview = true;
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 100;
            myTimer.Enabled = true;
            myTimer.Start();
            myTimer.Tick+=new EventHandler(MyTimer_Tick);             
            
        }
       
            

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.InternalCounter, new byte[] { });
                theClient.SendData(CommandID.Magnet);
                theClient.SendData(CommandID.Accn);
                theClient.SendData(CommandID.LineFollowing);
                cmdSwitchLedStatus_Click(null, null);
                Export();
            } 
        }
        /// <summary>
        /// Main Form entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            theClient = new TCPClient();
            writer = new StreamWriter("data.csv");

            if (useDialog)
            {
                //On program entry open dialog box to enter IP Address
             //   inputDialog IPinput = new inputDialog();
             //   IPinput.ShowDialog();


                try
                {
                    //Subscribe to message received event
                    theClient.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceived_Handler);

                    //Connect the Client to the server based on passed data
                    theClient.ConnectToServer("10.215.2.17", 9760);

                    //Set the appropriate form elements
                    txtIPAddress.Text = "10.215.2.17";
                    txtPort.Text = "9760";

                    //Disable appropriate button and enable others
                    cmdConnect.Enabled = false;
                    cmdDisconnect.Enabled = true;
                }
                catch
                {
                    //Show a messagebox to the user saying that the program was unable to connect to the specified rover
                    MessageBox.Show("Unable to connect to Rover Server");

                    //Disable appropriate form elements and enable others
                    cmdConnect.Enabled = true;
                    cmdDisconnect.Enabled = false;
                    txtIPAddress.Enabled = true;
                    txtPort.Enabled = true;
                }
            }
            else
            {
                //Set appropriate form elements
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
                txtIPAddress.Enabled = true;
                txtPort.Enabled = true;
            }
        }

        int chartx = 0, linex=0;
        /// <summary>
        /// Data received handler - when data is pushed from the rover to this program the event handler here
        /// parses the incoming data
        /// </summary>
        /// <param name="e"></param>
        private void DataReceived_Handler(Client_Message_EventArgs e)
        {
            //Take the new data received and convert it into a more manageable format
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                //Switch on the commandID set in the common.cs file
                switch (NewData[3])
                {
                    case (byte)CommandID.NullEcho:
                        break;
                    //If internal counter byte received
                    case (byte)CommandID.InternalCounter:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            txtCounter.Text = (NewData[4] + (NewData[5] << 8)).ToString();
                        }));
                        break;
                    //Command ID byte to show the switch and LED current status
                    case (byte)CommandID.SwitchLEDStatus:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            chkSwitch1Stat.Checked = ((NewData[4] & 0x01) == 0x01) ? true : false;
                            chkSwitch2Stat.Checked = ((NewData[4] & 0x02) == 0x02) ? true : false;
                            chkGreenStat.Checked = ((NewData[4] & 0x10) != 0x10) ? true : false;
                            chkRedStat.Checked = ((NewData[4] & 0x20) != 0x20) ? true : false;
                        }));
                        break;
                    case (byte)CommandID.PhotoDiode:
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            photodiodeValue=(NewData[5] + (NewData[4] << 8)) - 58900;
                            Photodiode.Text = photodiodeValue.ToString();
                            photoChart.Series[0].Points.AddXY(chartx++, photodiodeValue);
                            
                        }));
                        break;
                    
                       
                    case (byte)CommandID.MotorPosStat:
                        this.BeginInvoke(new EventHandler(delegate
                         {
                             LmotorPos=(NewData[5]+(NewData[6]<<8));
                             LmotorVel=NewData[4];
                             RmotorPos=(NewData[8]+(NewData[9]<<8));
                             RmotorVel=NewData[7];
                             Motor1Dist.Text = (NewData[5]+(NewData[6]<<8)).ToString();
                             Motor2Dist.Text = (NewData[8] + (NewData[9] << 8)).ToString();
                             LeftSpeed.Text = NewData[4].ToString();
                             RightSpeed.Text = NewData[7].ToString();
                         }));
                        break;
                    case (byte)CommandID.Magnet:
                        this.BeginInvoke(new EventHandler(delegate
                         {
                             int x = (NewData[4]<< 8) + NewData[5] ;
                             int z = (NewData[6]<< 8) + NewData[7] ;
                             int y = (NewData[8] << 8) + NewData[9];
                             MagnetData.Text = x.ToString() + "," + z.ToString() + "," + y.ToString();
                             double rotate = Math.Atan2(y,x);
                             if(rotate<0)
                                rotate += 2*Math.PI;
                             rotate = rotate * (180 / Math.PI);
                             rotateBox.Text = rotate.ToString();
                         }));
                        break;
                    case (byte)CommandID.Accn:

                        
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int accX = (NewData[4] << 8) | (NewData[5]);
                            accX = accX >> 4; accX -= 2048;
                            int accY = (NewData[6] << 8) | (NewData[7]);
                            accY = accY >> 4; accY -= 2048;
                            int accZ = (NewData[8] << 8) | (NewData[9]);
                            accZ = accZ >> 4; accZ -= 2048;
                            AccnData.Text = accX.ToString() + "," + accY.ToString() + "," + accZ.ToString();
                            writer.WriteLine(AccnData.Text);
                        }));
                        break;
                    case (byte)CommandID.LineFollowing:

                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int leftSensor = (NewData[5] + (NewData[6] << 8));
                            //int leftSensor = (NewData[5] << 8) | (NewData[6]);
                            int rightSensor = (NewData[7] + (NewData[8] << 8));
                            //int rightSensor = (NewData[7] << 8) | (NewData[8]);
                            LFLeft.Text = leftSensor.ToString();
                            LFRight.Text = rightSensor.ToString();
                            lineChart.Series[0].Points.AddXY(linex, leftSensor);
                            lineChart.Series[1].Points.AddXY(linex, rightSensor);
                            linex++;
                        }));
                        break;
                    
                }
            }
        }
       
        #region FORM CONTROL EVENT FUNCTIONS
        /// <summary>
        /// Connection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //assuming the client isn't already connected
            //if the client isn't connected an error will be thrown as no socket will be available
            if (!theClient.isConnected)
            {
                //then connect it using the parameters in the textbox
                theClient.ConnectToServer(txtIPAddress.Text, Convert.ToInt32(txtPort.Text));

                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;
            }
        }


        /// <summary>
        /// Disconnection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            if(theClient.isConnected)
                theClient.Disconnect();

            cmdConnect.Enabled = true;
            cmdDisconnect.Enabled = false;

            txtIPAddress.Enabled = true;
        }

        /// <summary>
        /// Function that is called when the Set LED button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetLEDs_Click(object sender, EventArgs e)
        {
            byte LEDs = 0;

            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                if (chkGreen.Checked) { LEDs |= 0x01; }
                if (chkRed.Checked) { LEDs |= 0x02; }

                theClient.SendData(CommandID.SetLEDs, new byte[] { LEDs });
            }
        }
       
        

       /// <summary>
        /// Function that is called when the Internal counter button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetCount_Click(object sender, EventArgs e)
        {
            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.InternalCounter, new byte[] { });
            }            
        }

        /// <summary>
        /// Function that is called when the LEDSwitch status packet button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSwitchLedStatus_Click(object sender, EventArgs e)
        {
            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.PhotoDiode, new byte[] { });
                theClient.SendData(CommandID.SwitchLEDStatus, new byte[] { });
                theClient.SendData(CommandID.MotorPosStat, new byte[] { });
            }
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            myTimer.Stop();
            timer1.Stop();

            byte motion = 0x00;
            DualMotorCommand(new byte[] { motion, motion });
            if (theClient.isConnected)
                theClient.Disconnect();

            writer.Flush();
            writer.Close();
        }

        private void chkRedStat_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region MOTION
        private void stop()
        {
            byte motion = 0x00;
            DualMotorCommand(new byte[] { motion, motion });
        }
        private void forward()
        {
            byte LMotion = 0x7F;
            byte RMotion = 0x71;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void SForward()
        {
            byte LMotion = 40;
            byte RMotion = 38;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void backward()
        {
            byte RMotion = 0x81;
            byte LMotion = 0x8F;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void SBackward()
        {
            byte LMotion = 0xE2;
            byte RMotion = 0xDA;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void antiClockwise()
        {
            byte LMotion = 0x7F;
            byte RMotion = 0x81;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void clockwise()
        {
            byte LMotion = 0x81;
            byte RMotion = 0x7F;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }


        private void Stop_Click(object sender, EventArgs e)
        {
            stop();
        }
        private void FowardButton_Click(object sender, EventArgs e)
        {
            forward();
        } 
        private void SlowFoward_Click(object sender, EventArgs e)
        {
            SForward();
        }
        private void AntiClockwise_Click(object sender, EventArgs e)
        {
            antiClockwise();
        }
        private void Clockwise_Click(object sender, EventArgs e)
        {
            clockwise();
        }
        private void Backward_Click(object sender, EventArgs e)
        {
            backward();
        }
        private void SlowBackward_Click(object sender, EventArgs e)
        {
            SBackward();
        }


        private void DualMotorCommand(byte[] command)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.MotorSpeed12, command);
            }
            groupBox2.Focus();
        }

        #endregion

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(119)))
                forward();
            else if (e.KeyChar.Equals(Convert.ToChar(115)))
                backward();
            else if (e.KeyChar.Equals(Convert.ToChar(97)))
                antiClockwise();
            else if (e.KeyChar.Equals(Convert.ToChar(100)))
                clockwise();
            else 
                stop();
        }

        private void ExportData_Click(object sender, EventArgs e)
        {
            exp = true;
        }

        private void Export()
        {
  
                //writer.Write(txtCounter.Text + "," + LmotorPos.ToString() + "," + RmotorPos.ToString() + ","                  + LmotorVel.ToString() + "," + RmotorVel.ToString() + "," +                    photodiodeValue.ToString() + "," +  MagnetData.Text+ ","  + AccnData.Text + "\r\n");

                writer.Flush();
        }

        private void clearGraph_Click(object sender, EventArgs e)
        {
            photoChart.Series[0].Points.Clear();
            chartx = 0;
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            stop();
        }
       









        

       

        

       






        

        
    }
}
