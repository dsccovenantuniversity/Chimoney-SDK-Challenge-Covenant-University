package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONObject;

public class Info extends Base {
	public Info(Chimoney chimoney) {
		super(chimoney);
	}

	public List<Object> getAirtimeCountries() throws Exception {
		HttpResponse<String> response = handleGETRequest("info/airtime-countries");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getAssets() throws Exception {
		HttpResponse<String> response = handleGETRequest("info/assets");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();

	}

	public List<Object> getBanks(String countryCode) throws Exception {
		HttpResponse<String> response = handleGETRequest("info/country-banks?countryCode=" + countryCode);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> getBankBranches(String bankCode) throws Exception {
		HttpResponse<String> response = handleGETRequest("info/bank-branches?bankCode=" + bankCode);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getExchangeRates() throws Exception {
		HttpResponse<String> response = handleGETRequest("info/exchange-rates");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> convertToUSD(String currency, int amountInOriginCurrency) throws Exception {
		HttpResponse<String> response = handleGETRequest(
				"info/local-amount-in-usd?originCurrency=" + currency + "&amountInOriginCurrency="
						+ amountInOriginCurrency);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Converts the specified amount in USD to the specified currency.
	 *
	 * @param currency    The destination currency to convert to.
	 * @param amountInUSD The amount in USD to convert.
	 * @return A map containing the converted amount in the destination currency.
	 * @throws Exception If an error occurs during the conversion process.
	 */
	public Map<String, Object> convertFromUSD(String currency, int amountInUSD) throws Exception {
		HttpResponse<String> response = handleGETRequest(
				"info/usd-amount-in-local?destinationCurrency=" + currency + "&amountInUSD=" + amountInUSD);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public List<Object> getMobileMoneyCodes() throws Exception {
		HttpResponse<String> response = handleGETRequest("info/mobile-money-codes");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> verifyBankAccountNumbers(String countryCode, String bankCode, String[] accountNumbers)
			throws Exception {
		JSONObject paramsJson = new JSONObject();
		JSONArray ja = new JSONArray();

		for (String acctNum : accountNumbers) {
			JSONObject jo = new JSONObject();

			jo.put("countryCode", countryCode);
			jo.put("account_bank", bankCode);
			jo.put("account_number", acctNum);

			ja.put(jo);
		}
		paramsJson.put("verifyAccountNumbers", ja);

		HttpResponse<String> response = handlePOSTRequest("info/verify-bank-account-number", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> verifyBankAccountNumbers(String[] countryCode, String[] bankCode, String[] accountNumbers)
			throws Exception {

		if ((countryCode.length != bankCode.length) && (countryCode.length != accountNumbers.length)) {
			throw new IllegalArgumentException("arrays should be of the same size");
		}

		JSONObject paramsJson = new JSONObject();
		JSONArray ja = new JSONArray();

		for (int i = 0; i < countryCode.length; i++) {
			JSONObject jo = new JSONObject();

			jo.put("countryCode", countryCode[i]);
			jo.put("account_bank", bankCode[i]);
			jo.put("account_number", accountNumbers[i]);

			ja.put(jo);
		}
		paramsJson.put("verifyAccountNumbers", ja);

		HttpResponse<String> response = handlePOSTRequest("info/verify-bank-account-number", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

}
