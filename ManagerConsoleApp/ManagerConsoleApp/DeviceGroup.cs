using ManagerConsoleApp.DeviceTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagerConsoleApp
{
    internal class DeviceGroup
    {
        public List<IndividualDevice> IndividualDevices;
        public String DeviceGroupName;
        public short DeviceGroupID;
        public List<string> modificationHistory;


        public DeviceGroup(List<IndividualDevice> devices, string deviceGroupName, short deviceGroupID, List<string> groupHistory)
        {
            IndividualDevices = devices;
            DeviceGroupName = deviceGroupName;
            DeviceGroupID = deviceGroupID;
            modificationHistory = groupHistory;
        }
        public void modifyDevice(string Decision, IndividualDevice deviceToChange, int originGroup)
        {
            string decision = Decision;
            bool isValid;

            switch (deviceToChange.Type)
            {
                case DeviceTypes.Speaker:
                    Speaker speaker = deviceToChange as Speaker;
                    switch (int.Parse(decision))
                    {
                        case 1:
                            Console.WriteLine("Please insert a new name for the Device");
                            speaker.changeDeviceName(Console.ReadLine());
                            break;
                        case 2:
                            isValid = false;
                            while (!isValid)
                            {
                                Console.WriteLine("Please insert a volume for the speaker from 0.0 to 1.0");
                                decision = Console.ReadLine();
                                if (float.TryParse(decision, out float result))
                                    isValid = (float.Parse(decision) >= 0 && float.Parse(decision) <= 1)? true : false;
                            }
                            speaker.changeVolume(float.Parse(decision));
                            break;
                        case 3:
                            speaker.changeSoundType(soundStateDefine());
                            break;
                        case 4:
                            isValid = false;
                            int choiceAmmount = -1;
                            while (!isValid)
                            {
                                Console.WriteLine("What group would you like to transfer this Device to?");
                                foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
                                {
                                    choiceAmmount += 1;
                                    Console.WriteLine(choiceAmmount + ": Device Group " + deviceGroup.DeviceGroupName + " ID: " + deviceGroup.DeviceGroupID);
                                }
                                decision = Console.ReadLine();
                                if (!int.TryParse(decision, out int result))
                                    break;

                                isValid = (int.Parse(decision) < Root.DeviceGroupList.Count && int.Parse(decision) >= 0) ? true : false;
                                if (isValid)
                                    changeDeviceGroupForDevice(originGroup, Root.DeviceGroupList[int.Parse(decision)].DeviceGroupID, speaker);

                            }
                            break;
                        case 5:
                            speaker.printHistory();
                            break;
                    }

                    break;
                case DeviceTypes.LedPanel:
                    LedPanel panel = deviceToChange as LedPanel;
                    switch (int.Parse(decision))
                    {
                        case 1:
                            Console.WriteLine("Please insert a new name for the device");
                            panel.changeDeviceName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Please insert a new message for the device");
                            panel.changeMessage(Console.ReadLine());
                            break;
                        case 3:
                            isValid = false;
                            int choiceAmmount = -1;
                            while (!isValid)
                            {
                                Console.WriteLine("What group would you like to transfer this Device to?");
                                foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
                                {
                                    choiceAmmount += 1;
                                    Console.WriteLine(choiceAmmount + ": Device Group " + deviceGroup.DeviceGroupName + " ID: " + deviceGroup.DeviceGroupID);
                                }
                                decision = Console.ReadLine();
                                if (!int.TryParse(decision, out int result))
                                    break;

                                isValid = (int.Parse(decision) < Root.DeviceGroupList.Count && int.Parse(decision) >= 0) ? true : false;
                                if (isValid)
                                    changeDeviceGroupForDevice(originGroup, Root.DeviceGroupList[int.Parse(decision)].DeviceGroupID, panel);

                            }
                            break;
                        case 4:
                            panel.printHistory();
                            break;
                    }

                    break;
                case DeviceTypes.CardReader:
                    CardReader reader = deviceToChange as CardReader;
                    switch(int.Parse(decision))
                    {
                        case 1:
                            Console.WriteLine("Please insert a new name for this device");
                            reader.changeDeviceName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("please insert a new code for the Card Reader");
                            reader.AcessCardValidation(Console.ReadLine());
                            break;
                        case 3:
                            isValid = false;
                            int choiceAmmount = -1;
                            while (!isValid)
                            {
                                Console.WriteLine("What group would you like to transfer this Device to?");
                                foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
                                {
                                    choiceAmmount += 1;
                                    Console.WriteLine(choiceAmmount + ": Device Group " + deviceGroup.DeviceGroupName + " ID: " + deviceGroup.DeviceGroupID);
                                }
                                decision = Console.ReadLine();
                                if (!int.TryParse(decision, out int result))
                                    break;

                                isValid = (int.Parse(decision) < Root.DeviceGroupList.Count && int.Parse(decision) >= 0) ? true : false;
                                if (isValid)
                                    changeDeviceGroupForDevice(originGroup, Root.DeviceGroupList[int.Parse(decision)].DeviceGroupID, reader);

                            }
                            break;
                        case 4:
                            reader.AcessCardValidation(reader.AccessCardNumber);
                            break;
                        case 5: 
                            reader.printHistory();
                            break;
                    }
                    break;
                case DeviceTypes.Door:
                    Door door = deviceToChange as Door;
                    switch (int.Parse(decision))
                    {
                        case 1:
                            Console.WriteLine("Please insert a new name for this device");
                            door.changeDeviceName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Please specify the new door status");
                            Console.WriteLine("1. Locked");
                            Console.WriteLine("2. Open");
                            Console.WriteLine("3. Open For Too Long");
                            Console.WriteLine("4. Broken");
                            isValid = false;
                            while (!isValid)
                            {
                                decision = Console.ReadLine();
                                if (int.TryParse(decision, out int result))
                                    isValid = (int.Parse(decision) > 0 && int.Parse(decision) < 5) ? true : false;
                            }
                            switch (int.Parse(decision))
                            {
                                case 1:
                                    door.changeDoorState(Door.PossibleStates.Locked);
                                    break;
                                case 2:
                                    door.changeDoorState(Door.PossibleStates.Open);
                                    break;
                                case 3:
                                    door.changeDoorState(Door.PossibleStates.OpenForTooLong);
                                    break;
                                case 4:
                                    door.changeDoorState(Door.PossibleStates.OpenedForcibly);
                                    break;
                            }
                            break;
                        case 3:
                            isValid = false;
                            int choiceAmmount = -1;
                            while (!isValid)
                            {
                                Console.WriteLine("What group would you like to transfer this Device to?");
                                foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
                                {
                                    choiceAmmount += 1;
                                    Console.WriteLine(choiceAmmount + ": Device Group " + deviceGroup.DeviceGroupName + " ID: " + deviceGroup.DeviceGroupID);
                                }
                                decision = Console.ReadLine();
                                if (!int.TryParse(decision, out int result))
                                    break;

                                isValid = (int.Parse(decision) < Root.DeviceGroupList.Count && int.Parse(decision) >= 0) ? true : false;
                                if (isValid)
                                    changeDeviceGroupForDevice(originGroup, Root.DeviceGroupList[int.Parse(decision)].DeviceGroupID, door);

                            }
                            break;
                        case 4:
                            door.printHistory();
                            break;
                    }
                    break;
            }
        }


        public void changeDeviceGroupForDevice(int deviceGroupOrigin, int deviceGroupDestination, IndividualDevice deviceToMove)
        {
            foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
            {
                if (deviceGroup.DeviceGroupID == deviceGroupOrigin)
                {
                    deviceGroup.removeDevice(deviceToMove.DeviceID);
                    deviceGroup.modificationHistory.Add("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " from Device group of: " + deviceGroup.DeviceGroupName);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Changed Device Group for the Device: " + deviceToMove.Name + " of ID: " + deviceToMove.DeviceID + " from Device group of: " + deviceGroup.DeviceGroupName);
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
            Root.printTree();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }

        public void addDeviceByUser()
        {
            string deviceChoice = "";
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("Please specify the device to be added: ");
                Console.WriteLine("1. Speaker");
                Console.WriteLine("2. LED Panel");
                Console.WriteLine("3. Door");
                Console.WriteLine("4. CardReader");
                deviceChoice = Console.ReadLine();
                if (!int.TryParse(deviceChoice, out int result))
                    correctInput = false;
                else
                    correctInput = (int.Parse(deviceChoice) < 5 && int.Parse(deviceChoice) > 0)? true : false;
            }

            Console.WriteLine("Please designate a name for the new device: ");
            string deviceName = Console.ReadLine();

            switch (int.Parse(deviceChoice))
            {
                case 1:
                    addDevice(new Speaker(DeviceTypes.Speaker, ++Root.currentDeviceIdIndex, deviceName, soundStateDefine(), 0f));
                    break;
                case 2:
                    Console.WriteLine("Please insert the message in display for the LED Panel: ");
                    string message = Console.ReadLine();
                    addDevice(new LedPanel(DeviceTypes.LedPanel, ++Root.currentDeviceIdIndex, deviceName, message));
                    break;
                case 3:
                    addDevice(new Door(DeviceTypes.Door, ++Root.currentDeviceIdIndex, deviceName, Door.PossibleStates.Locked));
                    break;
                case 4:
                    Console.WriteLine("Please provide the Card Reader with a Hexadecimal code");
                    string code = Console.ReadLine();
                    addDevice(new CardReader(DeviceTypes.CardReader, ++Root.currentDeviceIdIndex, deviceName, code));
                    break;

            }
        }

        public void addDevice(IndividualDevice newDevice)
        {
            string modificationString = "Added device " + newDevice.Name + " of ID: " + newDevice.DeviceID + " into group: " + DeviceGroupName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(modificationString);
            modificationHistory.Add(modificationString);
            IndividualDevices.Add(newDevice);
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }
        
        private Speaker.soundStates soundStateDefine()
        {
            string speakerFunction = "";
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("Please designate a function for the speakers: ");
                Console.WriteLine("1. Music");
                Console.WriteLine("2. Alarm");
                Console.WriteLine("3. None");
                speakerFunction = Console.ReadLine();
                if (!int.TryParse(speakerFunction, out int result))
                    correctInput = false;
                else
                    correctInput = (int.Parse(speakerFunction) < 4 && int.Parse(speakerFunction) > 0) ? true : false;
            }
            Speaker.soundStates speakerState = Speaker.soundStates.None;
            switch (int.Parse(speakerFunction))
            {
                case 1:
                    speakerState = Speaker.soundStates.Music;
                    break;
                case 2:
                    speakerState = Speaker.soundStates.Alarm;
                    break;
            }
            return speakerState;
        }


        public void printGroup()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================PRINTING GROUP=================");
            foreach (IndividualDevice device in IndividualDevices)
            {
                device.printCurrentState();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================PRINTING GROUP=================");
            Console.ResetColor();
        }

        public void removeDevice(int deviceID)
        {
            foreach (IndividualDevice device in IndividualDevices)
            {
                if (device.DeviceID == deviceID)
                {
                    string modificationString = "Removed " + device.Type.ToString() + " of ID: " + device.DeviceID + " from device group: " + DeviceGroupName;
                    modificationHistory.Add(modificationString);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(modificationString);
                    Console.ResetColor();
                    IndividualDevices.Remove(device);
                    Console.WriteLine("PRESS ENTER TO CONTINUE");
                    Console.ReadLine();
                    return;
                }
            }
        }


        public enum DeviceTypes
        {
            LedPanel,
            Door,
            Speaker,
            CardReader
        }
    }
}
