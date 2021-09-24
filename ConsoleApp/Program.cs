﻿using System;
using Domain;
using Persistence;

namespace ConsoleApp
{
    class Program
    {
        private static IRepoPerson _repoManager = new RepoManager(new AppDbContext());
        private static IRepoPerson _repoPerson = new RepoPerson(new AppDbContext());
        private static IRepoPerson _repoClient = new RepoClient(new AppDbContext());



        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");

            CreateTestManager();
            Console.WriteLine("Test Manager created!");

            Console.WriteLine(_repoManager.Delete(12));

            Console.WriteLine(_repoManager.List());

            Console.WriteLine(_repoManager.Detail(1).Name);

            CreateTestPerson();
            Console.WriteLine("Test Person created!");

            Console.WriteLine(_repoPerson.Delete(12));

            Console.WriteLine(_repoPerson.List());

            Console.WriteLine(_repoPerson.Detail(2).Name);

            CreateTestClient();
            Console.WriteLine("Test Client created!");

            Console.WriteLine(_repoClient.Delete(12));

            Console.WriteLine(_repoClient.List());

            Console.WriteLine(_repoClient.Detail(9).Name);

        }

        private static void CreateTestManager()
        {
            var dummy = new Manager
            {
                Name = "Kevin Raziel",
                DateOfBirth = new DateTime(1992, 1, 9),
                Salary = 5000000,
                Manager = null,
                Category = 10
            };

            var newEntity = _repoManager.Create(dummy);
        }


        private static void CreateTestPerson()
        {
            var dummy = new Person
            {
                Name = "Clark Kent",
                DateOfBirth = new DateTime(1956, 6, 30),
            };

            var newEntity = _repoPerson.Create(dummy);
        }

        private static void CreateTestClient()
        {
            var dummy = new Client
            {
                Name = "Harmony Granger",
                DateOfBirth = new DateTime(1994, 2, 16),
                PhoneNumber = "555-567890"
            };

            var newEntity = _repoClient.Create(dummy);
        }
    }
}
