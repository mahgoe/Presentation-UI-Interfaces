using System.Collections.ObjectModel;
using System.ComponentModel;
using TreeViewDemo.Models;

namespace TreeViewDemo.ViewModels
{
    /// <summary>
    /// ViewModel for representing a hierarchical tree structure
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Collection of top-level tree items
        /// </summary>
        public ObservableCollection<TreeItem> RootItems { get; set; }

        private TreeItem _selectedRootItem;

        /// <summary>
        /// Event triggered when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify subscribers of property changes
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Currently selected tree item
        /// </summary>
        public TreeItem SelectedRootItem
        {
            get { return _selectedRootItem; }
            set
            {
                if (_selectedRootItem != value)
                {
                    _selectedRootItem = value;
                    OnPropertyChanged(nameof(SelectedRootItem));
                }
            }
        }

        /// <summary>
        /// Initializes tree items with predefined data
        /// </summary>
        public MainViewModel()
        {
            RootItems = new ObservableCollection<TreeItem>
            {
                CreateTreeItem("Früchte und Gemüse",
                    CreateTreeItem("Früchte",
                        CreateTreeItem("Apfel"),
                        CreateTreeItem("Mango"),
                        CreateTreeItem("Granatapfel"),
                        CreateTreeItem("Getrocknete Früchte",
                            CreateTreeItem("Getrocknete Bananen ;)")
                        )
                    ),
                    CreateTreeItem("Exotische Früchte",
                        CreateTreeItem("Maracuja"),
                        CreateTreeItem("Drachenfrucht")
                    ),
                    CreateTreeItem("Gemüse",
                        CreateTreeItem("Karotte"),
                        CreateTreeItem("Sellerie")
                    )
                ),
                CreateTreeItem("Automarken und Automodelle",
                    CreateTreeItem("Mercedes-Benz",
                        CreateTreeItem("A-Klasse"),
                        CreateTreeItem("C-Klasse",
                            CreateTreeItem("C63 AMG")
                        )
                    ),
                    CreateTreeItem("BMW",
                        CreateTreeItem("M135i"),
                        CreateTreeItem("M6")
                    )
                ),
                CreateTreeItem("Linux Distributionen",
                    CreateTreeItem("Debian-basiert",
                        CreateTreeItem("Ubuntu",
                        CreateTreeItem("Xubuntu"),
                        CreateTreeItem("Kubuntu"),
                        CreateTreeItem("Lubuntu")
                 ),
                CreateTreeItem("Debian",
                    CreateTreeItem("Raspbian"),
                    CreateTreeItem("MX Linux")
                ),
                    CreateTreeItem("Mint")
                ),
                CreateTreeItem("Red Hat-basiert",
                    CreateTreeItem("Fedora",
                    CreateTreeItem("Korora"),
                    CreateTreeItem("Fedora Silverblue")
                ),
                CreateTreeItem("CentOS"),
                CreateTreeItem("Red Hat Enterprise Linux")
                ),
               CreateTreeItem("Arch-basiert",
                CreateTreeItem("Arch Linux",
                CreateTreeItem("Manjaro"),
                CreateTreeItem("Antergos")
                ),
              CreateTreeItem("Arch Labs"),
                CreateTreeItem("ArcoLinux")
            ),
            CreateTreeItem("Unabhängige Distributionen",
                CreateTreeItem("Solus"),
                CreateTreeItem("Gentoo"),
                CreateTreeItem("Slackware")
                    )
                )
            };
        }

        /// <summary>
        /// Helper method to create tree items
        /// </summary>
        /// <param name="name"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        private TreeItem CreateTreeItem(string name, params TreeItem[] children)
        {
            return new TreeItem
            {
                Name = name,
                Children = new ObservableCollection<TreeItem>(children)
            };
        }
    }
}
