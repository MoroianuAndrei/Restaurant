using System.Windows.Input;

namespace Restaurant.ViewModels.Commands;

public class RelayCommand<T>(Action<T> workToDo, Predicate<T> canExecute) : ICommand
{
    private readonly Action<T> _commandTask = workToDo;

    public RelayCommand(Action<T> workToDo)
        : this(workToDo, DefaultCanExecute)
    {
        _commandTask = workToDo;
    }

    private static bool DefaultCanExecute(T parameter)
    {
        return true;
    }

    public bool CanExecute(object parameter)
    {
        return canExecute != null && canExecute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object parameter)
    {
        _commandTask((T)parameter);
    }
}