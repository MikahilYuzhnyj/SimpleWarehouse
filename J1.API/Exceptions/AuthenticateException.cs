using System;

namespace J1.API.Exceptions
{
	public class AuthenticateException: Exception
	{
		public override string Message => "AuthenticateException";
	}
}