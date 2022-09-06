using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        public TaskManager()
        {
            InitializeComponent();
            ListAllProcesses();
            timer1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void ListAllProcesses()
        {
            dataGridView1.Rows.Clear();
            Process[] AllProcess = Process.GetProcesses();
            foreach(Process p1 in AllProcess)
            {
                try
                {
                    dataGridView1.Rows.Add(p1.ProcessName, p1.Id,p1.BasePriority, p1.WorkingSet64, p1.VirtualMemorySize64, p1.SessionId);
                }
                catch (Exception)
                {
                }

            }
            txtNumPro.Text = "Processes: " + dataGridView1.Rows.Count.ToString();
        }

        public void UpdateTable()
        {
            ListAllProcesses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                Process p = Process.GetProcessById(Int32.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()));
                p.Kill();
            } catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado ningún proceso para detener.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
