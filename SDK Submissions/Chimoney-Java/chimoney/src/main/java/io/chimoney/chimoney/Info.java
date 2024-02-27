package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * The Info class is a wrapper for the Info module of the Chimoney
 * API.
 * 
 */
public class Info extends Base {

	/**
	 * Constructs a new Info object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with this Info object
	 */
	public Info(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Retrieves a list of countries that support airtime.
	 *
	 * @return a list of countries
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getAirtimeCountries() throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("info/airtime-countries");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves the information of all assets.
	 *
	 * @return a map containing the assets information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getAssets() throws ChimoneyException {
		return getAssets(null);
	}

	/**
	 * Retrieves the assets for a specific country.
	 *
	 * @param countryCode the country code for which to retrieve the assets
	 * @return a map containing the assets information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getAssets(String countryCode) throws ChimoneyException {
		String queryString = countryCode != null ? "?countryCode=" + countryCode : "";
		HttpResponse<String> response = handleGETRequest("info/assets" + queryString);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();

	}

	/**
	 * Retrieves a list of supported banks and bank codes for a specific country.
	 *
	 * @param countryCode the country code for which to retrieve the banks
	 * @return a list of banks and bank codes
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getBanks(String countryCode) throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("info/country-banks?countryCode=" + countryCode);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves a list of bank branches and branch codes based on the specified
	 * bank code.
	 *
	 * @param bankCode the code of the bank
	 * @return a list of bank branches and branch codes
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getBankBranches(String bankCode) throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("info/bank-branches?bankCode=" + bankCode);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves the exchange rates against the USD.
	 *
	 * @return a map containing the exchange rates
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getExchangeRates() throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("info/exchange-rates");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Converts the specified amount in the given currency to USD.
	 *
	 * @param currency               The currency to convert from. Check the
	 *                               Chimoney API documentation for currency
	 *                               symbols
	 * @param amountInOriginCurrency the amount in the origin currency to convert
	 * @return a map containing the converted amount in USD
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> convertToUSD(String currency, int amountInOriginCurrency) throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest(
				"info/local-amount-in-usd?originCurrency=" + currency + "&amountInOriginCurrency="
						+ amountInOriginCurrency);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Converts the specified amount in USD to the specified currency.
	 *
	 * @param currency    the destination currency to convert to. Check the Chimoney
	 *                    API documentation for currency symbols
	 * @param amountInUSD the amount in USD to convert
	 * @return a map containing the converted amount in the destination currency
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> convertFromUSD(String currency, int amountInUSD) throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest(
				"info/usd-amount-in-local?destinationCurrency=" + currency + "&amountInUSD=" + amountInUSD);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Retrieves a list of all supported mobile money codes.
	 * 
	 * @return a list of mobile money codes
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getMobileMoneyCodes() throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("info/mobile-money-codes");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Verifies the bank account number for a given country code, bank code, and
	 * account number.
	 * 
	 * <p>
	 * Use this function when you want to verify a single bank
	 * account number. Otherwise, use {@link #verifyBankAccountNumbers(Map)}
	 * </p>
	 * 
	 * @param countryCode   the country code of the bank account
	 * @param bankCode      the bank code of the bank account
	 * @param accountNumber the account number of the bank account
	 * @return a list containing only the verified bank account number
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> verifyBankAccountNumber(String countryCode, String bankCode, String accountNumber)
			throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		JSONArray ja = new JSONArray();

		JSONObject jo = new JSONObject();

		jo.put("countryCode", countryCode);
		jo.put("account_bank", bankCode);
		jo.put("account_number", accountNumber);

		ja.put(jo);
		paramsJson.put("verifyAccountNumbers", ja);

		HttpResponse<String> response = handlePOSTRequest("info/verify-bank-account-number", paramsJson);
		JSONObject jObj = parseJSONData(response);

		return jObj.getJSONArray("data").toList();
	}

	/**
	 * Verifies bank account numbers based on the provided map of country codes,
	 * bank codes, and account numbers.
	 * 
	 * <p>
	 * Use {@code Map.of()} to create the map. The keys of the map should be
	 * <b>countryCode</b>, <b>bankCode</b> and <b>accountNumber</b>. The values
	 * should be {@code String[]} of the same length.
	 * </p>
	 * 
	 * <p>
	 * Use this function when you want to verify multiple bank account numbers.
	 * Otherwise, use {@link #verifyBankAccountNumber}
	 * </p>
	 * 
	 * @param map the map containing arrays of country codes, bank codes, and
	 *            account numbers
	 * @return a list of verified bank account numbers
	 * @throws IllegalArgumentException if the arrays in the map are not of the same
	 *                                  size
	 * @throws ChimoneyException        if an error is returned by the Chimoney API
	 */
	public List<Object> verifyBankAccountNumbers(Map<String, String[]> map) throws ChimoneyException {

		if ((map.get("countryCode").length != map.get("bankCode").length)
				&& (map.get("countryCode").length != map.get("accountNumber").length)) {
			throw new IllegalArgumentException("arrays should be of the same size");
		}

		JSONObject paramsJson = new JSONObject();
		JSONArray ja = new JSONArray();

		for (int i = 0; i < map.get("countryCode").length; i++) {
			JSONObject jo = new JSONObject();

			jo.put("countryCode", map.get("countryCode")[i]);
			jo.put("account_bank", map.get("bankCode")[i]);
			jo.put("account_number", map.get("accountNumber")[i]);

			ja.put(jo);
		}
		paramsJson.put("verifyAccountNumbers", ja);

		HttpResponse<String> response = handlePOSTRequest("info/verify-bank-account-number", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

}
