using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Mailing;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using MimeKit;
using System.Linq.Expressions;

namespace Application.Services.Contacts;

public class ContactsManager : IContactsService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMailService _mailService;

    public ContactsManager(IContactRepository contactRepository, ContactBusinessRules contactBusinessRules, IMailService mailService)
    {
        _contactRepository = contactRepository;
        _mailService = mailService;
    }

    public async Task<Contact?> GetAsync(
        Expression<Func<Contact, bool>> predicate,
        Func<IQueryable<Contact>, IIncludableQueryable<Contact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Contact? contact = await _contactRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return contact;
    }

    public async Task<IPaginate<Contact>?> GetListAsync(
        Expression<Func<Contact, bool>>? predicate = null,
        Func<IQueryable<Contact>, IOrderedQueryable<Contact>>? orderBy = null,
        Func<IQueryable<Contact>, IIncludableQueryable<Contact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Contact> contactList = await _contactRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return contactList;
    }

    public async Task<Contact> AddAsync(Contact contact)
    {
        Contact addedContact = await _contactRepository.AddAsync(contact);
        await SendNotificationMailAsync(contact);
        return addedContact;
    }

    public async Task<Contact> UpdateAsync(Contact contact)
    {
        Contact updatedContact = await _contactRepository.UpdateAsync(contact);

        return updatedContact;
    }

    public async Task<Contact> DeleteAsync(Contact contact, bool permanent = false)
    {
        Contact deletedContact = await _contactRepository.DeleteAsync(contact);

        return deletedContact;
    }

    public async Task SendNotificationMailAsync(Contact contact)
    {
        await _mailService.SendEmailAsync(new Mail
        {
            Subject = "Yeni Ýletiþim Mesajý",
            TextBody = $"Yeni bir iletiþim mesajý aldýnýz.\n" +
                       $"Mesaj Gönderen Kiþi : {contact.FullName}\n" +
                       $"Mesaj Gönderen Email : {contact.Email}\n" +
                       $"Mesaj Gönderen Telefon : {contact.PhoneNumber}\n" +
                       $"Mesaj Gönderenin Mesajý : {contact.Message}\n",
            ToList = new List<MailboxAddress> { new MailboxAddress("Emre Can Ayar", "emrecan.ayar@hotmail.com") },
        });
    }
}
