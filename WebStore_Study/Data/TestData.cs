using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Models;

namespace WebStore_Study.Data
{
    public static class TestData
    {
        public static List<Blog> Blogs { get; } = new List<Blog>()
        {
            new Blog
            {
                Id=1,
                Heading="GIRLS PINK T SHIRT ARRIVED IN STORE-1",
                Author="Mac Doe",
                MainText=loremText,
                CreationTime= new DateTime(2013, 12, 5, 13, 33, 0),
                Tags=new List<string>(){"Pink", "T-Shirt", "Girls"},
                Image=new BlogFile() { Id =1, Name=$"Blogimage-1", Path="/images/blog/blog-one.jpg"  }
            },
            new Blog
            {
                Id=2,
                Heading="GIRLS PINK T SHIRT ARRIVED IN STORE-2",
                Author="Mac Doe",
                MainText=loremText,
                CreationTime= new DateTime(2013, 12, 5, 13, 33, 0),
                Tags=new List<string>(){"Pink", "T-Shirt", "Girls"},
                Image=new BlogFile() { Id =2, Name=$"Blogimage-2",Path="/images/blog/blog-two.jpg"}
            },
            new Blog
            {
                Id=3,
                Heading="GIRLS PINK T SHIRT ARRIVED IN STORE-3",
                Author="Mac Doe",
                MainText=loremText,
                CreationTime= new DateTime(2013, 12, 5, 13, 33, 0),
                Tags=new List<string>(){"Pink", "T-Shirt", "Girls"},
                Image=new BlogFile()
                { Id =3, Name=$"Blogimage-3", Path="/images/blog/blog-three.jpg"  }
            },
            new Blog
            {
                Id=4,
                Heading="GIRLS PINK T SHIRT ARRIVED IN STORE-4",
                Author="Mac Doe",
                MainText=loremText,
                CreationTime= new DateTime(2013, 12, 5, 13, 33, 0),
                Tags=new List<string>(){"Pink", "T-Shirt", "Girls"},
                Image=new BlogFile()
                { Id =4, Name=$"Blogimage-4", Path="/images/blog/blog-one.jpg"  }
            }
        };

        public static List<Employee> Employees { get; } = new List<Employee>()
        {
            new(){Id=1, LastName="Иванов", FirstName="Иван", Patronymic="Иванович", Age=31},
            new(){Id=2, LastName="Петров", FirstName="Пётр", Patronymic="Петрович", Age=32},
            new(){Id=3, LastName="Сидоров", FirstName="Сидор", Patronymic="Сидорович", Age=33},
            new(){Id=4, LastName="Константинов", FirstName="Константин", Patronymic="Константинович", Age=34}
        };

        const string loremText = @"Lorem ipsum dolor sit amet, consectetur
        adipisicing elit, sed do eiusmod tempor incididunt ut labore
        et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
        exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
        Duis aute irure dolor in reprehenderit in voluptate velit esse cillum
        dolore eu fugiat nulla pariatur.

        Excepteur sint occaecat cupidatat non proident, sunt in culpa
        qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis
        unde omnis iste natus error sit voluptatem accusantium doloremque laudantium,
        totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto
        beatae vitae dicta sunt explicabo.

        Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit,
        sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

        Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur,
        adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore
        et dolore magnam aliquam quaerat voluptatem.";


        public static List<Section> Sections { get; } = new List<Section>()
        {
            new Section { Id = 1, Name = "Sportswear", Order = 0, ParentId = null},
            new Section {Id = 2,Name = "Nike",Order = 0,ParentId = 1},
            new Section {  Id = 3,Name = "Under Armour",Order = 1,ParentId = 1},
            new Section{Id = 4,Name = "Adidas",Order = 2,ParentId = 1},
            new Section{Id = 5,Name = "Puma",Order = 3,ParentId = 1},
            new Section{Id = 6,Name = "ASICS",Order = 4,ParentId = 1},
            new Section{Id = 7,Name = "Mens",Order = 1,ParentId = null},
            new Section{Id = 8,Name = "Fendi",Order = 0,ParentId = 7},
            new Section{Id = 9,Name = "Guess",Order = 1,ParentId = 7},
            new Section{Id = 10,Name = "Valentino",Order = 2,ParentId = 7},
            new Section{Id = 11,Name = "Dior",Order = 3,ParentId = 7},
            new Section{Id = 12,Name = "Versace",Order = 4,ParentId = 7},
            new Section{Id = 13,Name = "Armani",Order = 5,ParentId = 7},
            new Section{Id = 14,Name = "Prada",Order = 6,ParentId = 7},
            new Section{Id = 15,Name = "Dolce and Gabbana",Order = 7,ParentId = 7},
            new Section{Id = 16,Name = "Chanel",Order = 8,ParentId = 7},
            new Section{Id = 17,Name = "Gucci",Order = 1,ParentId = 7},
            new Section{Id = 18,Name = "Womens",Order = 2,ParentId = null},
            new Section{Id = 19,Name = "Fendi",Order = 0,ParentId = 18},
            new Section{Id = 20,Name = "Guess",Order = 1,ParentId = 18},
            new Section{Id = 21,Name = "Valentino",Order = 2,ParentId = 18},
            new Section{Id = 22,Name = "Dior",Order = 3,ParentId = 18},
            new Section{Id = 23,Name = "Versace",Order = 4,ParentId = 18},
            new Section{Id = 24,Name = "Kids",Order = 3,ParentId = null},
            new Section{Id = 25,Name = "Fashion",Order = 4,ParentId = null},
            new Section{Id = 26,Name = "Households",Order = 5,ParentId = null},
            new Section{Id = 27,Name = "Interiors",Order = 6,ParentId = null},
            new Section{Id = 28,Name = "Clothing",Order = 7,ParentId = null},
            new Section{Id = 29,Name = "Bags",Order = 8,ParentId = null},
            new Section{Id = 30,Name = "Shoes",Order = 9,ParentId = null}
        };

        public static List<Brand> Brands { get; } = new List<Brand>()
        {
                new Brand{Id = 1,Name = "Acne",Order = 0},
                new Brand{Id = 2,Name = "Grüne Erde",Order = 1},
                new Brand{Id = 3,Name = "Albiro",Order = 2},
                new Brand{Id = 4,Name = "Ronhill",Order = 3},
                new Brand{Id = 5,Name = "Oddmolly",Order = 4},
                new Brand{Id = 6,Name = "Boudestijn",Order = 5},
                new Brand{Id = 7,Name = "Rösch creative culture",Order = 6}
        };








    }
}
