using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBases;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;

namespace Vistas.CRUD.Ciudades
{
    /// <summary>
    /// Lógica de interacción para AltaCiudad.xaml
    /// </summary>
    public partial class AltaCiudad : Window
    {
        private IUnitOfWork _unitOfWork;
        private Ciudad _ciudad;
        private Ciudad _ciudadAuxiliar;
        private bool _update = false;
        private GestionCiudades _ucGestionCiudades;
        public static AltaCiudad _instancia;
        private int _id;

        public static AltaCiudad GetInstancia()
        {
            if (_instancia == null)
                _instancia = new AltaCiudad();
            return _instancia;
        }

        public AltaCiudad()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _ciudad = new Ciudad();
            DataContext = _ciudad;
        }

        private void AgregarCiudad()
        {
            _ciudad.Ciu_Codigo = Convert.ToInt32(txtCodeAddCity.Text);
            _ciudad.Ciu_Nombre = txtNameAddCity.Text.ToUpper();
            _unitOfWork.Ciudades.Add(_ciudad);
            MostrarMensajeInformacion("Ciudad agregada con exito", "Agregar Ciudad");
        }

        private void ActualizarCiudad()
        {
            _ciudad.Ciu_Id = _id;
            _ciudad.Ciu_Codigo = Convert.ToInt32(txtCodeAddCity.Text);
            _ciudad.Ciu_Nombre = txtNameAddCity.Text.ToUpper();
            _unitOfWork.Ciudades.Update(_ciudad);
            MostrarMensajeInformacion("Ciudad actualizada con exito", "Modificar Ciudad");
        }

        private void CargarDatos()
        {
            _ciudad.Ciu_Codigo = Convert.ToInt32(txtCodeAddCity.Text);
            _ciudad.Ciu_Nombre = txtNameAddCity.Text;
        }

        private bool ValidarCamposVacios()
        {
            return txtNameAddCity.Text != "" && txtCodeAddCity.Text != "";
        }

        private bool ValidarNombreCiudad(String ciudad)
        {
            return _unitOfWork.Ciudades.ValidarNombreCiudad(ciudad).Rows.Count == 0;
        }

        private bool ValidarCodigoCiudad(int codigo)
        {
            return _unitOfWork.Ciudades.ValidarCodigoCiudad(codigo).Rows.Count == 0;
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposVacios())
            {
                CargarDatos();
                if (!_update)
                {
                    if (ValidarNombreCiudad(_ciudad.Ciu_Nombre.ToUpper()) && ValidarCodigoCiudad(_ciudad.Ciu_Codigo))
                    {
                        AgregarCiudad();
                        ObtenerInstancia();
                    }
                    else
                        MostrarMensajeError("Ya existe codigo y/o nombre de ciudad", "Agregar Ciudad");
                }
                else
                {
                    if (TieneCambio())
                    {
                        ValidarActualizar();
                    }
                    else
                    {
                        MostrarMensajeInformacion("Ciudad actualizada con exito", "Modificar Ciudad");
                        ObtenerInstancia();
                    }
                }

            }
            else
                MessageBox.Show("Algunos campos estan vacios!!", "Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ValidarActualizar()
        {
            if (EsIgualNombre())
            {
                if (ObtenerValidacionCodigo())
                {
                    ActualizarCiudad();
                    ObtenerInstancia();
                }
                else
                    MostrarMensajeError("Ya existe codigo de ciudad", "Modificar Ciudad");
            }
            else
            {
                if (EsIgualCodigo())
                {
                    if (ObtenerValidacionNombre())
                    {
                        ActualizarCiudad();
                        ObtenerInstancia();
                    }
                    else
                        MostrarMensajeError("Ya existe nombre de ciudad", "Modificar Ciudad");
                }
                else
                {
                    if (ObtenerValidacionCodigo())
                    {
                        if (ObtenerValidacionNombre())
                        {
                            ActualizarCiudad();
                            ObtenerInstancia();
                        }
                        else
                            MostrarMensajeError("Ya existe nombre de ciudad", "Modificar Ciudad");
                    }
                    else
                    {
                        if (ObtenerValidacionNombre())
                        {
                            if (ObtenerValidacionCodigo())
                            {
                                ActualizarCiudad();
                                ObtenerInstancia();
                            }
                            else
                                MostrarMensajeError("Ya existe codigo de ciudad", "Modificar Ciudad");
                        }
                        else
                        {
                            MostrarMensajeError("Ya existe codigo y/o nombre cuidad", "Modificar Ciudad");
                        }
                    }
                }
            }
        }

        private bool TieneCambio()
        {
            return _ciudadAuxiliar.Ciu_Nombre != _ciudad.Ciu_Nombre.ToUpper() || _ciudadAuxiliar.Ciu_Codigo != _ciudad.Ciu_Codigo;
        }

        private bool EsIgualNombre()
        {
            return _ciudad.Ciu_Nombre.ToUpper() == _ciudadAuxiliar.Ciu_Nombre;
        }

        private bool EsIgualCodigo()
        {
            return _ciudad.Ciu_Codigo == _ciudadAuxiliar.Ciu_Codigo;
        }

        private bool EsDistintoCodigo()
        {
            return _ciudad.Ciu_Codigo != _ciudadAuxiliar.Ciu_Codigo;
        }

        private bool EsDistintoNombre()
        {
            return _ciudad.Ciu_Nombre.ToUpper() != _ciudadAuxiliar.Ciu_Nombre;
        }

        private bool ObtenerValidacionNombre()
        {
            return ValidarNombreCiudad(_ciudad.Ciu_Nombre.ToUpper()) && EsDistintoNombre();
        }

        private bool ObtenerValidacionCodigo()
        {
            return ValidarCodigoCiudad(_ciudad.Ciu_Codigo) && EsDistintoCodigo();
        }

        private void ObtenerInstancia()
        {
            _ucGestionCiudades = GestionCiudades.GetInstance();
            _ucGestionCiudades.LoadCiudades();
            this.Close();
        }

        public void SetCiudad(Ciudad ciudad, bool update)
        {
            _ciudadAuxiliar = new Ciudad(ciudad.Ciu_Codigo, ciudad.Ciu_Nombre);
            txtbTitle.Text = "Editar Ciudad";
            _update = update;
            DataContext = ciudad;
            _id = ciudad.Ciu_Id;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelCity_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtCodeAddCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void MostrarMensajeInformacion(String mensaje, String titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MostrarMensajeError(String mensaje, String titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}