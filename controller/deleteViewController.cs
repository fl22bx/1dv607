using System;
namespace dv607workshop2.controller
{
    public class DeleteViewController
    {
        private readonly view.DeleteView _deleteview;

        public DeleteViewController()
        {
            _deleteview = new view.DeleteView();
        }

        public void DeleteMember()
        {

            _deleteview.DisplayAllDeletableMembers(xmlHandler.Members);
            int index = _deleteview.GetMemberIndexToDelete();

            xmlHandler.DeleteMember(xmlHandler.Members[index]);

        }

        public void DeleteBoat()
        {
            models.XmlHandler xmlHandler = new models.XmlHandler();
            xmlHandler.DeSerialize();
            models.Member member = _deleteview.GetMember(xmlHandler.Members);
            models.Boat boat = _deleteview.GetBoatToDelete(member);

            member.DeleteBoat(boat);
            xmlHandler.SaveUpdates();
        }


    }
}
