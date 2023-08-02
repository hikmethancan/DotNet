using Entity.Abstract;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

    }
}
