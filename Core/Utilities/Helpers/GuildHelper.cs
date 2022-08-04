using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class GuildHelper
    {
        public static string CreateGuild()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
