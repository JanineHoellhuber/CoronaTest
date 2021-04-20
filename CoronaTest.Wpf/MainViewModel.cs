using CoronaTest.Core.Contracts;
using CoronaTest.Core.DTOs;
using CoronaTest.Core.Enums;
using CoronaTest.Persistence;
using CoronaTest.Wpf.Common;
using CoronaTest.Wpf.Common.Contracts;
using CoronaTest.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaTest.WPF
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<ExaminationsDto> _examinations;
        public int _negativTest;
        public int _positivTest;
        public DateTime? _from;
        public DateTime? _to;

        public ObservableCollection<ExaminationsDto> Examinations
        {
            get => _examinations;
            set
            {
                _examinations = value;
                OnPropertyChanged(nameof(Examinations));
            }

        }

        public int NegativTest
        {
            get => _negativTest;
            set
            {
                _negativTest = value;
                OnPropertyChanged(nameof(NegativTest));
            }

        }
        public int PositivTest
        {
            get => _positivTest;
            set
            {
                _positivTest = value;
                OnPropertyChanged(nameof(PositivTest));
            }

        }
        public DateTime? From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
                _ = LoadDataAsync();
            }

        }
        public DateTime? To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
                _ = LoadDataAsync();

            }

        }
        public MainViewModel(IWindowController windowController) : base(windowController)
        {
            LoadCommands();
           Test();
        }

        private void LoadCommands()
        {
        }

        public async Task Test()
        {
             await using IUnitOfWork uow = new UnitOfWork();
            var testresultsnegativ = await uow.ExaminationRepository.NegativTests();

            NegativTest = Examinations
                .Count(n => n.TestResult == TestResult.Negative);
            PositivTest = Examinations
                .Count(p => p.TestResult == TestResult.Positive);
        }

        private async Task LoadDataAsync()
        {
            await using IUnitOfWork uow = new UnitOfWork();
            var examinations = await uow.ExaminationRepository.GetExaminationByDate(From, To);
            Examinations = new ObservableCollection<ExaminationsDto>(examinations);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public static async Task<MainViewModel> CreateAsync(IWindowController windowController)
        {
            var viewModel = new MainViewModel(windowController);
            await viewModel.LoadDataAsync();
            return viewModel;
        }

        private ICommand _cmdParticipant;
        public ICommand CmdParticipant
        {
            get
            {
                if (_cmdParticipant == null)
                {
                    _cmdParticipant = new RelayCommand(
                        execute: _ =>
                        {
                            Controller.ShowWindow(new ParticipantViewModel(Controller), true);
                            LoadDataAsync();
                        },
                        canExecute: _ => true);
                }
                return _cmdParticipant;
            }
        }
        private ICommand _cmdCancel;

        public ICommand CmdCancel
        {
            get
            {
                if (_cmdCancel == null)
                {
                    _cmdCancel = new RelayCommand(
                        execute: _ =>
                        {
                            From = null;
                            To = null;
                            LoadDataAsync();
                        },
                        canExecute: _ => true);
                }
                return _cmdCancel;
            }

        }
    }
}





























