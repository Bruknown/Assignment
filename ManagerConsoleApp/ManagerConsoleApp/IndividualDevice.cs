using ManagerConsoleApp.DeviceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp
{
    internal class IndividualDevice
    {
        public Enum Type;
        public int DeviceID;
        public string Name;
        public List<string> modificationHistory;

        public void changeDeviceName(string newName)
        {
            string modificationString = "Changed device name from: " + Name + " INTO " + newName;
            Console.ForegroundColor = ConsoleColor.Yellow;
            modificationHistory.Add(modificationString);
            Console.WriteLine(modificationString);
            Name = newName;
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            printCurrentState();
            Console.ReadLine();
        }

        public void printCurrentState()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============OBJECT " + Name +  "=============");
            Console.WriteLine("Object Type: " + Type);
            Console.WriteLine("Object Name: " + Name);
            Console.WriteLine("Object ID: " + DeviceID);
            switch (Type)
            {
                case DeviceGroup.DeviceTypes.Door:
                    Door door = this as Door;
                    Console.WriteLine("Door Status: " + door.State);
                    break;
                case DeviceGroup.DeviceTypes.LedPanel:
                    LedPanel ledPanel = this as LedPanel;
                    Console.WriteLine("led Panel Message: " + ledPanel.Message);
                    break;
                case DeviceGroup.DeviceTypes.CardReader:
                    CardReader cardReader = this as CardReader;
                    Console.WriteLine("led Panel Message: " + cardReader.AccessCardNumber);
                    break;
                case DeviceGroup.DeviceTypes.Speaker:
                    Speaker speaker = this as Speaker;
                    Console.WriteLine("Speaker Volume: " + speaker.Volume);
                    Console.WriteLine("Speaker Sound Type: " + speaker.Sound);
                    break;
            }
            Console.ResetColor();
        }

        public void printHistory()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("COMMENCING HISTORY PRINT");
            foreach (string history in modificationHistory)
            {
                Console.WriteLine(history);
            }
            Console.WriteLine("END OF HISTORY, press enter to continue");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
