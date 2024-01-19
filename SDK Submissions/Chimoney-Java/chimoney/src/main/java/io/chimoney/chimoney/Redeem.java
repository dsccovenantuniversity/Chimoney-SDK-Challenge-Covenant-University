package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONObject;

public class Redeem extends Base {
	public Redeem(Chimoney chimoney) {
		super(chimoney);
	}

	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("phoneNumber", phoneNumber);
		params.put("countryToSend", countryToSend);

		HttpResponse<String> response = handlePOSTRequest("redeem/airtime", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("phoneNumber", phoneNumber);
		params.put("countryToSend", countryToSend);
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/airtime", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> airtime(String chiRef, String phoneNumber, String countryToSend, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("phoneNumber", phoneNumber);
		params.put("countryToSend", countryToSend);
		params.put("subAccount", subAccount);
		params.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("redeem/airtime", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> any(String chiRef, Map<String, String> redeemData) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemData", new JSONObject(redeemData));

		HttpResponse<String> response = handlePOSTRequest("redeem/any", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> any(String chiRef, Map<String, String> redeemData, String subAccount) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("subAccount", subAccount);
		params.put("redeemData", new JSONObject(redeemData));

		HttpResponse<String> response = handlePOSTRequest("redeem/any", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> any(String chiRef, Map<String, String> redeemData, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("subAccount", subAccount);
		params.put("redeemData", new JSONObject(redeemData));
		params.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("redeem/any", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> chimoney(Map<String, String>[] chimoneys) throws Exception {
		JSONObject params = new JSONObject();
		JSONArray ja = new JSONArray();

		for (Map<String, String> chimoney : chimoneys) {
			ja.put(new JSONObject(chimoney));
		}
		params.put("chimoneys", ja);

		HttpResponse<String> response = handlePOSTRequest("redeem/chimoney", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> chimoney(Map<String, String>[] chimoneys, String subAccount) throws Exception {
		JSONObject params = new JSONObject();
		JSONArray ja = new JSONArray();

		for (Map<String, String> chimoney : chimoneys) {
			ja.put(new JSONObject(chimoney));
		}
		params.put("chimoneys", ja);
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/chimoney", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> chimoney(Map<String, String>[] chimoneys, String subAccount, boolean turnOffNotification)
			throws Exception {
		JSONObject params = new JSONObject();
		JSONArray ja = new JSONArray();

		for (Map<String, String> chimoney : chimoneys) {
			ja.put(new JSONObject(chimoney));
		}
		params.put("chimoneys", ja);
		params.put("subAccount", subAccount);
		params.put("turnOffNotification", turnOffNotification);

		HttpResponse<String> response = handlePOSTRequest("redeem/chimoney", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> giftCard(String chiRef, Map<String, String> redeemOptions)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));

		HttpResponse<String> response = handlePOSTRequest("redeem/gift-card", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> giftCard(String chiRef, Map<String, String> redeemOptions, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/gift-card", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> mobileMoney(String chiRef, Map<String, String> redeemOptions)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));

		HttpResponse<String> response = handlePOSTRequest("redeem/mobile-money", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> mobileMoney(String chiRef, Map<String, String> redeemOptions, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("chiRef", chiRef);
		params.put("redeemOptions", new JSONObject(redeemOptions));
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("redeem/mobile-money", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
