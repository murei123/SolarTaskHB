namespace Solsr.domains.Entities
{
    public class AddPerson
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
