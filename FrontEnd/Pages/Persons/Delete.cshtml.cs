using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd.Pages.Persons
{
    public class DeleteModel : PageModel
    {
        private readonly IRepoPerson _repoEntity;

        [BindProperty]
        public Person Entity { get; set; }

        public DeleteModel(IRepoPerson repoEntity)
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
            if (Entity.PersonId > 0)
            {
                bool result = _repoEntity.Delete(Entity.PersonId);
                // Console.WriteLine("Deleting...");

            }
            return RedirectToPage("./List");
        }
    }
}
