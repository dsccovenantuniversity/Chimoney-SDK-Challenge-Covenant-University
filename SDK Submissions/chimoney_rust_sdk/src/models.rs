use serde::{Debug, Deserialize, Serialize};
// Accounts model
#[derive(Serialize, Deserialize, Debug)]
pub struct Account {
    pub id: String,
    pub sub_account: String,
    pub issue_id: String,
    pub user_id: String,
    pub link_code: String,
    pub receiver: String,
    pub amount: String,
    pub wallet: String,
    pub chi_ref: String,
}

// Info Model
#[derive(Serialize, Deserialize, Debug)]
pub struct Info {
    pub country_code: String,
    pub bank_code: String,
    pub origin_currency: String,
    pub amount_in_origin_currency: String,
    pub destination_currency: String,
    pub amount_in_usd: String,
}

// Payment Model
#[derive(Serialize, Deserialize, Debug)]
pub struct Payment {
    pub amount: String,
    pub currency: String,
    pub value_in_usd: String,
    pub sub_account: String,
    pub redirect_url: String,
    pub payer_email: String,
    pub id: String,
    pub issue_id: String,
    pub status: String,
}

// Payout Model
pub struct airtimes {
    pub country_to_send: String,
    pub phone_number: String,
    pub value_in_usd: i32,
}

pub struct banks {
    pub account_bank: String,
    pub account_number: String,
    pub reference: String,
    pub fullname: String,
    pub branch_code: String,
    pub value_in_usd: i32,
    pub country_to_send: String,
}

pub struct chimoney {
    pub email: String,
    pub phone: String,
    pub value_in_usd: i32,
    pub redeem_data: vec<chimoney_redeem_data>,
}

pub struct chimony_redeem_data {
    pub wallet_id: String,
    pub interledger_wallet_address: String,
}

pub struct wallet {
    pub receiver: String,
    pub value_in_usd: i32,
}

pub struct interledger_wallets {
    pub interledger_wallet_address: String,
    pub value_in_usd: i32,
}

pub struct giftcard {
    pub redeem_data: vec<giftcard_redeem_data>,
    pub value_in_usd: i32,
    pub email: String,
}

pub struct giftcard_redeem_data {
    pub product_id: i32,
    pub country_code: String,
    pub value_in_local_currency: i32,
}

pub struct momo {
    pub momo_code: String,
    pub country_to_send: String,
    pub phone_number: String,
    pub value_in_usd: i32,
    pub reference: String,
}

pub struct initiate_chimoney {
    pub email: String,
    pub phone: String,
    pub value_in_usd: i32,
    pub twitter: String,
}

pub struct crypto_payment {
    pub xrpl: vec<xrpl>,
}

pub struct xrpl {
    pub address: String,
    pub issuer: String,
    pub currency: String,
}

#[derive(Queryable, Serialize, Deserialize, Debug)]
pub struct Payout {
    pub sub_account: String,
    pub turn_off_notification: bool,
    pub enable_xumm_payment: bool,
    pub enable_interledger_payment: bool,
    pub airtimes: vec<airtimes>,
    pub banks: vec<banks>,
    pub chimoneys: vec<chimoney>,
    pub wallets: vec<wallet>,
    pub interledger_wallets: vec<interledger_wallets>,
    pub giftcards: vec<giftcard>,
    pub value_in_usd: i32,
    pub payer_email: String,
    pub redirect_url: String,
    pub currency: String,
    pub chi_ref: String,
    pub momos: vec<momo>,
    pub crypto_payment: vec<crypto_payment>,
    pub initiate_chimoney: vec<initiate_chimoney>,
}

// Redeem Model
pub struct edeem_meta {
    pub test: bool,
}

pub struct redeem_data {
    pub product_id: String,
    pub country_code: String,
    pub email: String,
}

#[derive(Queryable, Serialize, Deserialize, Debug)]
pub struct Redeem {
    pub sub_account: String,
    pub chi_ref: String,
    pub meta: meta,
    pub country_to_send: String,
    pub phone_number: String,
    pub redeem_data: vec<redeem_data>,
    pub turn_off_notification: bool,
}

// SubAccount Model
pub struct SubaccountMeta {
    pub rank: i32,
    pub discount_enabled: bool,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct SubAccount {
    pub name: String,
    pub email: String,
    pub first_name: String,
    pub last_name: String,
    pub phone_number: String,
    pub id: String,
    pub meta: subaccount_meta,
}

// Wallet Model
#[derive(Serialize, Deserialize, Debug)]
pub struct Wallet {
    pub sub_account: String,
    pub wallet_id: String,
    pub wallet: String,
    pub receiver: String,
    pub value_in_usd: i32,
}

// Beneficiary Model
pub struct BeneficiaryData {
    pub name: String,
    pub email: String,
    pub phone_number: String,
    pub country_code: String,
    pub bank_code: String,
    pub account_number: String,
    pub account_bank: String,
    pub branch_code: String,
}

#[derive(Queryable, Serialize, Deserialize, Debug)]
pub struct Beneficiary {
    pub owner: String,
    pub beneficiary_data: vec<beneficiary_data>,
}
