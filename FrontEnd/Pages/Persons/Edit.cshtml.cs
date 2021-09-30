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

        public IActionResult OnGet(int pk)
        {
            Entity = repoEntity.Detail(pk);
            if(Entity == null)
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
            Entity = repoEntity.Update(Entity);
            return Page();
        }
    }
}
