using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Data;
using ClasesBases;
using ClasesBases.Services.DTOs;
using ClasesBases.Commons;
using ClasesBases.Commons.Cache;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ImpresionPasaje.xaml
    /// </summary>
    public partial class ImpresionPasaje : Window
    {
        private TicketDto _ticket;
        

        public ImpresionPasaje()
        {
            InitializeComponent();
            _ticket = new TicketDto();
            // MessageBox.Show(dt.Rows[0][2].ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Nombre Empresa
            txbEmpresa.Text = _ticket.Servicio.Autobus.Empresa.Nombre;
            txbEmpresaG.Text = _ticket.Servicio.Autobus.Empresa.Nombre;

            //Texto Origen y Destino - PG
            txtOrigen.Text += _ticket.Servicio.TerminalOrigen.Ciudad.Ciu_Nombre;
            txtDestino.Text += _ticket.Servicio.TerminalDestino.Ciudad.Ciu_Nombre;
            txtOrigenG.Text += _ticket.Servicio.TerminalOrigen.Ciudad.Ciu_Nombre;
            txtDestinoG.Text += _ticket.Servicio.TerminalDestino.Ciudad.Ciu_Nombre;

            //Fecha Partida y Butaca - PG
            txtFechaPartida.Text += _ticket.Servicio.Ser_FechaHora;
            txtButaca.Text += _ticket.Pasaje.Pas_Asiento;
            txtFechaPartidaG.Text += _ticket.Servicio.Ser_FechaHora;
            txtButacaG.Text += _ticket.Pasaje.Pas_Asiento;

            //Datos Personales e Importe - PG
            txtCliente.Text += _ticket.Cliente.Apellido + ", " + _ticket.Cliente.Nombre;
            txtPrecio.Text += _ticket.Pasaje.Pas_Precio;
            txtPrecioG.Text += _ticket.Pasaje.Pas_Precio;

            //Tipo de Servicio y Nro Boleto - PG
            txtTipoServicio.Text += _ticket.Servicio.Autobus.TipoServicio;
            txtNroPasaje.Text += _ticket.Pasaje.Pas_Codigo.ToString("00000");
            txtTipoServicioG.Text += _ticket.Servicio.Autobus.TipoServicio;
            txtNroPasajeG.Text += _ticket.Pasaje.Pas_Codigo.ToString("00000");

            //Fecha Emision y Usuario - PG
            txtFechaOperacion.Text += _ticket.Pasaje.Pas_FechaHora;
            txtUsuario.Text += UserLoginCache.UserName;
            txtFechaOperacionG.Text += _ticket.Pasaje.Pas_FechaHora;
            txtUsuarioG.Text += UserLoginCache.UserName;

            
            
        }

        public void SetTicket(Pasaje pasaje, Servicio servicio, Cliente cliente)
        {
            _ticket.Pasaje = pasaje;
            _ticket.Servicio = servicio;
            _ticket.Cliente = cliente;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VentaDePasajes ventaPasaje = VentaDePasajes.GetInstancia();
            ventaPasaje.Close();

        }
    }
}
