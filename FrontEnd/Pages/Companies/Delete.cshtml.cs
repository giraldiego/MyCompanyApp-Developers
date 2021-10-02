using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly IRepoCompany _repoEntity;

        [BindProperty]
        public Company Entity { get; set; }

        public DeleteModel(IRepoCompany repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        public IActionResult OnGet(int pk)
        {
            Entity = _repoEntity.Detail(pk);

            if (Entity == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPost()
        {
            if (Entity.CompanyId > 0)
            {
                bool result = _repoEntity.Delete(Entity.CompanyId);
                // Console.WriteLine("Deleting...");

            }
            return RedirectToPage("./List");
        }
    }
}
