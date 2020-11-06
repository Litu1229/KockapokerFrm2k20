using Kockapoker;
using KockapokerFrm2k20.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockapokerFrm2k20
{
    public partial class FrmFo : Form
    {
        private Dobas gep;
        private Dobas ember;
        private PictureBox[] gepkep;
        private PictureBox[] emberkep;
        public FrmFo()
        {
            InitializeComponent();
            gepkep = new PictureBox[5] { pbGep1, pbGep2, pbGep3, pbGep4, pbGep5 };
            emberkep = new PictureBox[5] { pbEmber1, pbEmber2, pbEmber3, pbEmber4, pbEmber5 };
            gep = new Dobas();
            ember = new Dobas();

            lblEmberReszEredmeny.Text = "";
            lblGepReszEredmeny.Text = "";
            lblGeperedmeny.Text = "";
            lblEmbereredmeny.Text = "";
        }
        private void KepElhelyez(PictureBox pb, int szam)
        {
            switch (szam)
            {
                case 1:
                    pb.Image = Resources.egy;
                    break;
                case 2:
                    pb.Image = Resources.ketto;
                    break;
                case 3:
                    pb.Image = Resources.harom;
                    break;
                case 4:
                    pb.Image = Resources.negy;
                    break;
                case 5:
                    pb.Image = Resources.ot;
                    break;
                case 6:
                    pb.Image = Resources.hat;
                    break;
                default:
                    break;
            }
        }
        private void DobasMegjelenit(Dobas d,PictureBox[] kepek)
        {
            for (int i = 0; i < 5; i++)
            {
                KepElhelyez(kepek[i], d.Kockak[i]);
            }
        }
        private void btnDobas_Click(object sender, EventArgs e)
        {
            gep.EgyDobas();
            ember.EgyDobas();
            DobasMegjelenit(gep,gepkep);
            DobasMegjelenit(ember,emberkep);

            lblEmberReszEredmeny.Text = ember.Eredmeny;
            lblGepReszEredmeny.Text = gep.Eredmeny;

            if (gep.Pont > ember.Pont)
            {
                MessageBox.Show("Gép nyert!", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gep.Nyert++;
                lblGeperedmeny.Text = gep.Nyert.ToString();
            }
            else if (gep.Pont < ember.Pont)
            {
                MessageBox.Show("Ember nyert!", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ember.Nyert++;
                lblEmbereredmeny.Text = ember.Nyert.ToString();
            }
            else
            {
                MessageBox.Show("Döntetlen!", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
