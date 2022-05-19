using SwaggerPetShop.Commands;
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
        #endregion

        #region properties
        public ObservableCollection<Pet> PetList { get; set; }

        private Pet _pet;

        public Pet Pet
        {
            get { return _pet; }
            set 
            { 
                _pet = value;
                OnPropertyChanged("SelectedPet");
            }
        }


        #endregion

        #region Commands
        public GetPetByStatusCommand GetPetByStatusCommad { get; set; }
        #endregion

        public MainViewModel(IFindByStatusService findByStatusService)
        {
            _findByStatusService = findByStatusService;

            GetPetByStatusCommad = new GetPetByStatusCommand(this);

            PetList = new ObservableCollection<Pet>();
        }

        #region methods
        public async void GetPetByStatus()
        {
            var result = await _findByStatusService.FindByStatus("");
            PetList?.Clear();

            foreach(var pet in result)
            {
                PetList.Add(pet);
            }
        }
        #endregion
    }
}
