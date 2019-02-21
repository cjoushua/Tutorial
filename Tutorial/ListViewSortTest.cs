using System.Drawing;
using System.Windows.Forms;

namespace Tutorial
{
    public class ListViewSortTest
    {
        private int CurrentSortColumn = -1;

        //default Sort value
        private bool CurrentSortDesc;

        private void ListViewColumnSort(ListView listView, int sortIndex)
        {
            //▼
            string Asc = ((char)0x25bc).ToString().PadLeft(4, ' ');

            //▲
            string Des = ((char)0x25b2).ToString().PadLeft(4, ' ');

            //using defualt sort value
            if (CurrentSortDesc == false)
            {
                CurrentSortDesc = true;
                string oldStr = listView.Columns[sortIndex].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                listView.Columns[sortIndex].Text = oldStr + Des;
            }
            else if (CurrentSortDesc == true)
            {
                CurrentSortDesc = false;
                string oldStr = listView.Columns[sortIndex].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                listView.Columns[sortIndex].Text = oldStr + Asc;
            }

            //Custom sort ▼ or ▲
            listView.ListViewItemSorter = new ListViewItemComparer(sortIndex, CurrentSortDesc);

            listView.Sort();

            //Change the sort column color
            int rowCount = listView.Items.Count;
            if (CurrentSortColumn != -1)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    listView.Items[i].UseItemStyleForSubItems = false;
                    listView.Items[i].SubItems[CurrentSortColumn].BackColor = Color.White;


                    //Change sort title 
                    if (sortIndex != CurrentSortColumn)
                        listView.Columns[CurrentSortColumn].Text = listView.Columns[CurrentSortColumn].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (listView.Items[i].SubItems.Count <= sortIndex) break;
                listView.Items[i].UseItemStyleForSubItems = false;
                listView.Items[i].SubItems[sortIndex].BackColor = Color.WhiteSmoke;
                CurrentSortColumn = sortIndex;
            }
        }

        private class ListViewItemComparer : System.Collections.IComparer
        {
            public bool SortType;

            public SortOrder order = SortOrder.Ascending;

            private readonly int Column;

            public ListViewItemComparer()
            {
                Column = 0;
            }

            public ListViewItemComparer(int column, bool sort)
            {
                Column = column;
                SortType = sort;
            }

            public int Compare(object a, object b)
            {
                if (((ListViewItem)a).SubItems.Count <= Column || ((ListViewItem)b).SubItems.Count <= Column) return -1;

                if (SortType)
                {
                    //using the string compare instance
                    return string.Compare(((ListViewItem)a).SubItems[Column].Text.Substring(0, 1), ((ListViewItem)b).SubItems[Column].Text.Substring(0, 1));
                }
                else
                {
                    return string.Compare(((ListViewItem)b).SubItems[Column].Text.Substring(0, 1), ((ListViewItem)a).SubItems[Column].Text.Substring(0, 1));
                }
            }
        }
    }
}
