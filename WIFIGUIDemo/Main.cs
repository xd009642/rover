using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ServerLib;
using System.IO;

namespace WIFIGUIDemo
{
    /**Comments
     * 
     * check boxes to say if a line is being plotted are named using the convention <Sensor>PlotOn i.e LinePlotOn
     * speed has been changed to incorporate slider, should work - no promises
     * graphs still plotted against time not distance, as distance measuring isn't accurate yet
     * 
     * */
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
        bool exp = true, AccDistOn = false;
        int photodiodeValue = 0, LmotorPos = 0,  PRmotorPos = 0, PLmotorPos = 0,
            RmotorPos=0, AccDistGoal = 0;
        short LmotorVel = 0, RmotorVel = 0;
        byte clawGrab = 160;
        byte clawHeight = 70;
        int refPos1 = 0, refPos2 = 0;
        double VelDL = 0, VelDR = 0;
        bool conOn = false;

        /// <summary>
        /// Main Form Constructor
        /// </summary>
        public Main()
        {
            this.KeyPreview = true;
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 500;
            myTimer.Enabled = true;
            myTimer.Start();
            myTimer.Tick+=new EventHandler(MyTimer_Tick);

            //initialise claw to position
            
        }

        float recorded = 0;
        int delay = 1;
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (ManClockOn.Checked)
                myTimer.Interval = Convert.ToInt16(ClockText.Text);
            
