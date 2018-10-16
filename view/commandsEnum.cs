using System;
using System.ComponentModel;

namespace dv607workshop2.view
{
    public enum CommandsEnum
    {
        [Description("Add New Member")]
        add_new_member,
        [Description("Delete Member")]
        delete_member,
        [Description("Display verbose List of Members")]
        display_member_verbose,
        [Description("Display Compact List of Mebers")]
        display_member_compact,
        [Description("Update Member")]
        update_member,
        [Description("Add new Boat")]
        add_new_boat,
        [Description("Update Boat")]
        update_boat,
        [Description("View Specific Member")]
        specific_member,
        [Description("Delete Boat")]
        delete_boat


    }
}
