using VeriErisimKatmani.Data;

namespace VeriErisimKatmani
{
    public static class RepositorySingleton
    {
        private static ApplicationDbContext db;
        private static object obj = new object();

        public static ApplicationDbContext DbContextOlustur()
        {
            lock (obj)
            {
                if (db == null)
                    db = new ApplicationDbContext();

                return db;
            }
        }
    }
}
