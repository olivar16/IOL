using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IOLDOTNET.Models{

     public class GroceryStoreItemContext : DbContext
    {
        public GroceryStoreItemContext(DbContextOptions<GroceryStoreItemContext> options)
        : base(options)
        { }
        public DbSet<GroceryStoreItem> GroceryStoreItem { get; set;}
        
    }

    public class GroceryStoreItem
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [KeyAttribute]
        public int itemId{get; set;}
        
        [StringLengthAttribute(50)]
        public string Brand{get;set;}
        [StringLengthAttribute(30)]
        public string Store{get;set;}
        [StringLengthAttribute(50)]
        public string Item{get;set;}

        [Required(ErrorMessage = "Not valid currency format")]
        [DataTypeAttribute(DataType.Currency)]
        public decimal Price {get; set;}
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated{get;set;}
        
    }
}