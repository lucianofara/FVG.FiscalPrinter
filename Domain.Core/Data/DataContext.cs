using System.Threading;
using System.Threading.Tasks;
using FVG.FiscalPrinter.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FVG.FiscalPrinter.Domain.Core.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Entities.FiscalPrinter> FiscalPrinter { get; set; }
        public DbSet<Document> Document { get; set; }

        

        IDataContext IDataContext.Add<TEntity>(TEntity e)
        {
            if (this.Entry(e).State != EntityState.Modified)
                this.Entry(e).State = EntityState.Added;
            return this;
        }

        IDataContext IDataContext.Update<TEntity>(TEntity e)
        {
            if (this.Entry(e).State != EntityState.Modified)
                this.Entry(e).State = EntityState.Modified;
            return this;
        }

       
    }
}