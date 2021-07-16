using SimpleRentACarProject.Business.Abstract;
using SimpleRentACarProject.DAL.Data;
using SimpleRentACarProject.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRentACarProject.Business
{
    public class MusteriService : IMusteriService
    {
        private readonly RACContext _context;

        public MusteriService()
        {
            _context = new RACContext();
        }

        public int Add(Musteri entity)
        {
            _context.Musteriler.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            _context.Musteriler.Remove(_context.Musteriler.Find(id));
            return _context.SaveChanges();
        }

        public int Edit(int id, Musteri entity)
        {
            Musteri musteri = _context.Musteriler.Find(id);
            musteri.Ad = entity.Ad;
            musteri.Soyad = entity.Soyad;

            return _context.SaveChanges();
        }

        public List<Musteri> GetAll()
        {
            return _context.Musteriler.ToList();
        }

        public Musteri GetById(int id)
        {
            return _context.Musteriler.FirstOrDefault(x => x.Id == id);
        }
    }
}
