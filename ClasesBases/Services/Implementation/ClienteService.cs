using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Services.Interfaces;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Commons;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Services.Extension;
using ClasesBases.Business;
namespace ClasesBases.Services.Implementation
{
    public class ClienteService: IService<Cliente>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private Response response;
        

        public ClienteService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Cliente entity)
        {
            response = new Response();
            try
            {
                if (Validate.validarCliente(entity))
                {
                    _unitOfWork.Clientes.Add(entity);
                    response.Status = true;
                    response.Msg = "Cliente registrado con exito";
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
            }
            return response;
        }

        public Response Update(Cliente entity)
        {
            response = new Response();
            try
            {
                if (Validate.validarCliente(entity))
                {
                    _unitOfWork.Clientes.Update(entity);
                    response.Status = true;
                    response.Msg = "Cliente Modificado con exito";
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
            }
            return response;
        }

        public Response Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            Response response = new Response();
            /*try
            {
                response.Status = true;
                response.Data = ClienteMapper.ToCliente(_unitOfWork.Clientes.GetLastClient());
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error al conectar a la Base de Datos...";
                response.Data = null;
            }*/
            return response;
        }

        public Response GetLastClient()
        {
            Response response = new Response();
            try
            {
                response.Status = true;
                response.Data = ClienteMapper.ToCliente(_unitOfWork.Clientes.GetLastClient());
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error al conectar a la Base de Datos...";
                response.Data = null;
            }
            return response;
        }
    }
}
