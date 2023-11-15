using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class LedPanel : IndividualDevice
    {
        public String Message;

        public LedPanel(Enum type, int deviceID, string name, string message)
        {
            Type = type;
            DeviceID = deviceID;
            Name = name;
            Message = message;
        }
    }
}
