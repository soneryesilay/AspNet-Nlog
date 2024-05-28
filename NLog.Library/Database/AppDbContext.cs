using Microsoft.EntityFrameworkCore;
using Log = NLog.Library.Models.Log;



namespace NLog.Library.Database
{
	public sealed class AppDbContext: DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

		}
		public DbSet<Log> Logs { get; set; }

	}
}
