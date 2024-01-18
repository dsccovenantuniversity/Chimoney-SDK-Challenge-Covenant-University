package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONException;
import org.json.JSONObject;

public class Payments extends Base {
	enum Status {
		failed, expired, fraud
	}

	public Payments(Chimoney chimoney) {
		super(chimoney);
	}

	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("valueInUSD", valueInUSD);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD, String subAccount) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("valueInUSD", valueInUSD);
		paramsJson.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> initiatePayment(String payerEmail, int valueInUSD, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("valueInUSD", valueInUSD);
		paramsJson.put("subAccount", subAccount);
		paramsJson.put("meta", meta);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("currency", currency);
		paramsJson.put("amount", amount);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount, String subAccount)
			throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("currency", currency);
		paramsJson.put("amount", amount);
		paramsJson.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> initiatePayment(String payerEmail, String currency, int amount, String subAccount,
			Map<String, String> meta) throws Exception {
		JSONObject paramsJson = new JSONObject();
		paramsJson.put("payerEmail", payerEmail);
		paramsJson.put("currency", currency);
		paramsJson.put("amount", amount);
		paramsJson.put("subAccount", subAccount);
		paramsJson.put("meta", meta);

		HttpResponse<String> response = handlePOSTRequest("payment/initiate", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
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

	public Map<String, Object> simulatePayment(String issueID, Payments.Status status) throws Exception {
		JSONObject paramsJson = new JSONObject();
		Map<String, Object> ret;

		paramsJson.put("issueID", issueID);
		paramsJson.put("status", status.toString());

		HttpResponse<String> response = handlePOSTRequest("payment/simulate", paramsJson);
		JSONObject jo = parseJSONData(response);

		try {
			ret = jo.getJSONObject("data").toMap();
		} catch (JSONException e) {
			ret = jo.toMap();
		}

		return ret;
	}

	public Map<String, Object> simulatePayment(String issueID, Payments.Status status, String subAccount)
			throws Exception {
		JSONObject paramsJson = new JSONObject();
		Map<String, Object> ret;

		paramsJson.put("issueID", issueID);
		paramsJson.put("status", status.toString());
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
