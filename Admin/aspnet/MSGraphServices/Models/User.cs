using System;
using System.Collections.Generic;
using MSGraphService.RestServices.Clients;

namespace MSGraphService.Models
{
    public class User : Entity
    {
        public User() { }
    
        public string PreferredName { get; set; }
        public string MySite { get; set; }
        public ProfilePhoto Photo { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string MobilePhone { get; set; }
        public string MailNickname { get; set; }
        public string Mail { get; set; }
        public string JobTitle { get; set; }
        public IEnumerable<string> ImAddresses { get; set; }
        public string GivenName { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public IEnumerable<string> BusinessPhones { get; set; }
        public bool? AccountEnabled { get; set; }
        public string Country { get; set; }
        public string AboutMe { get; set; }
        public string UserPrincipalName { get; set; }
        public string UsageLocation { get; set; }
        public string Surname { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string OfficeLocation { get; set; }
        public string PostalCode { get; set; }
        public string LegalAgeGroupClassification { get; set; }
        public string AgeGroup { get; set; }
        public string UserType { get; set; }
    }

    public class Entity
    {
        public Entity()
        {
                
        }
        public string Id { get; set; }
        public string ODataType { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }
        public bool IsValid() => !string.IsNullOrEmpty(this.Id);
        public Response Response { get; set; }
    }
    public class ProfilePhoto : Entity
    {
        public ProfilePhoto() { }
        public int? Height { get; set; }      
        public int? Width { get; set; }
        public OData OData { get; set; }
    }

    public class OData : Entity
    {
        public string context { get; set; }
        public string mediaContentType { get; set; }
        public string mediaEtag { get; set; }
        

    }


}
