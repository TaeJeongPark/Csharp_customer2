using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class DeleteForm : Form
    {
        string memberID;

        public DeleteForm()
        {
            InitializeComponent();
        }

        public DeleteForm(String paraID)
        {
            InitializeComponent();
            memberID = paraID;
        }

        string connStr;         // DB에 연결 문자열 정보를 저장할 변수
        SqlConnection conn;     // DBMS 연결 객체
        SqlCommand cmd;         // sql 명령어 관리 객체
        SqlDataReader reader;   // 조회 객체

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            connStr = "Server=localhost\\SQLEXPRESS;Database=CookDB;Trusted_Connection=True;";
            conn = new SqlConnection(connStr);
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM member WHERE id = '" + memberID + "'";
            reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                MessageBox.Show("아이디(" + memberID + ")는 회원이 아닙니다.");
                this.Close();
            }
            else
            {
                string data1, data2, data3, data4;

                data1 = reader.GetString(0).Trim();
                data2 = reader.GetString(1).Trim();
                data3 = reader.GetString(2).Trim();
                data4 = reader.GetInt32(3).ToString();

                tb_id.Text = data1;
                tb_name.Text = data2;
                tb_email.Text = data3;
                tb_birth.Text = data4;

                reader.Close();
            }
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            cmd.CommandText = "DELETE FROM member WHERE id = '" + tb_id.Text.Trim() + "'";
            cmd.ExecuteNonQuery();

            MessageBox.Show("아이디(" + memberID + ")가 잘 삭제되었습니다. 창이 닫힙니다.");
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
