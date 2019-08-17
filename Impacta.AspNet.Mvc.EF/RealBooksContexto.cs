using Impacta.AspNet.Mvc.MOD;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Impacta.AspNet.Mvc.EF
{
	public class RealBooksContexto : DbContext
	{
		//static RealBooksContexto()
		//{
		//	Database.SetInitializer(
		//		new DropCreateDatabaseAlways<RealBooksContexto>());
		//}
		public RealBooksContexto() : base("RealBooksContext"){ }
		public DbSet<Editora> Editoras { get; set; }
		public DbSet<Endereco> Endereco { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
