using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Participants
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public ParticipantDto[] ParticipantDto { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostNewExaminationBtn_Click()
        {
            //TODO: Benutzer in Db speichern
            return RedirectToPage("./Examination/Create");
        }

        public IActionResult OnPostCancelBtn_Click()
        {
            return RedirectToPage("../Index");
        }
    }
}
