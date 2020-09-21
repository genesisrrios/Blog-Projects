using Domain.DTOs;
using Domain.Models;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ContactService
    {
        public async Task<(bool, string)> AddContact(Contact contact)
        {
            try
            {
                //TODO FIX Messages for errors
                using (var context = new Context())
                {
                    var alreadyContacts = await context.Contacts.Where(x => x.ContactId == contact.ContactId && x.UserId == contact.UserId).AnyAsync();

                    if (alreadyContacts)
                        return (false, "Already contacts");

                    context.Contacts.Add(new Contact
                    {
                        ContactId = contact.ContactId,
                        UserId = contact.UserId
                    });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return (true, "Contact added");
        }
        public async Task<List<ContactInformationDTO>> GetUserContacts(Guid user_id)
        {
            var contactList = new List<ContactInformationDTO>();

            try
            {
                using (var context = new Context())
                {
                    var contacts = context.Contacts.Where(x => x.UserId == user_id);

                    await contacts.ForEachAsync(async x =>
                    {
                        var lastMessageAndLastMessageDate = await context.Messages
                            .Where(w => w.From == user_id && w.To == x.ContactId)
                            .Select(m => new
                            {
                                m.Content,
                                LastMessageDate = m.TimeSent
                            }).LastOrDefaultAsync();

                        var lastMessage = lastMessageAndLastMessageDate?.Content?
                               .Substring(0, Math.Min(lastMessageAndLastMessageDate.Content.Length, 100));

                        var UserNameAndProfilePicture = await context.Users.Where(w => w.Id == x.ContactId)
                               .Select(s => new
                               {
                                   Name = s.UserName,
                                   s.ProfilePicture
                               }).FirstOrDefaultAsync();

                        contactList.Add(new ContactInformationDTO
                        {
                            LastMessage = lastMessage,
                            UserId = x.ContactId,
                            UserName = UserNameAndProfilePicture.Name,
                            ProfilePicture = UserNameAndProfilePicture?.ProfilePicture,
                            LastMessageDate = lastMessageAndLastMessageDate?.LastMessageDate.DateTime.ToShortTimeString()
                        });

                    });

                };
            }
            catch (Exception ex)
            {

            }
            return contactList;
        }
    }
}
