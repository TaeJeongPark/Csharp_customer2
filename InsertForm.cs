using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        string connStr;         // DB에 연결 문자열 정보를 저장할 변수
        SqlConnection conn;     // DBMS 연결 객체
        SqlCommand cmd;         // sql 명령어 관리 객체
        SqlDataReader reader;   // 조회 객체

        private void InsertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmd.Clone();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            connStr = "Server=localhost\\SQLEXPRESS;Database=CookDB;Trusted_Connection=True;";
            conn = new SqlConnection(connStr);
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO member VALUES ('" + tb_id.Text.Trim() + "', '" + tb_name.Text.Trim() + "', '" + tb_email.Text.Trim() + "', " + tb_birth.Text.Trim() + ")";
            cmd.ExecuteNonQuery();

            MessageBox.Show("아이디(" + tb_id.Text.Trim() + ")가 잘 입력되었습니다. 창이 닫힙니다.");
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
