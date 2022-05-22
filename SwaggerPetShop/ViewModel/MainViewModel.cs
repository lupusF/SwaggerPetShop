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

        public Pet PetToDisplay { get; set; }

        private Pet _selectedPet;
        public Pet SelectedPet
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
        public string PetId { get; set; }

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


        #endregion

        #region Commands
        public FindByStatusCommand FindByStatusCommad { get; set; }
        public AddPetCommand AddPetCommand { get; set; }
        public ViewUpdateClickedCommand ViewUpdateClickedCommand { get; set; }
        public GetByIdCommand GetByIdCommand { get; set; }
        public DeletePetCommand DeletePetCommand { get; set; }
        public UpdatePetCommand UpdatePetCommand { get; set; }
        public CancelClickedCommand CancelCommand { get; set; }
        public AddNewItemClickedCommand AddNewItemClickedCommand { get; set; }
        #endregion

        public MainViewModel(IFindByStatusService findByStatusService
                            ,IAddPetService addPetService
                            ,IDeletePetService deletePetService
                            ,IGetByIdService getByIdService
                            ,IUpdatePetService updatePetService)
        {
            _findByStatusService = findByStatusService;
            _addPetService = addPetService;
            _deletePetService = deletePetService;
            _getByIdService = getByIdService;
            _updatePetService = updatePetService;


            FindByStatusCommad = new FindByStatusCommand(this);
            AddPetCommand = new AddPetCommand(this);
            ViewUpdateClickedCommand = new ViewUpdateClickedCommand(this);
            GetByIdCommand = new GetByIdCommand(this);
            UpdatePetCommand = new UpdatePetCommand(this);
            DeletePetCommand = new DeletePetCommand(this);
            CancelCommand = new CancelClickedCommand(this);
            AddNewItemClickedCommand = new AddNewItemClickedCommand(this);

            PetList = new ObservableCollection<Pet>();
            SelectedPetStatus = PetStatus.sold;
            IsPopUpOpen = false;
            PetDetailsVisibility = Visibility.Hidden;
            }

        #region ApiCalls
        public async void FindPetByStatus()
        {
            var result = await _findByStatusService.FindByStatus(SelectedPetStatus.ToString());
           
            PetList?.Clear();

            foreach(var pet in result)
            {
                PetList.Add(pet);
            }
        }
        public async void GetById()
        {
            var result = await _getByIdService.GetById(PetId);

            if(result != null)
            {
                PetList?.Clear();
          
                PetList.Add(result);
            }
            else
            {
                IsPopUpOpen = true;
            }
        }

        public async void AddPet1(Pet pet)
        {
            var res = await _addPetService.AddPet(pet);

            if (res)
            {
                PetToDisplay = null;
                PetDetailsVisibility = Visibility.Collapsed;
            }
            else
            {
                IsPopUpOpen = true;
            }
        }

        public void AddPet(Pet pet)
        {
            if(_isNew)
            {
                AddPet1(pet);
            }
            else
            {
                UpdatePet(pet);
            }
        }

        public async void DeletePet()
        {
            var result = await _deletePetService.DeletePet((long)SelectedPet.id);

            if (result)
            {
                PetDetailsVisibility = Visibility.Collapsed;
                PetList.Clear();
            }
            else
            {
                IsPopUpOpen = true;
            }
        }

        public async void UpdatePet(Pet pet)
        {
           var result = await _updatePetService.UpdatePet(pet);

            if (result)
            {
                SelectedPet = null;
                PetDetailsVisibility = Visibility.Collapsed;
            }
            else
            {
                IsPopUpOpen = true;
            }
        }

        #endregion
        public void CancelClicked()
        {
            PetDetailsVisibility = Visibility.Hidden;
        }

        public void AddNewItemClicked()
        {
            _isNew = true;
            PetDetailsVisibility = Visibility.Visible;
            PetToDisplay = SetDefaultValues();
            OnPropertyChanged("PetToDisplay");
        }

        public async void ViewUpdateClicked()
        {
            PetDetailsVisibility = Visibility.Visible;
            PetToDisplay = SelectedPet;
            OnPropertyChanged("PetToDisplay");
        }

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
        #endregion
    }
}
