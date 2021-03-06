﻿// <auto-generated />
using System;
using Contact.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Contact.Data.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Contact.Data.Entities.ContactInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("Contact.Data.Entities.Contacts", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UUID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Contact.Data.Entities.ContactInformations", b =>
                {
                    b.HasOne("Contact.Data.Entities.Contacts", "Contact")
                        .WithMany("ContactInformations")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Contact.Data.Entities.Contacts", b =>
                {
                    b.Navigation("ContactInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
