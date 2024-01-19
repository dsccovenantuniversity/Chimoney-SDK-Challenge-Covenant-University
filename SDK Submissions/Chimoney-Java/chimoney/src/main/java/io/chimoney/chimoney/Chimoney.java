package io.chimoney.chimoney;

import io.github.cdimascio.dotenv.Dotenv;

/**
 * The Chimoney class represents a client for the Chimoney API.
 *
 */
public class Chimoney {
	private final String PRODUCTION_BASE_URL = "https://api.chimoney.io/v0.2/";
	private final String SANDBOX_BASE_URL = "https://api-v2-sandbox.chimoney.io/v0.2/";

	private String API_KEY;
	private String baseURL;

	/**
	 * Constructs a new Chimoney object with the API key from the .env file.
	 * 
	 * <p>
	 * Place the .env file in the root directory of your project (the directory that
	 * contains the top-level package directory).
	 * </p>
	 * 
	 */
	public Chimoney() {
		this.baseURL = PRODUCTION_BASE_URL;
		this.API_KEY = Dotenv.load().get("CHIMONEY_API_KEY");
	}

	/**
	 * Constructs a new Chimoney object with the given API key.
	 * 
	 * @param API_KEY The API key to use for requests.
	 */
	public Chimoney(String API_KEY) {
		this.baseURL = PRODUCTION_BASE_URL;
		this.API_KEY = API_KEY;
	}

	/**
	 * Constructs a new Chimoney object in sandbox mode with the API key from the
	 * .env file.
	 * 
	 * <p>
	 * Sandbox mode is a development environment. Check the Chimoney API
	 * documentation for more information.
	 * </p>
	 * <p>
	 * Place the .env file in the root directory of your project (the directory that
	 * contains the top-level package directory).
	 * </p>
	 * 
	 */
	public static Chimoney withSandbox() {
		Chimoney chimoney = new Chimoney();
		chimoney.baseURL = chimoney.SANDBOX_BASE_URL;

		return chimoney;
	}

	/**
	 * Constructs a new Chimoney object in sandbox mode with the given API key.
	 * 
	 * <p>
	 * Sandbox mode is a development environment. Check the Chimoney API
	 * documentation for more information.
	 * </p>
	 * 
	 * @param API_KEY The API key to use for requests.
	 */
	public static Chimoney withSandbox(String API_KEY) {
		Chimoney chimoney = new Chimoney(API_KEY);
		chimoney.baseURL = chimoney.SANDBOX_BASE_URL;

		return chimoney;
	}

	/**
	 * Returns the base URL of the API.
	 *
	 * @return the base URL as a String.
	 */
	public String getBaseURL() {
		return this.baseURL;
	}

	String getAPIKey() throws ChimoneyException {
		if (this.API_KEY == null)
			throw new ChimoneyException("API Key not set");

		return this.API_KEY;
	}
}