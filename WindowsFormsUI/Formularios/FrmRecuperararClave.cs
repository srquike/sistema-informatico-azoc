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

        private bool VerificarPreguntas(Usuario usuario)
        {
            string respuesta1 = TxtPregunta1.Text;
            string respuesta2 = TxtPregunta2.Text;
            string respuesta3 = TxtPregunta3.Text;

            if (respuesta1 != usuario.Respuesta1)
            {
                ErrPControles.SetError(TxtPregunta1, "La respuesta es incorrecta!");
            }
            else
            {
                ErrPControles.Clear();

                if (respuesta2 != usuario.Respuesta2)
                {
                    ErrPControles.SetError(TxtPregunta2, "La respuesta es incorrecta!");
                }
                else
                {
                    ErrPControles.Clear();

                    if (respuesta3 != usuario.Respuesta3)
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
            if (ValidarPreguntas() && ValidarNombre())
            {
                string nombre = MTxtNombre.Text;               

                Usuario usuario = _usuarioLogic.FindByName(nombre);

                if (VerificarPreguntas(usuario))
                {
                    GbNuevaClave.Enabled = true;
                    BtnGuardar.Enabled = true;
                }
            }
        }
    }
}