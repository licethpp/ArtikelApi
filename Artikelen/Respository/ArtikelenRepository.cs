using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artikelen.Respository
{
    public class ArtikelenRepository : IArtikelRepository

    {

        private readonly prulariacomContext context;
        public ArtikelenRepository(prulariacomContext context) => this.context = context;

        public void Delete(Artikelen artikelen)
        {
            context.Artikelens.Remove(artikelen);
            context.SaveChanges();
        }

        public IQueryable<Artikelen> FindAll() => context.Artikelens.AsNoTracking();
       


        public IQueryable<Artikelen> FindByBeginNaam(string begin) => context.Artikelens.Where(x => x.Naam.StartsWith(begin));

        public Artikelen FindById(int id) => context.Artikelens.Find(id);


        public void Insert(Artikelen artikelen)
        {
            context.Artikelens.Add(artikelen);
            context.SaveChanges();
        }

        public void Update(Artikelen artikelen)
        {
            context.Artikelens.Add(artikelen);
            context.SaveChanges();
        }
    }
}
