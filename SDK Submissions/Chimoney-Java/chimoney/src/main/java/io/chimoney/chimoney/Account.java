package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

public class Account extends Base {

	public Account(Chimoney chimoney) {
		super(chimoney);
	}

	public List<Object> getTransactionsByIssueID(String issueID) throws Exception {
		HttpResponse<String> response = handlePOSTRequest("accounts/issue-id-transactions?issueID=" + issueID,
				null);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> getTransactionsByIssueID(String issueID, String subAccount) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/issue-id-transactions?issueID=" + issueID,
				jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getProfile(String userID, String linkCode) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("userID", userID);
		jsonParams.put("linkCode", linkCode);

		HttpResponse<String> response = handlePOSTRequest("accounts/public-profile", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> getProfile(String subAccount, String userID, String linkCode) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("subAccount", subAccount);
		jsonParams.put("userID", userID);
		jsonParams.put("linkCode", linkCode);

		HttpResponse<String> response = handlePOSTRequest("accounts/public-profile", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public List<Object> getTransactionsByAccount() throws Exception {
		HttpResponse<String> response = handlePOSTRequest("accounts/transactions", null);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public List<Object> getTransactionsByAccount(String subAccount) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transactions", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getTransaction(String id) throws Exception {
		HttpResponse<String> response = handlePOSTRequest("accounts/transaction?id=" + id, null);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> getTransaction(String id, String subAccount) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transaction?id=" + id, jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> accountTransfer(String receiver, int valueInUSD) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("receiver", receiver);
		jsonParams.put("valueInUSD", valueInUSD);

		HttpResponse<String> response = handlePOSTRequest("accounts/transfer", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> accountTransfer(String receiver, int valueInUSD, String wallet) throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("receiver", receiver);
		jsonParams.put("valueInUSD", valueInUSD);
		jsonParams.put("wallet", wallet);

		HttpResponse<String> response = handlePOSTRequest("accounts/transfer", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> accountTransfer(String receiver, int valueInUSD, String wallet, String subAccount)
			throws Exception {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("receiver", receiver);
		jsonParams.put("valueInUSD", valueInUSD);
		jsonParams.put("wallet", wallet);
		jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transfer", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> deleteUnpaidTransaction(String chiRef)
			throws Exception {
		HttpResponse<String> response = handleDELETERequest("accounts/delete-unpaid-transaction?chiRef=" + chiRef);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> deleteUnpaidTransaction(String chiRef, String subAccount)
			throws Exception {
		HttpResponse<String> response = handleDELETERequest(
				"accounts/delete-unpaid-transaction?chiRef=" + chiRef + "&subAccount=" + subAccount);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
