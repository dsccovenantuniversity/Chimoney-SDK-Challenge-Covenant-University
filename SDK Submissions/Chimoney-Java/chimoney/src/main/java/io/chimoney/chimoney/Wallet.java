package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Wallet
 */
public class Wallet extends Base {
	enum Types {
		chi, momo, airtime
	}

	public Wallet(Chimoney chimoney) {
		super(chimoney);
	}

	public List<Object> listWallets() throws Exception {
		HttpResponse<String> response = handlePOSTRequest("wallets/list", null);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> getWallets(String subAccount) throws Exception {
		JSONObject params = new JSONObject();
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("wallets/list", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getWallet(String walletID) throws Exception {
		JSONObject params = new JSONObject();
		params.put("walletID", walletID);

		HttpResponse<String> response = handlePOSTRequest("wallets/lookup", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> getWallet(String walletID, String subAccount) throws Exception {
		JSONObject params = new JSONObject();
		params.put("walletID", walletID);
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("wallets/lookup", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> transferToWallet(String receiver, int valueInUSD) throws Exception {
		JSONObject params = new JSONObject();
		params.put("receiver", receiver);
		params.put("valueInUSD", valueInUSD);

		HttpResponse<String> response = handlePOSTRequest("wallets/transfer", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> transferToWallet(String receiver, int valueInUSD, Types walletType) throws Exception {
		JSONObject params = new JSONObject();
		params.put("receiver", receiver);
		params.put("valueInUSD", valueInUSD);
		params.put("wallet", walletType.toString());

		HttpResponse<String> response = handlePOSTRequest("wallets/transfer", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> transferToWallet(String receiver, int valueInUSD, Types walletType, String subAccount)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("receiver", receiver);
		params.put("valueInUSD", valueInUSD);
		params.put("wallet", walletType.toString());
		params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("wallets/transfer", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}