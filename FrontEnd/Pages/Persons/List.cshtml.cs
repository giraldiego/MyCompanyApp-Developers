using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace FrontEnd.Pages.Persons
{

    public class ListModel : PageModel
    {
        private readonly IRepoPerson repoEntity;

        public ListModel(IRepoPerson repoEntity)
        {
            this.repoEntity = repoEntity;
        }

        public IEnumerable<Person> Entities { get; set; }

        public void OnGet()
        {
            Entities = repoEntity.List();
        }
    }
}
