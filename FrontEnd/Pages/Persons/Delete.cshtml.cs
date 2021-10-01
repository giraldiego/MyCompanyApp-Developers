using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using Domain;

namespace FrontEnd
{
    public class DeleteModel : PageModel
    {
        private readonly IRepoPerson repoEntity;

        [BindProperty]
        public Person Entity { get; set; }

        public DeleteModel()
        {
            this.repoEntity = new RepoPerson(new AppDbContext());
        }

        public IActionResult OnGet(int pk)
        {
            Entity = repoEntity.Detail(pk);

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
                bool result = repoEntity.Delete(Entity.PersonId);
                // Console.WriteLine("Deleting...");

            }
            return RedirectToPage("./List");
        }
    }
}
