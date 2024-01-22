package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.Map;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * The Payments class is a wrapper for the Payments module of the Chimoney
 * API.
 * 
 */
public class Payments extends Base {

	/**
	 * Represents the status of a payment.
	 * Possible values are: failed, expired, fraud.
	 */
	enum Status {
		failed, expired, fraud
	}

	/**
	 * Constructs a new Payments object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with this Payments object
	 */
	public Payments(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Initiates a payment with the specified payer email and value in USD.
	 *
	 * @param payerEmail the email address of the payer
	 * @param valueInUSD the value of the payment in USD
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD) throws ChimoneyException {
		return initiatePayment(payerEmail, valueInUSD, null, null);
	}

	/**
	 * Initiates a payment with the specified payer email, value in USD, and
	 * sub-account.
	 * 
	 * @param payerEmail the email address of the payer
	 * @param valueInUSD the value of the payment in USD
	 * @param subAccount the sub-account for the payment
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD, String subAccount)
			throws ChimoneyException {
		return initiatePayment(payerEmail, valueInUSD, subAccount, null);
	}

	/**
	 * Initiates a payment with the given payer email, value in USD, sub-account,
	 * and metadata.
	 * 
	 * @param payerEmail the email address of the payer
	 * @param valueInUSD the value of the payment in USD
	 * @param subAccount the sub-account for the payment
	 * @param meta       the metadata associated with the payment
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD, String subAccount,
			Map<String, String> meta) throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("valueInUSD", valueInUSD);

		if (subAccount != null)
			paramsJson.put("subAccount", subAccount);

		if (meta != null)
			paramsJson.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Initiates a payment with the specified payer email, currency, and amount.
	 *
	 * @param payerEmail the email address of the payer
	 * @param currency   the currency of the payment. Check the Chimoney API
	 *                   documentation for supported currencies.
	 * @param amount     the amount of the payment
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount)
			throws ChimoneyException {
		return initiatePayment(payerEmail, currency, amount, null, null);
	}

	/**
	 * Initiates a payment with the specified payer email, currency, and amount.
	 *
	 * @param payerEmail the email address of the payer
	 * @param currency   the currency of the payment. Check the Chimoney API
	 *                   documentation for supported currencies.
	 * @param amount     the amount of the payment
	 * @param subAccount the sub-account for the payment
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount, String subAccount)
			throws ChimoneyException {
		return initiatePayment(payerEmail, currency, amount, subAccount, null);
	}

	/**
	 * Initiates a payment with the specified payer email, currency, and amount.
	 *
	 * @param payerEmail the email address of the payer
	 * @param currency   the currency of the payment. Check the Chimoney API
	 *                   documentation for supported currencies.
	 * @param amount     the amount of the payment
	 * @param subAccount the sub-account for the payment
	 * @param meta       the metadata associated with the payment
	 * @return a map containing the payment details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount, String subAccount,
			Map<String, String> meta) throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("currency", currency);
		paramsJson.put("amount", amount);

		if (subAccount != null)
			paramsJson.put("subAccount", subAccount);

		if (meta != null)
			paramsJson.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Verifies a payment with the specified ID.
	 *
	 * @param id the ID of the payment to verify
	 * @return a map containing the verified payment information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> verifyPayment(String id) throws ChimoneyException {
		return verifyPayment(id, null);
	}

	/**
	 * Verifies a payment with the given ID and sub-account.
	 *
	 * @param id         the ID of the payment to verify
	 * @param subAccount the sub-account associated with the payment
	 * @return a map containing the verified payment information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> verifyPayment(String id, String subAccount) throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("id", id);

		if (subAccount != null)
			paramsJson.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("payment/verify", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Simulates a card or other status change for a given issue ID, status, and
	 * sub-account. This method only works in staging.
	 * 
	 * @param issueID the ID of the issue
	 * @param status  the status of the payment
	 * @return a map containing the simulated payment data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> simulatePayment(String issueID, Status status) throws ChimoneyException {
		return simulatePayment(issueID, status, null);
	}

	/**
	 * Simulates a card or other status change for a given issue ID, status, and
	 * sub-account. This method only works in staging.
	 * 
	 * @param issueID    the ID of the issue
	 * @param status     the status of the payment
	 * @param subAccount the sub-account for the payment
	 * @return a map containing the simulated payment data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> simulatePayment(String issueID, Status status, String subAccount)
			throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		Map<String, Object> ret;

		paramsJson.put("issueID", issueID);
		paramsJson.put("status", status.toString());

		if (subAccount != null)
			paramsJson.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("payment/simulate", paramsJson);
		JSONObject jo = parseJSONData(response);

		try {
			ret = jo.getJSONObject("data").toMap();
		} catch (JSONException e) {
			ret = jo.toMap();
		}

		return ret;
	}
}
