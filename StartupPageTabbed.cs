
using TabbedListViewTester.Pages;

namespace TabbedListViewTester
{
    internal class StartupPageTabbed : TabbedPage
    {
        StartupPageModel viewModel;
        public StartupPageTabbed(StartupPageModel viewModel) 
        {
            this.viewModel = viewModel;

            Children.Add(new List1Page(viewModel));
            Children.Add(new CollectionViewPage(viewModel));

            Title = "StartupPage";

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ViewIsFirstAppearing.Execute(null);
        }
    }
}
