﻿namespace AppDelivery.Communication.Responses;
public class ResponseShortCompanyJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}