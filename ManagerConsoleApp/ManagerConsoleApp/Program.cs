using System;
using System.Runtime.InteropServices;

namespace ManagerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Root ShoppingMall = new Root();
            foreach (DeviceGroup group in ShoppingMall.DeviceGroupList)
            {
                group.printGroup();
            }
        }
    }



}
