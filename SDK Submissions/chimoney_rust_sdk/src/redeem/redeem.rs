use crate::core::api_client::APIClient;
use serde_json::json;

/// Redeem Airtime to a Phone number.
pub async fn redeem_airtime(
    api_client: &APIClient,
    country_to_send: &str,
    phone_number: &str,
    sub_account: &str,
    chi_ref: &str,
    test: &bool,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/redeem/airtime";

    let body = json!({
        "subAccount": sub_account,
        "chiRef": chi_ref,
        "countryToSend": country_to_send,
        "phoneNumber": phone_number,
        "meta": {
            "test": test
        }
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Redeem any
pub async fn redeem_any(
    api_client: &APIClient,
    sub_account: &str,
    chi_ref: &str,
    test: &bool,
    redeem_data_key: &str,
    redeem_data_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/redeem/any";

    let body = json!({
        "subAccount": sub_account,
        "chiRef": chi_ref,
        "meta": {
            "test": test
        },
        "redeemData": {
            redeem_data_key: redeem_data_value
        }
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Redeem Chimoney
pub async fn redeem_chimoney(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    chimoney_key: &str,
    chimoney_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/redeem/chimoney";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "chimoneys": {
            chimoney_key: chimoney_value
        },
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Redeem Giftcard
pub async fn redeem_giftcard(
    api_client: &APIClient,
    sub_account: &str,
    chi_ref: &str,
    redeem_key: &str,
    redeem_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/redeem/gift-card";

    let body = json!({
        "subAccount": sub_account,
        "chiRef": chi_ref,
        "redeemOptions": {
            redeem_key: redeem_value
        },
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Redeem Mobile Money
pub async fn redeem_mobile_money(
    api_client: &APIClient,
    sub_account: &str,
    chi_ref: &str,
    redeem_key: &str,
    redeem_value: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/redeem/mobile-money";

    let body = json!({
        "subAccount": sub_account,
        "chiRef": chi_ref,
        "redeemOptions": {
            redeem_key: redeem_value
        },
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}
