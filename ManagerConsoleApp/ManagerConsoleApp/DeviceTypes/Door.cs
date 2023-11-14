using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class Door : IndividualDevice
    {
        public bool Locked, Open, OpenForTooLong, OpenedForcibly;
        public enum State
        {

        }
    }
}
