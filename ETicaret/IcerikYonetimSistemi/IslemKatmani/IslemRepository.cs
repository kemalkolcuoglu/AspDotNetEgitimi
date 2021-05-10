using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeriErisimKatmani;
using VeriErisimKatmani.Data;

namespace IslemKatmani
{
    public class IslemRepository<T> where T : class
    {
        private Repository<T> repository;
        public IslemRepository()
        {
            repository = new Repository<T>();
        }

        public List<T> Listele()
        {
            return repository.Listele();
        }

        /// <summary>
        ///     Gönderilen Tipteki nesne db'den çekilir
        /// </summary>
        /// <param name="expression">Lambda Expesion Gerekli</param>
        /// <returns>Gönderilen tipteki nesne döndürülür</returns>
        public T Bul(Expression<Func<T, bool>> expression)
        {
            return repository.Bul(expression);
        }

        public int Ekle(T nesne)
        {
            return repository.Ekle(nesne);
        }

        public int Guncele(T nesne) => repository.Guncele(nesne);

        public int Sil(T nesne)
        {
            return repository.Sil(nesne);
        }

        public void CokluSil(List<T> nesneler)
        {
            repository.CokluSil(nesneler);
        }

        public IQueryable<T> Sorgu()
        {
            return repository.Sorgu();
        }

        public void KuyrugaEkle(T nesne)
        {
            repository.KuyrugaEkle(nesne);
        }

        public int Kaydet()
        {
            return repository.Kaydet();
        }

        public List<T> ListeFiltre(Expression<Func<T, bool>> expression)
        {
            return repository.ListeFilte(expression);
        }

        public IDbContextTransaction TransactionOlustur()
        {
            return repository.TransactionOlustur();
        }
    }
}
