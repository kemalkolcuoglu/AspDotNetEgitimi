using SimpleRentACarProject.Business.Abstract;
using SimpleRentACarProject.DAL.Data;
using SimpleRentACarProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRentACarProject.Business
{
    public class AracService : IAracService
    {
        private readonly RACContext _context;

        public AracService()
        {
            _context = new RACContext();
        }

        public int Add(Arac entity)
        {
            _context.Araclar.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            _context.Araclar.Remove(_context.Araclar.Find(id));
            return _context.SaveChanges();
        }

        public int Edit(int id, Arac entity)
        {
            Arac arac = _context.Araclar.Find(id);
            arac.Model = entity.Model;
            arac.Marka = entity.Marka;
            arac.Plaka = entity.Plaka;
            arac.VitesTipi = entity.VitesTipi;

            return _context.SaveChanges();
        }

        public List<Arac> GetAll()
        {
            return _context.Araclar.ToList();
        }

        public Arac GetById(int id)
        {
            return _context.Araclar.FirstOrDefault(x => x.Id == id);
        }

        public int AraciKirala(int aracId, int musteriId)
        {
            MusteriArac musteriArac = new MusteriArac()
            {
                AracId = aracId,
                MusteriId = musteriId
            };
            _context.MusteriAraclar.Add(musteriArac);
            return _context.SaveChanges();
        }
        public int KirayiSonlandir(int aracId, int musteriId)
        {
            MusteriArac musteriArac =_context.MusteriAraclar.SingleOrDefault(x => x.AracId == aracId && x.MusteriId == musteriId);
            _context.MusteriAraclar.Remove(musteriArac);
            return _context.SaveChanges();
        }
    }
}
