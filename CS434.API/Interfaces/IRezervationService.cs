using CS434.API.MODELS.Database;
using CS434.API.MODELS.Response;
using CS434.API.MODELS.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Interfaces
{
    interface IRezervationService
    {
        MessageModel makeRezervation(RezervationModel rezervationRequestModel);
        MessageModel returnRezervedItem(RezervationModel rezervationModel); 
        List<Items> ShowAllItems();
        
    }
}
