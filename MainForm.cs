using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm();
            select.ShowDialog();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            InsertForm insert = new InsertForm();
            insert.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(tb_updel_id.Text == "")
            {
                MessageBox.Show("수정할 아이디를 먼저 입력하세요.");
                tb_updel_id.Focus();
                return;
            }

            UpdateForm update = new UpdateForm(tb_updel_id.Text);
            update.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tb_updel_id.Text == "")
            {
                MessageBox.Show("삭제할 아이디를 먼저 입력하세요.");
                tb_updel_id.Focus();
                return;
            }

            DeleteForm delete = new DeleteForm(tb_updel_id.Text);
            delete.ShowDialog();
        }
    }
}
