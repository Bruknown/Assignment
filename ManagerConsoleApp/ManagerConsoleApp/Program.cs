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
            ShoppingMall.initialInsert();
            foreach (DeviceGroup group in Root.DeviceGroupList)
            {
                
                
            }

        }
    }



}
