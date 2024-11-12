using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Weboo.ExamenFinal;
using Weboo.ExamenFinal.Interfaces;

namespace Tester
{
    public partial class FormTester : Form
    {
        private List<string> members;

        private IJerarquia<string> jerarquia;

        public FormTester()
        {
            InitializeComponent();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxBoss.Text))
            {
                MessageBox.Show(this, "El nombre del jefe supremo no puede ser vacío.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                jerarquia = new Jerarquia<string>(tbxBoss.Text);

                members = new List<string>(new[] { tbxBoss.Text });
                gbxOrder.Enabled = true;
                gbxAssign.Enabled = true;
                tabData.Enabled = true;

                RecalculateAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalculateAll()   
        {
            dgvOrders.Rows.Clear();
            dgvStructure.Rows.Clear();

            foreach (var integrante in members)
            {
                foreach (var subordinado in members)
                {
                    try
                    {
                        if (jerarquia.EsSuperior(integrante, subordinado))
                        {
                            dgvStructure.Rows.Add(integrante, subordinado, "");
                        }
                    }
                    catch (Exception exc)
                    {
                        dgvStructure.Rows.Add(integrante, subordinado, exc.Message);
                    }
                }

                try
                {
                    if (jerarquia.TieneOrden(integrante))
                    {
                        string superior;
                        string orden = jerarquia.Orden(integrante, out superior);

                        dgvOrders.Rows.Add(integrante, true, orden, superior, "");
                    }
                    else
                    {
                        dgvOrders.Rows.Add(integrante, false, "", "", "");
                    }
                }
                catch (Exception exc)
                {
                    dgvOrders.Rows.Add(integrante, null, "", "", exc.Message);
                }
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAssignBoss.Text) || string.IsNullOrEmpty(tbxAssignSubordinate.Text))
            {
                MessageBox.Show(this, "Los nombres de jefe y subordinado no pueden estar vacíos.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                jerarquia.AsignaJefe(tbxAssignBoss.Text, tbxAssignSubordinate.Text);
                members.Add(tbxAssignSubordinate.Text);
                RecalculateAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxOrder.Text) || string.IsNullOrEmpty(tbxSuperior.Text) || string.IsNullOrEmpty(tbxSubordinate.Text))
            {
                MessageBox.Show(this, "Los nombres de jefe y subordinado y la orden no pueden estar vacíos.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                jerarquia.Ordena(tbxSuperior.Text, tbxSubordinate.Text, tbxOrder.Text);
                RecalculateAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTester_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
        }
    }
}
