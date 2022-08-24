using FlightsManager.Application.Contracts;
using FlightsManager.Domain.Models.Entities;
using FlightsManager.Infrastructure.DB;
using FlightsManager.Infrastructure.Repository;
using FlightsManager.Infrastructure.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        //private readonly IPaisRepository _paisRepository;
        readonly IRepository<Pais> _repositoryPais;


        public PaisController(/*IPaisRepository paisRepository,*/ 
            IUnitOfWork<ApplicationDBContext> unitOfWork)
        {
            //_paisRepository = paisRepository;
            _repositoryPais = unitOfWork.Repository<Pais>();
        }

        [HttpGet]
        [Route("paises")]
        public async Task<IActionResult> GetVuelos()
        {
            try
            {
                //var response = await _paisRepository.GetPaises();
                var response = _repositoryPais.Listar();

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor.");
            }
        }

        [HttpGet]
        [Route("paises-except")]
        public async Task<IActionResult> GetPaisesWithout(string nombrePais)
        {
            try
            {
                //var response = await _paisRepository.GetPaisesExcept(nombrePais);
                var response = _repositoryPais.Listar(x => x.Nombre != nombrePais);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error en el servidor.");
            }
        }


    }
}
