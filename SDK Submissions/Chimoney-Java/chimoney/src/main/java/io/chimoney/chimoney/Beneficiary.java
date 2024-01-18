package io.chimoney.chimoney;

import java.util.Map;
import java.net.http.HttpResponse;

import org.json.JSONObject;

public class Beneficiary extends Base {
	public Beneficiary(Chimoney chimoney) {
		super(chimoney);
	}

	public Map<String, Object> createBeneficiary(String ownerID, Map<String, String> beneficiaryData) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("owner", ownerID);
		paramsJson.put("beneficiaryData", beneficiaryData);

		HttpResponse<String> response = handlePOSTRequest("beneficiary/create", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
