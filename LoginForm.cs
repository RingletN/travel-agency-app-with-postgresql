using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COURSACH_APP_WITH_SQL
{
    public partial class LoginForm : Form
    {
        private DB db;
        public LoginForm()
        {
            db = new DB();
            InitializeComponent();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor= Color.FromArgb(6, 5, 46);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(153, 180, 209); 
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = passField.Text;
            

            if (loginUser=="administrator" && passUser == "administrator")
            {
                //переход к окну для администратора
                adminForm adminForm = new adminForm();
                adminForm.Show();
            }
            else if (loginUser == "manager" && passUser == "manager")
            {
                //переход к окну для менеджера
                managerForm managerForm = new managerForm();
                managerForm.Show();
            }
            else if (loginUser == "client")
            {
               
        //проверяем passUser, есть ли клиент с таким айди, если да то перекидываем к окну для клиента и запоминаем его айди
        DataTable data = db.ExecuteQuery($"SELECT * FROM Client WHERE client_id = {passUser}");
                if (data.Rows.Count > 0)
                {
                    Console.WriteLine($"Клиент с ID={passUser} найден.");
                    //переход к окну для клиента с указанным айди в пароле
                    clientForm clientForm = new clientForm(passUser);
                    clientForm.Show();
                }
                else
                {
                    MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            guestForm guestForm = new guestForm();
           guestForm.Show();
        }
    }
}
