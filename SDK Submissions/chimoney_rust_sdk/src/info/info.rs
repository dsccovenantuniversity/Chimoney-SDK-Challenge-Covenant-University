use crate::core::api_client::APIClient;
use serde_json::json;

/// Get supported aritime countries for chimoney
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
///    let api_client = APIClient::new(false).unwrap();
///   let res = info::get_airtime_countries(&api_client).await.unwrap();
///  println!("{}", res);
/// }
/// ```
pub async fn get_airtime_countries(
    api_client: &APIClient,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/airtime-countries";
    let res = api_client.get(path, None).await?;
    Ok(res)
}

/// Get list of all assets in chimoney
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {   
///   let api_client = APIClient::new(false).unwrap();
///  let res = info::get_assets(&api_client, "NG").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_assets(
    api_client: &APIClient,
    country_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/assets";
    let mut query = String::new();
    query.push_str("?countryCode=");
    query.push_str(country_code);
    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

/// Get list of supported banks and bank codes for chimoney
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
///  let api_client = APIClient::new(false).unwrap();
/// let res = info::get_banks(&api_client, "NG").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_banks(
    api_client: &APIClient,
    country_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/country-banks";
    let mut query = String::new();
    query.push_str("?countryCode=");
    query.push_str(country_code);
    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

/// Get list of bank branches and branch codes for chimoney
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::get_bank_branches(&api_client, "044").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_bank_branches(
    api_client: &APIClient,
    bank_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/bank-branches";
    let mut query = String::new();
    query.push_str("?bankCode=");
    query.push_str(bank_code);
    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

/// Get exchange rates for chimoney
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::get_exchange_rates(&api_client).await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_exchange_rates(
    api_client: &APIClient,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/exchange-rates";
    let res = api_client.get(path, None).await?;
    Ok(res)
}

/// convert local currency to USD
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::get_local_currency_to_usd(&api_client, "NGN", "100").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_local_currency_to_usd(
    api_client: &APIClient,
    origin_currency: &str,
    amount_in_origin_currency: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/local-amount-to-usd";
    let mut query = String::new();
    query.push_str("?originCurrency=");
    query.push_str(origin_currency);
    query.push_str("&amountInOriginCurrency=");
    query.push_str(amount_in_origin_currency);
    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

/// Get list of all supported mobile money code
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::get_mobile_money_codes(&api_client).await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_mobile_money_codes(
    api_client: &APIClient,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/mobile-money-codes";
    let res = api_client.get(path, None).await?;
    Ok(res)
}

/// Get usd amount in Local.
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::get_usd_to_local_currency(&api_client, "NGN", "100").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn get_usd_to_local_currency(
    api_client: &APIClient,
    destination_currency: &str,
    amount_in_usd: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/usd-amount-in-local";
    let mut query = String::new();
    query.push_str("?destinationCurrency=");
    query.push_str(destination_currency);
    query.push_str("&amountInUSD=");
    query.push_str(amount_in_usd);
    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

/// verify a bank account number or multiple bank account numbers
///
/// # Example
///
/// ```
/// use chimoney::info::info;
/// use chimoney::core::api_client::APIClient;
///
/// #[tokio::main]
/// async fn main() {
/// let api_client = APIClient::new(false).unwrap();
/// let res = info::verify_bank_account(&api_client, "NG", "044", "0690000031").await.unwrap();
/// println!("{}", res);
/// }
/// ```
pub async fn verify_bank_account(
    api_client: &APIClient,
    country_code: &str,
    account_bank: &str,
    account_number: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/info/verify-bank-account";
    let json_data = json!({
        "verifyAccountNumbers": [
            {
                "countryCode": country_code,
                "account_bank": account_bank,
                "account_number": account_number
            }
        ]
    });
    let res = api_client.post(path, &json_data.to_string(), None).await?;
    Ok(res)
}
