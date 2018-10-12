using it.core.Examples.Configuration.it;
using it.core.Examples.Repositories;
using System;

namespace RunTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var config = new Configuration();
            var value = config.Get<string>("test");

            AppUsersRepository.AppUsersCanBeQueriedTest();

            Console.ReadLine();
        }
    }
}
