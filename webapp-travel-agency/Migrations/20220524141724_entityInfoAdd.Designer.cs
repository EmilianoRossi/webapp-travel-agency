// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapp_travel_agency.Data;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    [DbContext(typeof(ViaggioContext))]
    [Migration("20220524141724_entityInfoAdd")]
    partial class entityInfoAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webapp_travel_agency.Models.Informazione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Telefono")
                        .HasMaxLength(75)
                        .HasColumnType("int");

                    b.Property<string>("Testo")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int?>("ViaggioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ViaggioId");

                    b.ToTable("Informaziones");
                });

            modelBuilder.Entity("webapp_travel_agency.Models.Viaggio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Viaggios");
                });

            modelBuilder.Entity("webapp_travel_agency.Models.Informazione", b =>
                {
                    b.HasOne("webapp_travel_agency.Models.Viaggio", "Viaggio")
                        .WithMany("Informaziones")
                        .HasForeignKey("ViaggioId");

                    b.Navigation("Viaggio");
                });

            modelBuilder.Entity("webapp_travel_agency.Models.Viaggio", b =>
                {
                    b.Navigation("Informaziones");
                });
#pragma warning restore 612, 618
        }
    }
}
