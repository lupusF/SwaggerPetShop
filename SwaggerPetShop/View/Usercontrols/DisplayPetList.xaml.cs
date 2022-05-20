using SwaggerPetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwaggerPetShop.View.Usercontrols
{
    /// <summary>
    /// Interaction logic for DisplayPetList.xaml
    /// </summary>
    public partial class DisplayPetList : UserControl
    {


        public Pet Pet
        {
            get { return (Pet)GetValue(PetProperty); }
            set { SetValue(PetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Pet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PetProperty =
            DependencyProperty.Register("Pet", typeof(Pet), typeof(DisplayPetList), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DisplayPetList displayPetListUserControl = d as DisplayPetList;

            if(displayPetListUserControl != null)
            {
                displayPetListUserControl.DataContext = displayPetListUserControl.Pet;
            }
        }

        public DisplayPetList()
        {
            InitializeComponent();
        }
    }
}
