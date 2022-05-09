using Microsoft.Maui.Layouts;

namespace TabbedListViewTester
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
            editButton.Clicked += (s, e) => {  };

            var deleteButton = new Button { Text = "Delete", Margin = 5 };
            deleteButton.Clicked += (s, e) => {  };

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

            listView.ItemTemplate = new DataTemplate(() => { return new ListViewDataTemplate(); });
            listView.SetBinding(ListView.ItemsSourceProperty, new Binding(nameof(StartupPageModel.List1DisplayItems), BindingMode.OneWay));
            #endregion

            var layout = new VerticalStackLayout { Children = { actionButtonsGrid, listView }, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Center, Padding = 20 };


            Title = "List1";
            Content = layout;
        }


        public class ListViewDataTemplate : ViewCell
        {

            public ListViewDataTemplate()
            {

                var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center, TextColor = Colors.Black };
                nameLabel.SetBinding(Label.TextProperty, new Binding(nameof(StartupPageModel.DisplayData.Name), BindingMode.TwoWay));

                View = nameLabel;

            }

        }
    }
}
