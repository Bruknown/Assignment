using ManagerConsoleApp.DeviceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp
{
    internal class Root
    {
        public List<DeviceGroup> DeviceGroupList;


        public Root(List<DeviceGroup> deviceGroupList)
        {
            DeviceGroupList = deviceGroupList;
        }
        public Root()
        {
            DeviceGroupList = new List<DeviceGroup>();
            addGroup();
        }
        public void addGroup()
        {
            List<IndividualDevice> groupDevices = new List<IndividualDevice>();
            IndividualDevice[] devicesToAdd = {
                new LedPanel(DeviceGroup.DeviceTypes.LedPanel, 1, "Led Panel", "PlaceHolder"),
                new Door(DeviceGroup.DeviceTypes.Door, 2, "Door"),
                new Speaker(DeviceGroup.DeviceTypes.Speaker, 3, "Speaker", Speaker.soundStates.Music, 0.5f),
                new CardReader(DeviceGroup.DeviceTypes.CardReader, 4, "Card Reader", "746573740d0a")
            };

            groupDevices.AddRange(devicesToAdd);
            DeviceGroupList.Add(new DeviceGroup(groupDevices, "Starter", 1));
        }
        public void removeGroup(int groupID)
        {
            foreach (DeviceGroup group in DeviceGroupList)
            {
                if (group.DeviceGroupID == groupID)
                {
                    DeviceGroupList.Remove(group);
                }
            }
        }
    }
}
