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
    public class TerminalService : IService<Terminal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Response Add(Terminal entity)
        {
            throw new NotImplementedException();
        }

        public Response Update(Terminal entity)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Terminal entity)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            Response response = new Response();
            try
            {
                response.Data = _unitOfWork.Terminales.GetAll();
                response.Status = true;
                response.Msg = "Listado de Terminales";
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
