using System;
using System.Windows.Input;
using Cas.Common.WPF.Behaviors;

namespace TextEditorApplication.Interfaces
{
    public interface IAboutViewModel : ICloseableViewModel
    {
        ICommand CloseCommand { get; }

        Version Version { get; }
    }
}