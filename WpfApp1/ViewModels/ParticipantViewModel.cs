using CoronaTest.Wpf.Common;
using CoronaTest.Wpf.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaTest.Wpf.ViewModels
{
    public class ParticipantViewModel : BaseViewModel
    {
        public ParticipantViewModel(IWindowController controller) : base(controller)
        {
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
