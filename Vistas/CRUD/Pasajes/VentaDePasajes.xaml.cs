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
using System.Collections;
using ClasesBases.Services.DTOs;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;
using System.Data;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Services.Extension;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentaDePasajes.xaml
    /// </summary>
    public partial class VentaDePasajes : Window
    {
       /* private static Brush ASIENTO_SELECCIONADO = (Brush) new BrushConverter().ConvertFrom("#007BFF");
        private static Brush ASIENTO_LIBRE = (Brush)new BrushConverter().ConvertFrom("#43a047");
        private static Brush ASIENTO_OCUPADO = (Brush)new BrushConverter().ConvertFrom("#c62828");
        */
        private Servicio _servicio;
        private ClienteService _clienteService;
        private PasajeSevice _pasajeService;
        private Cliente _cliente;
        private Pasaje _pasaje;
        private IUnitOfWork _unitOfWork;

        private List<PasajeDto> _pasajes;

        private Button boton;
        private static ImageBrush ASIENTO_OCUPADO= new ImageBrush();
        private static ImageBrush ASIENTO_SELECCIONADO = new ImageBrush();
        private static ImageBrush ASIENTO_DISPONIBLE = new ImageBrush();
        
        private static VentaDePasajes instancia;

        public static VentaDePasajes GetInstancia()
        {
            if (instancia == null)
                instancia = new VentaDePasajes();
            return instancia;
        }

        public VentaDePasajes()
        {
            InitializeComponent();
            _servicio = new Servicio();
            _clienteService = new ClienteService();
            _pasajeService = new PasajeSevice();
            _unitOfWork = new UnitOfWork();
            ASIENTO_DISPONIBLE.ImageSource = new BitmapImage(new Uri(@"..\..\resources\asiento_verde.png", UriKind.Relative));
            ASIENTO_SELECCIONADO.ImageSource = new BitmapImage(new Uri(@"..\..\resources\asiento_azul.png", UriKind.Relative));
            ASIENTO_OCUPADO.ImageSource = new BitmapImage(new Uri(@"..\..\resources\asiento_rojo.png", UriKind.Relative));

        }

     

        private void cargarAsientos() {
            for (int i = 1; i <= _servicio.Autobus.Capacidad; i++)
            {
                crearBoton( i.ToString());
            }
        }

        private void ClearSelected()
        {
            foreach (Button b in wrapPanel1.Children)
            {
                if (b.Background == ASIENTO_SELECCIONADO)
                    b.Background = ASIENTO_DISPONIBLE;
            }
            foreach (Button b in wrapPanel2.Children)
            {
                if (b.Background == ASIENTO_SELECCIONADO)
                    b.Background = ASIENTO_DISPONIBLE;
            }
        }

        private void mostrarMensajes(object sender, EventArgs e)
        {
            
            //int nro = Int32.Parse(boton.Name);
            boton = (Button)sender;
            if (boton.Background == ASIENTO_OCUPADO)
            {
                MessageBox.Show("Asiento no disponible: ","Venta de Pasajes",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else {
                //MessageBox.Show("Nro asiento: " +boton.Content);
                ClearSelected();
                boton.Background = ASIENTO_SELECCIONADO;
                MessageBox.Show("Ustede selecciono el asiento nro: "+boton.Content, "Venta de Pasajes", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instancia = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidarAsiento(int asiento)
        {
            foreach (PasajeDto pasaje in _pasajes)
                if (asiento == pasaje.NroAsiento)
                    return true;
            return false;
        }

        private void crearBoton(string nombre)
        {
             Button btn = new Button();
            btn.Width = 50;
            btn.Height = 50;
            btn.Background = ASIENTO_DISPONIBLE;
            //btn.BorderBrush = Brushes.Transparent;
            btn.Click += new RoutedEventHandler(mostrarMensajes);
            btn.MouseEnter += new MouseEventHandler(toolTip);
            btn.Content = nombre;
            btn.FontSize = 12;
            //btn.FontWeight = FontWeights.Bold;
            btn.Foreground = Brushes.Yellow;
            darBordes(btn);//para dejar el espacio del pasillo
            if (ValidarAsiento(Int32.Parse(nombre)))
                btn.Background = ASIENTO_OCUPADO;

            llenarWraps(btn);
        }

        private void darBordes(Button boton)
        {
            if (Convert.ToInt32(boton.Content) % 2 == 0)
            {
                boton.Margin = new Thickness(5, 5, 40, 5);
            }
            else { boton.Margin = new Thickness(5, 5, 5, 5); }
        }

        private void llenarWraps(Button btn)
        {

            if (wrapPanel1.Children.Count == 40)
            {
                wrapPanel2.Children.Add(btn);
            }
            else { wrapPanel1.Children.Add(btn); }
        }

      
    


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            determinarScroll();
            DataTable dt = (DataTable) _pasajeService.GetPasajesByServicio(_servicio.Ser_Codigo).Data;
            _pasajes = new List<PasajeDto>();

            foreach (DataRow row in dt.Rows)
            {
                PasajeDto pasaje = new PasajeDto();
                pasaje.Codigo = (int) row["PAS_Codigo"];
                pasaje.NroAsiento = (int) row["PAS_Asiento"];
                pasaje.FechaHoraOperacion = (DateTime) row["PAS_FechaHora"];
                pasaje.Cliente.Id = (int) row["CLI_Id"];
                pasaje.Cliente.Apellido = row["CLI_Apellido"].ToString();
                pasaje.Cliente.Nombre = row["CLI_Nombre"].ToString();

                pasaje.Cliente.Dni = Convert.ToInt32(row["CLI_Dni"].ToString());
                _pasajes.Add(pasaje);
            }

            cargarAsientos();
            countSeats();
        }

        private void countSeats()
        {
            txtCantOcupados.Text = _pasajes.Count.ToString();
            txtCantDisponibles.Text = (_servicio.Autobus.Capacidad-_pasajes.Count).ToString();
            
        }

        private void determinarScroll()
        {
            if (_servicio.Autobus.Capacidad <= 32)
            {
                scrll.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else {
                scrll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            }
        }

        private void limpiarWraps() 
        {
            wrapPanel1.Children.Clear();
            wrapPanel2.Children.Clear();
           
        }

        public void SetServicio(Servicio servicio)
        {
            _servicio = servicio;
            txtOrigen.Text = servicio.TerminalOrigen.Ciudad.Ciu_Nombre;
            txtDestino.Text = servicio.TerminalDestino.Ciudad.Ciu_Nombre;
            txtFecha.Text = servicio.Ser_FechaHora.ToString();
            txtCategoria.Text = servicio.Autobus.TipoServicio;
            txtCoche.Text = servicio.Autobus.Codigo.ToString();
            txtEstado.Text = servicio.Ser_Estado;
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            AltaCliente viewAltaCliente = AltaCliente.GetInstancia();
            

            viewAltaCliente.ShowDialog();
            if (viewAltaCliente._save)
            {
                _cliente = (Cliente)_clienteService.GetLastClient().Data;
               
                txtDni.Text = _cliente.Dni.ToString();
                txtApellido.Text = _cliente.Apellido;
                txtNombre.Text = _cliente.Nombre;
                txtTelefono.Text = _cliente.Telefono;
                txtEmail.Text = _cliente.Email;
            }
            
            
        }

        private void CargarDatos()
        {
            
            _pasaje = new Pasaje();
            _pasaje.Cli_Id = _cliente.Id;
            _pasaje.Ser_Codigo = _servicio.Ser_Codigo;
            _pasaje.Pas_Precio = Convert.ToInt32(txtPrecio.Text);
           
            _pasaje.Pas_Asiento = Convert.ToInt32(boton.Content);

        }

        private void btnVentaPasaje_Click(object sender, RoutedEventArgs e)
        {
           
            if (boton != null && txtDni.Text!="" && txtPrecio.Text!="")
            {
                ShowLoading();
            }
            else
                MessageBox.Show("Debe seleccionar un asiento y completar los campos vacios","Venta de pasaje",MessageBoxButton.OK,MessageBoxImage.Error);

            
        }

        private void SendTicket()
        {
            CargarDatos();
            AddPasaje();
            ImpresionPasaje print = new ImpresionPasaje();
            print.SetTicket(_pasaje, _servicio, _cliente);
            print.Show();
        }

        private void ShowLoading()
        {
            ViewBus loading = new ViewBus();
            loading.Show();
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            timer.Tick += delegate(object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (loading.IsActive) loading.Close();
                SendTicket();//retrasa esta tarea
            };

            timer.Start();
        }

        public void AddPasaje()
        {
            Response response = _pasajeService.Add(_pasaje);

            if (response.Status)
                MessageBox.Show(response.Msg, "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(response.Msg, "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void toolTip(object sender, EventArgs e)
        {
            popUp.IsOpen = false;
            
            Cliente cliTool=new Cliente();
            Button btn = (Button)sender;
            
            if (btn.Background == ASIENTO_OCUPADO)
            {
                findClient(Convert.ToInt32(btn.Content), cliTool);
                popUp.IsOpen = true;
             
                txtBlock.Text = 
                    "\n Nombre: " + cliTool.Nombre +
                    "\n Apellido: " + cliTool.Apellido +
                    "\n Dni: " + cliTool.Dni +
                    "\n"
                   ;
                //timeShow(); comentado por bugs
            }
            else {
              
                popUp.IsOpen = false;
            }


        }
        private void timeShow() {
            DispatcherTimer timer = new DispatcherTimer()
            {
             
                Interval = TimeSpan.FromSeconds(4)
            };
          
            timer.Tick += delegate(object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (popUp.IsOpen) 
                popUp.IsOpen = false;
            };

            timer.Start();
        }
        private void findClient(int butaca,Cliente cliente)
        {
            foreach (PasajeDto pdto in _pasajes) {

                if (pdto.NroAsiento == butaca) {
                    cliente.Apellido = pdto.Cliente.Apellido;
                    cliente.Nombre=pdto.Cliente.Nombre;
                    cliente.Dni = pdto.Cliente.Dni;
                }
            }
        }

        private void txtDni_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDni.Text.Length == 8)
            {
                DataTable resultado;
                resultado = _unitOfWork.Clientes.FindClientByDni(Convert.ToInt32(txtDni.Text));
                if (resultado.Rows.Count > 0)
                {
                        loadResult(resultado);
                }

            }
        }
        private void loadResult(DataTable resultado)
        {
            txtDni.Text = resultado.Rows[0]["CLI_Dni"].ToString();
            txtNombre.Text = resultado.Rows[0]["CLI_Nombre"].ToString();
            txtApellido.Text = resultado.Rows[0]["CLI_Apellido"].ToString();
            txtTelefono.Text = resultado.Rows[0]["CLI_Telefono"].ToString();
            txtEmail.Text = resultado.Rows[0]["CLI_Email"].ToString();
            _cliente = ClienteMapper.ToCliente(resultado);
        }
     

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            popUp.IsOpen = false;
            timeShow();
        }

       
    }
}
