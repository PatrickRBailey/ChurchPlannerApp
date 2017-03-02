using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChurchPlannerApp.Repositories;

namespace ChurchPlannerApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20170302040234_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("ChurchPlannerApp.Models.Message", b =>
                {
                    b.HasOne("ChurchPlannerApp.Models.Profile", "From")
                        .WithMany()
                        .HasForeignKey("FromProfileID");
                });
        }
    }
}
