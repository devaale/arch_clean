using System;
using Clean_Architecture.Domain.Entities;
using Clean_Architecture.Domain.ValueObjects;
using Clean_Architecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = Colour.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water", Done = true }
                    }
                });

                await context.SaveChangesAsync();
            }

            if (!context.Plcs.Any())
            {
                context.Plcs.Add(new Plc
                {
                    IpAddress = "122.150.14.130",
                    Rack = 1,
                    Slot = 2,
                    PlcBlocks =
                    {
                        new PlcBlock{Value = true, DataType = "DOUBLE", CommandType = "EVENT", OffsetBit = 25.5,
                            Records = { new Record { DateTimeCreated = DateTime.Now, Count = 15, ReceivedFrom = 10 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 105, ReceivedFrom = 4 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 155, ReceivedFrom = 5 }},
                            Events =
                            {
                                new Event {EventDateTime = DateTime.Now, Text = "This is Event"},
                                new Event {EventDateTime = DateTime.Now, Text = "This is error"}
                            }},
                        new PlcBlock{Value = true, DataType = "DOUBLE", CommandType = "ERROR", OffsetBit = 25.5,
                            Records = { new Record {DateTimeCreated = DateTime.Now, Count = 12, ReceivedFrom = 15}},
                            Events =
                            {
                                new Event {EventDateTime = DateTime.Now, Text = "This is Also Event"},
                                new Event {EventDateTime = DateTime.Now, Text = "This is Error"},
                                new Event {EventDateTime = DateTime.Now, Text = "This is another Error -> Check me"}
                            }
                        }
                    }
                });

                context.Plcs.Add(new Plc
                {
                    IpAddress = "100.100.100.100",
                    Rack = 3,
                    Slot = 2,
                    PlcBlocks =
                    {
                        new PlcBlock{Value = true, DataType = "INT", CommandType = "ERROR", OffsetBit = 25.5,
                            Records = { new Record { DateTimeCreated = DateTime.Now, Count = 6, ReceivedFrom = 3 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 66, ReceivedFrom = 2 }}},
                        new PlcBlock{Value = true, DataType = "BOOLEAN", CommandType = "EVENT", OffsetBit = 25.5,
                            Records = { new Record {DateTimeCreated = DateTime.Now, Count = 12, ReceivedFrom = 99} }}
                    }
                });

                context.Plcs.Add(new Plc
                {
                    IpAddress = "144.144.144.144",
                    Rack = 1,
                    Slot = 2,
                    PlcBlocks =
                    {
                        new PlcBlock{Value = true, DataType = "DOUBLE", CommandType = "EVENT", OffsetBit = 13.10,
                            Records = { new Record { DateTimeCreated = DateTime.Now, Count = 40, ReceivedFrom = 11 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 78, ReceivedFrom = 4 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 44, ReceivedFrom = 5 }}},
                        new PlcBlock{Value = true, DataType = "DOUBLE", CommandType = "EVENT", OffsetBit = 25.5,
                            Records = { new Record { DateTimeCreated = DateTime.Now, Count = 15, ReceivedFrom = 10 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 11, ReceivedFrom = 4 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 51, ReceivedFrom = 5 },
                                        new Record { DateTimeCreated = DateTime.Now, Count = 44, ReceivedFrom = 0 }}}
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
