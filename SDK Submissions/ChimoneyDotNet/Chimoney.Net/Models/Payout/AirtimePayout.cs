﻿namespace ChimoneyDotNet.Models;

public class AirtimePayout
{
    public string CountryToSend { get; set; }
    public string PhoneNumber { get; set; }
    public decimal ValueInUSD { get; set; }
}