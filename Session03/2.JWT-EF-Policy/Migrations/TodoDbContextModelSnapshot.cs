﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TodoApi.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    partial class TodoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("TodoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDesc")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskTo")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ToPublish")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsComplete = false,
                            Rating = "",
                            TaskDesc = "Complete daily homework assigned from the grad shcool",
                            TaskTitle = "Daily Homework",
                            TaskTo = "dwilliam",
                            ToPublish = false
                        },
                        new
                        {
                            Id = 2,
                            IsComplete = false,
                            Rating = "",
                            TaskDesc = "Daily standup to share the current workitem",
                            TaskTitle = "Standup Meeting",
                            TaskTo = "jbrown",
                            ToPublish = false
                        },
                        new
                        {
                            Id = 3,
                            IsComplete = false,
                            Rating = "",
                            TaskDesc = "Review current sprint and share overall progress",
                            TaskTitle = "Sprint Review",
                            TaskTo = "pjordan",
                            ToPublish = false
                        },
                        new
                        {
                            Id = 4,
                            IsComplete = true,
                            Rating = "Average",
                            TaskDesc = "Share the recent news to org-wide developer community",
                            TaskTitle = "Community Announcement",
                            TaskTo = "pjordan",
                            ToPublish = false
                        },
                        new
                        {
                            Id = 5,
                            IsComplete = true,
                            Rating = "Excellent",
                            TaskDesc = "Review daily tasks and update status",
                            TaskTitle = "Review Task",
                            TaskTo = "ajones",
                            ToPublish = true
                        });
                });

            modelBuilder.Entity("UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Amy",
                            LastName = "Jones",
                            Password = "ajones123",
                            Role = "Manager",
                            UserName = "ajones"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Pete",
                            LastName = "Jordan",
                            Password = "pjordan123",
                            Role = "Teamlead",
                            UserName = "pjordan"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "James",
                            LastName = "Brown",
                            Password = "jbrown123",
                            Role = "Worker",
                            UserName = "jbrown"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "David",
                            LastName = "William",
                            Password = "dwilliam123",
                            Role = "Worker",
                            UserName = "dwilliam"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
