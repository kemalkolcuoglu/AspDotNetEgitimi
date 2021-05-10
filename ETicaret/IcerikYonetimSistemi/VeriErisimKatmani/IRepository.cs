using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    interface IRepository<T> where T : class
    {
        int Ekle(T nesne);
        int Guncele(T nesne);
        int Sil(T nesne);
        List<T> Listele();
        IQueryable<T> Sorgu();
        T Bul(Expression<Func<T, bool>> expression);
        List<T> ListeFilte(Expression<Func<T, bool>> expression);
    }
}
