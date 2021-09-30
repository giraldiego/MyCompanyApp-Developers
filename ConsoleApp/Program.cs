﻿using System;
using System.Collections.Generic;
using Domain;
using Persistence;

namespace ConsoleApp
{
    class Program
    {
        private static IRepoManager _repoManager = new RepoManager(new AppDbContext());
        private static IRepoClient _repoClient = new RepoClient(new AppDbContext());

        // private static IRepoPerson _repoPerson = new RepoPerson(new AppDbContext());
        // private static IRepoPerson _repoEmployee = new RepoEmployee(new AppDbContext());
        // private static IRepoCompany _repoCompany = new RepoCompany(new AppDbContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");
            Console.WriteLine();

            TestRepoManager();

            TestRepoClient();

        }

        static private bool TestRepoManager()
        {

            string testingEntity = "Manager";

            Console.WriteLine("Testing CRUD for " + testingEntity);
            Console.WriteLine();

            Console.WriteLine("Testing List() for " + testingEntity);
            Console.WriteLine();

            Console.WriteLine("List of current " + testingEntity + "s:");

            foreach (Manager entity in _repoManager.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Testing Create() for " + testingEntity);
            Console.WriteLine();

            var dummyEntity = (Manager)TestCreateManager();

            Console.WriteLine("Test " + testingEntity + " created!");
            Console.WriteLine();

            Console.WriteLine("Testing Read() for " + testingEntity);

            Console.WriteLine("Name of the las entity created: " + _repoManager.Detail(dummyEntity.PersonId).Name);
            Console.WriteLine();

            Console.WriteLine("New list of " + testingEntity + "s:");

            foreach (Manager entity in _repoManager.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Trying to Delete the last " + testingEntity + " created");

            if (_repoManager.Delete(dummyEntity.PersonId))
            {
                Console.WriteLine("Deletion successful!");
            } else
            {
                Console.WriteLine("Deletion failed!");
            }
            Console.WriteLine();

            Console.WriteLine("List of " + testingEntity + " after deletion:");

            foreach (Manager entity in _repoManager.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("All test passed for " + testingEntity);
            Console.WriteLine();

            return true;
        }

        static private bool TestRepoClient()
        {

            string testingEntity = "Client";
            IRepoClient repo = _repoClient;

            Console.WriteLine("Testing CRUD for " + testingEntity);
            Console.WriteLine();

            Console.WriteLine("Testing List() for " + testingEntity);
            Console.WriteLine();

            Console.WriteLine("List of current " + testingEntity + "s:");

            foreach (Client entity in repo.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Testing Create() for " + testingEntity);
            Console.WriteLine();

            Client dummyEntity = TestCreateClient();

            Console.WriteLine("Test " + testingEntity + " created!");
            Console.WriteLine();

            Console.WriteLine("Testing Read() for " + testingEntity);

            Console.WriteLine("Name of the las entity created: " + repo.Detail(dummyEntity.PersonId).Name);
            Console.WriteLine();

            Console.WriteLine("New list of " + testingEntity + "s:");

            foreach (Client entity in repo.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Trying to Delete the last " + testingEntity + " created");

            if (repo.Delete(dummyEntity.PersonId))
            {
                Console.WriteLine("Deletion successful!");
            } else
            {
                Console.WriteLine("Deletion failed!");
            }
            Console.WriteLine();

            Console.WriteLine("List of " + testingEntity + " after deletion:");

            foreach (Client entity in repo.List())
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
            Console.WriteLine();

            Console.WriteLine("All test passed for " + testingEntity);
            Console.WriteLine();

            return true;
        }

        private static Object TestCreateManager()
        {
            var dummy = new Manager
            {
                Name = "Bill Gates",
                DateOfBirth = new DateTime(1992, 1, 9),
                Salary = 5000000,
                Manager = null,
                Category = 10
            };

            var newEntity = _repoManager.Create(dummy);
            return newEntity;
        }

        private static Client TestCreateClient()
        {
            var dummy = new Client
            {
                Name = "Hanna Montana",
                DateOfBirth = new DateTime(1994, 2, 16),
                PhoneNumber = "555-567890"
            };

            var newEntity = _repoClient.Create(dummy);
            return newEntity;
        }

        // private static Object CreateTestPerson()
        // {
        //     var dummy = new Person
        //     {
        //         Name = "Clark Kent",
        //         DateOfBirth = new DateTime(1956, 6, 30),
        //     };

        //     var newEntity = _repoPerson.Create(dummy);
        //     return newEntity;
        // }


        // private static Object CreateTestEmployee()
        // {
        //     var dummy = new Employee
        //     {
        //         Name = "Ron Weasly",
        //         DateOfBirth = new DateTime(1994, 3, 13),
        //         Salary = 2000000,
        //         Manager = null,
        //     };

        //     var newEntity = _repoEmployee.Create(dummy);
        //     return newEntity;
        // }
        // private static Object CreateTestCompany()
        // {
        //     var dummy = new Company
        //     {
        //         Name = "ACME",
        //         Address = "BH 90210"
        //     };

        //     var newEntity = _repoCompany.Create(dummy);
        //     return newEntity;
        // }
    }
}
