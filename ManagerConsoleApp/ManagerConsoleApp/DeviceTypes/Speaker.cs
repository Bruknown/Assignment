using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class Speaker : IndividualDevice
    {
        public soundStates Sound;
        public float Volume;

        public Speaker(Enum type, int deviceID, string name, soundStates soundState, float volume)
        {
            Type = type;
            DeviceID = deviceID;
            Name = name;
            Sound = soundState;
            Volume = volume;
        }

        public enum soundStates
        {
            None,
            Music,
            Alarm
        }

    }
}
