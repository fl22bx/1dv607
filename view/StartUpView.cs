using System;
using System.ComponentModel;
using System.Reflection;

namespace dv607workshop2.view
{
    /// <summary>
    /// Application startup view
    /// </summary>
    public class StartUpView
    {
    
        public void StartInterfaceView()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Boat Club");
            Console.WriteLine("-----------");
            foreach (CommandsEnum commands in Enum.GetValues(typeof(CommandsEnum))) {

                FieldInfo commandMetaData = commands
                    .GetType()
                    .GetField(commands.ToString());                                     
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])commandMetaData.GetCustomAttributes(typeof(DescriptionAttribute), false);
      
                Console.WriteLine((int)commands + ":" + attributes[0].Description);

            }
        }


        public CommandsEnum GetInput()
            {
            string input = Console.ReadLine();
            bool tryparesBool = int.TryParse(input, out int number);
            if (tryparesBool == false)
                throw new ArgumentException("Not A Valid Command");

            return (CommandsEnum)number;
            }

        }
    }
