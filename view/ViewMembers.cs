using System;
using System.Collections.Generic;
using System.Text;

namespace dv607workshop2.view
{
    /// <summary>
    /// renders compact and verbose list
    /// </summary>
    public class ViewMembers
    {

        public void CompactList(List<models.Member> Members)
        {

            Dictionary<string, int> table = (Dictionary<string, int>)BuildCompactTable(Members);
            StringBuilder row = BuildTableRow(table["rowLength"]);

            Console.WriteLine(row);
            RenderCompactHeader(table);
            Console.WriteLine(row);

            foreach (models.Member member in Members)
            {
                StringBuilder cellRow = new StringBuilder();

                StringBuilder nameCell = BuildCell(table["nameCellLength"], member.Name);
                StringBuilder idCell = BuildCell(table["idCellLength"], member.MemberId);

                StringBuilder nBoatCell = BuildCell(table["nBoatCellLength"], member.Boats.Count.ToString());

                cellRow.Append(nameCell);
                cellRow.Append(idCell);
                cellRow.Append(nBoatCell);

                Console.WriteLine(cellRow);
                Console.WriteLine(row);
            }
        }

        internal void DisplayMember(string name, long personalNumber)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Personal Number" + personalNumber);
        }

        public void ChooseMemberToViewConsole()
        {
           Console.WriteLine("--------");
            Console.WriteLine("Enter Member to View");
        }


        public void VerboseList(models.Member member)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Name: " + member.Name + ", " +"Personal Numeber:" + member.PersonalNumber);
            Console.WriteLine("------Boats-----");
            foreach (models.Boat boat in member.Boats) {
                Console.WriteLine("Type: " + boat.Type + ", " + "View Length: " + boat.Length);
            }
        }



        private StringBuilder BuildCell(int cellLength, string cellValue)
        {
            StringBuilder cell = new StringBuilder();

            int loopInt = cellLength - cellValue.Length;
            cell.Append("| ");
            cell.Append(cellValue);
            for (int i = 0; i <= loopInt; i++)
            {
                cell.Append(" ");
            }

            return cell;
        }

        private void RenderCompactHeader(Dictionary<string, int> table)
        {
            StringBuilder cellRow = new StringBuilder();

            StringBuilder nameCell = BuildCell(table["nameCellLength"], "Name");
            StringBuilder idCell = BuildCell(table["idCellLength"], "ID");

            StringBuilder nBoatCell = BuildCell(table["nBoatCellLength"], "Boats");

            cellRow.Append(nameCell);
            cellRow.Append(idCell);
            cellRow.Append(nBoatCell);

            Console.WriteLine(cellRow);
        }


        private StringBuilder BuildTableRow(int tableRowLength)
        {
            StringBuilder row = new StringBuilder();
            for (int i = 0; i < tableRowLength; i++)
            {
                row.Append("-");
            }

            return row;
        }


        private IDictionary<string, int> BuildCompactTable(List<models.Member> Members)
        {
            int nameCellLength = 0;
            int idCellLength = 0;
            int nBoatCellLength = 0;

            foreach (models.Member member in Members)
            {
                if (member.Name.Length > nameCellLength)
                {
                    nameCellLength = member.Name.Length;
                }

                if (member.MemberId.Length > idCellLength)
                {
                    idCellLength = member.MemberId.Length;
                }

                if (member.Name.Length > nBoatCellLength)
                {
                    nBoatCellLength = member.Name.Length;
                }

            }

            int totalCellLength = nameCellLength + 1 + idCellLength + 1 + nBoatCellLength + 1;

            Dictionary<string, int> dict = new Dictionary<string, int>
                {
                    { "rowLength", totalCellLength },
                    { "nameCellLength", nameCellLength },
                    { "idCellLength", idCellLength },
                    { "nBoatCellLength", nBoatCellLength }
                };

            return dict;
        }

    }
}
