#region "Namepaces do Sistema"

using ERP.RH.Domain;

//Expoe entidades genericas

#endregion

namespace RH.Domain.Entities
{
    public class UserApp : EFEntity
    {
        public string AppId { get; set; }
        public string UserId { get; set; }
    }
}