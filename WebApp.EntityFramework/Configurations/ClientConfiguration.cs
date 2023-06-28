using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Data.Entities;

namespace WebApp.EntityFramework.Configurations
{
	internal class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
	{
		public void Configure(EntityTypeBuilder<ClientEntity> builder)
		{
			builder.HasOne(client => client.SelectedUser)
				.WithMany(user => user.SubordinateClients)
				.HasForeignKey(client => client.SelectedUser_FK)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
