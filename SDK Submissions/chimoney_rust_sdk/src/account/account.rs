use crate::core::api_client::APIClient;
use serde_json::json;

/// Get transaction details by issueID.
pub async fn get_transaction_details(
    api_client: &APIClient,
    issue_id: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/issue-id-transactions";

    let mut query = String::new();
    query.push_str("?issueID=");
    query.push_str(issue_id);

    let body = json!({
        "subAccount": sub_account
    });
    // let res = api_client.get(path, Some(&query)).await?;
    let res = api_client
        .post(path, &body.to_string(), Some(&query))
        .await?;
    Ok(res)
}

/// Get Public profile of a Chimoney User.
pub async fn get_public_profile(
    api_client: &APIClient,
    sub_account: &str,
    user_id: &str,
    link_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/public-profile";

    let body = json!({
        "subAccount": sub_account,
        "userID": user_id,
        "linkCode": link_code
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Get all transactions by account.
pub async fn get_transactions_by_account(
    api_client: &APIClient,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/transactions";

    let body = json!({
        "subAccount": sub_account
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Get single transaction detail.
pub async fn get_transaction_detail(
    api_client: &APIClient,
    id: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/transaction";

    let mut query = String::new();
    query.push_str("?id=");
    query.push_str(id);

    let body = json!({
        "subAccount": sub_account,
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Account transfer.
pub async fn account_transfer(
    api_client: &APIClient,
    receiver: &str,
    value_in_usd: &i32,
    wallet: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/transfer";

    let body = json!({
        "receiver": receiver,
        "valueInUSD": value_in_usd,
        "wallet": wallet,
        "subAccount": sub_account,
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Deletes an unpaid transaction.
pub async fn delete_unpaid_transaction(
    api_client: &APIClient,
    chi_ref: &str,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/accounts/delete-unpaid-transaction";

    let mut query = String::new();
    query.push_str("?chiRef=");
    query.push_str(chi_ref);
    query.push_str("&subAccount=");
    query.push_str(sub_account);

    let res = api_client.delete(path, Some(&query)).await?;
    Ok(res)
}

/// Get single transaction detail.
pub async fn get_unpaid_transaction(
    api_client: &APIClient,
    sub_account: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/beneficiary";

    let mut query = String::new();
    query.push_str("?subAccount=");
    query.push_str(sub_account);

    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}
