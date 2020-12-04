using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
