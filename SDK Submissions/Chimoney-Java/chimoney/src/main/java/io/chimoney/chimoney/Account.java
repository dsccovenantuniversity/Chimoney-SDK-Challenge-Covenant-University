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
		HttpResponse<String> response = handlePOSTRequest("accounts/issue-id-transactions?issueID=" + issueID, null);
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
}
