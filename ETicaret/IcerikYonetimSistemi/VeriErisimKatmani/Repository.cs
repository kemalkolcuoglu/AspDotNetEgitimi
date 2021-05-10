using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VeriErisimKatmani.Data;

namespace VeriErisimKatmani
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> dbSet;

        public Repository()
        {
            _context = RepositorySingleton.DbContextOlustur();
            dbSet = _context.Set<T>();
        }

        public ApplicationDbContext Context { get; }

        public IQueryable<T> Sorgu()
        {
            return dbSet.AsQueryable<T>();
        }

        public List<T> Listele()
        {
            return dbSet.ToList();
        }

        public T Bul(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public int Ekle(T nesne)
        {
            EntityEntry<T> t = dbSet.Add(nesne);
            return _context.SaveChanges();
        }

        public void KuyrugaEkle(T nesne)
        {
            dbSet.Add(nesne);
        }

        public int Kaydet()
        {
            return _context.SaveChanges();
        }

        public int Guncele(T nesne) => _context.SaveChanges();

        public int Sil(T nesne)
        {
            dbSet.Remove(nesne);
            return _context.SaveChanges();
        }

        public void CokluSil(List<T> nesneler)
        {
            dbSet.RemoveRange(nesneler);
        }

        public List<T> ListeFilte(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public IDbContextTransaction TransactionOlustur()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
