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
    public class EditModel : PageModel
    {
        private readonly IRepoPerson repoEntity;

        [BindProperty]
        public Person Entity { get; set; }

        public EditModel()
        {
            this.repoEntity = new RepoPerson(new AppDbContext());
        }

        public IActionResult OnGet(int? pk)
        {
            if (pk.HasValue)
            {
                Entity = repoEntity.Detail(pk.Value);
            }
            else
            {
                Entity = new Person();
            }

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
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if (Entity.PersonId > 0)
            {
                Entity = repoEntity.Update(Entity);
            }
            else
            {
                repoEntity.Create(Entity);
            }
            return RedirectToPage("./List");
        }
    }
}
