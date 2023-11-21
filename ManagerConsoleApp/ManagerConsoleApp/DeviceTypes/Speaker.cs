using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class Speaker : IndividualDevice
    {
        public soundStates Sound;
        public float Volume;

        public Speaker(Enum type, int deviceID, string name, soundStates soundState, float volume)
        {
            Type = type;
            DeviceID = deviceID;
            Name = name;
            Sound = soundState;
            Volume = volume;
            modificationHistory = new List<string>();

        }

        public void changeSoundType(soundStates newSoundType)
        {
            string modificationString = "Changed Sound Type from " + Sound.ToString() + " INTO " + newSoundType.ToString();
            modificationHistory.Add(modificationString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(modificationString);
            Sound = newSoundType;
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            printCurrentState();
            Console.ReadLine();
        }

        public void changeVolume(float newVolume)
        {
            string modificationString = "Changed volume from: " + Volume + " INTO " + newVolume;
            modificationHistory.Add(modificationString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(modificationString);
            Volume = newVolume;
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            printCurrentState();
            Console.ReadLine();
        }

        public enum soundStates
        {
            None,
            Music,
            Alarm
        }

    }
}
