using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Model;

namespace PruebaTecnica
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ArticuloController : ControllerBase
    {
        #region Atributos
        private readonly PruebaTecnica.BusinessLogic.Interface.IArticulo businessLogicArticulo;

        #endregion


        public ArticuloController()
        {

        }

        public async Task<IEnumerable<Articulo>> Listar()
        {
            try
            {
                //businessLogicArticulo.Listar();
                return null;
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                throw;
            }
        }
    }
}
