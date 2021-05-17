using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMo
{
    public partial class Регистрация : Form
    {
         Model1 db = new Model1();
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Зарегистрировать_Click(object sender, EventArgs e)
        {
            // проверяем, что во все текстовые поля введены данные
            if (textBox1.Text == " " || textBox2.Text == " " ||
               textBox3.Text == " " || textBox4.Text == " "|| textBox9.Text == " ")
{
                MessageBox.Show(" Нужно задать все данные!");
                return;
            }
            if (textBox2.Text != textBox2.Text)
            {
                MessageBox.Show(" Значения паролей не совпадают!");
                return;
            }
            if ((textBox3.Text != "Администратор") && (textBox3.Text != "Менеджер А") && (textBox3.Text != " Менеджер С "));

{           MessageBox.Show(" Задана неверная роль! ");
            return;
            }
            // ищем запись пользователя с введенным логином
            Сотрудники usr = db.Сотрудники.Find(textBox1.Text);
            // если такой пользователь есть и его пароль правильный

            if (usr != null)
            {
                MessageBox.Show( " Пользователь с таким логином уже есть!");
                return;
            }
            // создаем объект Users для нового пользователя
            usr = new Сотрудники();
           // usr.ID_сотрудника = textBox9.Text;
            usr.Пароль = textBox2.Text;
            usr.Роль = textBox3.Text;
            usr.ФИО = textBox6.Text;
            usr.Логин = textBox1.Text;
            usr.Пол = textBox7.Text;
            usr.Номер_телефона = textBox4.Text;
            // добавляем новый объект в коллекцию объектов Users
            db.Сотрудники.Add(usr);
            try
            {
                // сохраняем нового пользователя в базе данных
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show( " Пользователь " +usr.ФИО +" зарегистрирован! ");
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
            return;
        }
    }
    
}
