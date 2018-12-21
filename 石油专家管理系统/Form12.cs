﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 石油专家管理系统
{

    public partial class Form12 : Form
    {
        Form1 f1;
       
        public Form12(Form1 form1)
        {
            f1 = form1;
            InitializeComponent();
        }
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“石油专家DataSet._Sheet2_”中。您可以根据需要移动或删除它。
            this.sheet2_TableAdapter.Fill(this.石油专家DataSet._Sheet2_);

        }
        static string str = @"Data Source=.;Initial Catalog=石油专家;Integrated Security=True";
        SqlConnection conn = new SqlConnection(str);
        public void  newfill() //刷新
        {
            conn.Open();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select *   from Sheet2$";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
            conn.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["工程编号"] == null) return;
            string bd = Convert.ToString(row["工程编号"]);
            string sql = "delete from Sheet2$ where 工程编号 =" + bd + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int del = cmd.ExecuteNonQuery();
            if (del == 1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
            newfill();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
