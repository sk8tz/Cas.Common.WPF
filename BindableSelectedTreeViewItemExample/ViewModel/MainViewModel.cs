using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Cas.Common.WPF;

namespace BindableSelectedTreeViewItemExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<NodeViewModel> _nodes = new ObservableCollection<NodeViewModel>();
        private NodeViewModel _selectedNode;

        public MainViewModel()
        {
            var node1 = new NodeViewModel("Node 1");
            node1.Children.Add(new NodeViewModel("Node 1.1"));
            node1.Children.Add(new NodeViewModel("Node 1.2"));

            var node2 = new NodeViewModel("Node 2");
            node2.Children.Add(new NodeViewModel("Node 2.1"));
            node2.Children.Add(new NodeViewModel("Node 2.2"));

            _nodes.Add(node1);
            _nodes.Add(node2);
        }

        public NodeViewModel SelectedNode
        {
            get { return _selectedNode; }
            set
            {
                _selectedNode = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NodeViewModel> Nodes
        {
            get { return _nodes; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}