using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Entities
{
	public class UserEntity
	{
		public UserEntity() => SubordinateClients = new List<ClientEntity>();
		public int Id { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }

		public ICollection<ClientEntity> SubordinateClients { get; set; }
	}
}
