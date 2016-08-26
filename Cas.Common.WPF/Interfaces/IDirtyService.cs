using System.ComponentModel;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// Keeps track of whether a persistable unit is dirty (requires saving) or not.
    /// </summary>
    public interface IDirtyService : IMarkClean, IMarkDirty, INotifyPropertyChanged
    {
        /// <summary>
        /// Returns true of the persistable unit has unsaved changes, false otherwise. 
        /// </summary>
        bool IsDirty { get; } 
    }
}