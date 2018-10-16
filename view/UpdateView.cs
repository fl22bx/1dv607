using System;
using System.Collections;
using System.Collections.Generic;
using dv607workshop2.models;

namespace dv607workshop2.view
{
    /// <summary>
    /// Uppdate member and boat view
    /// </summary>
    public class UpdateView
    {


        public string UpdateMemberMeny (string name, long personalNumber) {
            Console.WriteLine($"0: Do you want to change {name}");
            Console.WriteLine($"1: Do you want to change {personalNumber}");

            return Console.ReadLine();
        }

        public string GetNewName()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter New Name");
            return Console.ReadLine();
        }

        public long GetNewPersonalNumber()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("ENter new Personal Number");
            string input = Console.ReadLine();
            if (input == "")
                input = "0";
            bool isLong = long.TryParse(input, out long pNum);
            if (!isLong)
                throw new ArgumentException("Personal Number only allowed to contain numbers");
            return pNum;
        }


        public string GetNewType() {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter new Type");

            Console.WriteLine("0: SailBoat");
            Console.WriteLine("1:MotorSailer");
            Console.WriteLine("2: kayak / Canoe");
            Console.WriteLine("3: Other");
            string type = "";
            switch (Console.ReadLine()) {
                case "0":
                    type = "SailBoat";
                    break;
                case "1":
                    type = "MotorSailer";
                    break;
                case"2":
                    type = "kayak / Canoe";
                    break;
                case "3":
                    type = "Other";
                    break;

                default:
                    throw new ArgumentException("Wrong Type");
            }

            return type;
        }

        public string GetNewLenght() {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter new Length");
            Console.WriteLine("Leave blank to keep old value");

            return Console.ReadLine();
        }

        public void DisplayOwnerHeader()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter Owner of the Boat you want to change");
        }

        public void DisplayBoatsToUpdateHeader()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter Boat To Update");
        }
    }
}
