use crate::core::api_client::APIClient;
use serde_json::json;

/// Payout Airtime to a Phone number.
pub async fn payout_airtime(
    api_client: &APIClient,
    country_to_send: &str,
    phone_number: &str,
    sub_account: &str,
    turn_off_notification: &bool,
    value_in_usd: &i32,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/airtime";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "airtimes": {
            "countryToSend": country_to_send,
            "phoneNumber": phone_number,
            "valueInUSD": value_in_usd
        }
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

/// Payout to Bank in a supported Country.
pub async fn bank_payout(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    country_to_send: &str,
    account_bank: &str,
    account_number: &str,
    value_in_usd: &i32,
    reference: &str,
    fullname: &str,
    branch_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/bank";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "banks": {
            "countryToSend": country_to_send,
            "account_bank": account_bank,
            "account_number": account_number,
            "valueInUSD": value_in_usd,
            "reference": reference,
            "fullname": fullname,
            "branch_code": branch_code
        }
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Payout Chimoney
pub async fn payout_chimoney(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    email: &str,
    phone_number: &str,
    value_in_usd: &i32,
    wallet_id: &str,
    interledger_wallet_address: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/chimoney";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "chimoneys": [{
            "email": email,
            "phoneNumber": phone_number,
            "valueInUSD": value_in_usd,
            "redeemData": {
                "walletId": wallet_id,
                "interledgerWalletAddress": interledger_wallet_address
            }
        }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// payout to a chimoney wallet
pub async fn payout_chimoney_wallet(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    receiver: &str,
    value_in_usd: &i32,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/wallet";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "wallets": [{
            "receiver": receiver,
            "valueInUSD": value_in_usd
        }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Payout to a Interledger Wallet Address.
pub async fn payout_interledger_wallet(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    interledger_wallet_address: &str,
    value_in_usd: &i32,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/interledger-wallet";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "interledgerWallets": [{
            "interledgerWalletAddress": interledger_wallet_address,
            "valueInUSD": value_in_usd
        }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Payout girtcard to an email
pub async fn payout_giftcard_email(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    email: &str,
    value_in_usd: &i32,
    product_id: &i32,
    country_code: &str,
    value_in_local_currency: &i32,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/gift-card";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "giftcards": [{
            "email": email,
            "valueInUSD": value_in_usd,
            "redeemData": {
                "productId": product_id,
                "countryCode": country_code,
                "valueInLocalCurrency": value_in_local_currency
            }
        }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Payout mobile money
pub async fn payout_mobile_money(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    country_to_send: &str,
    phone_number: &str,
    value_in_usd: &i32,
    reference: &str,
    momos_code: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/mobile-money";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "momos": [{
            "countryToSend": country_to_send,
            "phoneNumber": phone_number,
            "valueInUSD": value_in_usd,
            "reference": reference,
            "momosCode": momos_code
        }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// Check PAyout Status
pub async fn check_payout_status(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    chi_reference: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/status";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "chiRef": chi_reference
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}

// initiate chimoney transactions
pub async fn initiate_chimoney_transaction(
    api_client: &APIClient,
    sub_account: &str,
    turn_off_notification: &bool,
    redirect_url: &str,
    enable_xumm_payment: &bool,
    enable_interledger_payment: &bool,
    phone_number: &str,
    email: &str,
    value_in_usd: &i32,
    twitter_handle: &str,
    xrpl_address: &str,
    xrpl_issuer: &str,
    xrpl_currency: &str,
) -> Result<String, Box<dyn std::error::Error>> {
    let path = "/v0.2/payouts/initiate-chimoney";

    let body = json!({
        "subAccount": sub_account,
        "turnOffNotification": turn_off_notification,
        "redirectUrl": redirect_url,
        "enableXummPayment": enable_xumm_payment,
        "enableInterledgerPayment": enable_interledger_payment,
        "chimoneys": [{
            "email": email,
            "phone": phone_number,
            "valueInUSD": value_in_usd,
            "twitter": twitter_handle,
        }],
        "crytoPayments": [{
            "xrpl":{
            "xrplAddress": xrpl_address,
            "xrplIssuer": xrpl_issuer,
            "xrplCurrency": xrpl_currency,
            "valueInUSD": value_in_usd
        }
    }]
    });

    let res = api_client.post(path, &body.to_string(), None).await?;
    Ok(res)
}
