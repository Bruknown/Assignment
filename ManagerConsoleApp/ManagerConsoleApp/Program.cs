using ManagerConsoleApp.DeviceTypes;
using System;
using System.Runtime.InteropServices;

namespace ManagerConsoleApp
{
    internal class Program
    {
        static int deviceGroupIndex = 0;
        static int deviceIndex = 0;
        static CurrentLocation currently = CurrentLocation.Root;
        static void Main(string[] args)
        {
            Root ShoppingMall = new Root();
            Console.WriteLine("==================================");
            Console.WriteLine("PRESS ENTER TO START MANAGER MODE");
            Console.WriteLine("==================================");
            Console.ReadLine();
            Console.Clear();
            bool programRunning = true;
            while (programRunning)
            {
                switch (currently)
                {
                    case CurrentLocation.Root:
                        RootBehavior(ShoppingMall);
                        break;
                    case CurrentLocation.DeviceGroup:
                        DeviceGroupBehavior(ShoppingMall);
                        break;
                    case CurrentLocation.Device:
                        DeviceBehavior(ShoppingMall);
                        break;

                }

            }
        }
        private static void DeviceBehavior(Root ShoppingMall)
        {
            bool validOption = false;
            while (!validOption)
            {
                Console.Clear();
                headerPrint(currently);
                Console.WriteLine("Please select a valid option");
                switch (Root.DeviceGroupList[deviceGroupIndex].IndividualDevices[deviceIndex].Type)
                {
                    case DeviceGroup.DeviceTypes.Door:
                        Console.WriteLine("1. Change Door Name");
                        Console.WriteLine("2. Change Door Status");
                        Console.WriteLine("3. Change Door Group");
                        Console.WriteLine("4. Print Device History");
                        Console.WriteLine("5. Return");
                        Console.WriteLine("DELETE. Delete Device");
                        break;
                    case DeviceGroup.DeviceTypes.CardReader:
                        Console.WriteLine("1. Change Card Reader Name");
                        Console.WriteLine("2. Change Card Reader Code");
                        Console.WriteLine("3. Change Card Reader Group");
                        Console.WriteLine("4. AccessCardValidation");
                        Console.WriteLine("5. Print Device History");
                        Console.WriteLine("6. Return");
                        Console.WriteLine("DELETE. Delete Device");
                        break;
                    case DeviceGroup.DeviceTypes.Speaker:
                        Console.WriteLine("1. Change Speaker Name");
                        Console.WriteLine("2. Change Speaker Volume");
                        Console.WriteLine("3. Change Speaker Sound Type");
                        Console.WriteLine("4. Change Speaker Group");
                        Console.WriteLine("5. Print Device History");
                        Console.WriteLine("6. Return");
                        Console.WriteLine("DELETE. Delete Device");
                        break;
                    case DeviceGroup.DeviceTypes.LedPanel:
                        Console.WriteLine("1. Change LED Panel Name");
                        Console.WriteLine("2. Change LED Panel Message");
                        Console.WriteLine("3. Change LED Panel Group");
                        Console.WriteLine("4. Print Device History");
                        Console.WriteLine("5. Return");
                        Console.WriteLine("DELETE. Delete Device");
                        break;
                }
                string userInput = Console.ReadLine();
                userInput = userInput.Trim().ToUpper();
                if (userInput.Equals("DELETE"))
                {
                    Root.DeviceGroupList[deviceGroupIndex].removeDevice(Root.DeviceGroupList[deviceGroupIndex].IndividualDevices[deviceIndex].DeviceID);
                    currently = CurrentLocation.DeviceGroup;
                }
                if (!int.TryParse(userInput, out int result))
                    break;

                validOption = (int.Parse(userInput) < ((Root.DeviceGroupList[deviceGroupIndex].IndividualDevices[deviceIndex].Type.Equals(DeviceGroup.DeviceTypes.Speaker) || Root.DeviceGroupList[deviceGroupIndex].IndividualDevices[deviceIndex].Type.Equals(DeviceGroup.DeviceTypes.CardReader)) ? 7 : 6) && int.Parse(userInput) > 0) ? true : false;

                if (validOption)
                    Root.DeviceGroupList[deviceGroupIndex].modifyDevice(userInput, Root.DeviceGroupList[deviceGroupIndex].IndividualDevices[deviceIndex], Root.DeviceGroupList[deviceGroupIndex].DeviceGroupID);

                currently = CurrentLocation.DeviceGroup;
            }
            //will print the device and its options
        }
        private static void RootBehavior(Root ShoppingMall)
        {
            bool validOption = false;
            while (!validOption)
            {
                Console.Clear();
                int choiceAmmount = -1;
                headerPrint(currently);
                Console.WriteLine("Please select a valid option");
                foreach (DeviceGroup deviceGroup in Root.DeviceGroupList)
                {
                    Console.WriteLine(++choiceAmmount + ": Device Group " + deviceGroup.DeviceGroupName + " ID: " + deviceGroup.DeviceGroupID);
                }
                Console.WriteLine("ADD: Create Device Group");
                Console.WriteLine("PRINT: Prints the tree");
                Console.WriteLine("EXIT: Exit Program");
                string userInput = Console.ReadLine();
                userInput = userInput.Trim().ToUpper();
                if (userInput.Equals("ADD") || userInput.Equals("EXIT") || userInput.Equals("PRINT"))
                {
                    switch (userInput)
                    {
                        case "ADD":
                            ShoppingMall.addGroup();
                            break;
                        case "EXIT":
                            Environment.Exit(0);
                            break;
                        case "PRINT":
                            Root.printTree();
                            break;
                    }
                }
                if (!int.TryParse(userInput, out int result))
                    break;

                validOption = ((int.Parse(userInput) < Root.DeviceGroupList.Count && int.Parse(userInput) > -1) && int.Parse(userInput) <= choiceAmmount) ? true : false;
                if (validOption)
                {
                    deviceGroupIndex = int.Parse(userInput);
                }
                currently = CurrentLocation.DeviceGroup;
            }
            //will print device groups
        }

