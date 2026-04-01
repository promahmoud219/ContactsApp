using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;
using ContactsApp.Core.Services.Email;
using Serilog;

namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{
    public class CreateContactUseCase : ICreateContactUseCase
    {
        private readonly IContactRepository _repository;
        private readonly IEmailSender _emailSender;
        private readonly Serilog.ILogger _logger;

        public CreateContactUseCase(
            IContactRepository repository,
            IEmailSender emailSender,
            Serilog.ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OperationResult<CreateContactOutput>> ExecuteAsync(CreateContactInput input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            try
            {
                var contact = new Contact(
                    input.FirstName,
                    input.LastName,
                    input.Phone,
                    input.Email,
                    input.Address,
                    input.CountryId
                );

                var createdId = await _repository.CreateAsync(contact);

                var output = new CreateContactOutput(
                    createdId,
                    $"{contact.FirstName} {contact.LastName}",
                    contact.Phone,
                    contact.Email,
                    contact.Address,
                    contact.CountryId
                );

                if (!string.IsNullOrWhiteSpace(contact.Email))
                {
                    try
                    {
                        await _emailSender.SendAsync(
                            contact.Email,
                            "Account created",
                            $"Hello {contact.FirstName}, your account/contact was created successfully.");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex,
                            "Failed to send created-contact email for ContactId={ContactId}",
                            createdId);
                    }
                }
                else
                {
                    _logger.Information(
                        "Contact created without email, skipping notification for ContactId={ContactId}",
                        createdId);
                }

                return new OperationResult<CreateContactOutput>(
                    OperationStatus.Success,
                    output,
                    null);
            }
            catch (ArgumentException ex)
            {
                return new OperationResult<CreateContactOutput>(
                    OperationStatus.ValidationError,
                    null,
                    ex.Message);
            }
            catch (Exception ex)
            {
                return new OperationResult<CreateContactOutput>(
                    OperationStatus.Failure,
                    null,
                    ex.Message);
            }
        }
    }
}
