package io.chimoney.chimoney;

import io.github.cdimascio.dotenv.Dotenv;

/**
 * Chimoney
 */
public class Chimoney {
	private final String PRODUCTION_BASE_URL = "https://api.chimoney.io/v0.2/";
	private final String SANDBOX_BASE_URL = "https://api-v2-sandbox.chimoney.io/v0.2/";

	private String API_KEY;
	private String baseURL;

	public Chimoney() {
		this.baseURL = PRODUCTION_BASE_URL;
		this.API_KEY = Dotenv.load().get("CHIMONEY_API_KEY");
	}

	public Chimoney(String API_KEY) {
		this.baseURL = PRODUCTION_BASE_URL;
		this.API_KEY = API_KEY;
	}

	public static Chimoney withSandbox() {
		Chimoney chimoney = new Chimoney();
		chimoney.baseURL = chimoney.SANDBOX_BASE_URL;

		return chimoney;
	}

	public static Chimoney withSandbox(String API_KEY) {
		Chimoney chimoney = new Chimoney(API_KEY);
		chimoney.baseURL = chimoney.SANDBOX_BASE_URL;

		return chimoney;
	}

	public String getBaseURL() {
		return this.baseURL;
	}

	String getAPIKey() throws ChimoneyException {
		if (this.API_KEY == null)
			throw new ChimoneyException("API Key not set");

		return this.API_KEY;
	}
}