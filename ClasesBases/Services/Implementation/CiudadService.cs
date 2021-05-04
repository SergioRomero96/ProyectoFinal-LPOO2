using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Services.Interfaces;
using ClasesBases.Commons;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;

namespace ClasesBases.Services.Implementation
{
    public class CiudadService : IService<Ciudad>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CiudadService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Ciudad entity)
        {
            throw new NotImplementedException();
        }

        public Response Update(Ciudad entity)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Ciudad entity)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            Response response = new Response();
            try
            {
                response.Data = _unitOfWork.Ciudades.GetAll();
                response.Status = true;
                response.Msg = "Listado de Ciudades";
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