        private static void DeviceGroupBehavior(Root ShoppingMall)
        {
            bool validOption = false;
            while (!validOption)
            {
                Console.Clear();
                int choiceAmmount = -1;
                headerPrint(currently);
                Console.WriteLine("Please select a valid option");
                foreach (IndividualDevice device in Root.DeviceGroupList[deviceGroupIndex].IndividualDevices)
                {
                    choiceAmmount += 1;
                    Console.WriteLine(choiceAmmount + ": Device " + device.Name + " ID: " + device.DeviceID);
                }
                Console.WriteLine("ADD: Create Device");
                Console.WriteLine("DELETE: Current Group");
                Console.WriteLine("RETURN: Return to Root");
                string userInput = Console.ReadLine();
                userInput = userInput.Trim().ToUpper();
                if (userInput.Equals("ADD") || userInput.Equals("RETURN") || userInput.Equals("DELETE"))
                {
                    switch (userInput)
                    {
                        case "ADD":
                            Root.DeviceGroupList[deviceGroupIndex].addDeviceByUser();
                            break;
                        case "RETURN":
                            currently = CurrentLocation.Root;
                            deviceGroupIndex = -1;
                            break;
                        case "DELETE":
                            ShoppingMall.removeGroup(Root.DeviceGroupList[deviceGroupIndex].DeviceGroupID);
                            currently = CurrentLocation.Root;
                            deviceGroupIndex = -1;
                            break;
                    }
                }
                if (!int.TryParse(userInput, out int result))
                    break;

                validOption = ((int.Parse(userInput) < Root.DeviceGroupList[deviceGroupIndex].IndividualDevices.Count && int.Parse(userInput) > -1) && int.Parse(userInput) <= choiceAmmount) ? true : false;
                if (validOption)
                    deviceIndex = int.Parse(userInput);
                currently = CurrentLocation.Device;

            }
            //will print devices in group
        }

        public static void headerPrint(CurrentLocation currently)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Welcome to Mall Manager 1.0.0");
            Console.WriteLine("What would you like to do? Overseer.");
            Console.WriteLine("==================================");
            Console.WriteLine("Current Location: " + currently.ToString());
            Console.WriteLine("==================================");

        }
        public enum CurrentLocation
        {
            Root,
            DeviceGroup,
            Device
        }
    }



}
