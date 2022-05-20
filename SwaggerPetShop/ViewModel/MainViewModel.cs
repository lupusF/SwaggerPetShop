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
        #endregion

        #region properties
        public ObservableCollection<Pet> PetList { get; set; }

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

        #endregion

        #region Commands
        public FindByStatusCommand FindByStatusCommad { get; set; }
        public AddPetCommand AddPetCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public GetByIdCommand GetByIdCommand { get; set; }
        public DeletePetCommand DeletePetCommand { get; set; }
        public UpdatePetCommand UpdatePetCommand { get; set; }

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
            SearchCommand = new SearchCommand(this);
            GetByIdCommand = new GetByIdCommand(this);
            UpdatePetCommand = new UpdatePetCommand(this);
            DeletePetCommand = new DeletePetCommand(this);

            PetList = new ObservableCollection<Pet>();
            SelectedPetStatus = PetStatus.sold;
            IsPopUpOpen = false;

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

        public async void AddPet(Pet pet)
        {
            _addPetService.AddPet(CreatePetDummy());
        }

        public async void DeletePet()
        {
            _deletePetService.DeletePet((int)SelectedPet.id);
        }

        public async void UpdatePet()
        {
            _updatePetService.UpdatePet();
        }


        public async void SearchClicked()
        {

        }
        #endregion

        #region Helpers
        Pet CreatePetDummy()
        {
            return new Pet()
            {
                category = new Category()
                {
                    id = 0,
                    name = "category"
                },
                id = 0,
                name = "morzsi",
                photoUrls = new List<string>(),
                status = PetStatus.pending.ToString(),
                tags = new List<Tag>()
                      {
                           new Tag()
                           {
                                id = 0,
                                 name = "tagName"
                           }
                      }
            };
        }
        #endregion
    }
}
