namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreditCard")]
    public partial class CreditCard:ModelExtension
    {
        public CreditCard()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("credit_card_id")]
        public long CreditCardId { get; set; }

        [StringLength(20)]
        [Column("credit_number")]
        public string CreditNumber { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
