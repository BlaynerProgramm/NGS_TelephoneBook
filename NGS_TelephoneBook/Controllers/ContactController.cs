using System.Collections.Generic;
using System.Data.SqlClient;
using NGS_TelephoneBook.Model;

namespace NGS_TelephoneBook.Controllers
{
	public class ContactController
	{
		/// <summary>
		/// Все контакты
		/// </summary>
		public List<Contact> Contacts { get; set; }

		public ContactController()
		{
			Contacts = new List<Contact>();
			const string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=Phone_Book;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStr))
			{
				connection.Open();
				var command = new SqlCommand("SELECT * FROM dbo.Contact", connection);
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					Contacts.Add(new Contact((string)reader[1], (string)reader[2], (int)reader[0]));
				}
			}
		}

		public void Create(string name, string phone)
		{
			const string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=Phone_Book;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStr))
			{
				connection.Open();
				var command = new SqlCommand($"INSERT Contact VALUES ('{name}', '{phone}')", connection);
				command.ExecuteNonQuery();
			}
		}

		public void Edit(Contact contact)
		{
			const string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=Phone_Book;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStr))
			{
				connection.Open();
				var command = new SqlCommand($"UPDATE Contact SET Name = '{contact.Name}', Phone = '{contact.Phone}' WHERE Id = '{contact.Id}'", connection);
				command.ExecuteNonQuery();
			}
		}

		public void Delete(Contact contact)
		{
			const string connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=Phone_Book;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStr))
			{
				connection.Open();
				var command = new SqlCommand($"DELETE Contact WHERE Id = '{contact.Id}'", connection);
				command.ExecuteNonQuery();
			}
		}
	}
}
