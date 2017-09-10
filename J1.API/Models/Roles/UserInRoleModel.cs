using System.Collections.Generic;

namespace J1.API.Models.Roles
{
	public class UsersInRoleModel
	{
		public string Id{ get; set; }
		public List< string > EnrolledUsers{ get; set; }
		public List< string > RemovedUsers{ get; set; }
	}
}