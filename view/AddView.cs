using System;
using System.Collections.Generic;
using System.Text;
using dv607workshop2.models;

namespace dv607workshop2.view
{
    /// <summary>
    /// Renders add member and boat view
    /// </summary>
    public class AddView
    {
        public string[] BoatsTypes => new string[] { "SailBoat", "MotorSailer", "kayak/Canoe", "Other" };


        public string GetNewUserName()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Add new Member");
            Console.WriteLine("Enter Name");
            return Console.ReadLine();
        }

        public long GetPersonalNumber() 
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter personal number of member");
            string input = Console.ReadLine();

            bool canConvert = long.TryParse(input, out long pNum);
            if (!canConvert)
                throw new ArgumentException("Personal Number must be numbers");
            return pNum;
        }

        public string GetNewBoatType() {
            Console.WriteLine("-----------");
            Console.WriteLine("Choose Boat Type");
            for (int i = 0; i < BoatsTypes.Length; i++) {
                Console.WriteLine($"{i}: {BoatsTypes[i]}");
            }

            bool intBool = int.TryParse(Console.ReadLine(), out int arIndex);

            if (!intBool)
                throw new ArgumentException("Not Valid Type Command");

            return BoatsTypes[arIndex];
        }


        public string GetBoatLength() {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter Lenght Of boat");
            return Console.ReadLine();
        }

        internal void EnterOwnerOfBoatHeader()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter Owner Of Boat");
        }
    }
}
