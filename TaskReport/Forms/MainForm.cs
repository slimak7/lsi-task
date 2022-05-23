using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskReport.Managers;
using TaskReport.Repos;

namespace TaskReport
{
    public partial class MainForm : Form
    {

        private ExportRepo exportsRepo;
        private DBManager dBManager;

        private DateTime dateFrom;
        private DateTime dateTo;

        public MainForm()
        {
            InitializeComponent();

            exportsRepo = new ExportRepo();
            dBManager = new DBManager();

            LoadSpacesNames();
        }

        private void LoadSpacesNames()
        {
            List<string> names = dBManager.LoadSpacesNames();

            comboBoxSpace.Items.AddRange(names.ToArray());
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string place = comboBoxSpace.SelectedItem?.ToString();

            if (place == null)
            {
                MessageBox.Show(this, "Błąd", "Wybierz lokal", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            dBManager.LoadAllExports(exportsRepo, place, dateTimePickerFrom.Value, dateTimePickerTo.Value);

            dataGridView1.Rows.Clear();

            List<List<string>> data = exportsRepo.GetAllData();

            foreach(var row in data)
            {
                dataGridView1.Rows.Add(row[1], row[2], row[3], row[4], row[5]);
            }
        }

       


    }
}
