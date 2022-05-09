
namespace TabbedListViewTester
{
    internal class StartupPageTabbed : TabbedPage
    {
        StartupPageModel viewModel;
        public StartupPageTabbed(StartupPageModel viewModel) 
        {
            this.viewModel = viewModel;

            Children.Add(new List1Page(viewModel));
            Children.Add(new List2Page(viewModel));
            Children.Add(new List3Page(viewModel));
            Children.Add(new List4Page(viewModel));
            Children.Add(new List5Page(viewModel));

            Title = "StartupPage";

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ViewIsFirstAppearing.Execute(null);
        }
    }
}
