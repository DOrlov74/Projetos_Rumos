using System;

namespace ModeloPOS
{
    public class Store:Auditable
    {
        public Guid StoreId { get; set; } = Guid.NewGuid();
        private string _storeName;
        private string _city;

        public string StoreName
        {
            get { return _storeName; }
            set { _storeName = value;
                UpdatedAt = DateTime.Now;
            }
        }
        public string City
        {
            get { return _city; }
            set { _city = value;
                UpdatedAt = DateTime.Now;
            }
        }
        public Store(string name="N/A", string city="N/A")
        {
            StoreName = name;
            City = city;
            CreatedAt = DateTime.Now;
        }
    }
}
