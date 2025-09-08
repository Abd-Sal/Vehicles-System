﻿namespace SellingRentingCarsSystem.API.Interfaces;

public interface INotificationSender
{
    Result SendEmailAsync(string toEmail, string subject, string body);
}
