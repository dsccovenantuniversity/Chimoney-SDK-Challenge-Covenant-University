use crate::core::{api_client, models};
use models::Account;

pub struct AccountClient {
    pub api_key: String,
    pub api_url: String,
}

// get transaction detail from issueID using api_client; take subAccount as body params; take issueID as query params
pub async fn get_transaction_detail(
    client: &AccountClient,
    issue_id: &str,
) -> Result<Account, Box<dyn std::error::Error>> {
    let url = format!("{}/v1/transactions/{}", client.api_url, issue_id);
    let resp = reqwest::Client::new()
        .get(&url)
        .header(AUTHORIZATION, &client.api_key)
        .send()
        .await?
        .json::<Account>()
        .await?;
    Ok(resp)
}

// pub async fn get_transaction_detail(
//     client: &AccountClient,
//     issue_id: &str,
// ) -> Result<Account, Box<dyn std::error::Error>> {
//     let url = format!("{}/v1/transactions/{}", client.api_url, issue_id);
//     let resp = reqwest::Client::new()
//         .get(&url)
//         .header(AUTHORIZATION, &client.api_key)
//         .send()
//         .await?
//         .json::<Account>()
//         .await?;
//     Ok(resp)
// }

// get public profile of a chimoney user
