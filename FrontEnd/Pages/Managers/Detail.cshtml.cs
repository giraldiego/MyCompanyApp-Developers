using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd.Pages.Managers
{
    public class DetailModel : PageModel
    {
        private readonly IRepoManager repoEntity;
        public Manager Entity { get; set; }  // Change entity type to match class

        public DetailModel()
        {
            this.repoEntity = new RepoManager(new AppDbContext());  // Repo type to match class
        }

        public IActionResult OnGet(int pk)
        {
            Entity = (Manager)repoEntity.Detail(pk);
            if(Entity == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }

        }
    }
}
