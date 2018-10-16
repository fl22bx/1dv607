using System;
using System.Collections.Generic;
using dv607workshop2.models;

namespace dv607workshop2.view
{
    /// <summary>
    /// Renders delete member and boat view
    /// </summary>
    public class DeleteView
    {
        public void DisplayAllMembersHeader()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Choose wich member");
            Console.WriteLine("-----------");
        }


        public void DisplayBoatToDeleteHeader()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Enter Boat to Delete");
        }

    }
}
