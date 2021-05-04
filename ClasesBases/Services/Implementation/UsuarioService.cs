using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClasesBases.Services.Interfaces;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Commons;
using ClasesBases.Business;

namespace ClasesBases.Services.Implementation
{
    public class UsuarioService : IService<Usuario>
    {
        private IUnitOfWork _unitOfWork;

        public UsuarioService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Usuario entity)
        {
            Response response = new Response();
            try
            {
                if (Validate.ValidarUsuario(entity))
                {
                    _unitOfWork.Usuarios.Add(entity);
                    response.Status = true;
                    response.Msg = "Usuario agregado correctamente";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Algunos campos presentan errores";
                }

            }
            catch (Exception error)
            {
                response.Status = false;
                response.Msg = "ERROR: " + error.Message;// se adapta a los distintos errores de la base de datos 
                response.Data = null;
                //_unitOfWork.Usuarios.closeConexion();//solo en caso de error en la base de datos se debe cerrar la conexion ya que
                //entro a una exepcion y no dejo que se termine ejecutar la query por lo tanto no llego a ejecutar la conexion.close()
            }
            return response;
        }

        public Response Update(Usuario entity)
        {
            Response response = new Response();
            try
            {
                if (Validate.ValidarUsuario(entity))
                {
                    _unitOfWork.Usuarios.Update(entity);
                    response.Status = true;
                    response.Msg = "Usuario modificado correctamente";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Algunos campos presentan errores";
                }
            }
            catch (Exception error)
            {
                response.Status = false;
                response.Msg = "ERROR: " + error.Message;
                response.Data = null;
                _unitOfWork.Usuarios.closeConexion();
            }
            return response;
        }

        public Response Delete(Usuario entity)
        {
            Response response = new Response();
            try
            {
                if (Validate.ValidarUsuarioEnSesion(entity))
                {
                    _unitOfWork.Usuarios.Delete(entity);
                    response.Status = true;
                    response.Msg = "Usuario eliminado correctamente";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Usuario en sesion Imposible eliminar";
                }
            }
            catch (Exception error)
            {
                response.Status = false;
                response.Msg = "ERROR: " + error.Message;
                response.Data = null;
            }
            return response;
        }

        public Response GetAll()
        {
            Response response = new Response();
            try
            {
                response.Status = true;
                response.Msg = "Listado de Usuarios";
                response.Data = _unitOfWork.Usuarios.GetAll();
            }
            catch (Exception error)
            {
                response.Status = false;
                response.Msg = "ERROR: " + error.ToString();
                response.Data = null;
            }
            return response;
        }
    }
}
