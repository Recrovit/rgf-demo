using Microsoft.EntityFrameworkCore;
using Recrovit.RecroGridFramework.Data;
using Recrovit.RecroGridFramework.Extensions;
using ScDemo.Northwind.Models;

namespace RGFDemo.Database;

public partial class RGFDemoDbContext : SchemoraGeneratedDbContext
{
    public RGFDemoDbContext() : base() { }

    public RGFDemoDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}