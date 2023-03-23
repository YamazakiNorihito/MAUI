using FlyoutNavigation.Pages;

namespace FlyoutNavigation;

public partial class AppShell : Shell
{
    // Dynamically create list of FlyoutItem in Shell?
    // https://stackoverflow.com/questions/65911023/dynamically-create-list-of-flyoutitem-in-shell
    public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("astronomicalbodydetails", typeof(AstronomicalBodyPage));
    }
}
