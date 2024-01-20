use crate::core::api_client::APIClient;
use serde_json::json;

/// Create momo, local bank & airtime beneficiary.
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `owner` - The owner of the beneficiary.
/// * `beneficiary_key` - The beneficiary key.
/// * `beneficiary_value` - The beneficiary value.
///
/// # Returns
///
/// A `Result` containing a JSON string with the transaction details if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::beneficiary::beneficiary::create_beneficiary;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let owner = "1234567";
///
/// match create_beneficiary(&api_client, owner, "momo", "0240000000").await {
///  Ok(result) => println!("Beneficiary: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
pub async fn create_beneficiary(
    api_client: &APIClient,
    owner: &str,
    beneficiary_key: &str,
    beneficiary_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/beneficiary/create";

    let body = json!({
        "beneficiaryData": {
            beneficiary_key: beneficiary_value
        },
        "owner": owner,
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}
