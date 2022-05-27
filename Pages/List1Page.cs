using Microsoft.Maui.Layouts;

namespace TabbedListViewTester.Pages
{
    public class List1Page : ContentPage
    {

        public List1Page(StartupPageModel viewModel)
        {
            BindingContext = viewModel;

            #region *// Buttons
            var addButton = new Button { Text = "Add", Margin = 5 };
            addButton.Clicked += (s, e) => { viewModel.OnList1AddPressed.Execute(null); };

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
            var listView = new ListView()
            {
                SelectionMode = ListViewSelectionMode.Single,
                HasUnevenRows = false,
                IsGroupingEnabled = false,
                BackgroundColor = Colors.Transparent,
                SeparatorColor = Colors.Black,
                Margin = 5
            };

            listView.ItemTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center, TextColor = Colors.Black };
                nameLabel.SetBinding(Label.TextProperty, new Binding(nameof(StartupPageModel.DisplayData.Name), BindingMode.TwoWay));

#if false
                // This works
                var layoutGrid = new Grid();
                layoutGrid.Add(nameLabel);
                return new ViewCell { View = layoutGrid };
#else
                // This crash when scrolling
                return new ViewCell { View = nameLabel };
#endif
            });
            listView.SetBinding(ListView.ItemsSourceProperty, new Binding(nameof(StartupPageModel.List1DisplayItems), BindingMode.OneWay));
            #endregion

            var layoutGrid = new Grid();
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            layoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            layoutGrid.Add(actionButtonsGrid, 0, 0);
            layoutGrid.Add(listView, 0, 1);

            Title = "ListView";
            Content = layoutGrid;

            ToolbarItems.Add(new ToolbarItem("Add", "", () => { viewModel.OnList1AddPressed.Execute(null); }, ToolbarItemOrder.Primary));
        }

    }
}
