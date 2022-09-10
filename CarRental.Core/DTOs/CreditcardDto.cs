﻿namespace CarRental.Core.DTOs
{
    public class CreditcardDto
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string CardCvc { get; set; } = null!;
        public string CardExpiration { get; set; } = null!;
    }
}
