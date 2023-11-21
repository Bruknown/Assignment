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
            modificationHistory = new List<string>();
        }

        public void changeMessage(string newMessage)
        {
            string modificationString = "Changed LED Display message from: " + Message + " INTO " + newMessage;
            modificationHistory.Add(modificationString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(modificationString);
            Console.ResetColor();
            Message = newMessage;
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            printCurrentState();
            Console.ReadLine();
        }
    }
}
