namespace J1.API.Models.Session
{
	public class UserSession
	{
		public TenantId TenantId{ get; set; }
		public TenantName TenantName{ get; set; }
		public UserId UserId{ get; set; }
		public UserName UserName{ get; set; }

		public UserSession( long tenantId, string tenantName, long userId, string userName )
		{
			this.TenantId = new TenantId() { Id = tenantId };
			this.TenantName = new TenantName { Value = tenantName };
			this.UserId = new UserId { Id = userId };
			this.UserName = new UserName { Value = userName };
		}
	}
}