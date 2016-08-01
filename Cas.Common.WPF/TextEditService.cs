using System;
using Cas.Common.WPF.Interfaces;
using Cas.Common.WPF.TextEdit;

namespace Cas.Common.WPF
{
    public class TextEditService : ITextEditService
    {
        public void EditText(string text, string caption, string title, Action<string> setter, Func<string, bool> validate = null)
        {
            if (setter == null) throw new ArgumentNullException(nameof(setter));

            var viewModel = new TextEditDialogViewModel(text, caption, title, validate);

            var view = new TextEditDialogView()
            {
                DataContext = viewModel,
                Owner = WindowUtil.GetActiveWindow()
            };

            if (view.ShowDialog() == true)
            {
                setter(viewModel.Text);
            }
        }
    }
}