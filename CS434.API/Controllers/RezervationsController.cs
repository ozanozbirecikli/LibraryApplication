using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS434.API.Interfaces;
using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using CS434.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CS434.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize]
    public class RezervationsController : ControllerBase
    {
        IRezervationService RezervationService;
        IConfiguration configuration;
        public RezervationsController(IConfiguration configuration)
        {
            RezervationService = new RezervationService(configuration);
        }

        [HttpPost("Rezerve")]
        public ReserveModel makeReservation(RezervationModel  reservationModel)
        {
            return 
        }




    }
}
