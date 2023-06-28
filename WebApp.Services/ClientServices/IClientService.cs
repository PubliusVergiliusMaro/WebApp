using WebApp.Data.Entities;

namespace WebApp.Services.ClientServices
{
	public interface IClientService
	{
		public void Create(ClientEntity client);
		public bool Update(ClientEntity client);
		public bool Delete(int id);
		public ClientEntity GetById(int id);
		public ICollection<ClientEntity> GetAll();
	}
}
