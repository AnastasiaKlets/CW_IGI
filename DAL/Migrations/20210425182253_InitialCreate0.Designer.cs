// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210425182253_InitialCreate0")]
    partial class InitialCreate0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ActorPerformance", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PerformancesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActorsId", "PerformancesId");

                    b.HasIndex("PerformancesId");

                    b.ToTable("ActorPerformance");
                });

            modelBuilder.Entity("GenrePerformance", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PerformancesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "PerformancesId");

                    b.HasIndex("PerformancesId");

                    b.ToTable("GenrePerformance");
                });

            modelBuilder.Entity("Model.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FIO")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Model.AgeQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AgeQualifications");
                });

            modelBuilder.Entity("Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Model.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Model.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AgeQualificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AgeQualificationId");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("Model.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeOfSeatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("TypeOfSeatId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Model.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PerformanceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PerformanceId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityPlace")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("PerformanceId1");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Model.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePurchase")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Model.TypeOfSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TypeOfSeats");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActorPerformance", b =>
                {
                    b.HasOne("Model.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Performance", null)
                        .WithMany()
                        .HasForeignKey("PerformancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenrePerformance", b =>
                {
                    b.HasOne("Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Performance", null)
                        .WithMany()
                        .HasForeignKey("PerformancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Performance", b =>
                {
                    b.HasOne("Model.AgeQualification", "AgeQualification")
                        .WithMany()
                        .HasForeignKey("AgeQualificationId");

                    b.Navigation("AgeQualification");
                });

            modelBuilder.Entity("Model.Place", b =>
                {
                    b.HasOne("Model.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId");

                    b.HasOne("Model.TypeOfSeat", "TypeOfSeat")
                        .WithMany()
                        .HasForeignKey("TypeOfSeatId");

                    b.Navigation("Hall");

                    b.Navigation("TypeOfSeat");
                });

            modelBuilder.Entity("Model.Session", b =>
                {
                    b.HasOne("Model.Performance", "Performance")
                        .WithMany()
                        .HasForeignKey("PerformanceId");

                    b.HasOne("Model.Performance", null)
                        .WithMany("Sessions")
                        .HasForeignKey("PerformanceId1");

                    b.Navigation("Performance");
                });

            modelBuilder.Entity("Model.Ticket", b =>
                {
                    b.HasOne("Model.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("Model.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.HasOne("Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Place");

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Performance", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
