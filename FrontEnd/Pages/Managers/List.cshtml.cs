using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace FrontEnd.Pages.Managers
{

    public class ListModel : PageModel
    {
        private readonly IRepoManager repoEntity;

        public ListModel()
        {
            this.repoEntity = new RepoManager(new AppDbContext());   // Repo type to match class
        }

        public IEnumerable<Manager> Entities { get; set; }   // Change entity type to match class

        public void OnGet()
        {
            Entities = repoEntity.List();   // Explicity convert to entity type to match class
            foreach (Manager entity in Entities)
            {
                Console.WriteLine(entity.PersonId + " - " + entity.Name);
            }
        }
    }
}