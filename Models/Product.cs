namespace ManagementPortal.Models
{
    public class Product
    {
        //attributes
        private int id;
        private string name;
        private string desc;
        private int inv;
        private decimal price;

        //constructors
        public Product()
        {
            id = 0;
            name = "Default Product";
            desc = "An unedited product object.";
            inv = 0;
            price = 0.0m;
        }

        public Product(int id, string name, string desc, int inv, decimal price)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.inv = inv;
            this.price = price;
        }
        //behaviors

        //getters and setters
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return desc; } set { desc = value; } }
        public int Inventory { get { return inv; } set { inv = value; } }
        public decimal Price { get { return price; } set { price = value; } }
    }

    
}
