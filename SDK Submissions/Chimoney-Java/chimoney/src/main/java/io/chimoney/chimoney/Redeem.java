package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * The Redeem class is a wrapper for the Redeem module of the Chimoney API.
 * 
 */
public class Redeem extends Base {

	/**
	 * Constructs a new Redeem object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with this Redeem object
	 */
	public Redeem(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Redeems airtime.
	 * 
	 * @param chiRef        The Chi reference
	 * @param phoneNumber   The phone number to send the airtime to
	 * @param countryToSend The country to send the airtime to
	 * @return A map containing the response data
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend) throws Exception {
		return airtime(chiRef, phoneNumber, countryToSend, null, null);
	}

	/**
	 * Redeems airtime.
	 * 
	 * @param chiRef        The Chi reference
	 * @param phoneNumber   The phone number to send the airtime to
	 * @param countryToSend The country to send the airtime to
	 * @param subAccount    The sub-account to use
	 * @return A map containing the response data
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend, String subAccount)
			throws Exception {
		return airtime(chiRef, phoneNumber, countryToSend, subAccount, null);
	}

	/**
	 * Redeem airtime transactions.
	 * 
	 * @param chiRef        The Chi reference
	 * @param phoneNumber   The phone number to send the airtime to
	 * @param countryToSend The country to send the airtime to
	 * @param subAccount    The sub-account to use
	 * @param meta          Additional meta data
	 * @return A map containing the response data
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("phoneNumber", phoneNumber);
		params.put("countryToSend", countryToSend);

		if (subAccount != null)
			params.put("subAccount", subAccount);

		if (meta != null)
			params.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("redeem/airtime", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Redeem any transaction.
	 *
	 * @param chiRef     the Chi reference
	 * @param redeemData the data required to redeem. Check the Chimoney API
	 *                   document for more information
	 * @return a map containing the response data
	 * @throws Exception if an error occurs during the redeem operation
	 */
	public Map<String, Object> any(String chiRef, Map<String, String> redeemData) throws Exception {
		return any(chiRef, redeemData, null, null);
	}

	/**
	 * Redeem any transaction.
	 *
	 * @param chiRef     the Chi reference
	 * @param redeemData the data required to redeem. Check the Chimoney API
	 *                   document for more information
	 * @param subAccount the sub-account to use
	 * @return a map containing the response data
	 * @throws Exception if an error occurs during the redeem operation
	 */
	public Map<String, Object> any(String chiRef, Map<String, String> redeemData, String subAccount) throws Exception {
		return any(chiRef, redeemData, subAccount, null);
	}

	/**
	 * Redeem any transaction.
	 *
	 * @param chiRef     the Chi reference
	 * @param redeemData the data required to redeem. Check the Chimoney API
	 *                   document for more information
	 * @param subAccount the sub-account to use
	 * @param meta       additional metadata
	 * @return a map containing the response data
	 * @throws Exception if an error occurs during the redeem operation
	 */
	public Map<String, Object> any(String chiRef, Map<String, String> redeemData, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemData", new JSONObject(redeemData));

		if (subAccount != null)
			params.put("subAccount", subAccount);

		if (meta != null)
			params.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("redeem/any", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Redeem Chimoney.
	 * 
	 * @param chimoneys An array of Chimoney key-value objects to be
	 *                  redeemed. Check the Chimoney API document for more
	 *                  information
	 * @return A map containing the response data from the redemption request
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> chimoney(Map<String, String>[] chimoneys) throws Exception {
		return chimoney(chimoneys, null, false);
	}

	/**
	 * Redeem Chimoney.
	 * 
	 * @param chimoneys  An array of Chimoney key-value objects to be
	 *                   redeemed. Check the Chimoney API document for more
	 *                   information
	 * @param subAccount The sub-account to use
	 * @return A map containing the response data from the redemption request
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> chimoney(Map<String, String>[] chimoneys, String subAccount) throws Exception {
		return chimoney(chimoneys, subAccount, false);
	}

	/**
	 * Redeem Chimoney.
	 * 
	 * @param chimoneys           An array of Chimoney key-value objects to be
	 *                            redeemed. Check the Chimoney API document for more
	 *                            information
	 * @param subAccount          The sub-account to use
	 * @param turnOffNotification A boolean value indicating whether to turn off
	 *                            notification
	 * @return A map containing the response data from the redemption request
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> chimoney(Map<String, String>[] chimoneys, String subAccount, boolean turnOffNotification)
			throws Exception {
		JSONObject params = new JSONObject();
		JSONArray ja = new JSONArray();

		for (Map<String, String> chimoney : chimoneys) {
			ja.put(new JSONObject(chimoney));
		}
		params.put("chimoneys", ja);

		if (subAccount != null)
			params.put("subAccount", subAccount);

		if (turnOffNotification)
			params.put("turnOffNotification", turnOffNotification);

		HttpResponse<String> response = handlePOSTRequest("redeem/chimoney", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Redeem a gift card.
	 *
	 * @param chiRef        The reference number of the gift card
	 * @param redeemOptions The options for redeeming the gift card. Check the
	 *                      Chimoney API documentation for more information
	 * @return A map containing the response data from the gift card redemption
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> giftCard(String chiRef, Map<String, String> redeemOptions)
			throws Exception {
		return giftCard(chiRef, redeemOptions, null);
	}

	/**
	 * Redeem a gift card.
	 *
	 * @param chiRef        The reference number of the gift card
	 * @param redeemOptions The options for redeeming the gift card. Check the
	 *                      Chimoney API documentation for more information
	 * @param subAccount    The sub-account to use
	 * @return A map containing the response data from the gift card redemption
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> giftCard(String chiRef, Map<String, String> redeemOptions, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));

		if (subAccount != null)
			params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/gift-card", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Redeem mobile money.
	 *
	 * @param chiRef        The Chi reference.
	 * @param redeemOptions The data for redeeming mobile money. Check the Chimoney
	 *                      API documentation for more information
	 * @param subAccount    The sub-account to use
	 * @return A map containing the response data from the redemption process
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> mobileMoney(String chiRef, Map<String, String> redeemOptions)
			throws Exception {
		return mobileMoney(chiRef, redeemOptions, null);
	}

	/**
	 * Redeem mobile money.
	 *
	 * @param chiRef        The Chi reference.
	 * @param redeemOptions The data for redeeming mobile money. Check the Chimoney
	 *                      API documentation for more information
	 * @param subAccount    The sub-account to use
	 * @return A map containing the response data from the redemption process
	 * @throws Exception If an error occurs during the redemption process
	 */
	public Map<String, Object> mobileMoney(String chiRef, Map<String, String> redeemOptions, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));

		if (subAccount != null)
			params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/mobile-money", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
