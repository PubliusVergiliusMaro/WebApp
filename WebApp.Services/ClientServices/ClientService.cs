using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;
using WebApp.EntityFramework.Repository;

namespace WebApp.Services.ClientServices
{
	public class ClientService : IClientService
	{
		private IGenericRepository<ClientEntity> _clientRepository;
		public ClientService(IGenericRepository<ClientEntity> clientRepository)
		{
		_clientRepository = clientRepository;
		}
		public void Create(ClientEntity client)
		{
			_clientRepository.Create(client);
		}

		public bool Delete(int Id)
		{
			ClientEntity dbRecord = _clientRepository.Table
				.Where(cl => cl.Id == Id)
				.Include(cl=>cl.SelectedUser)
				.FirstOrDefault();
			if(dbRecord == null)
			{
				return false;
			}
			_clientRepository.Remove(dbRecord);
			return true;
		}

		public ICollection<ClientEntity> GetAll()
		{
			ICollection<ClientEntity> dbRecord = _clientRepository.Table
				.Include(cl => cl.SelectedUser)
				.ToList();
			if(dbRecord == null)
			{
				return null;
			}
			return dbRecord;
		}

		public ClientEntity GetById(int id)
		{
			ClientEntity dbRecord = _clientRepository.Table
				.Where(cl => cl.Id == id)
				.Include(cl => cl.SelectedUser)
				.FirstOrDefault();
			if (dbRecord == null)
				return null;

			return dbRecord;
		}

		public bool Update(ClientEntity client)
		{
			try
			{
				ClientEntity dbRecord = _clientRepository.Table
					.Where(cl => cl.Id == client.Id)
					.Include(cl => cl.SelectedUser)
					.FirstOrDefault();
				if (dbRecord == null)
					return false;

				dbRecord.Login = client.Login;
				dbRecord.Password = client.Password;
				dbRecord.SelectedUser_FK = client.SelectedUser_FK;

				_clientRepository.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
