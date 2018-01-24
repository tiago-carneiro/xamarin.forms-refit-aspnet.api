using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormsRefit
{
    [Headers("Content-Type: application/json")]
    public interface IApiRestfull
    {
        [Get("/api/contact")]
        Task<List<ContactModel>> GetContacts();

        [Get("/api/contact/{id}")]
        Task<ContactModel> GetContact(string id);

        [Post("/api/contact")]
        Task PostContact([Body] ContactModel contact);

        [Put("/api/contact")]
        Task PutContact([Body] ContactModel contact);

        [Delete("/api/contact")]
        Task DeleteContact(string id);
    }
}
