using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotAl.Model;

 namespace NotAl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            btnGuncel.Enabled = false;
        }
        LeCahierEntities2 db = new LeCahierEntities2();
         void Listele()
        {
            listView1.Items.Clear();
            foreach (Note not in db.Notes.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = not.Note1;
                lvi.Tag = not.ID;
                listView1.Items.Add(lvi);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Note n = new Note();
            n.Note1 = txtNot.Text;

            db.Notes.Add(n);
            bool result = db.SaveChanges() > 0;
            Listele();
            MessageBox.Show(result ? "OK":"Sıkıntı Var");
            txtNot.Text = " ";
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Notes.Remove(db.Notes.Find((int)listView1.SelectedItems[0].Tag));
            bool result = db.SaveChanges() > 0;
            Listele();
            MessageBox.Show(result ? "OK":"Sıkıntı Var");

        }
        Note updtd;
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updtd = db.Notes.Find((int)listView1.SelectedItems[0].Tag);
            txtNot.Text = updtd.Note1;
            btnGuncel.Enabled = true;
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
                updtd.Note1 = txtNot.Text;
                bool result = db.SaveChanges() > 0;
                Listele();
                MessageBox.Show(result ? "OK" : "Sıkıntı Var");
                txtNot.Text = " ";
            
        }
    }
}
