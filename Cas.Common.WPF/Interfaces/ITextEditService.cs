using System;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// Responsible for editing text.
    /// </summary>
    public interface ITextEditService
    {
        /// <summary>
        /// Edits a small piece of text.
        /// </summary>
        /// <param name="text">The original piece of text.</param>
        /// <param name="caption">The caption of the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="setter">Invoked if the text is successfully edited.</param>
        /// <param name="validate">Optional validation func.</param>
        void EditText(string text, string caption, string title, Action<string> setter, Func<string, bool>  validate = null);
    }
}