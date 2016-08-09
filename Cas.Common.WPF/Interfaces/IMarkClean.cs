namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// Marks an item as no longer having any unsaved changes.
    /// </summary>
    public interface IMarkClean
    {
        /// <summary>
        /// Marks the item as having no unsaved changes. Typically called after loading from file and after saving to a file.
        /// </summary>
        void MarkClean();
    }
}