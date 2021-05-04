using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Services.Interfaces;
using ClasesBases.Commons;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Business;

namespace ClasesBases.Services.Implementation
{
    public class AutobusService:IService<Autobus>
    {
        private readonly IUnitOfWork _unitOfWork;
        private Response response;
        

        public AutobusService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Autobus entity)
        {
            response = new Response();
            try
            {
                if (Validate.ValidarAutobus(entity))
                {
                    _unitOfWork.Autobus.Add(entity);
                    response.Status = true;
                    response.Msg = "Autobus registrado con exito";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Algunos campos presentan errores";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error En la base de datos: " + ex.Message;
                _unitOfWork.Usuarios.closeConexion();//solo en caso de error en la base de datos se debe cerrar la conexion ya que
                //entro a una exepcion y no dejo que se termine ejecutar la query por lo tanto no llego a ejecutar la conexion.close()
            
            }
            return response;
        }

        public Response Update(Autobus entity)
        {
            response = new Response();
            try
            {
                if (Validate.ValidarAutobus(entity))
                {
                    _unitOfWork.Autobus.Update(entity);
                    response.Status = true;
                    response.Msg = "Autobus Modificado con exito";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Algunos campos presentan errores";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error En la base de datos: " + ex.Message;
                _unitOfWork.Usuarios.closeConexion();//solo en caso de error en la base de datos se debe cerrar la conexion ya que
                //entro a una exepcion y no dejo que se termine ejecutar la query por lo tanto no llego a ejecutar la conexion.close()
            
            }
            return response;
        }

        public Response Delete(Autobus entity)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            Response response = new Response();
            try
            {
                response.Data = _unitOfWork.Autobus.GetAll();
                response.Status = true;
                response.Msg = "Listado de Autobuses";
            }
            catch (Exception error)
            {
                response.Data = null;
                response.Status = false;
                response.Msg = "ERROR: " + error.ToString();
            }
            return response;
        }
    }
}
