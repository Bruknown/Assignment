using ManagerConsoleApp.DeviceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ManagerConsoleApp
{
    internal class Root
    {
        public static List<DeviceGroup> DeviceGroupList;
        public static int currentDeviceIdIndex = 0;
        public static short currentDeviceGroupIdIndex = 0;
        public List<string> changeHistory;

        public Root(List<DeviceGroup> deviceGroupList)
        {
            DeviceGroupList = deviceGroupList;
        }
        public Root()
        {
            DeviceGroupList = new List<DeviceGroup>();
            changeHistory = new List<string>();
            addGroup();
        }
        public void changeDeviceGroupForDevice(int deviceGroupOrigin, int deviceGroupDestination, IndividualDevice deviceToMove)
        {
            foreach (DeviceGroup deviceGroup in DeviceGroupList)
            {
                if (deviceGroup.DeviceGroupID == deviceGroupOrigin)
                {
                    deviceGroup.removeDevice(deviceToMove.DeviceID);
                    deviceGroup.modificationHistory.Add("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to Device group of ID: " + deviceGroupDestination);
                    Console.WriteLine("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to Device group of ID: " + deviceGroupDestination);
                }
                if (deviceGroup.DeviceGroupID == deviceGroupDestination)
                {
                    deviceGroup.IndividualDevices.Add(deviceToMove);
                    deviceGroup.modificationHistory.Add("Transferred Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to current Device Group of: " + deviceGroup.DeviceGroupName);
                    Console.WriteLine("Transferred Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to current Device Group of: " + deviceGroup.DeviceGroupName);
                }
            }
        }

        public void initialInsert()
        {
            Random rand = new Random();
            string[] hexadecimalArray =
            {
                "7468 69 73",
                "697 3",
                "6B6 96 E64206 F6 6",
                "63 6F 6F 6C",
                "not a hexadecimal",
                "definitivamente não é um hexadecimal",
                "6",
                "Jsem Bruno"
            };
            List<IndividualDevice> deviceListToAdd = new List<IndividualDevice>();
            List<string> changeList = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                int repetitionChance = rand.Next(2, 5);
                for (int j = 0; j < repetitionChance; i++)
                {
                    if (rand.Next(1, 10) > 3)
                    {
                        deviceListToAdd.Add(new Speaker(DeviceGroup.DeviceTypes.Speaker, currentDeviceIdIndex + 1, "Music Speaker", Speaker.soundStates.Music, 0.5f));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());   
                    }
                    if (rand.Next(1, 10) > 5)
                    {
                        deviceListToAdd.Add(new Speaker(DeviceGroup.DeviceTypes.Speaker, currentDeviceIdIndex + 1, "Alarm Speaker", Speaker.soundStates.Alarm, 1f));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                    }
                    if (rand.Next(1, 10) > 4)
                    {
                        deviceListToAdd.Add(new LedPanel(DeviceGroup.DeviceTypes.LedPanel, currentDeviceIdIndex + 1, "LED Display", "21st Night of September"));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                    }
                }
                deviceListToAdd.Add(new CardReader(DeviceGroup.DeviceTypes.CardReader, currentDeviceIdIndex + 1, "Obligatory Card Reader Unit", hexadecimalArray[rand.Next(0, hexadecimalArray.Length)]));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                deviceListToAdd.Add(new Door(DeviceGroup.DeviceTypes.Door, currentDeviceIdIndex + 1, "Obligatory entrance door", Door.PossibleStates.Locked));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                if (rand.Next(1, 10) > 5)
                {
                    deviceListToAdd.Add(new Door(DeviceGroup.DeviceTypes.Door, currentDeviceIdIndex + 1, "Not so obligatory exit door", Door.PossibleStates.Locked));
                    changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());
                }

                DeviceGroupList.Add(new DeviceGroup(deviceListToAdd, "Commerce N" + i, ++currentDeviceGroupIdIndex, changeList));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                deviceListToAdd.Clear();
            
            }
        }

        private void initialModifications()
        {
            foreach(DeviceGroup deviceGroup in DeviceGroupList)
            {

            }
        }

        public void addGroup()
        {
            Console.WriteLine("Please provide a name for the device group: ");
            string nameInput = Console.ReadLine();
            DeviceGroupList.Add(new DeviceGroup(new List<IndividualDevice>(), nameInput, (short)(DeviceGroupList.Count + 1), new List<string>()));
            changeHistory.Add("Added Device Group of name: " + nameInput);
            Console.WriteLine("AddedDeviceGroup of name: " + nameInput);
        }
        public void removeGroup(int groupID)
        {
            foreach (DeviceGroup group in DeviceGroupList)
            {
                if (group.DeviceGroupID == groupID)
                {
                    DeviceGroupList.Remove(group);
                    changeHistory.Add("Removed group " + group + " from root");
                    Console.WriteLine("Removed group " + group + " from root");
                }
            }
        }
    }
}
