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
            initialInsert();
            initialModifications();
        }
        public void changeDeviceGroupForDevice(int deviceGroupOrigin, int deviceGroupDestination, IndividualDevice deviceToMove)
        {
            foreach (DeviceGroup deviceGroup in DeviceGroupList)
            {
                if (deviceGroup.DeviceGroupID == deviceGroupOrigin)
                {
                    deviceGroup.removeDevice(deviceToMove.DeviceID);
                    deviceGroup.modificationHistory.Add("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to Device group of ID: " + deviceGroupDestination);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to Device group of ID: " + deviceGroupDestination);
                    Console.ResetColor();                
                }
                if (deviceGroup.DeviceGroupID == deviceGroupDestination)
                {
                    deviceGroup.IndividualDevices.Add(deviceToMove);
                    deviceGroup.modificationHistory.Add("Transferred Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to current Device Group of: " + deviceGroup.DeviceGroupName);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Transferred Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " to current Device Group of: " + deviceGroup.DeviceGroupName);
                    Console.ResetColor();
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
            for (int i = 0; i < 6; i++)
            {
                List<IndividualDevice> deviceListToAdd = new List<IndividualDevice>();
                List<string> changeList = new List<string>();
                int repetitionChance = rand.Next(2, 5);
                for (int j = 0; j < repetitionChance; j++)
                {
                    if (rand.Next(1, 11) > 9)
                    {
                        deviceListToAdd.Add(new Speaker(DeviceGroup.DeviceTypes.Speaker, ++currentDeviceIdIndex, "Music Speaker", Speaker.soundStates.Music, 0.5f));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());   
                    }
                    if (rand.Next(1, 11) > 7)
                    {
                        deviceListToAdd.Add(new Speaker(DeviceGroup.DeviceTypes.Speaker, ++currentDeviceIdIndex, "Alarm Speaker", Speaker.soundStates.Alarm, 1f));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                    }
                    if (rand.Next(1, 11) > 8)
                    {
                        deviceListToAdd.Add(new LedPanel(DeviceGroup.DeviceTypes.LedPanel, ++currentDeviceIdIndex, "LED Display", "21st Night of September"));
                        changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                    }
                }
                deviceListToAdd.Add(new CardReader(DeviceGroup.DeviceTypes.CardReader, ++currentDeviceIdIndex, "Obligatory Card Reader Unit", hexadecimalArray[rand.Next(0, hexadecimalArray.Length)]));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                deviceListToAdd.Add(new Door(DeviceGroup.DeviceTypes.Door, ++currentDeviceIdIndex, "Obligatory entrance door", Door.PossibleStates.Locked));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

                if (rand.Next(1, 11) > 5)
                {
                    deviceListToAdd.Add(new Door(DeviceGroup.DeviceTypes.Door, ++currentDeviceIdIndex, "Not so obligatory exit door", Door.PossibleStates.Locked));
                    changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());
                }

                DeviceGroupList.Add(new DeviceGroup(deviceListToAdd, "Commerce N" + i, ++currentDeviceGroupIdIndex, changeList));
                changeList.Add("Added " + deviceListToAdd.Last().Type.ToString());

            
            }
        }

        private void initialModifications()
        {
            Random rand = new Random();
            foreach(DeviceGroup deviceGroup in DeviceGroupList)
            {
                int rng = rand.Next(1, 5);
                switch (rng)
                {
                    case 1:
                        deviceGroup.addDevice(new Door(DeviceGroup.DeviceTypes.Door, ++currentDeviceIdIndex, "Not so obligatory exit door", Door.PossibleStates.Locked));
                        break;
                    case 2:
                        deviceGroup.addDevice(new CardReader(DeviceGroup.DeviceTypes.CardReader, ++currentDeviceIdIndex, "Card Reader Unit", "63 6F 6F 6C"));
                        break;
                    case 3:
                        deviceGroup.addDevice(new Speaker(DeviceGroup.DeviceTypes.Speaker, ++currentDeviceIdIndex, "Music Speaker", Speaker.soundStates.Music, 0.5f));
                        break;
                    case 4:
                        deviceGroup.addDevice(new LedPanel(DeviceGroup.DeviceTypes.LedPanel, ++currentDeviceIdIndex, "LED Display", "21st Night of September"));
                        break;
                }
                deviceGroup.removeDevice(deviceGroup.IndividualDevices[rand.Next(0, deviceGroup.IndividualDevices.Count)].DeviceID);
                IndividualDevice deviceToChange = deviceGroup.IndividualDevices[rand.Next(0, deviceGroup.IndividualDevices.Count)];
                switch (deviceToChange.Type)
                {
                    case DeviceGroup.DeviceTypes.Door:
                        Door doorToChange = deviceToChange as Door;
                        doorToChange.changeDoorState(Door.PossibleStates.OpenedForcibly);
                        break;
                    case DeviceGroup.DeviceTypes.CardReader:
                        CardReader cardReaderToChange = deviceToChange as CardReader;
                        cardReaderToChange.changeCardNumber("6B6 96 E64206 F6 6");
                        break;
                    case DeviceGroup.DeviceTypes.LedPanel:
                        LedPanel ledPanelToChange = deviceToChange as LedPanel;
                        ledPanelToChange.changeMessage("Dancing With Myself");
                        break;
                    case DeviceGroup.DeviceTypes.Speaker:
                        Speaker speakerToChange = deviceToChange as Speaker;
                        speakerToChange.changeSoundType(Speaker.soundStates.None);
                        speakerToChange.changeVolume((float)rand.NextDouble());
                        break;
                }
                changeDeviceGroupForDevice(deviceGroup.DeviceGroupID, DeviceGroupList[^1].DeviceGroupID, deviceGroup.IndividualDevices[rand.Next(0, deviceGroup.IndividualDevices.Count-1)]);
            }
        }

        public void addGroup()
        {
            Console.WriteLine("Please provide a name for the device group: ");
            string nameInput = Console.ReadLine();
            DeviceGroupList.Add(new DeviceGroup(new List<IndividualDevice>(), nameInput, (short)(DeviceGroupList.Count+1), new List<string>()));

            Console.ForegroundColor = ConsoleColor.Green;
            changeHistory.Add("Added Device Group of name: " + nameInput);
            Console.WriteLine("AddedDeviceGroup of name: " + nameInput);
            Console.ResetColor();
        }
        public void removeGroup(int groupID)
        {
            foreach (DeviceGroup group in DeviceGroupList)
            {
                if (group.DeviceGroupID == groupID)
                {
                    DeviceGroupList.Remove(group);
                    Console.ForegroundColor = ConsoleColor.Red;
                    changeHistory.Add("Removed group " + group + " from root");
                    Console.WriteLine("Removed group " + group + " from root");
                    Console.ResetColor();
                }
            }
        }
    }
}
