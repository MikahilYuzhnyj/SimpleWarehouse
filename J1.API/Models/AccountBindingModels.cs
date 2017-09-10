using System.ComponentModel.DataAnnotations;

namespace J1.API.Models
{
	public class RegisterBindingModel
	{
		[ Required ]
		public string TenantName{ get; set; }

		[ Required ]
		public string TenantPhone{ get; set; }

		[ Required ]
		public string TenantAddress{ get; set; }

		[ Required ]
		[ EmailAddress ]
		public string TenantEmail{ get; set; }

		[ Required ]
		public string UserName{ get; set; }

		[ Required ]
		[ EmailAddress ]
		public string Email{ get; set; }

		[ Required ]
		public string Phone{ get; set; }

		[ Required ]
		public string Password{ get; set; }

		[ Required ]
		public string ConfirmPassword{ get; set; }
	}

	public class CreateUserBindingModel
	{
		[ Required ]
		[ EmailAddress ]
		[ Display( Name = "Email" ) ]
		public string Email{ get; set; }

		[ Required ]
		[ Display( Name = "Username" ) ]
		public string Username{ get; set; }

		[ Required ]
		[ Display( Name = "First Name" ) ]
		public string FirstName{ get; set; }

		[ Required ]
		[ Display( Name = "Last Name" ) ]
		public string LastName{ get; set; }

		[ Display( Name = "Role Name" ) ]
		public string RoleName{ get; set; }

		[ Required ]
		[ StringLength( 100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6 ) ]
		[ DataType( DataType.Password ) ]
		[ Display( Name = "Password" ) ]
		public string Password{ get; set; }

		[ Required ]
		[ DataType( DataType.Password ) ]
		[ Display( Name = "Confirm password" ) ]
		[ Compare( "Password", ErrorMessage = "The password and confirmation password do not match." ) ]
		public string ConfirmPassword{ get; set; }
	}

	public class ChangePasswordBindingModel
	{
		[ Required ]
		[ DataType( DataType.Password ) ]
		[ Display( Name = "Current password" ) ]
		public string OldPassword{ get; set; }

		[ Required ]
		[ StringLength( 100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6 ) ]
		[ DataType( DataType.Password ) ]
		[ Display( Name = "New password" ) ]
		public string NewPassword{ get; set; }

		[ Required ]
		[ DataType( DataType.Password ) ]
		[ Display( Name = "Confirm new password" ) ]
		[ Compare( "NewPassword", ErrorMessage = "The new password and confirmation password do not match." ) ]
		public string ConfirmPassword{ get; set; }
	}
}