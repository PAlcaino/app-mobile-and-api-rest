using debts_app.DataAccess;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace DebtsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var dataAccess = new DataAccess();
            var data = await dataAccess.GetDebts();

            var itemsCell = data.Select(x => x.Amount);

            //ListView.ItemsSource = data;
        }
    }
}
