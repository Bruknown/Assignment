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



        public DeviceGroup(List<IndividualDevice> devices, string deviceGroupName, short deviceGroupID)
        {
            IndividualDevices = devices;
            DeviceGroupName = deviceGroupName;
            DeviceGroupID = deviceGroupID;
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
