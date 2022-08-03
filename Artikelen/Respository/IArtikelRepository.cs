using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artikelen.Respository
{
    public interface IArtikelRepository
    {
        IQueryable<Artikelen> FindAll();
        Artikelen FindById(int id);
        IQueryable<Artikelen> FindByBeginNaam(string begin);
        void Insert(Artikelen artikelen);
        void Delete(Artikelen artikelen);
        void Update(Artikelen artikelen);
    }
}
