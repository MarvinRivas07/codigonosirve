using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsFormADO.net
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
        public FrmNuevo(int? id=null)
        {
            InitializeComponent();
            this.Id = id;
        }
        private void Loaddata()
        {
            peopledb oPeopleDB = new peopledb();
            People oPeople = oPeopleDB.Get((int)Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            peopledb oPeople = new peopledb();
            try
            {
                oPeople.Add(int.Parse(txtid.Text),txtName.Text, int.Parse(txtEdad.Text));
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al guardar"+ ex.Message);
            }
        }
    }
}
