using CS434.API.Interfaces;
using CS434.API.MODELS.Database;
using CS434.API.MODELS.Request;
using CS434.API.MODELS.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.Services
{
    public class ReservationService : IReservationService
    {
        IConfiguration configuration;
        public ReservationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ReserveResponseModel makeReservation(ReservationModel rezervationModel)
        {
            using (var dbContext = new DEV_Context())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        ReserveResponseModel reserveResponseModel = new ReserveResponseModel();
                        var sorgu = dbContext.Set<Reservations>().FirstOrDefault(x => x.USER_ID == rezervationModel.User_Id && x.ITEM_ID == rezervationModel.Item_Id && x.IS_RETURNED == false);
                        if (sorgu != null)
                        {
                            reserveResponseModel.Message = "Bu kitabınız hala rezerve haldedir.";
                            reserveResponseModel.Result = false;
                            reserveResponseModel.Rezervation = null;
                            return reserveResponseModel;

                        }
                        else
                        {
                            var rezervation = new Reservations
                            {
                                USER_ID = rezervationModel.User_Id,
                                ITEM_ID = rezervationModel.Item_Id,
                                IS_RETURNED = false,
                                REZ_DATE = DateTime.Now,
                                RETURN_DATE = null
                            };

                            reserveResponseModel.Rezervation = rezervation;
                            reserveResponseModel.Message = "Rezervasyon başarıyla oluşturulmuştur.";
                            reserveResponseModel.Result = true;

                            dbContext.Set<Reservations>().Add(rezervation);
                            var itemSorgu = dbContext.Set<Items>().FirstOrDefault(x => x.Id == rezervationModel.Item_Id);
                            itemSorgu.Amount = itemSorgu.Amount - 1;
                            dbContext.SaveChanges();
                            dbContextTransaction.Commit();

                            return reserveResponseModel;
                        }
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        Console.WriteLine(e.InnerException.Message);
                        throw;
                    }
                }

            }
        }

        public MessageModel returnReservedItem(ReservationModel rezervationModel)
        {
            using (var dbContext = new DEV_Context())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        MessageModel messageModel = new MessageModel();
                        var sorgu = dbContext.Set<Reservations>().FirstOrDefault(x => x.USER_ID == rezervationModel.User_Id && x.ITEM_ID == rezervationModel.Item_Id);
                        if (sorgu.IS_RETURNED == true)
                        {
                            messageModel.Message = "Book is already avalaible.";
                            messageModel.Result = false;
                            return messageModel;
                        }
                        else
                        {
                            sorgu.IS_RETURNED = true;
                            sorgu.RETURN_DATE = DateTime.Now;
                            messageModel.Message = "Book has been returned.";
                            messageModel.Result = true;
                            var itemSorgu = dbContext.Set<Items>().FirstOrDefault(x => x.Id == rezervationModel.Item_Id);
                            itemSorgu.Amount = itemSorgu.Amount + 1;
                            dbContext.SaveChanges();
                            dbContextTransaction.Commit();


                            return messageModel;
                        }
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        Console.WriteLine(e.InnerException.Message);
                        throw;
                    }
                }

            }
        }



        public ReservationsResponseModel ShowAllItems(int userId)
        {
            using (var dbContext = new DEV_Context())
            {

                try
                {
                    ReservationsResponseModel reservationsResponseModel = new ReservationsResponseModel();
                    var queryList = dbContext.Set<Reservations>().ToList();
                    if (queryList.Count > 0)
                    {
                        reservationsResponseModel.Message = "All reservations is fetched succesfully!";
                        reservationsResponseModel.Result = true;
                        reservationsResponseModel.reservations = queryList;
                        return reservationsResponseModel;
                    }
                    else
                    {
                        reservationsResponseModel.Message = "There is no reservations!";
                        reservationsResponseModel.Result = false;
                        reservationsResponseModel.reservations = null;
                        return reservationsResponseModel;
                    }
                }


                catch (Exception e)
                {

                    throw;
                }


            }
        }





    }
}
