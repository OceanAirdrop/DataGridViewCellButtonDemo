using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewButtonDemo
{
    public partial class Form1 : Form
    {
        MyCellButton m_myCellButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dataGridView);
            PopulateDataGridView(dataGridView);
            SetupSmartButtonCtrl();
        }

        public void StyleDataGridView(DataGridView dgv)
        {
            try
            {
                dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                dgv.DefaultCellStyle.Font                   = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.CellBorderStyle                         = DataGridViewCellBorderStyle.Single;
                dgv.ColumnHeadersBorderStyle                = DataGridViewHeaderBorderStyle.Single;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
                dgv.DefaultCellStyle.BackColor              = Color.Empty;
                dgv.AllowUserToAddRows                      = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PopulateDataGridView(DataGridView dgv)
        {
            AddToDataGridView(1, "Chris", "Barrie", "HR", "band 2", false, "Below Average");
            AddToDataGridView(2, "Craig", "Charles", "Reception", "band 3", false, "Meh");
            AddToDataGridView(3, "Danny", "John Jules", "Pilot", "band 1", false, "Needs Improvement");
            AddToDataGridView(4, "Robert", "Llewellyn", "Laundry", "band 3", false, "Awesome");
        }

        private void AddToDataGridView(int id, string firstName, string lastName, string dept, string salaryBand, bool isManager, string perfScore)
        {
            int nNewRow = dataGridView.Rows.Add();

            int nColCount = 0;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = id;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = firstName;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = lastName;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = dept;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = salaryBand;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = isManager;
            dataGridView.Rows[nNewRow].Cells[nColCount++].Value = perfScore;
        }

        private void SetupSmartButtonCtrl()
        {
            m_myCellButton = new MyCellButton(dataGridView);
            m_myCellButton.SetupButtonImage(global::DataGridViewButtonDemo.Properties.Resources.bullet_red16);
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            m_myCellButton?.DisplayCellButton(e.ColumnIndex, e.RowIndex);
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView.Focused == false)
            {
                // Hide the cell button!
                m_myCellButton?.HideCellButton();
            }
        }
    }
}
