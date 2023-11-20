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
        }
    }
}
