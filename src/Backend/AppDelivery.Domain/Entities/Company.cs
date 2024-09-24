namespace AppDelivery.Domain.Entities
{
    public class Company : User
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string NumberLocation { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateSignup { get; set; }
    }
}
