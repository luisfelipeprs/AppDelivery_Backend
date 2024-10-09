﻿namespace AppDelivery.Communication.Requests
{
    public class RequestProductJson
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
