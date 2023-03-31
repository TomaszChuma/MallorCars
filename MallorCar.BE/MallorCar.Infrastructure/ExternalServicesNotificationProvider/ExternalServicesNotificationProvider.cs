using MailKit.Net.Smtp;
using MallorCarApplication.Common.Interfaces;
using MallorCarApplication.Dtos;
using MimeKit;
using Sms77.Api;
using Sms77.Api.Library;
using Message = MallorCarApplication.Dtos.Message;

namespace MallorCar.Infrastructure.ExternalServicesNotificationProvider;

public class ExternalServicesNotificationProvider : IExternalNotificationServicesProvider
{
    private readonly EmailConfiguration _emailConfig;
    private readonly SmsConfiguration _smsConfiguration;

    public ExternalServicesNotificationProvider(EmailConfiguration emailConfig, SmsConfiguration smsConfiguration)
    {
        _emailConfig = emailConfig;
        _smsConfiguration = smsConfiguration;
    }

    public void SendMessage(string clientName, string carModel, string rentalCode, DateTime startDate, DateTime endDate,
        string startLocation,
        string endLocation,
        decimal totalCost,
        string receiverEmail,
        string receiverPhoneNumber)
    {
        SendSms(startLocation, endLocation, rentalCode, startDate, endDate, receiverPhoneNumber); //za to się płaci
        SendEmail(
            clientName,
            carModel, 
            rentalCode, 
            startDate, 
            endDate, 
            startLocation,
            endLocation,
            totalCost,
            receiverEmail);
    }

    public void SendSms(string startLocation, string endLocation, string rentalCode, DateTime startDate, DateTime endDate,
        string receiverPhoneNumber)
    {
        var smsParams = new SmsParams
        {
            Text = $"MallorCar Rental" +
                   $"\nPick up at: {startLocation} - {startDate}" +
                   $"\nReturn at: {endLocation} - {endDate}" +
                   $"\nYour rental code is: {rentalCode}",
                   To = receiverPhoneNumber,
            Flash = true,
            From = "MallorCar",
            Label = "TestLabel",
            Ttl = 300000,
            NoReload = true,
            PerformanceTracking = true,
            ForeignId = "MyTestForeignId",
        };

        var client = new Client(_smsConfiguration.ApiKey);
        client.Sms(smsParams);
    }

    public void SendEmail(string clientName, string carModel, string rentalCode, DateTime startDate, DateTime endDate,
        string startLocation,
        string endLocation,
        decimal totalCost,
        string receiverEmail)
    {
        var message = new Message(new string[] { receiverEmail }, $"MallorCar - Booking Confirmation",
            $"Hi {clientName}, \n \nYour rental request for Tesla Model {carModel} has been accepted." +
            $"\nYou will be able to pick up the car on {startDate} in {startLocation}" +
            $"\nAnd have to return it on {endDate} in {endLocation}" +
            $"\nTotal cost of the rental will be {totalCost}" +
            $"\nYour rental code is {rentalCode}. You can use it on our website to see details." +
            "\n \n See you soon" +
            "\n MallorCar Team");
        var emailMessage = CreateEmailMessage(message);
        Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("MallorCar - Luxury Tesla Rental Service", _emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

            client.Send(mailMessage);
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
}