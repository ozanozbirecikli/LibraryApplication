using CS434.API.MODELS.Database;
using CS434.API.MODELS.Response;
using CS434.API.MODELS.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Interfaces
{
    interface IReservationService
    {
        ReserveResponseModel makeReservation(ReservationModel rezervationRequestModel);
        MessageModel returnReservedItem(ReservationModel rezervationModel); 
        ReservationsResponseModel ShowAllItems(int USER_ID);
        
    }
}
