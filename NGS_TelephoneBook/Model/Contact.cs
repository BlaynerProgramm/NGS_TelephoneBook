using System;

namespace NGS_TelephoneBook.Model
{
	public class Contact
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }

		public Contact(string name, string phone, int id)
		{
			if (!string.IsNullOrWhiteSpace(name) || !string.IsNullOrWhiteSpace(phone))
			{
				Id = id;
				Name = name;
				Phone = phone;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public override string ToString() => $"{Name} \n{Phone}";
	}
}