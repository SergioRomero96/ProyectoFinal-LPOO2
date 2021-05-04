using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Commons;
using ClasesBases.Services.Interfaces;
using ClasesBases.Business;
using ClasesBases.Services.Extension;

namespace ClasesBases.Services.Implementation
{
    public class PasajeSevice : IService<Pasaje>
    {
        private IUnitOfWork _unitOfWork;

        public PasajeSevice()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Pasaje entity)
        {
            Response response = new Response();
            try
            {
                entity.Pas_Codigo = _unitOfWork.Pasajes.Add(entity);
                response.Status = true;
                response.Msg = "Operacion Exitosa";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "Error, no se pudo conectar a la base de datos";
                response.Data = null;
            }
            return response;
        }

        public Response GetPasajesByServicio(int codigo)
        {
            Response response = new Response();
            try
            {
                response.Data = _unitOfWork.Pasajes.GetPasajeByServicio(codigo);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Data = null;
            }
            return response;
        }



        public Response Update(Pasaje entity)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Pasaje entity)
        {
            Response response = new Response();
            try
            {   
                Servicio servicio = new Servicio();
                servicio=ServicioMapper.ToService(_unitOfWork.Servicios.FindServeiceByCode(entity.Ser_Codigo));
                if (Validate.validarPasajeNoVencido(servicio))
                {
                    _unitOfWork.Pasajes.Delete(entity);
                    response.Status = true;
                    response.Msg = "Pasaje Cancelado Correctamente";
                }
                else
                {
                    response.Status = false;
                    response.Msg = "Nose puede cancelar pasajes que ya partieron " + 
                        "\n Partio : "+servicio.Ser_FechaHora;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Data = null;
                response.Msg = "Error en la base de datos: "+ex.Message;
            }
            return response;
        }

        public Response GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
