using System;
namespace dv607workshop2.controller
{
    public class AddViewController
    {
        private readonly view.AddView _memberView;

        public AddViewController()
        {
            _memberView = new view.AddView();
        }

        public void AddNewMember() 
        {
           string username = _memberView.GetNewUserName();
            long personalNumber = _memberView.GetPersonalNumber();
            WriteMemberPercistanceData(username, personalNumber);
        }

        private void WriteMemberPercistanceData(string username, long personalNumber)
        {
            // todo: return cast error message if user already exist
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();
            models.Member newMember = new models.Member(username, personalNumber);
            xmlHandler.AddMember(newMember);
        }

        public void NewBoat()
        {
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();
            string BoatType = _memberView.GetNewBoatType();
            string Lenght = _memberView.GetBoatLength();
            models.Member Owner = _memberView.GetOwnerIndexOfBoat(xmlHandler.Members);

            models.Boat boat = new models.Boat(BoatType, Lenght);
            AddBoatToMember(boat, Owner);
            xmlHandler.SaveUpdates();
        }

        private void AddBoatToMember(models.Boat boat, models.Member member) {
            member.AddBoat(boat);
        }
    }
}
