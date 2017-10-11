using FVG.FiscalPrinter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FVG.FiscalPrinter.Domain.Core.Data
{
    public interface IDataContext
    {
        DbSet<Reservation> Reservation { get; set; }
        DbSet<Entities.FiscalPrinter> FiscalPrinter { get; set; }
        DbSet<Document> Document { get; set; }

        int SaveChanges();
       
        IDataContext Add<TEntity>(TEntity e) where TEntity : class;

        IDataContext Update<TEntity>(TEntity e) where TEntity : class;
        
    }
}