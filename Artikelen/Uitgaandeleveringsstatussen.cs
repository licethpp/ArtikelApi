using System;
using System.Collections.Generic;

#nullable disable

namespace Artikelen
{
    public partial class Uitgaandeleveringsstatussen
    {
        public Uitgaandeleveringsstatussen()
        {
            Uitgaandeleveringens = new HashSet<Uitgaandeleveringen>();
        }

        public int UitgaandeLeveringsStatusId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; }
    }
}
