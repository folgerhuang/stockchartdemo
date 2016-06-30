using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockChartDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseData1.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.databaseData.Stock);
            // TODO: This line of code loads data into the 'databaseData.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.databaseData.Stock);
            // TODO: This line of code loads data into the 'databaseData.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.databaseData.Stock);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                stockBindingSource.EndEdit();
                stockTableAdapter.Update(databaseData.Stock);
                dataGridView1.Refresh();
                MessageBox.Show("your data has been saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(),"message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            chart.Series["Daily"].XValueMember = "Day";
            chart.Series["Daily"].YValueMembers = "High,Low,Open,Close";
            chart.Series["Daily"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart.Series["Daily"].CustomProperties = "PriceDownColor=Green,PriceUpColor=Red";
            chart.Series["Daily"]["ShowOpenClose"] = "Both";
            chart.DataManipulator.IsStartFromFirst = true;
            chart.DataSource = databaseData.Stock;
            chart.DataBind();

        }
    }
}
