using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solsr.domains.Entities
{
    public class Person
    {
        [Key]
        public  Guid Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[]? Picture { get; set; }
    }
}
