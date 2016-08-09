using System.ComponentModel;
using System.Runtime.CompilerServices;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    public class DirtyService : IDirtyService
    {
        private bool _isDirty;

        public void MarkClean()
        {
            IsDirty = false;
        }

        public void MarkDirty()
        {
            IsDirty = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            private set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}