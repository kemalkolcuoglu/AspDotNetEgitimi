using SimpleRentACarProject.DAL.Abstract;
using SimpleRentACarProject.Entity;

namespace SimpleRentACarProject.Business.Abstract
{
    public interface IAracService : IRepository<Arac>
    {
        int AraciKirala(int aracId, int musteriId);
        int KirayiSonlandir(int aracId, int musteriId);
        int DeleteByBrandAndModel(string marka, string model);
    }
}
