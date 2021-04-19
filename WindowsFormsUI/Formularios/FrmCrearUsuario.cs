﻿using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmCrearUsuario : Form
    {
        private EmpleadoBLL _empleado;
        private UsuarioBLL _usuario;
        private PermisoUsuarioBLL _permisoUsuario;

        public FrmCrearUsuario()
        {
            InitializeComponent();

            _empleado = new EmpleadoBLL();
            _usuario = new UsuarioBLL();
            _permisoUsuario = new PermisoUsuarioBLL();
        }

        private void LlenarComboBoxEmpleados()
        {
            var empleados = _empleado.List();
            var nombres = (from empleado in empleados
                           select new
                           {
                               Nombre = $"{empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.TercerNombre} {empleado.PrimerApellido} {empleado.SegundoApellido} {empleado.TercerApellido} ",
                               Id = empleado.EmpleadoId
                           }).ToList();

            CmbEmpleados.DisplayMember = "Nombre";
            CmbEmpleados.DataSource = nombres;
            CmbEmpleados.ValueMember = "Id";
        }

        private void AgregarPermisos(int usuarioId)
        {
            PermisoUsuario permisoUsuario;

            foreach (CheckBox check in GrpPermisos.Controls)
            {
                if (check.CheckState == CheckState.Checked)
                {
                    permisoUsuario = new PermisoUsuario
                    {
                        PermisoId = int.Parse(check.Tag.ToString()),
                        UsuarioId = usuarioId
                    };

                    if (_permisoUsuario.Create(permisoUsuario) == false)
                    {
                        MessageBox.Show("No se pudo agregar el permiso al usuario.");
                    }
                }
            }
        }

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {
            LlenarComboBoxEmpleados();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Nombre = MTxtUsuario.Text.Replace("-", ""),
                Clave = TxtClave.Text,
                FechaCreacion = DateTime.Today,
                UltimoAcceso = DateTime.Now,
                EmpleadoId = int.Parse(CmbEmpleados.SelectedValue.ToString())
            };

            if (ChkActivarUsuario.Checked)
            {
                usuario.Estado = '1';
            }
            else
            {
                usuario.Estado = '0';
            }

            if (_usuario.Create(usuario))
            {
                AgregarPermisos(usuario.UsuarioId);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo crear el usuario.");
            }
        }

        private void ChkVerClaves_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked)
            {
                TxtClave.UseSystemPasswordChar = false;
                TxtRepetirClave.UseSystemPasswordChar = false;
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
                TxtRepetirClave.UseSystemPasswordChar = true;
            }
        }

        private void BtnElegirImagen_Click(object sender, EventArgs e)
        {
            if (OfdElegirAvatar.ShowDialog() == DialogResult.OK)
            {
                PctAvatar.ImageLocation = OfdElegirAvatar.FileName;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
