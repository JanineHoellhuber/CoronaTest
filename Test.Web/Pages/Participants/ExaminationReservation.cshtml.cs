using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Web.Pages.Participants
{
    public class ExaminationReservationModel : PageModel
    {

        [BindProperty]
        public Examination Examination { get; set; }

        public void OnGet()
        {
        }
    }
}