            if (theClient.isConnected)
            {
                delay++;
             //   if(delay%10==0)
             //       if (conOn)
                        
                
                theClient.SendData(CommandID.InternalCounter, new byte[] { });
                if (recordOn.Checked)
                {
                    float _dist = (LmotorPos - PLmotorPos + RmotorPos - PRmotorPos) / 2;
                    recorded += (_dist / 8.86f);
                    recDistBox.Text = recorded.ToString();
                }
                else recorded = 0;
                if (ExportOn.Checked)
                    Export();
                if (MagOn.Checked)
                    theClient.SendData(CommandID.Magnet);
                if (LEDOn.Checked)
                    theClient.SendData(CommandID.LED, new byte[] {0xFF});
                else
                    theClient.SendData(CommandID.LED, new byte[] { 0x00 });
               if (AccelOn.Checked)
                    theClient.SendData(CommandID.Accn);
               if (LineFolOn.Checked)
                    theClient.SendData(CommandID.LineFollowing);
               if (PhotoOn.Checked)
                    theClient.SendData(CommandID.PhotoDiode, new byte[] { });
               if(MotorDataOn.Checked)
                    theClient.SendData(CommandID.MotorPosStat, new byte[] { });
               cmdSwitchLedStatus_Click(null, null);
               
              // Control();
               if ((AccDistGoal < RmotorPos) && (AccDistOn))
               {
                    AccDistOn = false;
                    stop();
               }
              // int tickCount = 0;
               if (LineFollowing.Checked)
               {
                   LineFolOn.Checked = true;
                   //  if ((tickCount % 7) == 0)
                   //    {
                   stop();
                   LineFollow();
                   //     }
               }
               else LFdistance = 0;  
             //  tickCount++;
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
                    theClient.SendData(CommandID.Servo1, new byte[] { clawGrab });
                    theClient.SendData(CommandID.Servo2, new byte[] { clawHeight });
                    theClient.SendData(CommandID.SetLEDs, new byte[] { 0x3 });
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

        int chartx = 0, linex=0, riverx=0;
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
                            photodiodeValue=(NewData[5] + (NewData[4] << 8)) - 58000;
                            Photodiode.Text = photodiodeValue.ToString();
                            if (PhotoPlotOn.Checked && photodiodeValue>0)
                            {
                                double scale = (19 / 245) * Math.Pow(LmotorPos - 700, 2)+200;
                                if (MagOn.Checked)
                                    photoChart.Series[0].Points.AddY(photodiodeValue);//-scale);
                                else
                                {
                                    int distance = (int)(LmotorPos / 8.86) - 20;
                                    photoChart.Series[0].Points.AddXY(distance, photodiodeValue);//-scale);
                                }
                            }
                            
                        }));
                        break;
                    
                       
                    case (byte)CommandID.MotorPosStat:
                        this.BeginInvoke(new EventHandler(delegate
                         {
                             try
                             {
                                 PLmotorPos = LmotorPos;
                                 PRmotorPos = RmotorPos;
                                 LmotorPos = (NewData[5]|(NewData[6]<<8));
                                 LmotorVel = NewData[4];
                                 RmotorPos = (NewData[8]|(NewData[9]<<8));
                                 RmotorVel = NewData[7];
                                 if (LmotorVel > 127) { LmotorVel -= 255; }
                                 if (RmotorVel > 127) { RmotorVel -= 255; }
                                 Motor1Dist.Text = (NewData[5]+(NewData[6]<<8)).ToString();
                                 Motor2Dist.Text = (NewData[8] + (NewData[9] << 8)).ToString();
                                 LeftSpeed.Text = LmotorVel.ToString();
                                 RightSpeed.Text = RmotorVel.ToString();
                             }
                            catch (ArgumentOutOfRangeException exception)
                            {
                                Motor1Dist.Text = "packet loss";
                                Motor2Dist.Text = exception.ToString();
                            }
                         }));
                        break;
                    case (byte)CommandID.Magnet:
                        this.BeginInvoke(new EventHandler(delegate
                         {
                             try
                             {
                                 int x = (NewData[4]<< 8) | NewData[5] ;
                                 x = x >> 4; x -= 2048;
                                 int y = (NewData[6]<< 8) | NewData[7] ;
                                 y = y >> 4; y -= 2048;
                                 int z = (NewData[8] << 8) | NewData[9];
                                 z = z >> 4; z -= 2048;
                                 MagnetData.Text = x.ToString() + "," + y.ToString() + "," + z.ToString();
                                 double rotate = Math.Atan2(z,x);
                                 if(rotate<0)
                                    rotate += 2*Math.PI;
                                 rotate = rotate * (180 / Math.PI);
                                 rotateBox.Text = rotate.ToString();
                                 magnetChart.Series[0].Points.Clear();
                                 magnetChart.Series[0].Points.AddY(x);
                                 magnetChart.Series[0].Points.AddY(y);
                                //magnetChart.Series[0].Points.AddY(z);
                                 if (MagnetPlotOn.Checked)
                                 {
                                     VortexChart.Series[0].Points.AddY(x);
                                 }
                             }
                             catch (ArgumentOutOfRangeException exception)
                             {
                                 MagnetData.Text = "packet loss";

                             }
                         }));
                        break;
                    case (byte)CommandID.Accn:

                        
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            try
                            {
                                int accX = (NewData[4] << 8) | (NewData[5]);
                                accX = accX >> 4; accX -= 2048;
                                int accY = (NewData[6] << 8) | (NewData[7]);
                                accY = accY >> 4; accY -= 2048;
                                int accZ = (NewData[8] << 8) | (NewData[9]);
                                accZ = accZ >> 4; accZ -= 2048;
                                AccnData.Text = accX.ToString() + "," + accY.ToString() + "," + accZ.ToString();
                                writer.WriteLine(AccnData.Text);
                                accelChart.Series[0].Points.Clear();
                                accelChart.Series[0].Points.AddY(accX);
                                accelChart.Series[0].Points.AddY(accY);
                                accelChart.Series[0].Points.AddY(accZ);
                                if (on.Checked)
                                {
                                    accelchartDist.Series[0].Points.AddY(accX);
                                    accelchartDist.Series[1].Points.AddY(accY);
                                    accelchartDist.Series[2].Points.AddY(accZ);
                                }
                            }
                            catch (ArgumentOutOfRangeException exception)
                            {
                               AccnData.Text = "packet loss";
                                
                            }
                        }));
                        break;
                    case (byte)CommandID.River:
                        this.BeginInvoke(new EventHandler(delegate
                            {
                                int y=NewData.Count;
                                if(NewData.Count==54)
                                {
                                    for (int i = 0; i < 25; i++)
                                    {
                                        int s1 = NewData[4 + 2 * i] | (NewData[5 + 2 * i] << 8);
                                        RiverChart.Series[0].Points.AddXY(riverx, s1);
                                        riverx++;
                                    }
                                }
                            }));
                        break;
                    case (byte)CommandID.LineFollowing:

                        this.BeginInvoke(new EventHandler(delegate
                        {
                            try
                            {

                                int leftSensor = (NewData[5] + (NewData[6] << 8));
                                //int leftSensor = (NewData[5] << 8) | (NewData[6]);
                                int rightSensor = (NewData[7] + (NewData[8] << 8));
                                //int rightSensor = (NewData[7] << 8) | (NewData[8]);

                                LFLeft.Text = leftSensor.ToString();
                                LFRight.Text = rightSensor.ToString();
                                //okay motor pos is used to plot in terms of distance 
                                //this isn't properly implemented yet so i just used the 
                                //only distance variables we have.
                                if (LinePlotOn.Checked)
                                {
                                    lineChart.Series[0].Points.AddXY(LmotorPos, leftSensor);
                                    lineChart.Series[1].Points.AddXY(LmotorPos, rightSensor);
                                    linex++;
                                }
                            }
                            catch (ArgumentOutOfRangeException exception)
                            {
                                LFLeft.Text = "packet loss";
                                LFRight.Text = exception.ToString();
                            }
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
                theClient.SendData(CommandID.SwitchLEDStatus, new byte[] { });
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
            conOn = false;
            VelDL = 0; VelDR = 0;
            DualMotorCommand(new byte[] { motion, motion });
        }
        private void forward()
        {
            conOn = true;
            int barValue = speedbar.Value;
            byte LMotion = (byte)(int)(/*(0.850f)*/(125.0f * ((float)barValue / 100.0f)));
            byte RMotion = (byte)(int)((127.0f * ((float)barValue / 100.0f)));

            VelDL = (277 * (barValue / 100.0));
            VelDR = (277 * (barValue / 100.0));
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        
        private void backward()
        {
            conOn = true;
            refPos1 = LmotorPos;
            refPos2 = RmotorPos;
            int barValue = speedbar.Value;
            short L = (short)(-128 * (barValue / 100.0));
            short R = (short)(-128 * (barValue / 100.0));
            VelDL = (-277 * (barValue / 100.0));
            VelDR = (-277 * (barValue / 100.0));
            byte RMotion = (byte)L;
            byte LMotion = (byte)R;
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
       
        private void antiClockwise()
        {
            conOn = false;
            int barValue = speedbar.Value;
            if (speedbar.Value < 65)
                barValue = 60;
            byte LMotion = (byte)(127 * (barValue / 100.0));
            short R = (short)(-127 * (barValue / 100.0));
            byte RMotion = (byte)R;
            VelDR = R; VelDL = Convert.ToInt16(LMotion);
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void clockwise()
        {
            conOn = false;
            int barValue = speedbar.Value;
            if (speedbar.Value < 65)
                barValue = 60;
            short L = (short)(-127 * (barValue / 100.0));
            byte LMotion = (byte)L;
            byte RMotion = (byte)(127 * (barValue / 100.0));
            VelDL = L; VelDR = Convert.ToInt16(RMotion);
            DualMotorCommand(new byte[] { LMotion, RMotion });
        }
        private void grab() 
        {
            if (clawGrab < 121)
            {
                clawGrab += 5;
                theClient.SendData(CommandID.Servo1, new byte[] { clawGrab });
            }
        }
        private void release() 
        {
            if (clawGrab >30)
            {
                clawGrab -= 5;
                theClient.SendData(CommandID.Servo1, new byte[] { clawGrab });
            }
        }
        private void raise() 
        {
            if (clawHeight < 120)
            {
                clawHeight += 5;
                theClient.SendData(CommandID.Servo2, new byte[] { clawHeight });
            }
        }
        private void lower() 
        {
            if (clawHeight>5)
            {
                clawHeight -= 5;
                theClient.SendData(CommandID.Servo2, new byte[] { clawHeight });
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            stop();
            LineFollowing.Checked = false;
        }
        private void FowardButton_Click(object sender, EventArgs e)
        {
            forward();
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
        


        private void DualMotorCommand(byte[] command)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.MotorSpeed12, command);
            }
           // Accelerometer.Focus();
        }

        #endregion

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(119)))
            {
                if (chkInvert.Checked)
                {
                    backward();
                }
                else
                {
                    forward();
                }
            }
            else if (e.KeyChar.Equals(Convert.ToChar(115)))
                if (chkInvert.Checked)
                {
                    forward();
                }
                else
                {
                    backward();
                }
            else if (e.KeyChar.Equals(Convert.ToChar(97)))
                antiClockwise();
                
            else if (e.KeyChar.Equals(Convert.ToChar(100)))
                clockwise();
            else
                stop();

            if (e.KeyChar.Equals(Convert.ToChar(105)))
                raise();
            else if (e.KeyChar.Equals(Convert.ToChar(107)))
                lower();
            if (e.KeyChar.Equals(Convert.ToChar(106)))
                release();
            else if (e.KeyChar.Equals(Convert.ToChar(108)))
                grab();
        }

        private void ExportData_Click(object sender, EventArgs e)
        {
            //exp = true;
            for (int i = 0; i < RiverChart.Series[0].Points.Count; i++)
            {
                writer.WriteLine(RiverChart.Series[0].Points[i].XValue.ToString() + "," + RiverChart.Series[0].Points[i].YValues.Max().ToString());
            }
            writer.Flush();
        }

        private void Export()
        {
  
                writer.Write(txtCounter.Text +","  + AccnData.Text + "\r\n");
            /*for (int i = 0; i < RiverChart.Series[0].Points.Count; i++)
            {
                writer.WriteLine(RiverChart.Series[0].Points[i].XValue.ToString() + "," + RiverChart.Series[0].Points[i].YValues.Max().ToString());
            }*/
            writer.Flush();
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            stop();
        }

        #region GRAPHING
        private void clearPhoto_Click(object sender, EventArgs e)
        {
             photoChart.Series[0].Points.Clear();
             chartx = 0;
        }
        
        private void clearLine_Click(object sender, EventArgs e)
        {
            lineChart.Series[0].Points.Clear();
            lineChart.Series[1].Points.Clear();
            linex = 0;
        }
        private void RiverClear_Click(object sender, EventArgs e)
        {
            RiverChart.Series[0].Points.Clear();
            RiverChart.Series[1].Points.Clear();
            riverx = 0;
        }
        private void ClearMagnet_Click(object sender, EventArgs e)
        {
            VortexChart.Series[0].Points.Clear();
        }
        private void RiverClipboard_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                RiverChart.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                
                Bitmap bmp = new Bitmap(ms);
                Bitmap dest = new Bitmap(Convert.ToInt32(riverW.Text), Convert.ToInt32(riverH.Text));
                Graphics g = Graphics.FromImage(dest);
                g.DrawImage(bmp, 0, 0, Convert.ToInt32(riverW.Text), Convert.ToInt32(riverH.Text));
                Clipboard.SetImage(dest);
            }
        }

        #endregion 

        private void speedbar_MouseHover(object sender, EventArgs e)
        {
            ToolTip speedBarTip = new ToolTip();
            speedBarTip.UseFading = true;
            speedBarTip.AutoPopDelay = 1000;
            
            speedBarTip.ShowAlways=true;
            speedBarTip.SetToolTip(speedbar, speedbar.Value.ToString());
        }

        private void AccDistance_Click(object sender, EventArgs e)
        {
            double distTravel = 0;
            double distNeedTravel = 0;
            double MotorConst = 866;
            double MStartValue = 0;
            distNeedTravel = float.Parse(AccDist.Text.ToString());
            distTravel = distNeedTravel * MotorConst;
            MStartValue = RmotorPos;
            forward();
            AccDistOn = true;
            AccDistGoal = (int)((MStartValue + distTravel)+17.320f);
        }
        #region LINE FOLLOWING


        int number = 400;
        int dangling = 550;
        char flag;
        int LFdistance = 0;
        private void LineFollow()
        {
            if (LFdistance == 0)
            {
                PLmotorPos = LmotorPos;
                LFdistance++;
            }
            if (LmotorPos > PLmotorPos)
                LFdistance += LmotorPos - PLmotorPos;
            PLmotorPos = LmotorPos;
            number = Convert.ToInt32(lineTesting.Text); //Testing line, remove when we've chosen a value for number
            if ((Convert.ToInt16(LFRight.Text) < number) & (Convert.ToInt16(LFLeft.Text) < number))
            {
                flag=' ';
                forward();
            }
            else if ((Convert.ToInt16(LFRight.Text) > dangling) || (Convert.ToInt16(LFLeft.Text) > dangling))
            {
                forward();
                flag = ' ';
            }
            else if ((Convert.ToInt16(LFLeft.Text) > number) & (Convert.ToInt16(LFRight.Text) < number))
            {
                flag = 'L';
                forward();
            }
            else if ((Convert.ToInt16(LFRight.Text) > number) & (Convert.ToInt16(LFLeft.Text) < number))
            {
                flag = 'R';
                forward();
            }
            else
            {
                if (flag == 'R')
                {
                    antiClockwise();
                }
                else if (flag == 'L')
                {
                    clockwise();
                }
                else if (flag == ' ' )
                {
                    stop();
                }
                
            }
            
        }

        

        #endregion

       
        private void RiverDataOn_CheckedChanged(object sender, EventArgs e)
        {
            theClient.SendData(CommandID.River, new byte[] { });
        }

        private void Twitch_Click(object sender, EventArgs e)
        {
            byte motion1 = (byte)servoBar1.Value;
            byte motion2 = (byte)servoBar2.Value;
            clawValues.Text = servoBar1.Value.ToString() + ":" + servoBar2.Value.ToString();
            theClient.SendData(CommandID.Servo1, new byte[] { motion1 });
            theClient.SendData(CommandID.Servo2, new byte[] { motion2 });
        }

       private void Control()
        {
            
            if (VelDL!=0 & VelDR!=0)//PLmotorPos!=LmotorPos)
            {
                double Lactual = 0, Ractual = 0;
                Lactual = ((double)(LmotorPos - PLmotorPos) / ((double)myTimer.Interval * 0.001));
                Ractual = ((double)(RmotorPos - PRmotorPos) / ((double)myTimer.Interval * 0.001));
                double leftError = VelDL - Lactual;
                double rightError = VelDR - Ractual;
               
                int newSpeed1 = LmotorVel;
                int newSpeed2 = RmotorVel;
                
                
                if (VelDR > Ractual & newSpeed1<127)
                    newSpeed1++;
                else if (VelDR < Ractual & newSpeed1 > -127)
                    newSpeed1--;

                if (VelDL > Lactual & newSpeed2< 127)
                    newSpeed2++;
                else if (VelDL < Lactual & newSpeed2> -127)
                    newSpeed2--;

                DualMotorCommand(new byte[] { (byte)newSpeed1, (byte)newSpeed2 });

             
            }
        }

        private void ControlData_CheckedChanged(object sender, EventArgs e)
        {
            if (ExportOn.Checked) {
                theClient.SendData(CommandID.Control, new byte[] { });
            }
        }

        private void accelchartDist_Click(object sender, EventArgs e)
        {
            accelchartDist.Series[0].Points.Clear();
            accelchartDist.Series[1].Points.Clear();
            accelchartDist.Series[2].Points.Clear();
        }
        int einstein_A_Go_Go = 0;
        private void einstein_Click(object sender, EventArgs e)
        {
            emcSquared.Text = (++einstein_A_Go_Go).ToString();
        }

       
        private void speedbar_ValueChanged(object sender, EventArgs e)
        {
            speedBox.Text = speedbar.Value.ToString();
        }

        private void setSpeed_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(speedBox.Text) > 20 && Convert.ToInt32(speedBox.Text)<101)
                speedbar.Value = Convert.ToInt32(speedBox.Text);
        }

        private void photoChart_Click(object sender, EventArgs e)
        {
            double xMin=photoChart.Series[0].Points.ElementAt(0).XValue;
            for (int i = 0; i < photoChart.Series[0].Points.Count; i++)
            {
                photoChart.Series[0].Points.ElementAt(i).XValue -= xMin;
            }
            photoChart.Series[1].Points.AddXY(0, 0);
        }

        private void lightClip_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                photoChart.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                Bitmap bmp = new Bitmap(ms);
               // Bitmap dest = new Bitmap(Convert.ToInt32(px.Text), Convert.ToInt32(py.Text));
                Bitmap dest = new Bitmap(640, 480);
                Graphics g = Graphics.FromImage(dest);
               // g.DrawImage(bmp, 0, 0, Convert.ToInt32(px.Text), Convert.ToInt32(py.Text));
                g.DrawImage(bmp, 0, 0, Convert.ToInt32(640), Convert.ToInt32(480));
                Clipboard.SetImage(dest);
            }
        }

    }
       
 }