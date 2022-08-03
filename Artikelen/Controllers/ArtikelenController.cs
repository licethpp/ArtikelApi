using Artikelen.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artikelen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikelenController : ControllerBase

    {

        private readonly IArtikelRepository repository;
        public ArtikelenController(IArtikelRepository repository) =>
        this.repository = repository;


        [SwaggerOperation("Alle Artikelen")]
        [HttpGet]
        public ActionResult FindAll() => base.Ok(repository.FindAll());

        [SwaggerOperation("Artikel waarvan je de id kent")]
        [HttpGet("{id}")]
        public ActionResult FindById(int id)
        {
            var artikelen = repository.FindById(id);
            return artikelen == null ? base.NotFound() : base.Ok(artikelen);
        }

        //[HttpGet("Naam")]
        //public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));

        [SwaggerOperation("Niet toegankelijk")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var artikelen = repository.FindById(id);
            if (artikelen == null)
            {
                return base.NotFound();
            }
            repository.Delete(artikelen);
            return base.Ok();
        }

        [SwaggerOperation("Artikel toevoegen")]
        [HttpPost]
        public ActionResult Post(Artikelen artikel)
        {
            repository.Insert(artikel);
            return base.CreatedAtAction(nameof(FindById), new
            {
                id = artikel.ArtikelId
            }, null);
        }
        [SwaggerOperation("Artikel wijzigen")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, Artikelen artikelen)
        {
            try
            {
                artikelen.ArtikelId = id;
                repository.Update(artikelen);
                return base.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return base.NotFound();
            }
            catch
            {
                return base.Problem();
            }
        }


    }
}
