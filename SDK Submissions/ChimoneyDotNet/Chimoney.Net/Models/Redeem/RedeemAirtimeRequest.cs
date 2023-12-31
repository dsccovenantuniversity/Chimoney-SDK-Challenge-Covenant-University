﻿
namespace ChimoneyDotNet.Models;

public class RedeemAirtimeRequest : RedeemRequest
{
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Country to send to
    /// </summary>
    public string CountryToSend { get; set; }

}
