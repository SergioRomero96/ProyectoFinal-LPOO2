using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Services.Interfaces;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Commons;
using System.Collections.ObjectModel;
using System.Data;
using ClasesBases.Business;

namespace ClasesBases.Services.Implementation
{
    public class ServicioService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Servicio entity,bool semanal)
        {
            Response response = new Response();
            try
            {
                if (Validate.validarServicio(entity))
                {
                    if (Validate.validarDestinos(entity))
                    {
                        if (Validate.validarBus(entity))
                        {
                            if (semanal)
                            {
                                _unitOfWork.Servicios.InsertSemanal(entity);
                            }
                            else {
                                _unitOfWork.Servicios.Add(entity);
                            }
                            response.Status = true;
                            response.Msg = "Agregado Correctamente";
                        }
                        else
                        {
                            response.Status = false;
                            response.Msg = "Este coche "+entity.Aut_Codigo+" ya esta asignado a un servicio con horario similar";
                        }
                    }
                    else
                    {
                        response.Status = false;
                        response.Msg = "Debe elegir un destino distinto del origen";
                    }
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
                response.Msg = "ERROR en la base de datos: " + ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response Update(Servicio entity)
        {
            Response response = new Response();
            try
            {
                if (Validate.validarServicio(entity))
                {
                    if (Validate.validarDestinos(entity))
                    {
                        if (Validate.validarBus(entity))
                        {
                            _unitOfWork.Servicios.Update(entity);
                            response.Status = true;
                            response.Msg = "Modificado Correctamente";
                        }
                        else
                        {
                            response.Status = false;
                            response.Msg = "Este coche " + entity.Aut_Codigo + " ya esta asignado a un servicio con horario similar";

                        }
                    }
                    else
                    {
                        response.Status = false;
                        response.Msg = "Debe elegir un destino distinto del origen";
                    }
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
                response.Msg = "ERROR en la base de datos: " + ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response Delete(Servicio entity)
        {
            Response response = new Response();
            try
            {
                if(Validate.validarServicioSinPasajes(_unitOfWork.Pasajes.GetPasajeByServicio(entity.Ser_Codigo))){
                _unitOfWork.Servicios.Delete(entity);
                response.Status = true;
                response.Msg = "Eliminado Correctamente";
                }
                else
                {
                response.Status = false;
                response.Msg = "No se puede eliminar servicios con pasajes vendidos";
                }
              
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Msg = "ERROR en la base de datos: " + ex.Message;
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
                response.Data = _unitOfWork.Servicios.GetAll();
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Msg = "ERROR: " + ex.ToString();
                response.Data = null;
            }
            return response;

        }


        public ObservableCollection<Servicio> GetAllServices()
        {
            ObservableCollection<Servicio> listServicios = new ObservableCollection<Servicio>();
            foreach (DataRow row in _unitOfWork.Servicios.GetAll().Rows)
            {
                Servicio servicio = new Servicio();
                servicio.Ser_Codigo = (int) row["SER_Codigo"];
                servicio.Ser_FechaHora = (DateTime) row["SER_FechaHora"];
                servicio.Ser_Estado = row["SER_Estado"].ToString();
                servicio.Autobus.Id = (int) row["AUT_Codigo"];
                servicio.Autobus.Codigo = (int)row["AUT_Nro"];
                servicio.Autobus.TipoServicio = row["AUT_TipoServicio"].ToString();
                servicio.Autobus.Empresa.Codigo = (int) row["EMP_Codigo"];
                servicio.Autobus.Empresa.Nombre = row["EMP_Nombre"].ToString();

                servicio.Autobus.Capacidad = (int) row["AUT_Capacidad"];
                servicio.TerminalOrigen.Ter_Id = (int) row["TER_Codigo_Origen"];
                servicio.TerminalOrigen.Ciudad.Ciu_Id = (int) row["CIU_Cod_Origen"];
                servicio.TerminalOrigen.Ciudad.Ciu_Nombre = row["CIU_Origen"].ToString();
                servicio.TerminalDestino.Ter_Id = (int) row["TER_Codigo_Destino"];
                servicio.TerminalDestino.Ciudad.Ciu_Id = (int) row["CIU_Cod_Destino"];
                servicio.TerminalDestino.Ciudad.Ciu_Nombre = row["CIU_Destino"].ToString();

                listServicios.Add(servicio);
            }
            return listServicios;
        }
    }
}
