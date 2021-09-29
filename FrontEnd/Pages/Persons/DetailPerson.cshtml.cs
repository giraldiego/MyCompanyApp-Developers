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
    public class DetailPersonModel : PageModel
    {
        private readonly IRepoPerson repoPerson;
        public Person Entity { get; set; }

        public DetailPersonModel()
        {
            this.repoPerson = new RepoPerson(new AppDbContext());
        }

        public IActionResult OnGet(int pk)
        {
            Entity = repoPerson.Detail(pk);
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
