using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp
{
    internal class DeviceGroup
    {
        public List<IndividualDevice> IndividualDevices;
        public String DeviceGroupName;
        public short DeviceGroupID;


        private void testing()
        {
            IndividualDevices.Add(new DeviceTypes.LedPanel());
        }
    }
}
