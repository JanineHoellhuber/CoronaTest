using CoronaTest.Core.Contracts;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Enums;
using CoronaTest.Persistence;
using CoronaTest.Wpf.Common;
using CoronaTest.Wpf.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaTest.Wpf.ViewModels
{
    public class ParticipantViewModel : BaseViewModel
    {
        private string _participantIdentifier;
        private string _examinationIdentifier;
        private List<TestResult> _testResults;
        private string _selectedTestResult;
        private string _examinationIdentifierInfo;
        private string _participantIdentifierInfo;
        private string _testResultInfo;
        private string _errorMessage;
        private Examination _examination;

        public string SelectedTestResult
        {
            get 
            {
                return _selectedTestResult; 
            }
            set
            {
                _selectedTestResult = value;
                OnPropertyChanged();
            }
        }

        public Examination Examination
        {
            get
            {
                return _examination;
            }
            set
            {
                _examination = value;
                OnPropertyChanged();
            }
        }


        public string ExaminationIdentifier
        {
            get 
            {
                return _examinationIdentifier;
            }
            set
            {
                _examinationIdentifier = value;
                OnPropertyChanged();
            }
        }

        public string ParticipantIdentifier
        {
            get 
            { 
                return _participantIdentifier;
            }
            set
            {
                _participantIdentifier = value;
                OnPropertyChanged();
            }
        }

        public string ExaminationIdentifierInfo
        {
            get 
            { 
                return _examinationIdentifierInfo; 
            }
            set
            {
                _examinationIdentifierInfo = value;
                OnPropertyChanged();
                Validate();
            }
        }

        public string ParticipantIdentifierInfo
        {
            get 
            {
                return _participantIdentifierInfo; 
            }
            set
            {
                _participantIdentifierInfo = value;
                OnPropertyChanged();
                Validate();
            }
        }

        public List<TestResult> TestResults
        {
            get { return _testResults; }
            set
            {
                _testResults = value;
                OnPropertyChanged();
            }
        }

        public string TestResultInfo
        {
            get 
            { 
                return _testResultInfo; 
            }
            set
            {
                _testResultInfo = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get 
            { 
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand CmdExaminationIdentifier { get; set; }
        public ICommand CmdParticipantIdentifier { get; set; }
        public ICommand CmdTestResult { get; set; }
        public ICommand CmdQuitExamination { get; set; }


        public ParticipantViewModel(IWindowController controller) : base(controller)
        {
            TestResults = new List<TestResult>
            {
                TestResult.Unknown,
                TestResult.Negative,
                TestResult.Positive
            };

            LoadCommands();


        }

        private void LoadCommands()
        {
            CmdExaminationIdentifier = new RelayCommand(async _ => await ExaminationIdentifierAsync(),
                _ => ExaminationIdentifier != null);
            CmdParticipantIdentifier = new RelayCommand(_ => ParticipantIdentifierAsync(),
             _ => ParticipantIdentifier != null);
            CmdTestResult = new RelayCommand(async _ => await TestResultAsync(),
                _ => SelectedTestResult != null);
            CmdQuitExamination = new RelayCommand(_ => Controller.CloseWindow(this), _ => true);

        }


        public async Task ExaminationIdentifierAsync()
        {
            await using IUnitOfWork unitOfWork = new UnitOfWork();

            Examination = await unitOfWork.ExaminationRepository
                          .GetByIdentifierAsync(ExaminationIdentifier);

        }

      
        public void ParticipantIdentifierAsync()
        {
            if (ParticipantIdentifier != null )
            {
                
                ParticipantIdentifierInfo = $"Teilnehmer: {Examination.Participant.FirstName} {Examination.Participant.LastName}";
                 ErrorMessage = String.Empty;
            }
            else
            {
                ErrorMessage = "Der Teilnehmer Code ist ungültig";
            }
    }

     
        public async Task TestResultAsync()
        {
            await using IUnitOfWork unitOfWork = new UnitOfWork();

            var examinationInDb = await unitOfWork.ExaminationRepository.GetByIdAsync(Examination.Id);

            if (SelectedTestResult == "Positiv")
            {
              
                examinationInDb.TestResult = TestResult.Positive;


            }
            else if(SelectedTestResult == "Negativ")
            {
                examinationInDb.TestResult = TestResult.Negative;
            }
            else
            {
                examinationInDb.TestResult = TestResult.Unknown;
            }
            await unitOfWork.SaveChangesAsync();

        }

        private ICommand _cmdExit;
        public ICommand CmdExit
        {
            get
            {
                if (_cmdExit == null)
                {
                    _cmdExit = new RelayCommand(
                        execute: async _ =>
                        {

                            Controller.CloseWindow(this);

                        },
                        canExecute: _ => true
                        );
                }
                return _cmdExit;
            }
        }



        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ParticipantIdentifier))
            {
                yield return new ValidationResult("Der Teilnehmer-Identifier ist nicht gültig ", new string[] { nameof(ParticipantIdentifier) });
                OnPropertyChanged(ParticipantIdentifier);
            }
            else if (string.IsNullOrEmpty(ExaminationIdentifier))
            {
                yield return new ValidationResult("Der Untersuchungs-Identifier ist nicht gültig ", new string[] { nameof(ExaminationIdentifier)});
                OnPropertyChanged(ExaminationIdentifier);
            }

            yield return ValidationResult.Success;
        }

        public static async Task<ParticipantViewModel> CreateAsync(IWindowController controller)
        {
            var viewModel = new ParticipantViewModel(controller);
            return viewModel;
        }


        
    }
}
