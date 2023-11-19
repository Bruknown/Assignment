using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class Door : IndividualDevice
    {
        public bool Locked, Open, OpenForTooLong, OpenedForcibly;
        public PossibleStates State;
        
        [Flags]
        public enum PossibleStates
        {
            Open = 0b_0000_0001,  // 1
            OpenForTooLong  = 0b_0000_0010,  // 2
            OpenedForcibly = 0b_0000_0100,  // 4
            Locked  = 0b_0000_1000,  // 8
        }
        public Door(Enum type, int deviceID, string name, PossibleStates doorState)
        {
            Type = type;
            DeviceID = deviceID;
            Name = name;
            modificationHistory = new List<string>();
            State = doorState;
        }

        public void changeDoorState(PossibleStates newState)
        {
            string changeHistoryString = "Door status changed from: " + State + " INTO " + newState;
            modificationHistory.Add(changeHistoryString);
            Console.WriteLine(changeHistoryString);
            State = newState;
        }
    }
}
