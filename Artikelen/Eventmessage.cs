using System;
using System.Collections.Generic;

#nullable disable

namespace Artikelen
{
    public partial class Eventmessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
