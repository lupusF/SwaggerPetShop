using SwaggerPetShop.Commands;
using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Implementation;
using SwaggerPetShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SwaggerPetShop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        #region Fields
        private IFindByStatusService _findByStatusService;
        private IAddPetService _addPetService;
        private IDeletePetService _deletePetService;
        private IGetByIdService _getByIdService;
        private IUpdatePetService _updatePetService;
        private bool _isNew;
        #endregion

        #region properties
        public ObservableCollection<Pet> PetList { get; set; }

        public Pet? PetToDisplay { get; set; }
        public string PetId { get; set; }

        private Pet _selectedPet;
        public Pet? SelectedPet
        {
            get { return _selectedPet; }
            set
            {
                _selectedPet = value;
                OnPropertyChanged("SelectedPet");
            }
        }

        private PetStatus _selectedPetStatus;
        public PetStatus SelectedPetStatus
        {
            get { return _selectedPetStatus; }
            set
            {
                _selectedPetStatus = value;
                OnPropertyChanged("SelectedPetStatus");
            }
        }

        private bool _isPopUpOpen;
        public bool IsPopUpOpen
        {
            get { return _isPopUpOpen; }
            set
            {
                _isPopUpOpen = value;
                OnPropertyChanged("IsPopUpOpen");
            }
        }

        private Visibility _petDetailsVisibility;
        public Visibility PetDetailsVisibility
        {
            get { return _petDetailsVisibility; }
            set
            {
                _petDetailsVisibility = value;
                OnPropertyChanged("PetDetailsVisibility");
            }
        }

        private bool _searchById;
        public bool SearchById
        {
            get { return _searchById; }
            set
            {
                _searchById = value;
                OnPropertyChanged("SeaarchById");
            }
        }

        private bool _searchByStatus;

        public bool SearchByStatus
        {
            get { return _searchByStatus; }
            set
            {
                _searchByStatus = value;
                OnPropertyChanged("SearchByStatus");
            }
        }

        private string _popupMessage;

        public string PopupMessage
        {
            get { return _popupMessage; }
            set
            {
                _popupMessage = value;
                OnPropertyChanged("PopupMessage");
            }
        }


        #endregion

        #region Commands
        public SaveButtonClickedCommand SaveButtonClickedCommand { get; set; }
        public ViewUpdateClickedCommand ViewUpdateClickedCommand { get; set; }
        public DeletePetCommand DeletePetCommand { get; set; }
        public CancelClickedCommand CancelClickedCommand { get; set; }
        public AddNewItemClickedCommand AddNewItemClickedCommand { get; set; }
        public SearchClickedCommand SearchClickedCommand { get; set; }
        public RadioButtonLostFocusCommand RadioButtonLostFocusCommand { get; set; }
        public SelectionChangedCommand SelectionChangedCommand { get; set; }
        #endregion

        #region ctor
        public MainViewModel(IFindByStatusService findByStatusService
                            , IAddPetService addPetService
                            , IDeletePetService deletePetService
                            , IGetByIdService getByIdService
                            , IUpdatePetService updatePetService)
        {
            _findByStatusService = findByStatusService;
            _addPetService = addPetService;
            _deletePetService = deletePetService;
            _getByIdService = getByIdService;
            _updatePetService = updatePetService;

            RadioButtonLostFocusCommand = new RadioButtonLostFocusCommand(this);
            SaveButtonClickedCommand = new SaveButtonClickedCommand(this);
            ViewUpdateClickedCommand = new ViewUpdateClickedCommand(this);
            DeletePetCommand = new DeletePetCommand(this);
            CancelClickedCommand = new CancelClickedCommand(this);
            AddNewItemClickedCommand = new AddNewItemClickedCommand(this);
            SearchClickedCommand = new SearchClickedCommand(this);
            SelectionChangedCommand = new SelectionChangedCommand(this);

            PetList = new ObservableCollection<Pet>();
            IsPopUpOpen = false;
            PetDetailsVisibility = Visibility.Hidden;
        }
        #endregion

        #region ApiCalls
        public async void FindPetByStatus()
        {
            var result = await _findByStatusService.FindByStatus(SelectedPetStatus.ToString());

            if (result.Message.Equals("OK"))
            {
                PetList?.Clear();

                foreach (var pet in result.PetList)
                {
                    PetList.Add(pet);
                }
            }
            else
            {
                SetErrorMessage(result.Message); 
                IsPopUpOpen = true;
            }


        }
        public async void GetById()
        {
            var result = await _getByIdService.GetById(PetId);

            if (result.Message.Equals("OK"))
            {
                PetList?.Clear();

                PetList.Add(result.Pet);
            }
            else
            {
                SetErrorMessage(result.Message);
                IsPopUpOpen = true;
            }
        }

        public async void AddPet(Pet pet)
        {
            PetList.Clear();
            var result = await _addPetService.AddPet(pet);

            if (result.Message.Equals("OK"))
            {
                PetToDisplay = null;
                PetDetailsVisibility = Visibility.Collapsed;
                PopupMessage = "Pet added";
            }
            else
            {
                SetErrorMessage(result.Message);
            }
            IsPopUpOpen = true;
        }

        public async void DeletePet()
        {
            var result = await _deletePetService.DeletePet((long)SelectedPet.id);

            if (result.Message.Equals("OK"))
            {
                PetDetailsVisibility = Visibility.Collapsed;
                PetList.Remove(SelectedPet);
                PopupMessage = "Pet is deleted";
            }
            else
            {
                SetErrorMessage(result.Message);
            }
            
            IsPopUpOpen = true;
        }

        public async void UpdatePet(Pet pet)
        {
            var result = await _updatePetService.UpdatePet(pet);

            if (result.Message.Equals("OK"))
            {
                SelectedPet = null;
                PetDetailsVisibility = Visibility.Collapsed;
                PopupMessage = "Pet is updated";
            }
            else
            {
                SetErrorMessage(result.Message);
            }
            IsPopUpOpen = true;
        }
        #endregion

        #region Methods
        public void SaveButtonClicked(Pet pet)
        {
            if (_isNew)
            {
                AddPet(pet);
            }
            else
            {
                UpdatePet(pet);
            }
            _isNew = false;
        }
        public void CancelClicked()
        {
            PetDetailsVisibility = Visibility.Hidden;
            SelectedPet = null;
            PetToDisplay = null;
        }

        public void AddNewItemClicked()
        {
            _isNew = true;
            PetDetailsVisibility = Visibility.Visible;
            PetToDisplay = SetDefaultValues();
            PetId = String.Empty;
            OnPropertyChanged("PetToDisplay");
            OnPropertyChanged("PetId");
        }

        public void SearchClicked()
        {
            PetList.Clear();
            if (SearchById)
            {
                GetById();
            }
            else
            {
                FindPetByStatus();
            }
        }

        public void ViewUpdateClicked()
        {
            PetDetailsVisibility = Visibility.Visible;
            PetToDisplay = SelectedPet;
            PetList.Clear();
            OnPropertyChanged("PetToDisplay");
        }

        public void RadioButtonLostFocus()
        {
            if (!SearchById)
            {
                PetId = String.Empty;
                OnPropertyChanged("PetId");
            }
        }

        public void SelectionChanged()
        {
            if (PetList.Count > 0)
            {
                PetList.Clear();
            }
        }
        #endregion

        #region Helpers
        private Pet SetDefaultValues()
        {
            return new Pet()
            {
                category = new Category(),
                photoUrls = new List<string>
                {
                     ""
                },
                tags = new List<Tag>()
                {
                           new Tag()
                           {
                                id = 1
                           }
                },
            };
        }
        private void SetErrorMessage(string msg)
        {
            PopupMessage=$"{"Something went wrong! "}{"Message: "}{msg}";
        }
        #endregion
    }
}
