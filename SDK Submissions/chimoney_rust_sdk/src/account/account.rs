use crate::core::api_client::APIClient;
use serde_json::json;

/// Get transaction details by issueID.
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `issue_id` - The issueID of the transaction to be retrieved.
/// * `sub_account` - The sub-account associated with the transaction.
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
/// use chimoney::account::account::get_transaction_details;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let issue_id = "123456789";
/// let sub_account = "1234567";
///
/// match get_transaction_details(&api_client, issue_id, sub_account).await {
///    Ok(result) => println!("Transaction Details: {}", result),
///   Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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

    let res = api_client
        .post(path, &body.to_string(), Some(&query))
        .await?;
    Ok(res)
}

/// Get Public profile of a Chimoney User.
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `sub_account` - The sub-account associated with the user.
/// * `user_id` - The user ID of the user.
/// * `link_code` - The link code of the user.
///
/// # Returns
///
/// A `Result` containing a JSON string with the user's public profile if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney_rust_sdk::core::api_client::APIClient;
/// use chimoney_rust_sdk::account::account::get_public_profile;
///
/// # #[tokio::main]
/// # fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let sub_account = "1234567";
/// let user_id = "123456789";
/// let link_code = "123456789";
///
/// match get_public_profile(&api_client, sub_account, user_id, link_code).await {
///    Ok(result) => println!("Public Profile: {}", result),
///  Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `sub_account` - The sub-account associated with the transactions.
///
/// # Returns
///
/// A `Result` containing a JSON string with the transactions if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::account::account::get_transactions_by_account;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let sub_account = "1234567";
///
/// match get_transactions_by_account(&api_client, sub_account).await {
///   Ok(result) => println!("Transactions: {}", result),
///  Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `id` - The ID of the transaction to be retrieved.
/// * `sub_account` - The sub-account associated with the transaction.
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
/// use chimoney::account::account::get_transaction_detail;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let id = "123456789";
/// let sub_account = "1234567";
///
/// match get_transaction_detail(&api_client, id, sub_account).await {
///  Ok(result) => println!("Transaction Detail: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `receiver` - The receiver of the transfer.
/// * `value_in_usd` - The value of the transfer in USD.
/// * `wallet` - The wallet associated with the transfer.
/// * `sub_account` - The sub-account associated with the transfer.
///
/// # Returns
///
/// A `Result` containing a JSON string with the result of the transfer if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::account::account::account_transfer;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let receiver = "123456789";
/// let value_in_usd = 100;
/// let wallet = "123456789";
/// let sub_account = "1234567";
///
/// match account_transfer(&api_client, receiver, &value_in_usd, wallet, sub_account).await {
///    Ok(result) => println!("Transfer Result: {}", result),
///  Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
/// # Notes
///
/// The `value_in_usd` argument must be an integer.
///
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

/// Delete an unpaid transaction.
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `chi_ref` - The CHI reference of the unpaid transaction to be deleted.
/// * `sub_account` - The sub-account associated with the unpaid transaction.
///
/// # Returns
///
/// A `Result` containing a JSON string with the result of the deletion if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::account::account::delete_unpaid_transaction;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let chi_ref = "123456789";
/// let sub_account = "1234567";
///
/// match delete_unpaid_transaction(&api_client, chi_ref, sub_account).await {
///   Ok(result) => println!("Deletion Result: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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

/// Retrieve unpaid transactions for a specific sub-account.
///
/// # Arguments
///
/// * `api_client` - An instance of the `APIClient` used to make API requests.
/// * `sub_account` - The sub-account for which unpaid transactions should be retrieved.
///
/// # Returns
///
/// A `Result` containing a JSON string with the unpaid transactions if successful,
/// or an error if the request fails.
///
/// # Examples
///
/// ```rust
/// use chimoney::core::api_client::APIClient;
/// use chimoney::account::account::get_unpaid_transactions;
///
/// # #[tokio::main]
/// # async fn main() {
/// let api_client = APIClient::new("https://api.example.com");
/// let sub_account = "1234567";
///
/// match get_unpaid_transactions(&api_client, sub_account).await {
///    Ok(result) => println!("Unpaid Transactions: {}", result),
/// Err(err) => eprintln!("Error: {}", err),
/// }
/// # }
/// ```
///
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
