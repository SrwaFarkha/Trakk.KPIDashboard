using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountToken : IEntity
    {
        public int AccountTokenId { get; set; } // AccountTokenId (Primary key)
        public Guid TokenGuid { get; set; } // TokenGuid
        public bool IsUsed { get; set; } // IsUsed
        public string Token { get; set; } // Token

        public AccountToken()
        {
            IsUsed = false;
        }
    }
}