namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer: ModelExtension
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("customer_id")]
        public long CustomerId { get; set; }

        [StringLength(50)]
        [Column("customer_name")]
        public string CustomerName { get; set; }

        [StringLength(11)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [StringLength(6)]
        [Column("gender")]
        public string Gender { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        [Column("username")]
        public string Username { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
