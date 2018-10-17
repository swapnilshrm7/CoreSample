﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Contracts;

namespace VisitorService
{
    public interface IVisitor
    {
        List<VisitorsData> GetAllVisitorsFromLog();
        List<VisitorsData> GetVisitorsLogByName(string searchInput);
        List<VisitorsData> GetVisitorsLogByMeetingPerson(string SearchInput);
        List<VisitorsData> GetVisitorLogByDate(string fromDate, string toDate, string fromTime, string toTime);
        List<VisitorsData> GetVisitorLogByPurposeOfVisitor(string searchInput);
    }

}
