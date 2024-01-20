use crate::core::api_client::APIClient;
use serde_json::json;

// List associated wallets
pub async fn list_associated_wallets(
    api_client: &APIClient,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/wallets/list";

    let body = json!({
        "subAccount": sub_account
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// get single wallet details
pub async fn get_single_wallet_details(
    api_client: &APIClient,
    wallet_id: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/wallets/lookup";

    let body = json!({
        "walletId": wallet_id,
        "subAccount": sub_account
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Transfer between wallets
pub async fn transfer_between_wallets(
    api_client: &APIClient,
    wallet: &str,
    value_in_usd: &i32,
    sub_account: &str,
    reciever: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/wallets/transfer";

    let body = json!({
        "wallet": wallet,
        "valueInUSD": value_in_usd,
        "subAccount": sub_account,
        "receiver": reciever
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}
