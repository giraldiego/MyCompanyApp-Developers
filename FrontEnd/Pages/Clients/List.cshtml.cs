using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;

namespace FrontEnd.Pages.Clients
{

    public class ListModel : PageModel
    {
        private readonly IRepoClient _repoEntity;

        public ListModel(IRepoClient repoEntity)
        {
            this._repoEntity = repoEntity;
        }

        public IEnumerable<Client> Entities { get; set; }

        public void OnGet()
        {
            Entities = _repoEntity.List();
            // foreach (Client entity in Entities)
            // {
            //     Console.WriteLine(entity.PersonId + " - " + entity.Name);
            // }
        }
    }
}
