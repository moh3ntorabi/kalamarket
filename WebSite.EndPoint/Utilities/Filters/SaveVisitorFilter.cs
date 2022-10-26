using Application.Services.Visitors.SaveVisitorInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace WebSite.EndPoint.Utilities.Filters
{
    public class SaveVisitorFilter : IActionFilter
    {
        private readonly ISaveVisitorInfoService _saveVisitorInfoService;
        public SaveVisitorFilter(ISaveVisitorInfoService saveVisitorInfoService)
        {
            _saveVisitorInfoService = saveVisitorInfoService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var Request = context.HttpContext.Request;
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var currentUrl = Request.Path;
            var referer = Request.Headers["Referer"].ToString();
            var userAgent = Request.Headers["User-Agent"].ToString();
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo= uaParser.Parse(userAgent);
            string visitorId = context.HttpContext.Request.Cookies["VisitorId"];
            
            _saveVisitorInfoService.Execute(new RequestSaveVisitorInfo
            {
                Ip = ip,
                CurrentLink = currentUrl,
                ReferrerLink=referer,
                Method=Request.Method,
                PhysicalPath=$"",
                Protocol=Request.Protocol,
                VisitorId=visitorId,
                Browser=new VisitorVersionDto
                {
                    Family=clientInfo.UA.Family,
                    Version=$"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}",
                },
                OperationSystem=new VisitorVersionDto
                {
                    Family=clientInfo.OS.Family,
                    Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}",
                },
                Device=new DeviceDto
                {
                    Brand=clientInfo.Device.Brand,
                    Family=clientInfo.Device.Family,
                    Model=clientInfo.Device.Model,
                    IsSpider=clientInfo.Device.IsSpider
                },
            });
        }
    }
}
