using System.Collections.ObjectModel;

namespace TreeViewDemo.Models
{
    /// <summary>
    /// Represents an individual node in a tree structure.
    /// </summary>
    public class TreeItem
    {
        /// <summary>
        /// Name of the tree item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of child tree items.
        /// </summary>
        public ObservableCollection<TreeItem> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the TreeItem class.
        /// </summary>
        public TreeItem()
        {
            Children = new ObservableCollection<TreeItem>();
        }
    }
}
