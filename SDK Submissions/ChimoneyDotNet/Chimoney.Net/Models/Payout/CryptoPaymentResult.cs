
using System.Text.Json.Serialization;

namespace ChimoneyDotNet.Models;

public class CryptoPaymentResult
{
    public Token Xrpl { get; set; }
    public Token Eth { get; set; }
    public Token Bsc { get; set; }
    //TODO figure this out
    //public XummPayment XummPayment { get; set; }
}

public class XummPayment
{
    public string Uuid { get; set; }
    public Next Next { get; set; }
    public Refs Refs { get; set; }
    public bool Pushed { get; set; }
}

public class Next
{
    public string Always { get; set; }
}
public class Refs
{
    [JsonPropertyName("qr_png")]
    public string QrPng { get; set; }
    [JsonPropertyName("qr_matrix")]
    public string QrMatrix { get; set; }
    [JsonPropertyName("qr_uri_quality_opts")]
    public string[] QrUriQualityOpts { get; set; }
    [JsonPropertyName("websocket_status")]
    public string WebsocketStatus { get; set; }
    public bool Pushes { get; set; }
}

public class Token
{
    public string[] AcceptedTokens { get; set; }
    public string Address { get; set; }
    public DeliveAmount DeliveAmount { get; set; }
    public string PaymentInstructions { get; set; }
}

public class DeliveAmount
{
    public decimal Value { get; set; }
    public string Currency { get; set; }
}

public class InterledgerPayment
{
    public string Id { get; set; }
    public string WalletAddress { get; set; }
    public IncomingAmount IncomingAmount { get; set; }
    public ReceivedAmount ReceivedAmount { get; set; }
    public bool Completed { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string ExternalRef { get; set; }
    public IlpStreamConnection IlpStreamConnection { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;}
}

public class IlpStreamConnection
{
    public string Id { get; set; }
    public string IlpAddress { get; set; }
    public string SharedSecret { get; set; }
    public string AssetCode { get; set; }
    public string AssetScale { get; set; }
}

public class ReceivedAmount
{
    public string Value { get; set; }
    public string AssetCode { get; set; }
    public string AssetScale { get; set; }
}

public class IncomingAmount
{
    public decimal Value { get; set; }
    public string AssetCode { get; set; }
    public string AssetScale { get; set; }
}