using Application.Interfaces.Context;
using Domain.Visitors;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Application.Services.Visitors.VisitorOnline
{
    public class VisitorOnlineService : IVisitorOnlineService
    {
        private readonly IMongoDbContext<OnlineVisitor> mongoDbContext;
        private readonly IMongoCollection<OnlineVisitor> mongoCollection;
        public VisitorOnlineService(IMongoDbContext<OnlineVisitor> mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
            mongoCollection = this.mongoDbContext.GetCollection();
        }
        public void ConnectUser(string ClientId)
        {
            var exist = mongoCollection.AsQueryable().FirstOrDefault(p => p.ClientId == ClientId);
            if (exist==null)
            {
                mongoCollection.InsertOne(new OnlineVisitor
                {
                    ClientId = ClientId,
                    Time = DateTime.Now
                });
            }
        }

        public void DisConnectUser(string ClientId)
        {
            mongoCollection.FindOneAndDelete(p=>p.ClientId==ClientId);
        }

        public int GetCount()
        {
            return mongoCollection.AsQueryable().Count();
        }
    }
}
