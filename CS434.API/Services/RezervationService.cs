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
    public class RezervationService: IRezervationService
    {
        IConfiguration configuration;
        public RezervationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ReserveResponseModel makeRezervation(RezervationModel rezervationModel)
        {
            using (var dbContext = new DEV_Context())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        ReserveResponseModel reserveResponseModel = new ReserveResponseModel();
                        var sorgu = dbContext.Set<Rezervations>().FirstOrDefault(x => x.USER_ID == rezervationModel.User_Id && x.ITEM_ID == rezervationModel.Item_Id && x.IS_RETURNED == false);
                        if (sorgu!= null)
                        {
                            reserveResponseModel.Message = "Bu kitabınız hala rezerve haldedir.";
                            reserveResponseModel.Result = false;
                            reserveResponseModel.Rezervation = null;
                            return reserveResponseModel;

                        }
                        else
                        {
                            var rezervation = new Rezervations
                            {
                                USER_ID = rezervationModel.User_Id,
                                ITEM_ID = rezervationModel.Item_Id,
                                IS_RETURNED = false,
                                REZ_DATE = DateTime.Now
                            };

                            reserveResponseModel.Rezervation = rezervation;
                            reserveResponseModel.Message = "Rezervasyon başarıyla oluşturulmuştur.";
                            reserveResponseModel.Result = true;

                            dbContext.Set<Rezervations>().Add(rezervation);
                            var itemSorgu = dbContext.Set<Items>().FirstOrDefault(x => x.Id == rezervationModel.Item_Id);
                            itemSorgu.Amount = itemSorgu.Amount - 1;
                            dbContext.SaveChanges();
                            dbContextTransaction.Commit();

                            return  reserveResponseModel;
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

        public MessageModel returnRezervedItem(RezervationModel rezervationModel)
        {
            using (var dbContext = new DEV_Context())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        MessageModel messageModel = new MessageModel();
                        var sorgu = dbContext.Set<Rezervations>().FirstOrDefault(x => x.USER_ID == rezervationModel.User_Id && x.ITEM_ID == rezervationModel.Item_Id);
                        if (sorgu.IS_RETURNED == true)
                        {
                            messageModel.Message = "Kitap zaten rezerve edilmemiştir.";
                            messageModel.Result = false;
                            return messageModel;
                        }
                        else
                        {
                            sorgu.IS_RETURNED = true;
                            messageModel.Message = "Kitap iade edilmiştir";
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

        public List<Items> ShowAllItems()
        {
            throw new NotImplementedException();
        }

        //public List<Items> ShowAllItems(int USER_ID)
        //{
        //    using (var dbContext = new DEV_Context())
        //    {
        //        using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //        {
        //            try
        //            {

        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //        }
        //    }
        //}





    }
}
