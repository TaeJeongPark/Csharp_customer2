using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        string connStr;     // DB에 연결 문자열 정보를 저장할 변수
        SqlConnection conn; // DBMS 연결 객체
        SqlCommand cmd;     // sql 명령어 관리 객체

        private void SelectForm_Load(object sender, EventArgs e)
        {
            connStr = "Server=localhost\\SQLEXPRESS;Database=CookDB;Trusted_Connection=True;";
            conn = new SqlConnection(connStr);
            conn.Open();

            cmd = new SqlCommand(connStr);
            cmd.Connection = conn;

            list_member.View = View.Details;
            list_member.GridLines = true;
            int listWidth = list_member.Width;
            list_member.Columns.Add("아이디", (int)(listWidth * 0.2));
            list_member.Columns.Add("이름", (int)(listWidth * 0.3));
            list_member.Columns.Add("이메일", (int)(listWidth * 0.3));
            list_member.Columns.Add("출생연도", (int)(listWidth * 0.2));

            String data1, data2, data3, data4;

            cmd.CommandText = "SELECT * FROM member";

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                list_member.Items.Clear();
                ListViewItem item;

                while (reader.Read())
                {
                    data1 = reader.GetString(0);
                    data2 = reader.GetString(1);
                    data3 = reader.GetString(2);
                    data4 = reader.GetInt32(3).ToString();

                    item = new ListViewItem(data1);
                    item.SubItems.Add(data2);
                    item.SubItems.Add(data3);
                    item.SubItems.Add(data4);

                    list_member.Items.Add(item);
                }

                reader.Close();
            } catch
            {
                MessageBox.Show("SQL SERVER 조회 오류");
            }
            
        }

        private void SelectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void btn_sel_update_Click(object sender, EventArgs e)
        {
            if(list_member.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 아이디를 먼저 선택하세요.");
                return;
            }

            UpdateForm subForm = new UpdateForm(list_member.Items[list_member.SelectedItems[0].Index].SubItems[0].Text);
            subForm.ShowDialog();
            this.Close();
        }

        private void btn_sel_delete_Click(object sender, EventArgs e)
        {
            if (list_member.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 아이디를 먼저 선택하세요.");
                return;
            }

            DeleteForm subForm = new DeleteForm(list_member.Items[list_member.SelectedItems[0].Index].SubItems[0].Text);
            subForm.ShowDialog();
            this.Close();
        }
    }
}
