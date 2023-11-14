using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp
{
    internal class IndividualDevice
    {
        public string Type;
        public int DeviceID;
        public string Name;

        public virtual String GetCurrentState()
        {
            return "";
        }
    }
}
