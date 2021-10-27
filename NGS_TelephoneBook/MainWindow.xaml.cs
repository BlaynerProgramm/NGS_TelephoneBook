using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NGS_TelephoneBook.Controllers;
using NGS_TelephoneBook.Model;
using NGS_TelephoneBook.View;

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
			UpdateItemSource();
		}

		private void UpdateItemSource() => LBviewContacts.ItemsSource = new ContactController().Contacts;
		private void ButtonBaseAdd_OnClick(object sender, RoutedEventArgs e)
		{
			var window = new CreateOrEditContact();
			window.ShowDialog();
			UpdateItemSource();
		}

		private void LBviewContacts_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var contact = (Contact)LBviewContacts.SelectedItem;
			var window = new CreateOrEditContact(contact);
			window.ShowDialog();
			UpdateItemSource();
		}

		private void ButtonBaseDelete_OnClick(object sender, RoutedEventArgs e)
		{
			var contact = (Contact)LBviewContacts.SelectedItem;
			var controller = new ContactController();
			controller.Delete(contact);
			UpdateItemSource();
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			LBviewContacts.ItemsSource = new ContactController().Contacts.Where(x => x.Name.ToLower().StartsWith(tbSearch.Text.ToLower()));
		}
	}
}
