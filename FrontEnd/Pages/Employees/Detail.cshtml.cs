using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd.Pages.Employees
{
    public class DetailModel : PageModel
    {
        private readonly IRepoEmployee _repoEntity;
        public Employee Entity { get; set; }  // Change entity type to match class

        public DetailModel(IRepoEmployee repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        public IActionResult OnGet(int pk)
        {
            Entity = (Employee)_repoEntity.Detail(pk);
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
