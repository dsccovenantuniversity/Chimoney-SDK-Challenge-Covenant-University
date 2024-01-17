use crate::APIClient::APIClient;

pub fn get_supported_airtime_contires() {
    let api_client = APIClient::new();
    let path = "v0.2/info/airtime-countries";
    let response = api_client.get(path);
}
