using System;
using System.Collections.Generic;
using System.Text;
using static ManagerConsoleApp.DeviceTypes.Speaker;
using static System.Net.Mime.MediaTypeNames;

namespace ManagerConsoleApp.DeviceTypes
{
    internal class CardReader : IndividualDevice
    {
        public string AccessCardNumber;
        public CardReader(Enum type, int deviceID, string name, string accessCardNumber)
        {
            Type = type;
            DeviceID = deviceID;
            Name = name;
            AccessCardNumber = accessCardNumber;
        }

        public void AcessCardValidation(string acessCardNumber)
        {
            if (acessCardNumber.Length % 2 == 0 && acessCardNumber.Length <= 16 && verifyHexadecimal(acessCardNumber))
            {
                AccessCardNumber = ReserveBytesAndPad(acessCardNumber);
            }

        }

        private string ReserveBytesAndPad(string acessCardNumber)
        {
            string product = "";
            char[] charArray = acessCardNumber.ToCharArray();
            Array.Reverse(charArray);
            product = new string(charArray);

            while (product.Length < 16)
            {
                product = "0" + product;
            }

            return product;
        }

        private bool verifyHexadecimal(string acessCardNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(acessCardNumber, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
