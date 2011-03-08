namespace System.Windows.Input
{
	public interface ICommand
	{
		event EventHandler CanExecuteChanged;
		bool CanExecute(object parameter);
		void Execute(object parameter);
	}
}