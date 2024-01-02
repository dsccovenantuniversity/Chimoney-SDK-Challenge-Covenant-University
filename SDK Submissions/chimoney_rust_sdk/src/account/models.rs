use serde::{Deserialize, Serialize};

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
