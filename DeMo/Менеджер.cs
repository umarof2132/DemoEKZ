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
    public partial class Менеджер : Form
    {
        Model1 db = new Model1();
        public Менеджер()
        {
            InitializeComponent();
        }

        private void Менеджер_Load(object sender, EventArgs e)
        {
            арендаторыBindingSource.DataSource = db.Арендаторы.ToList();
        }
    }
}
