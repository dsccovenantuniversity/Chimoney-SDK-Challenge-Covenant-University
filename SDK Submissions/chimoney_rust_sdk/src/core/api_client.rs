use dotenv::dotenv;
use reqwest::Client;
use std::env;

#[derive()]
pub struct APIClient {
    content_type: String,
    accept: String,
    base_url: String,
    api_key: String,
}

impl APIClient {
    pub fn new(use_sandbox: bool) -> Result<APIClient, String> {
        let production_base_url = "https://api.chimoney.io".to_string();
        let sandbox_base_url = "https://api-v2-sandbox.chimoney.io".to_string();
        let content_type = "application/json".to_string();
        let accept = "application/json".to_string();

        let api_key: String = match env::var("X_API_KEY") {
            Ok(key) => key,
            Err(_) => return Err("X_API_KEY not found".to_string()),
        };

        dotenv().ok();

        let base_url = if use_sandbox {
            sandbox_base_url
        } else {
            production_base_url
        };

        Ok(APIClient {
            base_url,
            content_type,
            accept,
            api_key,
        })
    }

    pub async fn get(
        &self,
        path: &str,
        query: Option<&str>,
    ) -> Result<String, Box<dyn std::error::Error>> {
        let mut url = format!("{}{}", self.base_url, path);

        if let Some(params) = query {
            url.push_str("?");
            url.push_str(params);
        }

        let client = Client::new();
        let res = client
            .get(&url)
            .header("Content-Type", self.content_type.clone())
            .header("Accept", self.accept.clone())
            .header("X-API-KEY", self.api_key.clone())
            .send()
            .await?;
        Ok(res.text().await?)
    }

    pub async fn post(
        &self,
        path: &str,
        body: &str,
        query: Option<&str>,
    ) -> Result<String, Box<dyn std::error::Error>> {
        let mut url = format!("{}{}", self.base_url, path);

        if let Some(params) = query {
            url.push_str("?");
            url.push_str(params);
        }

        let client = Client::new();
        let res = client
            .post(&url)
            .header("Content-Type", self.content_type.clone())
            .header("Accept", self.accept.clone())
            .header("X-API-KEY", self.api_key.clone())
            .body(body.to_string())
            .send()
            .await?;
        Ok(res.text().await?)
    }

    pub async fn put(
        &self,
        path: &str,
        body: &str,
        query: Option<&str>,
    ) -> Result<String, Box<dyn std::error::Error>> {
        let mut url = format!("{}{}", self.base_url, path);

        if let Some(params) = query {
            url.push_str("?");
            url.push_str(params);
        }

        let client = Client::new();
        let res = client
            .put(&url)
            .header("Content-Type", self.content_type.clone())
            .header("Accept", self.accept.clone())
            .header("X-API-KEY", self.api_key.clone())
            .body(body.to_string())
            .send()
            .await?;
        Ok(res.text().await?)
    }

    pub async fn delete(
        &self,
        path: &str,
        query: Option<&str>,
    ) -> Result<String, Box<dyn std::error::Error>> {
        let mut url = format!("{}{}", self.base_url, path);

        if let Some(params) = query {
            url.push_str("?");
            url.push_str(params);
        }

        let client = Client::new();
        let res = client
            .delete(&url)
            .header("Content-Type", self.content_type.clone())
            .header("Accept", self.accept.clone())
            .header("X-API-KEY", self.api_key.clone())
            .send()
            .await?;
        Ok(res.text().await?)
    }

    // Methods for handling responses and error handling
    pub async fn handle_response(
        &self,
        response: String,
    ) -> Result<String, Box<dyn std::error::Error>> {
        let response_json: serde_json::Value = serde_json::from_str(&response)?;
        let response_code = response_json["code"].as_u64().unwrap();
        let response_message = response_json["message"].as_str().unwrap();
        if response_code == 200 {
            Ok(response_message.to_string())
        } else {
            Err(response_message.to_string().into())
        }
    }

    pub async fn handle_error(&self, error: String) -> Result<String, Box<dyn std::error::Error>> {
        let error_json: serde_json::Value = serde_json::from_str(&error)?;
        let error_code = error_json["code"].as_u64().unwrap();
        let error_message = error_json["message"].as_str().unwrap();
        if error_code == 400 {
            return Err(error_message.to_string().into());
        } else {
            return Err(error_message.to_string().into());
        }
    }
}
