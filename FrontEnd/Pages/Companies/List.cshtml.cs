using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace FrontEnd.Pages.Companies
{

    public class ListModel : PageModel
    {
        private readonly IRepoCompany _repoEntity;

        public ListModel(IRepoCompany repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        public IEnumerable<Company> Entities { get; set; }

        public void OnGet()
        {
            Entities = _repoEntity.List();
        }
    }
}
