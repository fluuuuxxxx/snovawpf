using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snovawpf.Model;

namespace snovawpf
{
    internal class CurrentUser
    {
        private static CurrentUser _instance;
        public users User { get; private set; }

        private CurrentUser() { }

        public static CurrentUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CurrentUser();
                }
                return _instance;
            }
        }

        public void SetCurrentUser(users user)
        {
            User = user;
        }
    }
}
