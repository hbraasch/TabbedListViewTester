using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TabbedListViewTester
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class StartupPageModel
    {
        public class DisplayData
        {
            public string Name { get; set; }
        }


        public ObservableCollection<DisplayData> List1DisplayItems { get; set; }
        public ObservableCollection<DisplayData> List2DisplayItems { get; set; }
        public ObservableCollection<DisplayData> List3DisplayItems { get; set; }
        public ObservableCollection<DisplayData> List4DisplayItems { get; set; }
        public ObservableCollection<DisplayData> List5DisplayItems { get; set; }


        public StartupPageModel()
        {
            List1DisplayItems = new ObservableCollection<DisplayData>();
            List2DisplayItems = new ObservableCollection<DisplayData>();
            List3DisplayItems = new ObservableCollection<DisplayData>();
            List4DisplayItems = new ObservableCollection<DisplayData>();
            List5DisplayItems = new ObservableCollection<DisplayData>();
        }



        public ICommand ViewIsFirstAppearing => new Command(() =>
        {
            UpdateDisplay();
        });

        private void UpdateDisplay()
        {
            var list1 = new List<DisplayData>();
            var list2 = new List<DisplayData>();
            var list3 = new List<DisplayData>();
            var list4 = new List<DisplayData>();
            var list5 = new List<DisplayData>();

            for (int i = 0; i < 400; i++)
            {
                list1.Add(new DisplayData() { Name = $"List 1 item {i}" });
                list2.Add(new DisplayData() { Name = $"List 2 item {i}" });
                list3.Add(new DisplayData() { Name = $"List 3 item {i}" });
                list4.Add(new DisplayData() { Name = $"List 4 item {i}" });
                list5.Add(new DisplayData() { Name = $"List 5 item {i}" });
            }
            List1DisplayItems = new ObservableCollection<DisplayData>(list1);
            List2DisplayItems = new ObservableCollection<DisplayData>(list2);
            List3DisplayItems = new ObservableCollection<DisplayData>(list3);
            List4DisplayItems = new ObservableCollection<DisplayData>(list4);
            List5DisplayItems = new ObservableCollection<DisplayData>(list5);
        }


        public ICommand OnList1AddPressed => new Command(() =>
        {
            var list = List1DisplayItems.ToList();
            list.Add(new DisplayData { Name = "Added item" });
            list = list.OrderBy(o => o.Name).ToList();
            List1DisplayItems = new ObservableCollection<DisplayData>(list);
        });

        public ICommand OnCollectionViewAddPressed => new Command(() =>
        {
            var list = List2DisplayItems.ToList();
            list.Add(new DisplayData { Name = "Added item" });
            list = list.OrderBy(o => o.Name).ToList();
            List2DisplayItems = new ObservableCollection<DisplayData>(list);
        });
    }
}
