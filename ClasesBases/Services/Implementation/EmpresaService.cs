using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Services.Interfaces;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Commons;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Business;

namespace ClasesBases.Services.Implementation
{
    public class EmpresaService : IService<Empresa>
    {
        private readonly IUnitOfWork _unitOfWork;
        private Response response;

        public EmpresaService()
        {
            _unitOfWork = new UnitOfWork();
        }


        public Response Add(Empresa entity)
        {
            response = new Response();
            try
            {
                if (Validate.validarEmpresa(entity))
                {
                    _unitOfWork.Empresas.Add(entity);
                    response.Status = true;
                    response.Msg = "Empresa registrada con exito";
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
                response.Msg = "Error en la base de datos: " + ex.Message;
                _unitOfWork.Usuarios.closeConexion();

            }
            return response;
        }

        public Response Update(Empresa entity)
        {
            response = new Response();
            try
            {
                if (Validate.validarEmpresa(entity))
                {
                    _unitOfWork.Empresas.Update(entity);
                    response.Status = true;
                    response.Msg = "Empresa modificada con exito";
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
                response.Msg = "Error en la base de datos: " + ex.Message;
                _unitOfWork.Usuarios.closeConexion();

            }
            return response;
        }

        public Response Delete(Empresa entity)
        {
            response = new Response();
            try
            {
                if (Validate.validarEmpresaSinCoches(entity))
                {
                    _unitOfWork.Empresas.Delete(entity);
                    response.Status = true;
                    response.Msg = "Empresa eliminada con exito";
                }
                else
                { 
                 response.Status = false;
                 response.Msg = "No se puede eliminar Empresas con Autobuses cargados";
                }
            }
            
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error en la base de datos: " + ex.Message;
            }
            return response;
        }

        public Response GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
