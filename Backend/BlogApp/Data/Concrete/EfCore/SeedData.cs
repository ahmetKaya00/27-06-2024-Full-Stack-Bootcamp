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
                        new Tag {Text = "web prograglama",Url="web-programlama", Color = TagColors.primary},
                        new Tag {Text = "full-stack",Url="full-stack", Color = TagColors.danger},
                        new Tag {Text = "game",Url="game", Color = TagColors.info},
                        new Tag {Text = "backend",Url="backend", Color = TagColors.success},
                        new Tag {Text = "frounded",Url="frounded", Color = TagColors.secondary}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName = "ahmetkaya", Name="Ahmet Kaya", Email = "info@ahmetkaya.com",Password="123456,", Image = "p1.jpg"},
                        new User{UserName = "sinankarabulut", Name="Sinan Karabulut", Email = "info@sinan.com",Password="123456,", Image = "p2.jpg"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net Core",
                            Content = "asp.net core güzel bir kütüphanedir.",
                            Description = "asp.net core güzeldir",
                            Url ="asp-net-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "3.png",
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment {Text = "başarılı", PublishedOn = new DateTime(),UserId=1},
                                new Comment {Text = "başarılı, tavsiye ederim", PublishedOn = new DateTime(),UserId=2}
                            }
                        },
                        new Post{
                            Title = "Unity ile oyun geliştirme",
                            Content = "Unity editörü ile oyunlar geliştirebilirsiniz.",
                            Description = "Unity editörünü tanıyalım",
                            Url ="Unity-ile-oyun-geliştirme",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.png",
                            UserId = 2
                        },
                        new Post{
                            Title = "Full Stack Developer Olmak",
                            Content = "Full Stack Developer Olmak Güzeldir.",
                            Description = "Full Stack Developer nasıl olunur",
                            Url ="Full-Stack-Developer",
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