using Laboratorio3;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laboratorio3
{
    public partial class Form1 : Form
    {
        // Se cambia ArrayList por List<Persona> para compatibilidad con DataGridView
        List<Persona> listaPersonas = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona miColaborador1 = new Persona();
            miColaborador1.Id = 1;
            miColaborador1.Nombres = "Elena Carolina";
            miColaborador1.Apellidos = "González Rodríguez";
            miColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            miColaborador1.FechaNacimiento = new DateTime(1995, 5, 15);
            miColaborador1.Salario = 1500.00m;

            listaPersonas.Add(miColaborador1);

            RefrescarGrid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                errorProvider1.SetError(txtID, "Ingrese un ID");
                txtID.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtID, "");
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese los nombres del Colaborador");
                txtNombre.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Ingrese los apellidos del Colaborador");
                txtApellido.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtApellido, "");
            }

            if (!Utilidades.EsCorreoValido(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido");
                txtCorreo.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtCorreo, "");
            }

            decimal salario;
            if (!decimal.TryParse(txtSalario.Text, out salario))
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario válido");
                txtSalario.Focus();
                return;
            }
            if (salario <= 0 || salario > 100000)
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario válido");
                txtSalario.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSalario, "");
            }

            Persona colaborador1 = new Persona();
            colaborador1.Id = int.Parse(txtID.Text);
            colaborador1.Nombres = txtNombre.Text;
            colaborador1.Apellidos = txtApellido.Text;
            colaborador1.Correo = txtCorreo.Text;
            colaborador1.Salario = salario;
            colaborador1.FechaNacimiento = dtpFecha.Value;

            listaPersonas.Add(colaborador1);

            RefrescarGrid();
            LimpiarCampos();
        }

        private void RefrescarGrid()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaPersonas;
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtSalario.Clear();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}