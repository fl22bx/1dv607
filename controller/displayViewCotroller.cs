using System;
namespace dv607workshop2.controller
{
    public class DisplayViewController
    {
        private readonly view.OutputAllMembersToConsole _meberOutput;

        public DisplayViewController()
        {

            _meberOutput = new view.OutputAllMembersToConsole();

        }

        public void DisplayCompactList() {
            models.XmlHandler members = new models.XmlHandler();
            members.DeSerialize();
            _meberOutput.CompactList(members.Members);
        }

        public void SpecificMember()
        {
            models.XmlHandler members = new models.XmlHandler();
            members.DeSerialize();

            _meberOutput.ChooseMemberToViewConsole();
            _meberOutput.DisplayAllDeletableMembers(members.Members);
            int index = _meberOutput.GetIndex();

            _meberOutput.DisplayMember(members.Members[index].Name, members.Members[index].PersonalNumber);
            _meberOutput.DisplayBoats(members.Members[index]);
        }
    }
}
