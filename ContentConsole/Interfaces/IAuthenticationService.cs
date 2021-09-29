using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Interfaces
{
    public interface IAuthenticationService
    {
        public void PromptUserForAuth();
        public ApplicationRoot GetUserRole();
    }
}
