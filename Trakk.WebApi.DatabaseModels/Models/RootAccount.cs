

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class RootAccount : IEntity
    {
        public int RootAccountId { get; set; } // RootAccountId (Primary key)
        public int RootAccountTypeId { get; set; } // RootAccountTypeId
        public string UserName { get; set; } // UserName (length: 255)
        public string PasswordHash { get; set; } // PasswordHash (length: 255)
        public int? CustomerAdminId { get; set; } // CustomerAdminId
        public bool IsLocked { get; set; } // IsLocked

        // Foreign keys

        /// <summary>
        /// Parent CustomerAdmin pointed by [RootAccount].([CustomerAdminId]) (FK_RootAccount_CustomerAdmin)
        /// </summary>
        public virtual CustomerAdmin CustomerAdmin { get; set; } // FK_RootAccount_CustomerAdmin

        /// <summary>
        /// Parent RootAccountType pointed by [RootAccount].([RootAccountTypeId]) (FK_RootAccount_RootAccountType)
        /// </summary>
        public virtual RootAccountType RootAccountType { get; set; } // FK_RootAccount_RootAccountType

        public RootAccount()
        {
            IsLocked = false;
        }
    }
}