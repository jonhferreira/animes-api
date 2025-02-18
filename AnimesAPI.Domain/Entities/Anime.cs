using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Entities
{
    public sealed class Anime
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Director { get;  set; }
        public string Description { get;  set; }
        public bool IsDeleted { get; set; }
    }
}
