using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public abstract class ContactRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }

    public class ContactPostRequest : ContactRequest
    {

    }

    public class ContactPutRequest : ContactRequest
    {
        [Required]
        public string Id { get; set; }
    }
}