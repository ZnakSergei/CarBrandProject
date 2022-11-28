using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class ModelDetailsFormViewModel : BaseViewModel
    {
        private string _modelName;
        public string ModelName
        {
            get { return _modelName; }
            set
            {
                _modelName = value;
                OnPropertyChanged(nameof(ModelName));
            }
        }

        private string _typeOfFuel;
        public string TypeOfFuel 
        {
            get { return _typeOfFuel; }
            set
            {
                _typeOfFuel = value;
                OnPropertyChanged(nameof(TypeOfFuel));
            }
        }

        private string _dateOnMarket;
        public string DateOnMarket 
        {
            get { return _dateOnMarket; }
            set
            {
                _dateOnMarket = value;
                OnPropertyChanged(nameof(DateOnMarket));
            }
        }

        private string _modelClass;
        public string ModelClass
        {
            get { return _modelClass; }
            set
            {
                _modelClass = value;
                OnPropertyChanged(nameof(_modelClass));
            }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _passangerCapacity;
        public int PassangerCapacity
        {
            get
            {
                return _passangerCapacity;
            }
            set
            {
                _passangerCapacity = value;
                OnPropertyChanged(nameof(PassangerCapacity));
            }
        }

        private bool _isAvalable;
        
        public bool IsAvalable
        {
            get { return _isAvalable; }
            set
            {
                _isAvalable = value;
                OnPropertyChanged(nameof(IsAvalable));
            }
        }

        public ICommand SubmitModelCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ModelDetailsFormViewModel(ICommand submitModelCommand, ICommand cancelCommand)
        {
            SubmitModelCommand = submitModelCommand;
            CancelCommand = cancelCommand;
        }
    }
}
