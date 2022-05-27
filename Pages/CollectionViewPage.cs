using Microsoft.Maui.Layouts;

namespace TabbedListViewTester.Pages
{
    public class CollectionViewPage : ContentPage
    {
        StartupPageModel viewModel;
        public CollectionViewPage(StartupPageModel viewModel)
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

                var layoutGrid = new Grid();
                layoutGrid.Add(nameLabel);

                return layoutGrid;
            });
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, new Binding(nameof(StartupPageModel.List2DisplayItems), BindingMode.OneWay));
            collectionView.RemainingItemsThreshold = 10;
            collectionView.RemainingItemsThresholdReached += CollectionView_RemainingItemsThresholdReached;
            #endregion

            var layoutGrid = new Grid();
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute) });
            layoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            layoutGrid.Add(actionButtonsGrid, 0, 0);
            layoutGrid.Add(collectionView, 0, 1);

            Title = "CollectView";
            Content = layoutGrid;
        }

        private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            viewModel.GetNextItems(10);
        }
    }
}
