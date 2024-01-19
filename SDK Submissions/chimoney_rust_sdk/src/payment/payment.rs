use crate::core::api_client::APIClient;
use serde_json::json;

/// Initiate a payment request
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
