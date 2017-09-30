using System.Data.Entity;
using J1.DAL.Entities;
using J1.DAL.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.DAL
{
	public class J1Context: IdentityDbContext< ApplicationUser >
	{
		public J1Context()
			: base( "J1Context" )
		{
		}

		public static J1Context Create()
		{
			return new J1Context();
		}
		
		public DbSet< Buyer > Buyers{ get; set; }
		public DbSet< Product > Products{ get; set; }
		public DbSet< ProductAlternateCode > ProductAlternateCodes{ get; set; }
		public DbSet< ProductAlternateSku > ProductAlternateSkus{ get; set; }
		public DbSet< ProductTag > ProductTags{ get; set; }
		public DbSet< Sale > Sales{ get; set; }
		public DbSet< SaleItem > SaleItems{ get; set; }
		public DbSet< SaleShipment > SaleShipments{ get; set; }
		public DbSet< Tag > Tags{ get; set; }
		public DbSet< Brand > Brands{ get; set; }
		public DbSet< Classification > Classifications{ get; set; }
		public DbSet< Supplier > Suppliers{ get; set; }
		public DbSet< Kit > Kits{ get; set; }
		public DbSet< KitTag > KitTags{ get; set; }
		public DbSet< KitItem > KitItems{ get; set; }
		public DbSet< KitAlternateCode > KitAlternateCodes{ get; set; }
		public DbSet< KitAlternateSku > KitAlternateSkus{ get; set; }

		public DbSet< Tenant > Tenants{ get; set; }
		public DbSet< User > TenantUsers{ get; set; }
	}
}