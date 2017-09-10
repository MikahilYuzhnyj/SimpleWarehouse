using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using J1.DAL.Entities;
using J1.DAL.Enums;
using J1.DAL.Helpers;

namespace J1.DAL.Migrations
{
	internal sealed class Configuration: DbMigrationsConfiguration< J1Context >
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		//protected override void Seed( J1Context context )
		//{
		//	if( !context.Clients.Any() )
		//	{
		//		return;
		//	}

		//	context.Clients.AddRange( BuildClientsList() );
		//	context.SaveChanges();
		//}

		//private static IEnumerable< Client > BuildClientsList()
		//{
		//	var clientsList = new List< Client >
		//	{
		//		new Client
		//		{
		//			Id = "ngAuthApp",
		//			Secret = GeneratorHash.GetHash( "abc@123" ),
		//			Name = "AngularJS front-end Application",
		//			ApplicationType = ApplicationTypes.JavaScript,
		//			Active = true,
		//			RefreshTokenLifeTime = 7200,
		//			AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net"
		//		},
		//		new Client
		//		{
		//			Id = "consoleApp",
		//			Secret = GeneratorHash.GetHash( "123@abc" ),
		//			Name = "Console Application",
		//			ApplicationType = ApplicationTypes.NativeConfidential,
		//			Active = true,
		//			RefreshTokenLifeTime = 14400,
		//			AllowedOrigin = "*"
		//		}
		//	};

		//	return clientsList;
		//}
	}
}
