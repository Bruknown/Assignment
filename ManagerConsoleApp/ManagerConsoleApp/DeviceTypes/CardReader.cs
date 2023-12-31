﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            modificationHistory = new List<string>();

        }

        public void changeCardNumber(string newCardNumberInput)
        {
            string modificationString = "Changed ACCESS CARD NUMBER from: " + AccessCardNumber + " INTO " + newCardNumberInput;
            modificationHistory.Add(modificationString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(modificationString);
            AccessCardNumber = newCardNumberInput;
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            printCurrentState();
            Console.ReadLine();
        }

        public void AcessCardValidation(string acessCardNumber)
        {
            string formattedAcessCard = RemoveWhitespace(acessCardNumber).ToUpper();
            if (formattedAcessCard.Length % 2 == 0 && formattedAcessCard.Length <= 16 && verifyHexadecimal(formattedAcessCard))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ACCESSCODE IS IN THE CORRECT FORMAT, PRESS ENTER TO CONTINUE");
                Console.ReadLine();
                Console.ResetColor();
                ReserveBytesAndPad(formattedAcessCard);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACCESSCODE IS IN THE WRONG FORMAT, PRESS ENTER TO CONTINUE");
                Console.ReadLine();
                Console.ResetColor();
            }

        }

        private string RemoveWhitespace(string stringToClear)
        {
            return new string(stringToClear.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        private void ReserveBytesAndPad(string acessCardNumber)
        {
            char[] charArray = acessCardNumber.ToCharArray();
            Array.Reverse(charArray);
            string product = new string(charArray);

            while (product.Length < 16)
            {
                product = "0" + product;
            }

            changeCardNumber(product);
        }

        private bool verifyHexadecimal(string acessCardNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(acessCardNumber, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
