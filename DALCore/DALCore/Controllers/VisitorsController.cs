using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALCore.EntityFramework_Access;
using DALCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Contracts;
using VisitorService;

namespace DALCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        IVisitor visitor;
        public VisitorsController(IVisitor _visitor)
        {
            visitor = _visitor;
        } 
        [HttpGet]
        public List<VisitorsData> GetVisitorsFromLog()
        {
            return visitor.GetAllVisitorsFromLog();
        }
        [HttpPut]
        public List<VisitorsData> GetVisitorsLogByName(string searchInput)
        {
            return visitor.GetVisitorsLogByName(searchInput);
        }
        [HttpPut]
        public List<VisitorsData> GetVisitorLogByMeetingPerson(string meetingPerson)
        {
            return visitor.GetVisitorsLogByMeetingPerson(meetingPerson);
        }
        [HttpPut]
        public List<VisitorsData> GetLogByDateAndTime(string fromDate, string toDate, string fromTime, string toTime)
        {
            return visitor.GetVisitorLogByDate(fromDate, toDate, fromTime, toTime);
        }
        [HttpPut]
        public List<VisitorsData> GetLogByPurposeOfVisit(string purposeOfVisit)
        {
            return visitor.GetVisitorLogByPurposeOfVisitor(purposeOfVisit);
        }
    }
}
