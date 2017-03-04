﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChurchPlannerApp.Repositories;

namespace ChurchPlannerApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ServiceID");

                    b.Property<int>("Type");

                    b.Property<string>("UserName");

                    b.HasKey("ProfileID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd();

<<<<<<< HEAD
                    b.Property<DateTime>("PracticeDate");

                    b.Property<DateTime>("ServiceDate");
=======
                    b.Property<DateTime>("Date");
>>>>>>> start to list service requests

                    b.Property<string>("Title");

                    b.HasKey("ServiceID");

<<<<<<< HEAD
                    b.ToTable("Services");
=======
                    b.ToTable("Service");
                });

            modelBuilder.Entity("ChurchPlannerApp.Models.ServiceRequest", b =>
                {
                    b.Property<int>("ServiceRequestID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProfileID");

                    b.Property<int?>("ServiceID");

                    b.HasKey("ServiceRequestID");

                    b.HasIndex("ProfileID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Requests");
>>>>>>> start to list service requests
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

<<<<<<< HEAD
            modelBuilder.Entity("ChurchPlannerApp.Models.Profile", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Service")
                        .WithMany("Team")
=======
            modelBuilder.Entity("ChurchPlannerApp.Models.ServiceRequest", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.HasOne("ChurchPlannerApp.Models.Service", "Service")
                        .WithMany()
>>>>>>> start to list service requests
                        .HasForeignKey("ServiceID");
                });
        }
    }
}
