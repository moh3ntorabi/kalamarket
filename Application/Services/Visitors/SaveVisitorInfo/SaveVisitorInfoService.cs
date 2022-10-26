using Application.Interfaces.Context;
using Domain.Visitors;
using MongoDB.Driver;
using System;

namespace Application.Services.Visitors.SaveVisitorInfo
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _mongoCollection;
        public SaveVisitorInfoService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _mongoCollection = _mongoDbContext.GetCollection();
        }
        public void Execute(RequestSaveVisitorInfo request)
        {
            _mongoCollection.InsertOne(new Visitor
            {
                Ip=request.Ip,
                CurrentLink=request.CurrentLink,
                ReferrerLink=request.ReferrerLink,
                Method=request.Method,
                Protocol=request.Protocol,
                PhysicalPath=request.PhysicalPath,
                VisitorId=request.VisitorId,
                VisitTime=DateTime.Now,
                Browser = new VisitorVersion
                {
                    Family = request.Browser.Family,
                    Version = request.Browser.Version,
                },
                OperationSystem = new VisitorVersion
                {
                    Family = request.OperationSystem.Family,
                    Version = request.OperationSystem.Version,
                },
                Device = new Device
                {
                    Brand = request.Device.Brand,
                    Family = request.Device.Family,
                    Model = request.Device.Model,
                    IsSpider=request.Device.IsSpider,
                },
            });
        }
    }

}
