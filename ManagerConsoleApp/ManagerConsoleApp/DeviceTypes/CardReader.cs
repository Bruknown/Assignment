﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class CardReader : IndividualDevice
    {
        public string AccessCardNumber;

        private void AcessCardValidation(string acessCardNumber)
        {
            if (acessCardNumber.Length % 2 == 0 && acessCardNumber.Length <= 16 && verifyHexadecimal(acessCardNumber))
            {
                //something
            }

        }

        private string ReserveBytesAndPad(string acessCardNumber)
        {
            string product = "";

            return product;
        }

        private bool verifyHexadecimal(string acessCardNumber)
        {

            return false;
        }
    }
}