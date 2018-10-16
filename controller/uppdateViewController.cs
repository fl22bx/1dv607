using System;
namespace dv607workshop2.controller
{
    public class UppdateViewController
    {
        private readonly view.UpdateView _updateView;

        public UppdateViewController()
        {
            _updateView = new view.UpdateView();
        }

        public void UpdateMember()
        {
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();
            _updateView.DisplayAllMembersToUpdate(xmlHandler.Members);
            int memberIndex = _updateView.GetMemberToUpdateIndex();

            string newName = _updateView.GetNewName();
            if (newName == "")
                newName = xmlHandler.Members[memberIndex].Name;

            long newPersonaleNumber = _updateView.GetNewPersonalNumber();
            if (newPersonaleNumber == 0)
                newPersonaleNumber = xmlHandler.Members[memberIndex].PersonalNumber;

            xmlHandler.Members[memberIndex].Name = newName;
            xmlHandler.Members[memberIndex].PersonalNumber = newPersonaleNumber;
            xmlHandler.SaveUpdates();
        }

        public void UpdateBoat() {
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();
            models.Boat boat = _updateView.GetBoatToChange(xmlHandler.Members);
            string newType = _updateView.GetNewType();
            string newLenght = _updateView.GetNewLenght();

            if(newType != "")
                boat.Type = newType;
            if(newLenght != "")
                boat.Length = newLenght;

            xmlHandler.SaveUpdates();
        }
    }
}
