package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

public class Payments extends Base {
	public Payments(Chimoney chimoney) {
		super(chimoney);
	}

	public List<Object> verifyPayment(String id) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("id", id);

		HttpResponse<String> response = handlePOSTRequest("payment/verify", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> verifyPayment(String id, String subAccount) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("id", id);
		paramsJson.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("payment/verify", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
