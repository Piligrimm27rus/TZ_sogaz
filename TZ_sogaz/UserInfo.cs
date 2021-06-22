using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ_sogaz
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int countMessages { get; set; }

        public bool canSendOnlyText
        {
            get
            {
                if (countMessages <= 3)
                    return true;
                else
                    return false;
            }
        }

        public UserInfo(string name)
        {
            Username = name;
            countMessages = 0;
        }
    }
}
