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
        private static IRepoCompany _repoCompany = new RepoCompany(new AppDbContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");

            Console.WriteLine("\nTesting Manager CRUD");

            var dummyManager = (Manager)CreateTestManager();

            Console.WriteLine("Test Manager created!");

            Console.WriteLine(_repoManager.List());

            Console.WriteLine(_repoManager.Delete(99));

            Console.WriteLine(_repoManager.Detail(dummyManager.PersonId).Name);


            Console.WriteLine("\nTesting Person CRUD");

            var dummyPerson = (Person)CreateTestPerson();
            Console.WriteLine("Test Person created!");

            Console.WriteLine(_repoPerson.Delete(99));

            Console.WriteLine(_repoPerson.List());

            Console.WriteLine(_repoPerson.Detail(dummyPerson.PersonId).Name);

            Console.WriteLine("\nTesting Client CRUD");

            var dummyClient = (Client)CreateTestClient();
            Console.WriteLine("Test Client created!");

            Console.WriteLine(_repoClient.Delete(99));

            Console.WriteLine(_repoClient.List());

            Console.WriteLine(_repoClient.Detail(dummyClient.PersonId).Name);

            Console.WriteLine("\nTests completed");

            var dummyCompany = (Company)CreateTestCompany();
            Console.WriteLine("Test Company created!");

            Console.WriteLine(_repoCompany.Delete(99));

            Console.WriteLine(_repoCompany.List());

            Console.WriteLine(_repoCompany.Detail(dummyCompany.CompanyId).Name);

            Console.WriteLine("\nTests completed");
        }

        private static Object CreateTestManager()
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
            return newEntity;
        }


        private static Object CreateTestPerson()
        {
            var dummy = new Person
            {
                Name = "Clark Kent",
                DateOfBirth = new DateTime(1956, 6, 30),
            };

            var newEntity = _repoPerson.Create(dummy);
            return newEntity;
        }

        private static Object CreateTestClient()
        {
            var dummy = new Client
            {
                Name = "Harmony Granger",
                DateOfBirth = new DateTime(1994, 2, 16),
                PhoneNumber = "555-567890"
            };

            var newEntity = _repoClient.Create(dummy);
            return newEntity;
        }

        private static Object CreateTestCompany()
        {
            var dummy = new Company
            {
                Name = "ACME",
                Address = "BH 90210"
            };

            var newEntity = _repoCompany.Create(dummy);
            return newEntity;
        }
    }
}
