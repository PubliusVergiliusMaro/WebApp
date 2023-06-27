using WebApp.Data.Entities;

namespace WebApp.Services.UserServices
{
	public interface IUserService
	{
		public void Create(UserEntity user);
		public bool Update(UserEntity user);
		public bool Delete(int Id);
		public ICollection<UserEntity> GetAll();
		public UserEntity GetById(int Id);
	}
}
