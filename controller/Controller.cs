using System;
using System.Collections;
using System.Collections.Generic;

namespace dv607workshop2.controller
{
    /// <summary>
    /// Controlls Model View
    /// </summary>
    public class Controller
    {
        private readonly models.XmlHandler _xmlHandler;
        private readonly view.MainView _mainView;

        public Controller( models.XmlHandler xmlHandler, view.MainView mainView) {
            _xmlHandler = xmlHandler;
            _mainView = mainView;
        }


        /// <summary>
        /// Start Application
        /// </summary>
        public void Start() {
            _mainView.Start();
            ControllRendering();
        }

        /// <summary>
        /// Meny Controll
        /// </summary>
        private void ControllRendering() 
        {
            try {
                switch (_mainView.Navigator())
                {
                    case view.CommandsEnum.add_new_member:
                        AddNewMember();
                        break;

                    case view.CommandsEnum.display_member_compact:
                        DisplayCompactList();
                        break;

                    case view.CommandsEnum.display_member_verbose:
                        DisplayVerboseList();
                        break;

                    case view.CommandsEnum.delete_member:
                        DeleteMember();
                        break;

                    case view.CommandsEnum.delete_boat:
                        DeleteBoat();
                        break;

                    case view.CommandsEnum.update_member:
                        UpdateMember();
                        break;

                    case view.CommandsEnum.add_new_boat:
                        NewBoat();
                        break;

                    case view.CommandsEnum.update_boat:
                        UpdateBoat();
                        break;

                    case view.CommandsEnum.specific_member:
                        SpecificMember();
                        break;
                    default:
                        break;

                }

            } catch (ArgumentException e) {
                _mainView.DisplayExceptionMessage(e.Message);
            } finally {
                Start();
            }

        }

        /// <summary>
        /// Calls Verbose list View
        /// </summary>
        private void DisplayVerboseList()
        {
            _mainView.VerboseList(_xmlHandler.Members);
        }

        /// <summary>
        /// Calls Add new member View
        /// </summary>
        private void AddNewMember()
        {
            models.Member newMember = _mainView.AddMember();
            _xmlHandler.AddMember(newMember);
        }

        /// <summary>
        /// Calls New Boat View
        /// </summary>
        private void NewBoat()
        {
            models.Boat newBoat = _mainView.AddBoat();
            models.Member Owner = _mainView.GetOwner(_xmlHandler.Members);
            Owner.AddBoat(newBoat);
            _xmlHandler.SaveUpdates();
        }

        /// <summary>
        /// Calls Compact list view
        /// </summary>
        private void DisplayCompactList()
        {
            _mainView.CompactList(_xmlHandler.Members);
        }

        /// <summary>
        /// Calls specific member view
        /// </summary>
        private void SpecificMember()
        {
            _mainView.ViewSpecificMember(_xmlHandler.Members);
        }

        /// <summary>
        /// Calls delete member View
        /// </summary>
        private void DeleteMember()
        {
            models.Member memberToDelete = _mainView.GetMemberToDelete(_xmlHandler.Members);
            _xmlHandler.DeleteMember(memberToDelete);
        }

        /// <summary>
        /// Calls delete boat View
        /// </summary>
        private void DeleteBoat()
        {
            models.Member member = _mainView.GetOwner(_xmlHandler.Members);
            models.Boat BoatToDelete = _mainView.DeleteBoat(member);
            member.DeleteBoat(BoatToDelete);
            _xmlHandler.SaveUpdates();
        }

        /// <summary>
        /// Calls update member View
        /// </summary>
        private void UpdateMember()
        {
            _mainView.UpdateMember(_xmlHandler.Members);
            _xmlHandler.SaveUpdates();
        }

        /// <summary>
        /// Calls Update boat View
        /// </summary>
        private void UpdateBoat()
        {
            _mainView.UpdateBoat(_xmlHandler.Members);
            _xmlHandler.SaveUpdates();
        }

    }

}
