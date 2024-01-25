using Fokus.ViewModel;

namespace Fokus;

public partial class TaskPage : ContentPage
{
	public TaskPage(TaskViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}