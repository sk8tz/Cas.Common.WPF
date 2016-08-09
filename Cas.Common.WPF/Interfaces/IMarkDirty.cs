namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// For marking a persistable unit as dirty.
    /// </summary>
    public interface IMarkDirty
    {
        /// <summary>
        /// Marks the unit as dirty.
        /// </summary>
        void MarkDirty();
    }
}