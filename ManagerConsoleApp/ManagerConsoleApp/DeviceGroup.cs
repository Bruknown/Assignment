using ManagerConsoleApp.DeviceTypes;
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
        public List<string> modificationHistory;


        public DeviceGroup(List<IndividualDevice> devices, string deviceGroupName, short deviceGroupID, List<string> groupHistory)
        {
            IndividualDevices = devices;
            DeviceGroupName = deviceGroupName;
            DeviceGroupID = deviceGroupID;
            modificationHistory = groupHistory;
        }
        public void modifyDevice(IndividualDevice deviceToChange)
        {
            string decision = "";
            bool isValid;

            switch (deviceToChange.Type)
            {
                case DeviceTypes.Speaker:
                    Speaker speaker = deviceToChange as Speaker;
                    Console.WriteLine("1. Speaker Name");
                    Console.WriteLine("2. Speaker Volume");
                    Console.WriteLine("3. Speaker Type");
                    isValid = false;
                    while (!isValid)
                    {
                        decision = Console.ReadLine();
                        if (int.TryParse(decision, out int result))
                            isValid = (int.Parse(decision) > 0 && int.Parse(decision) < 4) ? true : false;
                    }
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
                    }

                    break;
                case DeviceTypes.LedPanel:
                    LedPanel panel = deviceToChange as LedPanel;
                    Console.WriteLine("1. LED Panel Name");
                    Console.WriteLine("2. LED Panel Message");
                    isValid = false;
                    while (!isValid)
                    {
                        decision = Console.ReadLine();
                        if (int.TryParse(decision, out int result))
                            isValid = (int.Parse(decision) > 0 && int.Parse(decision) < 3) ? true : false;
                    }
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
                    }

                    break;
                case DeviceTypes.CardReader:
                    CardReader reader = deviceToChange as CardReader;
                    Console.WriteLine("1. Card Reader Name");
                    Console.WriteLine("2. Card Reader Code");
                    isValid = false;
                    while (!isValid)
                    {
                        decision = Console.ReadLine();
                        if (int.TryParse(decision, out int result))
                            isValid = (int.Parse(decision) > 0 && int.Parse(decision) < 3) ? true : false;
                    }
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
                    }
                    break;
                case DeviceTypes.Door:
                    Door door = deviceToChange as Door;
                    Console.WriteLine("1. Door Name");
                    Console.WriteLine("2. Door Status");
                    isValid = false;
                    while (!isValid)
                    {
                        decision = Console.ReadLine();
                        if (int.TryParse(decision, out int result))
                            isValid = (int.Parse(decision) > 0 && int.Parse(decision) < 3) ? true : false;
                    }
                    switch (int.Parse(decision))
                    {
                        case 1:
                            Console.WriteLine("Please insert a new name for this device");
                            door.changeDeviceName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Please specify the new door status");

                            break;
                    }
                    break;
            }
        }
        public void addDevice()
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
                if (int.TryParse(deviceChoice, out int result))
                    break;
                correctInput = (int.Parse(deviceChoice) < 5 && int.Parse(deviceChoice) > 0)? true : false;
            }

            Console.WriteLine("Please designate a name for the new device: ");
            string deviceName = Console.ReadLine();

            switch (int.Parse(deviceChoice))
            {
                case 1:
                    IndividualDevices.Add(new Speaker(DeviceTypes.Speaker, Root.currentDeviceIdIndex+1, deviceName, soundStateDefine(), 0f));
                    break;
                case 2:
                    Console.WriteLine("Please insert the message in display for the LED Panel: ");
                    string message = Console.ReadLine();
                    IndividualDevices.Add(new LedPanel(DeviceTypes.LedPanel, Root.currentDeviceIdIndex + 1, deviceName, message));
                    break;
                case 3:
                    IndividualDevices.Add(new Door(DeviceTypes.Door, Root.currentDeviceIdIndex + 1, deviceName, Door.PossibleStates.Locked));
                    break;
                case 4:
                    Console.WriteLine("Please provide the Card Reader with a Hexadecimal code");
                    string code = Console.ReadLine();
                    IndividualDevices.Add(new CardReader(DeviceTypes.CardReader, Root.currentDeviceIdIndex + 1, deviceName, code));
                    break;

            }
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
                if (int.TryParse(speakerFunction, out int result))
                    break;
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
            foreach (IndividualDevice device in IndividualDevices)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("DEVICE NAME: " + device.Name);
                Console.WriteLine("DEVICE ID: " + device.DeviceID);
                Console.WriteLine("DEVICE TYPE: " + device.Type.ToString());
                switch (device.Type)
                {
                    case DeviceTypes.Speaker:
                        Speaker speaker = device as Speaker;
                        Console.WriteLine("SPEAKER MODE: " + speaker.Sound.ToString());
                        Console.WriteLine("SPEAKER VOLUME: " + speaker.Volume);
                        break;
                    case DeviceTypes.CardReader:
                        CardReader cardReader = device as CardReader;
                        Console.WriteLine("CARDREADER CODE: " + cardReader.AccessCardNumber);
                        Console.WriteLine("Validating Code...");
                        cardReader.AcessCardValidation(cardReader.AccessCardNumber);
                        Console.WriteLine("CARDREADER CODE: " + cardReader.AccessCardNumber);
                        break;
                    case DeviceTypes.LedPanel:
                        LedPanel ledpanel = device as LedPanel;
                        Console.WriteLine("PANEL MESSAGE: " + ledpanel.Message);
                        break;
                    case DeviceTypes.Door:
                        Door door = device as Door;
                        Console.WriteLine("DOOR STATUS: hey this is a todo still");
                        break;

                }
                Console.WriteLine("--------------------------------------------");
            }
        }

        public void removeDevice(int deviceID)
        {
            foreach (IndividualDevice device in IndividualDevices)
            {
                if (device.DeviceID == deviceID)
                {
                    IndividualDevices.Remove(device);
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
