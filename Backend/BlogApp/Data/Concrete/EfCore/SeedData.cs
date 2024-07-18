using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore{

    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }

                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                        new Tag {Text = "web prograglama"},
                        new Tag {Text = "full-stack"},
                        new Tag {Text = "game"},
                        new Tag {Text = "backend"},
                        new Tag {Text = "frounded"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName = "ahmetkaya"},
                        new User{UserName = "sinankarabulut"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net Core",
                            Content = "asp.net core güzel bir kütüphanedir.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "3.png",
                            UserId = 1
                        },
                        new Post{
                            Title = "Unity ile oyun geliştirme",
                            Content = "Unity editörü ile oyunlar geliştirebilirsiniz.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.png",
                            UserId = 2
                        },
                        new Post{
                            Title = "Full Stack Developer Olmak",
                            Content = "Full Stack Developer Olmak Güzeldir.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "1.png",
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}