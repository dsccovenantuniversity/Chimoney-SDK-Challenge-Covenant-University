use crate::core::api_client::APIClient;
use serde_json::json;

/// Initiate a payment request
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `value_in_usd` - The value of the payment in USD.
/// * `payer_email` - The email of the payer.
/// * `currency` - The currency of the payment.
/// * `amount` - The amount of the payment.
/// * `redirect_url` - The redirect URL of the payment.
/// * `sub_account` - The sub-account of the payment.
/// * `meta_key` - The meta key of the payment.
/// * `meta_value` - The meta value of the payment.
///
/// # Returns
///
/// A `Result` containing a JSON string with the payment details if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::payment::payment::initiate_payment;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let value_in_usd = "100";
/// let payer_email = "example@example";
/// let currency = "USD";
/// let amount = "100";
/// let redirect_url = "https://example.com";
/// let sub_account = "1234567";
/// let meta_key = "key";
/// let meta_value = "value";
///
/// match initiate_payment(&api_client, value_in_usd, payer_email, currency, amount, redirect_url, sub_account, meta_key, meta_value).await {
///   Ok(result) => println!("Payment: {}", result),
///  Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
pub async fn initiate_payment(
    api_client: &APIClient,
    value_in_usd: &str,
    payer_email: &str,
    currency: &str,
    amount: &str,
    redirect_url: &str,
    sub_account: &str,
    meta_key: &str,
    meta_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payment/initiate";

    let body = json!({
        "valueInUSD": value_in_usd,
        "payerEmail": payer_email,
        "currency": currency,
        "amount": amount,
        "redirectUrl": redirect_url,
        "subAccount": sub_account,
        "meta": {
            meta_key: meta_value
        }
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Verify a payment
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `sub_account` - The sub-account of the payment.
/// * `id` - The ID of the payment.
///
/// # Returns
///
/// A `Result` containing a JSON string with the payment details if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::payment::payment::verify_payment;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let sub_account = "1234567";
/// let id = "1234567";
///
/// match verify_payment(&api_client, sub_account, id).await {
///  Ok(result) => println!("Payment: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
pub async fn verify_payment(
    api_client: &APIClient,
    sub_account: &str,
    id: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payment/verify";

    let body = json!({
        "subAccount": sub_account,
        "id": id
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Simulate a card
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `issue_id` - The issue ID of the card.
/// * `status` - The status of the card.
/// * `sub_account` - The sub-account of the card.
///
/// # Returns
///
/// A `Result` containing a JSON string with the card details if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::payment::payment::simulate_card;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let issue_id = "1234567";
/// let status = "active";
/// let sub_account = "1234567";
///
/// match simulate_card(&api_client, issue_id, status, sub_account).await {
/// Ok(result) => println!("Card: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
pub async fn simulate_card(
    api_client: &APIClient,
    issue_id: &str,
    status: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payment/simulate";

    let body = json!({
        "issueId": issue_id,
        "status": status,
        "subAccount": sub_account
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}
