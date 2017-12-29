using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonDemo.Dialogs
{
    public partial class OptionSelectionForm : Form
    {
        public string SelectedItem { get; set; }
        public OptionSelectionForm(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }

        private void OptionSelectionForm_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            try
            {
                listView.FullRowSelect = true;
                listView.Columns[0].Width = 30;
                listView.Columns[1].Width = 200;
               
                listView.Items.Clear();

                int id = 1;
                listView.Items.Add(CreateListViewItem(id++, "Accounting"));
                listView.Items.Add(CreateListViewItem(id++, "Production"));
                listView.Items.Add(CreateListViewItem(id++, "HR"));
                listView.Items.Add(CreateListViewItem(id++, "Marketing"));
                listView.Items.Add(CreateListViewItem(id++, "Pilot"));
                listView.Items.Add(CreateListViewItem(id++, "Laundry"));
            }
            catch (Exception ex)
            {
            }
        }

        private ListViewItem CreateListViewItem(int id, string name)
        {
            ListViewItem itm = new ListViewItem(id.ToString());
            itm.SubItems.Add(name);

            return itm;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = listView.SelectedItems[0];
                SelectedItem = lvItem.SubItems[1].Text;
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = listView.SelectedItems[0];
                SelectedItem = lvItem.SubItems[1].Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
