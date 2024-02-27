use crate::core::api_client::APIClient;
use serde_json::json;

// create a new sub-account
pub async fn create_sub_account(
    api_client: &APIClient,
    sub_account_name: &str,
    sub_acount_first_name: &str,
    sub_account_last_name: &str,
    sub_account_email: &str,
    sub_account_phone: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/sub-account/create";

    let body = json!({
        "name": sub_account_name,
        "email": sub_account_email,
        "firstName": sub_acount_first_name,
        "lastName": sub_account_last_name,
        "phoneNumber": sub_account_phone
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Update a sub-account
pub async fn update_sub_account(
    api_client: &APIClient,
    id: &str,
    meta_key: &str,
    meta_value: &str,
    sub_acount_first_name: &str,
    sub_account_last_name: &str,
    sub_account_phone: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/sub-account/update";

    let body = json!({
        "id": id,
        "meta": {
            meta_key: meta_value
        },
        "firstName": sub_acount_first_name,
        "lastName": sub_account_last_name,
        "phoneNumber": sub_account_phone
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Delete an existing sub-account
pub async fn delete_sub_account(
    api_client: &APIClient,
    id: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/sub-account/delete";

    let mut query = String::new();
    query.push_str("?id=");
    query.push_str(id);

    let res = api_client.delete(path, Some(&query)).await?;
    Ok(res)
}

// Get details of a existing sub-account
pub async fn get_sub_account_details(
    api_client: &APIClient,
    id: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/sub-account/get";

    let mut query = String::new();
    query.push_str("?id=");
    query.push_str(id);

    let res = api_client.get(path, Some(&query)).await?;
    Ok(res)
}

// Get all sub-accounts associated with a user
pub async fn get_all_sub_accounts(
    api_client: &APIClient,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/sub-account/list";

    let res = api_client.get(path, None).await?;
    Ok(res)
}
