using Application.Interfaces.Context;
using Domain.Visitors;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Visitors.GetTodayReport
{
    public interface IGetTodayReportService
    {
        ResultReportDto Execute();
    }
    public class GetTodayReportService : IGetTodayReportService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> visitorMongoCollection;
        public GetTodayReportService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            visitorMongoCollection = _mongoDbContext.GetCollection();
        }

        public ResultReportDto Execute()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);

            var todayPageViewCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.VisitTime >= startDate && p.VisitTime <= endDate).LongCount();
            var todayVisitorCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.VisitTime >= startDate && p.VisitTime <= endDate)
                .GroupBy(p => p.VisitorId).LongCount();
            var allPageViewCount = visitorMongoCollection.AsQueryable().LongCount();
            var allVisitorCount = visitorMongoCollection.AsQueryable().LongCount();
            VisitCountDto visitPerHour = GetVisitPerDay(startDate, endDate);
            VisitCountDto visitPerDay = GetVisitPerDay();
            var visitorInfo = visitorMongoCollection.AsQueryable()
                .OrderByDescending(p => p.VisitTime)
                .Take(10)
                .Select(p => new VisitorInfoDto
                {
                    Id=p.Id,
                    Ip=p.Ip,
                    CurrentLink=p.Ip,
                    RefererLink=p.ReferrerLink,
                    Browser=p.Browser.Family,
                    OperationSystem=p.OperationSystem.Family,
                    IsSpider=p.Device.IsSpider,
                    Time=p.VisitTime,
                    VisitorId=p.VisitorId,
                }).ToList();
            return new ResultReportDto
            {
                GeneralState = new GeneralStateDto
                {
                    TotalPageViews = allPageViewCount,
                    TotalVisitors = allVisitorCount,
                    PageViewPerVisit = GetAvg(allPageViewCount, allVisitorCount),
                    VisitPerDay = visitPerDay,
                },
                Today = new Today
                {
                    PageViews = todayPageViewCount,
                    Visitors = todayVisitorCount,
                    ViewsPerVisitors = GetAvg(todayPageViewCount, todayVisitorCount),
                    VisitPerHour = visitPerHour,
                },
                VisitorInfo=visitorInfo,
            };
        }

        private VisitCountDto GetVisitPerDay(DateTime startDate, DateTime endDate)
        {
            var todayPageViewList = visitorMongoCollection.AsQueryable()
                            .Where(p => p.VisitTime >= startDate && p.VisitTime < endDate)
                            .Select(p => new { p.VisitTime }).ToList();

            VisitCountDto visitPerHour = new VisitCountDto() { Display = new string[24], Value = new int[24] };
            for (int i = 0; i <= 23; i++)
            {
                visitPerHour.Display[i] = $"h-{i}";
                visitPerHour.Value[i] = todayPageViewList.Where(p => p.VisitTime.Hour == i).Count();
            }

            return visitPerHour;
        }

        private VisitCountDto GetVisitPerDay()
        {
            var startMonth = DateTime.Now.AddDays(-30);
            var endMonth = DateTime.Now.AddDays(1);
            var dayPageViewList = visitorMongoCollection.AsQueryable()
                .Where(p => p.VisitTime >= startMonth && p.VisitTime < endMonth)
                .Select(p => new { p.VisitTime }).ToList();

            VisitCountDto visitPerDay = new VisitCountDto() { Display = new string[31], Value = new int[31] };
            for (int i = 0; i <= 30; i++)
            {
                var currentDay = DateTime.Now.AddDays(i * (-1));
                visitPerDay.Display[i] = i.ToString();
                visitPerDay.Value[30 - i] = dayPageViewList.Where(p => p.VisitTime.Date == currentDay.Date).Count();
            }

            return visitPerDay;
        }

        public float GetAvg(long pageViews,long visitor)
        {
            if (visitor==0)
            {
                return 0;
            }
            else
            {
                return pageViews / visitor;
            }
        }
    }
    public class ResultReportDto
    {
        public GeneralStateDto GeneralState { get; set; }
        public Today Today { get; set; }
        public List<VisitorInfoDto> VisitorInfo { get; set; }
    }
    public class GeneralStateDto
    {
        public long TotalPageViews { get; set; }
        public long TotalVisitors { get; set; }
        public float PageViewPerVisit { get; set; }
        public VisitCountDto VisitPerDay { get; set; }
    }
    public class Today
    {
        public long PageViews { get; set; }
        public long Visitors { get; set; }
        public float ViewsPerVisitors { get; set; }
        public VisitCountDto VisitPerHour { get; set; }
    }
    public class VisitCountDto
    {
        public string[] Display { get; set; }
        public int[] Value { get; set; }
    }

    public class VisitorInfoDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string RefererLink { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public bool IsSpider { get; set; }
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
