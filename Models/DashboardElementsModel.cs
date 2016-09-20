using Microsoft.EntityFrameworkCore;

namespace IOL.net.Models{
public class DashboardElements{
    public Newtonsoft.Json.Linq.JObject commute { get; set;}
}

public class DashboardElementsDBContext : DbContext{
public DbSet<DashboardElements> DashboardData{get; set;}
}

}