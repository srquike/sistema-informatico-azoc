using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Logics;
using BusinessObjectsLayer.Models;

namespace WindowsFormsUI.Formularios
{
    public partial class FrmRecuperararClave : Form
    {
        private readonly UsuarioBLL _usuarioLogic;
        private Usuario _usuario;

        public FrmRecuperararClave()
        {
            InitializeComponent();

            _usuarioLogic = new UsuarioBLL();
        }

        private bool ValidarPreguntas()
        {
            if (string.IsNullOrEmpty(TxtPregunta1.Text))
            {
                ErrPControles.SetError(TxtPregunta1, "Por favor, escriba la respuesta a la pregunta 1!");
            }
            else
            {
                ErrPControles.Clear();

                if (string.IsNullOrEmpty(TxtPregunta2.Text))
                {
                    ErrPControles.SetError(TxtPregunta2, "Por favor, escriba la respuesta a la pregunta 2!");
                }
                else
                {
                    ErrPControles.Clear();

                    if (string.IsNullOrEmpty(TxtPregunta3.Text))
                    {
                        ErrPControles.SetError(TxtPregunta3, "Por favor, escriba la respuesta a la pregunta 3!");
                    }
                    else
                    {
                        ErrPControles.Clear();
                        return true;
                    }
                }
            }

            return false;
        }

        private bool VerificarPreguntas()
        {
            string respuesta1 = TxtPregunta1.Text;
            string respuesta2 = TxtPregunta2.Text;
            string respuesta3 = TxtPregunta3.Text;

            if (respuesta1 != _usuario.Respuesta1)
            {
                ErrPControles.SetError(TxtPregunta1, "La respuesta es incorrecta!");
            }
            else
            {
                ErrPControles.Clear();

                if (respuesta2 != _usuario.Respuesta2)
                {
                    ErrPControles.SetError(TxtPregunta2, "La respuesta es incorrecta!");
                }
                else
                {
                    ErrPControles.Clear();

                    if (respuesta3 != _usuario.Respuesta3)
                    {
                        ErrPControles.SetError(TxtPregunta3, "La respuesta es incorrecta!");
                    }
                    else
                    {
                        ErrPControles.Clear();
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ValidarNombre()
        {
            if (!MTxtNombre.MaskFull)
            {
                ErrPControles.SetError(MTxtNombre, "Por favor, escriba el nombre de usuario!");
            }
            else
            {
                ErrPControles.Clear();
                return true;
            }

            return false;
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            if (ValidarNombre() && ValidarPreguntas())
            {
                string nombre = MTxtNombre.Text;               

                _usuario = _usuarioLogic.FindByName(nombre);

                if (_usuario != null)
                {
                    if (VerificarPreguntas())
                    {
                        GbNuevaClave.Enabled = true;
                        BtnGuardar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe!", "Recuperación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarClaves()
        {
            if (string.IsNullOrEmpty(TxtClave.Text))
            {
                ErrPControles.SetError(TxtClave, "Por favor ingrese una clave correcta!");
            }
            else
            {
                ErrPControles.Clear();

                if (string.IsNullOrEmpty(TxtRepetirClave.Text) || TxtRepetirClave.Text != TxtClave.Text)
                {
                    ErrPControles.SetError(TxtRepetirClave, "Las claves deben ser iguales!");
                }
                else
                {
                    ErrPControles.Clear();
                    return true;
                }
            }

            return false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarClaves())
            {
                _usuario.Clave = TxtClave.Text;

                if (_usuarioLogic.Edit(_usuario, true))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error al intentar recuperar la contraseña", "Recuperación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}