using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class Speaker : IndividualDevice
    {
        public enum Sound
        {
            None,
            Music,
            Alarm
        }
        public float Volume;
    }
}
