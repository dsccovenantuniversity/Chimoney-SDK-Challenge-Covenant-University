use crate::core::api_client::APIClient;
use serde_json::json;

/// Create momo, local bank & airtime beneficiary.
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
