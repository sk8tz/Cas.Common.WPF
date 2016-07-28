using System.Collections.ObjectModel;

namespace BindableSelectedTreeViewItemExample.ViewModel
{
    public class NodeViewModel
    {
        private readonly string _name;
        private readonly ObservableCollection<NodeViewModel> _children = new ObservableCollection<NodeViewModel>();

        public NodeViewModel(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public ObservableCollection<NodeViewModel> Children
        {
            get { return _children; }
        }
    }
}