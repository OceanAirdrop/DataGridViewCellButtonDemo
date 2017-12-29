using DataGridViewButtonDemo.DataGridViewCellButtonHelper;
using DataGridViewButtonDemo.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonDemo
{
    class MyCellButton : CellButtonCtrl
    {
        public enum CellButtonColumns
        {
            Department = 3,
            SalryBand = 4,
            PerfScore = 6,
        }

        public MyCellButton(DataGridView dgv) : base(dgv)
        {
            Color veryLightGrey = Color.FromArgb(248, 250, 246);

            ColourBackgroundCells(veryLightGrey);
            SetReadOnlyColumns();
        }

        private void ColourBackgroundCells(Color grey)
        {
            try
            {
                var dataGridView = GetHostDataGridViewCtrl();
                dataGridView.Columns[(int)CellButtonColumns.Department].DefaultCellStyle.BackColor = grey;
                dataGridView.Columns[(int)CellButtonColumns.SalryBand].DefaultCellStyle.BackColor = grey;
                dataGridView.Columns[(int)CellButtonColumns.PerfScore].DefaultCellStyle.BackColor = grey;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetReadOnlyColumns()
        {
            var dgv = GetHostDataGridViewCtrl();

            if (dgv.ColumnCount == 0)
                return;

            dgv.Columns[(int)CellButtonColumns.Department].ReadOnly = true;
            dgv.Columns[(int)CellButtonColumns.SalryBand].ReadOnly = true;
            dgv.Columns[(int)CellButtonColumns.PerfScore].ReadOnly = true;
        }

        public override void DisplayCellButton(int ColumnIndex, int RowIndex)
        {
            base.DisplayCellButton(ColumnIndex, RowIndex);

            this.Visible = false;
            if (ColumnIndex == (int)CellButtonColumns.Department || ColumnIndex == (int)CellButtonColumns.SalryBand || ColumnIndex == (int)CellButtonColumns.PerfScore)
            {
                //GetHostDataGridViewCtrl().CurrentCell = GetHostDataGridViewCtrl().Rows[HostDgvRowIndex].Cells[HostDgvColumnIndex];
                this.Visible = true;
            }
        }

        public override void buttonCellAction_Click(object sender, EventArgs e)
        {
            var dgv = GetHostDataGridViewCtrl();

            Console.WriteLine("Cell Button Clicked. Row: {0}, Col: {1}", HostDgvRowIndex, HostDgvColumnIndex);

            var currentVal = dgv.Rows[HostDgvRowIndex].Cells[HostDgvColumnIndex].Value.ToString();

            if (HostDgvColumnIndex == (int)CellButtonColumns.Department ) 
            {
                var form = new OptionSelectionForm(Cursor.Position);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    dgv.Rows[HostDgvRowIndex].Cells[HostDgvColumnIndex].Value = form.SelectedItem;
                    dgv.Rows[HostDgvRowIndex].Cells[HostDgvColumnIndex].Style.BackColor = Color.FromArgb(255, 199, 206);
                }
            }

            if (HostDgvColumnIndex == (int)CellButtonColumns.SalryBand)
            {
                MessageBox.Show(string.Format("Department - {0}", currentVal));
            }

            if (HostDgvColumnIndex == (int)CellButtonColumns.PerfScore)
            {
                MessageBox.Show(string.Format("PerfScore - {0}", currentVal));
            }
        }
    }
}
