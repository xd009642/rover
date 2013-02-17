using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerLib
{
    /// <summary>
    /// Public enumerable containing information about packet headers
    /// </summary>
    public enum CommandID : int
    {
        NullEcho = 0x00,
        SwitchLEDStatus = 0x01,
        SetLEDs = 0x02,
        InternalCounter = 0x03,
        MotorPosStat = 0x04,
        MotorSpeed2= 0x05,
        MotorSpeed1 = 0x06,
        MotorSpeed12 = 0x07,
        LineFollowing = 0x08,
        PhotoDiode = 17,
        Accn = 40,              //Accelerometer
        Magnet = 45             //Magnetometer
    };
}
