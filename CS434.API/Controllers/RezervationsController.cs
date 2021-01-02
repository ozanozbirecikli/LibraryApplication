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
        IReservationService reservationService;
        IConfiguration configuration;
        public RezervationsController(IConfiguration configuration)
        {
            reservationService = new ReservationService(configuration);
        }

        [HttpPost("Reserve")]
        public ReserveResponseModel makeReservation(ReservationModel  reservationModel)
        {
            return reservationService.makeReservation(reservationModel);
        }

        [HttpPost("Return")]
        public MessageModel returnReservation(ReservationModel reservationModel)
        {
            return reservationService.returnReservedItem(reservationModel); 
        }

        [HttpPost("ShowReservations")]
        public ReservationsResponseModel showReservations(int USER_ID)
        {
            return reservationService.ShowAllItems(USER_ID);
        }





    }
}
