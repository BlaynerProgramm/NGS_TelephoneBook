using System.Collections.Generic;
using System.Data.SqlClient;
using NGS_TelephoneBook.Model;

namespace NGS_TelephoneBook.Controllers
{
	public class ContactController
	{
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
					Contacts.Add(new Contact((string)reader[1], (string)reader[2]));
				}
			}
		}
	}
}
