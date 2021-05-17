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
    public partial class Form1 : Form
    {
        public static Сотрудники Сотрудники { get; set; }
        Model2 db = new Model2();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red; // изменение цвета при наведении курсора 
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Green; // изменение цвета при наведении курсора 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверяем, что в текстовые поля введены данные
            if (textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show(" Нужно задать логин и пароль!");
                return;
            }
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                Администратор frm = new Администратор();

                frm.Show();
                return;
            }

            foreach (Сотрудники users in db.Сотрудники)

                if (users != null && users.Пароль == textBox2.Text)
                {
                    if (users.Роль == "Администратор")
                    {
                        Администратор frm = new Администратор();
                        frm.Show();
                        this.Hide();
                    }
                    else if (users.Роль == "Менеджер А")
                    {
                        Менеджер form = new Менеджер();
                        form.Show();
                        this.Hide();
                    }
                    else if (users.Роль == "Менеджер C")
                    {
                        Менеджер form = new Менеджер();
                        form.Show();
                        this.Hide();
                    }
                    return;
                }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Регистрация form2 = new Регистрация(); // переход к другой форме
            form2.Show();

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Green; // изменение цвета при наведении курсора 
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Green; // изменение цвета при наведении курсора 
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Green; // изменение цвета при наведении курсора 
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red; // изменение цвета при наведении курсора 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

