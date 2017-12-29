using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonDemo.DataGridViewCellButtonHelper
{
    public partial class CellButtonCtrl : UserControl
    {
        DataGridView m_hostDgvCtrl = null;

        public int HostDgvColumnIndex { get; set; }
        public int HostDgvRowIndex { get; set; }

        public CellButtonCtrl(DataGridView dgv)
        {
            InitializeComponent();

            if (dgv == null) throw new ArgumentNullException("DataGridView cannot be null");

            m_hostDgvCtrl = dgv;

            SetupSmartButtonCtrl();
        }

        public DataGridView GetHostDataGridViewCtrl()
        {
            return m_hostDgvCtrl;
        }

        private void SetupSmartButtonCtrl()
        {
            try
            {
                this.Visible = false;
                m_hostDgvCtrl?.Controls.Add(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetupButtonImage(Bitmap image)
        {
            buttonCellAction.Image = image;
        }

        public virtual void DisplayCellButton(int ColumnIndex, int RowIndex)
        {
            Console.WriteLine("Ticks: {0}, Cell Button Clicked. Row: {1}, Col: {2}", DateTime.Now.Ticks, ColumnIndex, RowIndex);

            HostDgvColumnIndex = ColumnIndex;
            HostDgvRowIndex    = RowIndex;

            // Work out the location of where to display the button!
            var dgv            = GetHostDataGridViewCtrl();
            int cellHeight     = dgv.Rows[RowIndex].Height;
            int cellWidth      = dgv.Columns[ColumnIndex].Width;
            this.Height        = cellHeight - 2;
            var cellProps      = dgv.Rows[RowIndex].Cells[ColumnIndex].ContentBounds;
            var loc            = dgv.GetCellDisplayRectangle(ColumnIndex, RowIndex, true).Location;
            this.Location      = new Point(loc.X + cellWidth - (this.Width + 2), loc.Y);
            //this.Visible     = true;
        }

        public void HideCellButton()
        {
            Console.WriteLine("Hide Cell Button");
            this.Visible = false;
        }

        public virtual void buttonCellAction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("base class");
        }
    }
}
