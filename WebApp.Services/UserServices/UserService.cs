using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;
using WebApp.EntityFramework.Repository;

namespace WebApp.Services.UserServices
{
	public class UserService : IUserService
	{
		private readonly IGenericRepository<UserEntity> _userRepository;
		public UserService(IGenericRepository<UserEntity> userRepository) 
		{
		_userRepository = userRepository;
		}
		public void Create(UserEntity user)
		{
			_userRepository.Create(user);
		}

		public bool Delete(int Id)
		{
			UserEntity dbRecord = _userRepository.Table
			   .Where(u => u.Id == Id)
			   .Include(u=>u.SubordinateClients)
			   .FirstOrDefault();
			if(dbRecord == null)
			{
				return false;
			}
			_userRepository.Remove(dbRecord);
			return true;
		}

		public ICollection<UserEntity> GetAll()
		{
			ICollection<UserEntity> dbRecord = _userRepository.Table
				.Include(u => u.SubordinateClients)
				.ToList();
			if(dbRecord ==null)
			{
				return null;
			}
			return dbRecord;
		}

		public UserEntity GetById(int Id)
		{
			UserEntity dbRecord = _userRepository.Table
			 .Where(u => u.Id == Id)
			 .Include(u => u.SubordinateClients)
			 .FirstOrDefault();
			if (dbRecord == null)
			{
				return null;
			}
			return dbRecord;
		}

		public bool Update(UserEntity user)
		{
			try
			{
				UserEntity dbRecord = _userRepository.Table
			   .Where(u => u.Id == user.Id)
			   .Include(u => u.SubordinateClients)
			   .FirstOrDefault();
				if (dbRecord == null)
				{
					return false;
				}
				
				dbRecord.Login = user.Login;
				dbRecord.Email = user.Email;
				dbRecord.Phone = user.Phone;

				_userRepository.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
