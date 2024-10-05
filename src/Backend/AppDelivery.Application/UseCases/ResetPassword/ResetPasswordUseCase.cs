using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AutoMapper;
using System.Net.Mail;
using System.Net;
using AppDelivery.Domain.Repositories.Driver;
using AppDelivery.Domain.Repositories.Consumer;
using AppDelivery.Domain.Repositories.ResetPassword;

namespace AppDelivery.Application.UseCases.ResetPassword;
public class ResetPasswordUseCase : IResetPasswordUseCase
{
    private readonly IResetPasswordWriteOnlyRepository _writeResetPasswordOnlyRepository;
    private readonly IResetPasswordReadOnlyRepository _readResetPasswordOnlyRepository;
    private readonly ICompanyWriteOnlyRepository _writeCompanyOnlyRepository;
    private readonly IConsumerReadOnlyRepository _readConsumerOnlyRepository;
    private readonly ICompanyReadOnlyRepository _readCompanyOnlyRepository;
    private readonly IDriverReadOnlyRepository _readDriverOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public ResetPasswordUseCase(
        IResetPasswordWriteOnlyRepository writeResetPasswordOnlyRepository,
        ICompanyWriteOnlyRepository writeCompanyOnlyRepository,
        IResetPasswordReadOnlyRepository readResetPasswordOnlyRepository,
        ICompanyReadOnlyRepository readCompanyOnlyRepository,
        IConsumerReadOnlyRepository readConsumerOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        PasswordEncripter passwordEncripter)
    {
        _writeResetPasswordOnlyRepository = writeResetPasswordOnlyRepository;
        _writeCompanyOnlyRepository = writeCompanyOnlyRepository;
        _readResetPasswordOnlyRepository = readResetPasswordOnlyRepository;
        _readCompanyOnlyRepository = readCompanyOnlyRepository;
        _readConsumerOnlyRepository = readConsumerOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;

    }

    public async Task<string?> ResetPassword(RequestResetPasswordJson request)
    {
        UserBase? entity = null;
        TypeEntity typeEntity;
        if (request.TypeEntity == "Company")
        {
            var companyRequest = _mapper.Map<Domain.Entities.Company>(request);
            entity = await _readCompanyOnlyRepository.GetCompanyByEmail(companyRequest.Email);
            typeEntity = TypeEntity.Company;
        }
        else if (request.TypeEntity == "Driver")
        {
            var driverRequest = _mapper.Map<Domain.Entities.Driver>(request);
            entity = await _readDriverOnlyRepository.GetDriverByEmail(driverRequest.Email);
            typeEntity = TypeEntity.Driver;
        }
        else if (request.TypeEntity == "Consumer")
        {
            var consumerRequest = _mapper.Map<Domain.Entities.Consumer>(request);
            entity = await _readConsumerOnlyRepository.GetConsumerByEmail(consumerRequest.Email);
            typeEntity = TypeEntity.Consumer;
        }
        else
        {
            throw new SystemException("Tipo de entidade inválido.");
        }

        if (entity == null)
        {
            throw new SystemException("Email inválido");
        }
        if (request.TypeEntity == "Company" && !(entity as Domain.Entities.Company)?.Active == true ||
            request.TypeEntity == "Driver" && !(entity as Domain.Entities.Driver)?.Active == true ||
            request.TypeEntity == "Consumer" && !(entity as Domain.Entities.Consumer)?.Active == true)
        {
            throw new SystemException("Conta inativa");
        }
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("lipezeraxz@gmail.com", "dykt igac lyzs zenw"),
            EnableSsl = true,
        };

        // Criar o código de redefinição
        Random random = new Random();
        string codeResetPassword = random.Next(0, 1000000).ToString("D6");

        // Armazenar no banco de dados com data de expiração
        var resetToken = new PasswordResetToken
        {
            EntityId = entity.Id,
            TypeEntity = typeEntity,
            ResetToken = codeResetPassword,
            ExpiresAt = DateTime.Now.AddMinutes(15),
            Used = false
        };

        await _writeResetPasswordOnlyRepository.AddToken(resetToken);
        await _unitOfWork.Commit();

        // Enviar o e-mail
        var mailMessage = new MailMessage
        {
            From = new MailAddress("lipezeraxz@gmail.com"),
            Subject = "Redefinição de Senha",
            Body = $"<p>Olá {entity.Name}, o código para redefinir sua senha é: <br><br><strong>{codeResetPassword}</strong></p>",
            IsBodyHtml = true,
        };

        mailMessage.To.Add(entity.Email);
        smtpClient.Send(mailMessage);

        return "E-mail de redefinição enviado com sucesso.";
    }

    public async Task ConfirmReset(RequestConfirmResetJson request)
    {
        UserBase? entity = null;
        var tokenRequest = _mapper.Map<PasswordResetToken>(request);
        var resetToken = await _readResetPasswordOnlyRepository.GetToken(request.Token);
        if (resetToken.TypeEntity == TypeEntity.Company)
        {
            var companyRequest = _mapper.Map<Domain.Entities.Company>(request);
            entity = await _readCompanyOnlyRepository.GetCompanyByEmail(companyRequest.Email);
        }
        else if (resetToken.TypeEntity == TypeEntity.Driver)
        {
            var driverRequest = _mapper.Map<Domain.Entities.Driver>(request);
            entity = await _readDriverOnlyRepository.GetDriverByEmail(driverRequest.Email);
        }
        else if (resetToken.TypeEntity == TypeEntity.Consumer)
        {
            var consumerRequest = _mapper.Map<Domain.Entities.Consumer>(request);
            entity = await _readConsumerOnlyRepository.GetConsumerByEmail(consumerRequest.Email);
        }

        if (resetToken == null || resetToken.ExpiresAt < DateTime.Now)
        {
            throw new SystemException("Token inválido ou expirado.");
        }
        entity.Password = _passwordEncripter.Encrypt(request.NewPassword);
        resetToken.Used = true;
        await _unitOfWork.Commit();
    }
}