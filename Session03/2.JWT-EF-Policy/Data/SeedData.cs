public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<TodoEntity>().HasData(new List<TodoEntity> {
            new TodoEntity {
                Id = 1,
                TaskTitle = "Daily Homework",
                TaskDesc = "Complete daily homework assigned from the grad shcool",
                TaskTo = "dwilliam",
                IsComplete = false,
                Rating = "",
                ToPublish = false
            },
            new TodoEntity {
                Id = 2,
                TaskTitle = "Standup Meeting",
                TaskDesc = "Daily standup to share the current workitem",
                TaskTo = "jbrown",
                IsComplete = false,
                Rating = "",
                ToPublish = false
            },
            new TodoEntity {
                Id = 3,
                TaskTitle = "Sprint Review",
                TaskDesc = "Review current sprint and share overall progress",
                TaskTo = "pjordan",
                IsComplete = false,
                Rating = "",
                ToPublish = false
            },
            new TodoEntity {
                Id = 4,
                TaskTitle = "Community Announcement",
                TaskDesc = "Share the recent news to org-wide developer community",
                TaskTo = "pjordan",
                IsComplete = true,
                Rating = "Average",
                ToPublish = false
            },
            new TodoEntity {
                Id = 5,
                TaskTitle = "Review Task",
                TaskDesc = "Review daily tasks and update status",
                TaskTo = "ajones",
                IsComplete = true,
                Rating = "Excellent",
                ToPublish = true
            }
       });

        builder.Entity<UserEntity>().HasData(new List<UserEntity> {
            new UserEntity {
                Id = 1,
                UserName = "ajones",
                FirstName = "Amy",
                LastName = "Jones",
                Role = "Manager",
                Password = "ajones123"
            },
            new UserEntity {
                Id = 2,
                UserName = "pjordan",
                FirstName = "Pete",
                LastName = "Jordan",
                Role = "Teamlead",
                Password = "pjordan123"
            },
            new UserEntity {
                Id = 3,
                UserName = "jbrown",
                FirstName = "James",
                LastName = "Brown",
                Role = "Worker",
                Password = "jbrown123"
            },
            new UserEntity {
                Id = 4,
                UserName = "dwilliam",
                FirstName = "David",
                LastName = "William",
                Role = "Worker",
                Password = "dwilliam123"
            }
        });
    }   
}