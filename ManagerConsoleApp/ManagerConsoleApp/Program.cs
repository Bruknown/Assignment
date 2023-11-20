using ManagerConsoleApp.DeviceTypes;
using System;
using System.Runtime.InteropServices;

namespace ManagerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Root ShoppingMall = new Root();
            Console.WriteLine("==================================");
            Console.WriteLine("PRESS ENTER TO START MANAGER MODE");
            Console.WriteLine("==================================");
            Console.ReadLine();
            Console.Clear();
            bool programRunning = true;
            CurrentLocation currently = CurrentLocation.Root;
            while (programRunning)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("Welcome to Mall Manager 1.0.0");
                Console.WriteLine("What would you like to do? Overseer.");
                Console.WriteLine("==================================");
                Console.WriteLine("Current Location: " + currently.ToString());
                Console.WriteLine("==================================");
                switch (currently)
                {
                    case CurrentLocation.Root:
                        Console.ReadLine();
                        //will print device groups
                        break;
                    case CurrentLocation.DeviceGroup:
                        Console.ReadLine();
                        //will print devices in group
                        break;
                    case CurrentLocation.Device:
                        Console.ReadLine();
                        //will print the device and its options
                        break;

                }

            }
        }


        public enum CurrentLocation
        {
            Root,
            DeviceGroup,
            Device
        }
    }



}
