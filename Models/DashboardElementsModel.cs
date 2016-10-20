using Microsoft.EntityFrameworkCore;

namespace IOLDOTNET.Models{
public class DashboardElements{
    public Newtonsoft.Json.Linq.JObject commute { get; set;}

}

public class DashboardElementsDBContext {
public DbSet<DashboardElements> DashboardData{get; set;}

}

}