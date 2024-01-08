use serde::{Deserialize, Serialize};
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
#[derive(Serialize, Deserialize, Debug)]
pub struct Airtimes {
    pub country_to_send: String,
    pub phone_number: String,
    pub value_in_usd: i32,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Banks {
    pub account_bank: String,
    pub account_number: String,
    pub reference: String,
    pub fullname: String,
    pub branch_code: String,
    pub value_in_usd: i32,
    pub country_to_send: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Chimoney {
    pub email: String,
    pub phone: String,
    pub value_in_usd: i32,
    pub redeem_data: Vec<ChimoneyRedeemData>,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct ChimoneyRedeemData {
    pub wallet_id: String,
    pub interledger_wallet_address: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct PayoutWallet {
    pub receiver: String,
    pub value_in_usd: i32,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct InterledgerWallets {
    pub interledger_wallet_address: String,
    pub value_in_usd: i32,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Giftcard {
    pub redeem_data: Vec<GiftcardRedeemData>,
    pub value_in_usd: i32,
    pub email: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct GiftcardRedeemData {
    pub product_id: i32,
    pub country_code: String,
    pub value_in_local_currency: i32,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Momo {
    pub momo_code: String,
    pub country_to_send: String,
    pub phone_number: String,
    pub value_in_usd: i32,
    pub reference: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct InitiateChimoney {
    pub email: String,
    pub phone: String,
    pub value_in_usd: i32,
    pub twitter: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct CryptoPayment {
    pub xrpl: Vec<Xrpl>,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Xrpl {
    pub address: String,
    pub issuer: String,
    pub currency: String,
}

#[derive(Serialize, Deserialize)]
pub struct Payout {
    pub sub_account: String,
    pub turn_off_notification: bool,
    pub enable_xumm_payment: bool,
    pub enable_interledger_payment: bool,
    pub airtimes: Vec<Airtimes>,
    pub banks: Vec<Banks>,
    pub chimoneys: Vec<Chimoney>,
    pub wallets: Vec<PayoutWallet>,
    pub interledger_wallets: Vec<InterledgerWallets>,
    pub giftcards: Vec<Giftcard>,
    pub value_in_usd: i32,
    pub payer_email: String,
    pub redirect_url: String,
    pub currency: String,
    pub chi_ref: String,
    pub momos: Vec<Momo>,
    pub crypto_payment: Vec<CryptoPayment>,
    pub initiate_chimoney: Vec<InitiateChimoney>,
}

// Redeem Model
#[derive(Serialize, Deserialize, Debug)]
pub struct RedeemMeta {
    pub test: bool,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct RedeemData {
    pub product_id: String,
    pub country_code: String,
    pub email: String,
}

#[derive(Serialize, Deserialize, Debug)]
pub struct Redeem {
    pub sub_account: String,
    pub chi_ref: String,
    pub meta: Vec<RedeemMeta>,
    pub country_to_send: String,
    pub phone_number: String,
    pub redeem_data: Vec<RedeemData>,
    pub turn_off_notification: bool,
}

// SubAccount Model
#[derive(Serialize, Deserialize, Debug)]
pub struct SubAccountMeta {
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
    pub meta: Vec<SubAccountMeta>,
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
#[derive(Serialize, Deserialize, Debug)]
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

#[derive(Serialize, Deserialize, Debug)]
pub struct Beneficiary {
    pub owner: String,
    pub beneficiary_data: Vec<BeneficiaryData>,
}
