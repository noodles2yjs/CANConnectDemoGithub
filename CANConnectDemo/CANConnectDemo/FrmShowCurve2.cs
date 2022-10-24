﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CANConnectDemo
{
    public partial class FrmShowCurve2 : Form
    {


        List<DataGridViewRow>datas=   new List<DataGridViewRow>();
        List<string> cols=new  List<string>();
        public FrmShowCurve2(List<DataGridViewRow> data, List<string> data1)
        {
            datas = data;
            cols = data1;
            InitializeComponent();
            Inint();
           // MessageBox.Show(datas.Count.ToString());
        }
        /// <summary>
        /// 初始化Chart
        /// </summary>
        private void Inint()
        {

            // set up chart
            var colors = new List<Color> { Color.Green, Color.Red, Color.Black };
            chart1.Series.Clear();

            // var systemStandard2 = (SystemStandard2)owner;
            // DataGridView dataGridView2 = _systemStandard2.dataGridView2;// 我需要这了有数据,不是null 这里获取不到数据,我无法初始化数据,
            for (int i = 1; i <= datas.Count; i++)
            {
                var series = chart1.Series.Add("series" + i);
                series.ChartType = SeriesChartType.Line;
                series.Color = colors[i - 1];
            }

            // fill in all the values from the dgv to chart 

            for (int i = 0; i < datas.Count; i++)
            {
                chart1.Series[i].XAxisType = AxisType.Primary;
               // chart1.ChartAreas[0].AxisX.;
                for (int j = 1; j < cols.Count; j++)
                {
                    Console.WriteLine(datas[i].Cells[j].Value);
                    chart1.Series[i].Points.AddXY(cols[j], double.Parse(datas[i].Cells[j].Value.ToString()));
                }
            }
            /*var owner = this.Owner;
            if (owner == null)
            {ying
                //var systemStandard2 = (SystemStandard2) owner;
                DataGridView dataGridView2 = _systemStandard2.dataGridView2;
                for (int i = 1; i <= dataGridView2.Rows.Count; i++)
                {
                    var series = chart1.Series.Add("series" + i);
                    series.ChartType = SeriesChartType.Line;
                    series.Color = colors[i - 1];
                }
           
                // fill in all the values from the dgv to chart 

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 1; j < dataGridView2.ColumnCount; j++)
                    {
                        chart1.Series[i].Points.AddXY(dataGridView2.Columns[j].HeaderText, dataGridView2[i, j]);
                    }

                }
            }*/
        }
       

    }



}