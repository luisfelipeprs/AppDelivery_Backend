﻿namespace AppDelivery.Communication.Responses
{
    public class ResponseProductJson
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public long CompanyId { get; set; }
    }
}