using System;
using System.Collections.Generic;

namespace dv607workshop2.view
{
    /// <summary>
    /// Controlls wich console view to render
    /// </summary>
    public class MainView
    {
        private readonly DeleteView _deleteView;
        private readonly AddView _memberView;
        private readonly ViewMembers _memberOutput;
        private readonly StartUpView _startupView;
        private readonly UpdateView _updateView;

        public MainView()
        {
            _startupView = new StartUpView();
            _memberView = new AddView();
            _memberOutput = new ViewMembers();
            _deleteView = new DeleteView();
            _updateView = new UpdateView();
        }


        public void Start() {
           _startupView.StartInterfaceView();
        }

        /// <summary>
        /// Gets user input from navigation menue
        /// </summary>
        public CommandsEnum Navigator () {
                return _startupView.GetInput();
        }

        /// <summary>
        /// Displays all members
        /// </summary>
        private void DisplayAllMembers(List<models.Member> members)
        {
            Console.WriteLine("---Members---");
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i}: {members[i].Name} {members[i].PersonalNumber}");
            }
            Console.WriteLine("-------------");
        }

        /// <summary>
        /// Controlls add member view
        /// </summary>
        public models.Member AddMember ()
        {
            Console.Clear();
            string username = _memberView.GetNewUserName();
            long personalNumber = _memberView.GetPersonalNumber();
            models.Member newMember = new models.Member(username, personalNumber);
            return newMember;
        }

        /// <summary>
        /// Controlls add boat view
        /// </summary>
        public models.Boat AddBoat () {
            Console.Clear();
            string BoatType = _memberView.GetNewBoatType();
            string Lenght = _memberView.GetBoatLength();
            models.Boat boat = new models.Boat(BoatType, Lenght);
            _memberView.EnterOwnerOfBoatHeader();
            return boat;
        }

        /// <summary>
        /// Controlls Compact view
        /// </summary>
        public void CompactList (List<models.Member> members)
        {
            Console.Clear();
            _memberOutput.CompactList(members);
        }

        /// <summary>
        /// Controlls specific member view
        /// </summary>
        public void ViewSpecificMember (List<models.Member> members) {
            Console.Clear();
            _memberOutput.ChooseMemberToViewConsole();
            models.Member member = GetMember(members);
            _memberOutput.DisplayMember(member.Name, member.PersonalNumber);
           DisplayBoats(member);
        }

        /// <summary>
        /// Controlls verbose view
        /// </summary>
        public void VerboseList(List<models.Member> members)
        {
            foreach(models.Member member in members) {
                _memberOutput.VerboseList(member);
            }
        }

        /// <summary>
        /// Controlls update member view
        /// </summary>
        public void UpdateMember (List<models.Member> members) {
            Console.Clear();
            models.Member member = GetMember(members);
            string selectedMeny = _updateView.UpdateMemberMeny(member.Name, member.PersonalNumber);

            switch (selectedMeny) {
                case "0":
                    member.Name = _updateView.GetNewName();
                        break;
                case "1":
                    member.PersonalNumber = _updateView.GetNewPersonalNumber();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Controlls update boat view
        /// </summary>
        public void UpdateBoat (List<models.Member> members)
        {
            Console.Clear();
            _updateView.DisplayOwnerHeader();
            models.Member owner = GetMember(members);
            _updateView.DisplayBoatsToUpdateHeader();
            models.Boat boat = GetBoat(owner);

            Console.WriteLine($"0: Do you want to Change type from {boat.Type}");
            Console.WriteLine($"Do you want to change Length from {boat.Length}");

            switch (Console.ReadLine()) {
                case "0":
                    boat.Type = _updateView.GetNewType();
                        break;
                case "1":
                    boat.Length = _updateView.GetNewLenght();
                    break;

                default:
                    break;

            }
        }

        /// <summary>
        /// Controlls user to choose member
        /// </summary>
        private models.Member GetMember (List<models.Member> members)
        {

            DisplayAllMembers(members);
            int Index = GetIndex();
            return members[Index];
        }

        public models.Member GetOwner (List<models.Member> members) {
            Console.WriteLine("Enter Owner Of Boat");
            return GetMember(members);
        }

        /// <summary>
        /// Controlls delete view
        /// </summary>
        public models.Member GetMemberToDelete (List<models.Member> members)
        {
            Console.Clear();
            _deleteView.DisplayAllMembersHeader();
            return GetMember(members);
        }

        public models.Boat DeleteBoat (models.Member Owner)
        {
            Console.Clear();
            _deleteView.DisplayBoatToDeleteHeader();
            models.Boat BoatToDelete = GetBoat(Owner);
            return BoatToDelete;
        }

        /// <summary>
        /// Gets input index
        /// </summary>
        private int GetIndex()
        {
          bool isNum = int.TryParse(Console.ReadLine(), out int Index);
            if (!isNum)
                throw new ArgumentException("Must be a Number");

            return Index;
        }

        /// <summary>
        /// displays all boats
        /// </summary>
        private void DisplayBoats(models.Member owner) 
        {
            Console.WriteLine("----Boats----");
            for (int i = 0; i < owner.Boats.Count; i++)
            {
                Console.WriteLine($"{i}: Type: {owner.Boats[i].Type}, Lenght: {owner.Boats[i].Length}");
            }
            Console.WriteLine("------------");
        }

        /// <summary>
        /// Lets user choose boat
        /// </summary>
        private models.Boat GetBoat(models.Member owner) {
            DisplayBoats(owner);
            int index = GetIndex();
            return owner.Boats[index];
        }

        /// <summary>
        /// Controlls error handling
        /// </summary>
        public void DisplayExceptionMessage(string eMessage) {
            Console.WriteLine("---------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(eMessage);
            Console.ResetColor();
            Console.WriteLine("---------------");
        }
    }
}
