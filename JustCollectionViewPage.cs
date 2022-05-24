using Microsoft.Maui.Layouts;

namespace TabbedListViewTester.Pages
{
    public class JustCollectionViewPage : ContentPage
    {
        StartupPageModel viewModel;
        public JustCollectionViewPage(StartupPageModel viewModel)
        {
            this.viewModel = viewModel;
            BindingContext = viewModel;

            #region *// Buttons
            var addButton = new Button { Text = "Add", Margin = 5 };
            addButton.Clicked += (s, e) => { viewModel.OnCollectionViewAddPressed.Execute(null); };

            var editButton = new Button { Text = "Edit", Margin = 5 };
            editButton.Clicked += (s, e) => { };

            var deleteButton = new Button { Text = "Delete", Margin = 5 };
            deleteButton.Clicked += (s, e) => { };

            var actionButtonsGrid = new Grid();
            actionButtonsGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            actionButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            actionButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            actionButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            actionButtonsGrid.Add(addButton, 0, 0);
            actionButtonsGrid.Add(editButton, 1, 0);
            actionButtonsGrid.Add(deleteButton, 2, 0);
            #endregion

            #region *// List
            var collectionView = new CollectionView()
            {
                SelectionMode = SelectionMode.Single,
                BackgroundColor = Colors.Transparent,
                Margin = 5
            };

            collectionView.ItemTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center, TextColor = Colors.Black };
                nameLabel.SetBinding(Label.TextProperty, new Binding(nameof(StartupPageModel.DisplayData.Name), BindingMode.TwoWay));

                var seperator = new BoxView { HeightRequest = 1, BackgroundColor = Colors.Black };

                Grid grid = new Grid { Padding = 10 };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.Add(nameLabel, 0, 0);
                grid.Add(seperator, 0, 1);

                return nameLabel;
            });
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, new Binding(nameof(StartupPageModel.List2DisplayItems), BindingMode.OneWay));
            collectionView.RemainingItemsThreshold = 10;
            collectionView.RemainingItemsThresholdReached += CollectionView_RemainingItemsThresholdReached;
            #endregion

            var layout = new VerticalStackLayout { Children = { actionButtonsGrid, collectionView }, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Center, Padding = 20 };


            Title = "CollectView";
            Content = collectionView;
        }

        private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            viewModel.GetNextItems(10);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ViewIsFirstAppearing.Execute(null);
        }
    }
}
