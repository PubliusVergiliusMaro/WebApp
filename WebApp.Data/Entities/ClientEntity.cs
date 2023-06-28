using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Data.Entities
{
	public class ClientEntity
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public int SelectedUser_FK { get; set; }
		public UserEntity SelectedUser { get; set; }
	}
}
