using Xamarin.Forms;
using FT.Views;
namespace FT
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FTEntry_Page), typeof(FTEntry_Page));
        }

    }
}