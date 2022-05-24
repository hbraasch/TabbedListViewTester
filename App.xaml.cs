using TabbedListViewTester.Pages;

namespace TabbedListViewTester;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new StartupPageTabbed(new StartupPageModel())) { BarBackgroundColor = Colors.LightGray, BarTextColor = Colors.Black };

        // MainPage = new NavigationPage(new JustCollectionViewPage(new StartupPageModel())) { BarBackgroundColor = Colors.LightGray, BarTextColor = Colors.Black };
    }
}
