using System.Collections.Generic;
using System.Windows;
using NGS_TelephoneBook.Model;

namespace NGS_TelephoneBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			var testData = new List<Contact>()
			{
				new Contact("Kirill", "455264643"),
				new Contact("Las", "432535435")
			};
			LBviewContacts.DataContext = testData;
		}
	}
}
