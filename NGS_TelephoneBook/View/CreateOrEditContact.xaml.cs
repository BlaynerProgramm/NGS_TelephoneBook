using System.Windows;
using System.Windows.Markup;
using NGS_TelephoneBook.Model;
using NGS_TelephoneBook.Controllers;

namespace NGS_TelephoneBook.View
{
	/// <summary>
	/// Interaction logic for CreateOrEditContact.xaml
	/// </summary>
	public partial class CreateOrEditContact : Window
	{
		/// <summary>
		/// Создание контакта
		/// </summary>
		public CreateOrEditContact()
		{
			InitializeComponent();
			bt.Click += Bt_OnClick;
		}

		private readonly int _id;
		/// <summary>
		/// Редактирование контакта
		/// </summary>
		/// <param name="contact"></param>
		public CreateOrEditContact(Contact contact)
		{
			InitializeComponent();
			_id = contact.Id;
			tbName.Text = contact.Name;
			tbPhone.Text = contact.Phone;
			bt.Content = "Изменить";
			bt.Click += Bt_onClickEdit;
		}

		private void Bt_OnClick(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tbPhone.Text))
			{
				var controller = new ContactController();
				controller.Create(tbName.Text, tbPhone.Text);
				MessageBox.Show("Создано");
				Close();
			}
			else
			{
				MessageBox.Show("Введите валидные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Bt_onClickEdit(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tbPhone.Text))
			{
				var controller = new ContactController();
				controller.Edit(new Contact(tbName.Text, tbPhone.Text, _id));
				MessageBox.Show("Изменено");
				Close();
			}
			else
			{
				MessageBox.Show("Введите валидные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}