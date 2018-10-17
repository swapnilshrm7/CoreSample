using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuardService
{
    public interface IGuard
    { 
        List<GuardData> GetAllGuardsFromLog();
        List<GuardData> GetGuardsLogByName(string searchInput);
    }
}
