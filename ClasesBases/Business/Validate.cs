using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Commons.Cache;
using System.Data;

namespace ClasesBases.Business
{
    public class Validate
    {
        private static IUnitOfWork _unitOfWork = new UnitOfWork();
        public static bool ValidarAutobus(Autobus _autobus)
        {

            return _autobus["Capacidad"] == null && _autobus["TipoServicio"] == null && _autobus["Matricula"] == null && _autobus["Codigo"] == null;
        }

        public static bool ValidarUsuario(Usuario _usuario)
        {
            return _usuario["ApellidoNombre"] == null && _usuario["Contraseña"] == null && _usuario["NombreUsuario"] == null && _usuario["Email"]==null;
        }
        public static bool ValidarUsuarioEnSesion(Usuario _usuario)
        {
            return UserLoginCache.Id != _usuario.ID;
        }

        public static bool validarCliente(Cliente _cliente)
        {
            return _cliente["Apellido"] == null && _cliente["Dni"] == null && _cliente["Nombre"] == null && _cliente["Telefono"] == null && _cliente["Email"] == null;
        }
        public static bool validarEmpresa(Empresa _empresa)
        {
            return _empresa["Empresa"] == null && _empresa["Codigo"] == null && _empresa["Nombre"] == null && _empresa["Direccion"] == null && _empresa["Telefono"] == null && _empresa["Email"] == null;
        }
        public static bool validarEmpresaSinCoches(Empresa _empresa) {
            if (_unitOfWork.Autobus.FindByEmpresas(_empresa.Codigo).Rows.Count > 0)
                return false;
            else
                return true;
        }
        public static bool validarPasajeNoVencido(Servicio servicio) {

            if (servicio.Ser_FechaHora > DateTime.Now)
                return true;//todavia no partio el viaje
            else
                return false;
            
        }
        public static bool validarServicioSinPasajes(DataTable dtPasajes) {

            if (dtPasajes.Rows.Count == 0)
                return true;
            else
                return false;
        }

        public static bool validarServicio(Servicio servicio)
        {
            return servicio["Ser_FechaHora"] == null;
        }
        public static bool validarDestinos(Servicio servicio)
        {
            return servicio.Ter_Codigo_Destino != servicio.Ter_Codigo_Origen;
        }

        public static bool validarBus(Servicio servicio)
        {
          
            return _unitOfWork.Servicios.FindServiceByDate(servicio).Rows.Count==0;
        }
    }
}
