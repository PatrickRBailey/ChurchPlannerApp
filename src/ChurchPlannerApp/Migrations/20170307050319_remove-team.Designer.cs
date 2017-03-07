using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChurchPlannerApp.Repositories;

namespace ChurchPlannerApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20170307050319_remove-team")]
    partial class removeteam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChurchPlannerApp.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProfileID");

                    b.HasKey("InstrumentID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("FromProfileID");

                    b.HasKey("MessageID");

                    b.HasIndex("FromProfileID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Profile", b =>
                {
                    b.Property<int>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<int>("PhoneNum");

                    b.Property<int>("Type");

                    b.Property<string>("UserName");

                    b.HasKey("ProfileID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("PracticeDate");

                    b.Property<DateTime>("ServiceDate");

                    b.Property<string>("Title");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.ServiceRequest", b =>
                {
                    b.Property<int>("ServiceRequestID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Is_Accepted");

                    b.Property<int?>("ProfileRProfileID");

                    b.Property<int?>("ServiceRServiceID");

                    b.HasKey("ServiceRequestID");

                    b.HasIndex("ProfileRProfileID");

                    b.HasIndex("ServiceRServiceID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("SongID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Instrument", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Profile")
                        .WithMany("Instruments")
                        .HasForeignKey("ProfileID");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Message", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Profile", "From")
                        .WithMany()
                        .HasForeignKey("FromProfileID");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.ServiceRequest", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Profile", "ProfileR")
                        .WithMany()
                        .HasForeignKey("ProfileRProfileID");

                    b.HasOne("ChurchPlannerApp.Models.Service", "ServiceR")
                        .WithMany()
                        .HasForeignKey("ServiceRServiceID");
                });
        }
    }
}
