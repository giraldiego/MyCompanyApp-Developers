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
    public class EditModel : PageModel
    {
        private readonly IRepoPerson _repoEntity;

        [BindProperty]
        public Person Entity { get; set; }

        public EditModel(IRepoPerson repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        public IActionResult OnGet(int? pk)
        {
            if (pk.HasValue)
            {
                Entity = _repoEntity.Detail(pk.Value);
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
                Entity = _repoEntity.Update(Entity);
            }
            else
            {
                _repoEntity.Create(Entity);
            }
            return RedirectToPage("./List");
        }
    }
}
