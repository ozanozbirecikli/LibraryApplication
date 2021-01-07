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
        IReservationService _reservationService;
        
        public RezervationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("Reserve")]
        public ReserveResponseModel makeReservation([FromBody] ReservationModel  reservationModel)
        {
            return _reservationService.makeReservation(reservationModel);
        }

        [HttpPost("Return")]
        public MessageModel returnReservation([FromBody] ReservationModel reservationModel)
        {
            return _reservationService.returnReservedItem(reservationModel); 
        }

        [HttpGet("ShowReservations")]
        public ReservationsResponseModel showReservations(int USER_ID)
        {
            return _reservationService.ShowAllItems(USER_ID);
        }





    }
}
