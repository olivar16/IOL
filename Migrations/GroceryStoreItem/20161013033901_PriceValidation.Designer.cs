using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IOLDOTNET.Models;

namespace IOLDotNet.Migrations.GroceryStoreItem
{
    [DbContext(typeof(GroceryStoreItemContext))]
    [Migration("20161013033901_PriceValidation")]
    partial class PriceValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("IOLDOTNET.Models.GroceryStoreItem", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Item")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("Price");

                    b.Property<string>("Store")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("itemId");

                    b.ToTable("GroceryStoreItem");
                });
        }
    }
}
