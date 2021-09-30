using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd.Pages.Clients
{
    public class DetailModel : PageModel
    {
        private readonly IRepoClient repoEntity;
        public Client Entity { get; set; }  // Change entity type to match class

        public DetailModel()
        {
            this.repoEntity = new RepoClient(new AppDbContext());  // Repo type to match class
        }

        public IActionResult OnGet(int pk)
        {
            Entity = (Client)repoEntity.Detail(pk);
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
