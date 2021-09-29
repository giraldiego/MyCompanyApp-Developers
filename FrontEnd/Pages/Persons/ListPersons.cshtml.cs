using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace FrontEnd
{

    public class ListPersonsModel : PageModel
    {
        private readonly IRepoPerson repoPerson;

        public ListPersonsModel()
        {
            this.repoPerson = new RepoPerson(new AppDbContext());
        }

        public IEnumerable<Person> Persons { get; set; }

        public void OnGet()
        {
            Persons = repoPerson.List();
        }
    }
}
