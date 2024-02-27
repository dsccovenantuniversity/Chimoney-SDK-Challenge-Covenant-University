package io.chimoney.chimoney;

import java.util.Map;
import java.net.http.HttpResponse;

import org.json.JSONObject;

/**
 * The Beneficiary class is a wrapper for the Beneficiary module of the Chimoney
 * API.
 * 
 */
public class Beneficiary extends Base {

	/**
	 * Constructs a new Beneficiary object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with the beneficiary
	 */
	public Beneficiary(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Creates a beneficiary with the given user ID and beneficiary data.
	 *
	 * @param ownerID         the ID of the user/sub-account
	 * @param beneficiaryData the data of the beneficiary
	 * @return A map containing the beneficiary data. Check the Chimoney API
	 *         documentation for more information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> createBeneficiary(String ownerID, Map<String, String> beneficiaryData)
			throws ChimoneyException {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("owner", ownerID);
		paramsJson.put("beneficiaryData", new JSONObject(beneficiaryData));

		HttpResponse<String> response = handlePOSTRequest("beneficiary/create", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
