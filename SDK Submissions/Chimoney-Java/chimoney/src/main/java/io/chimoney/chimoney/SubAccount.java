package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

public class SubAccount extends Base {
	SubAccount(Chimoney chimoney) {
		super(chimoney);
	}

	public Map<String, Object> create(String name) throws Exception {
		JSONObject params = new JSONObject();
		params.put("name", name);

		HttpResponse<String> response = handlePOSTRequest("sub-account/create", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> create(String name, String email) throws Exception {
		JSONObject params = new JSONObject();
		params.put("name", name);
		params.put("email", email);

		HttpResponse<String> response = handlePOSTRequest("sub-account/create", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> create(String name, String email, String firstName, String lastName) throws Exception {
		JSONObject params = new JSONObject();
		params.put("name", name);
		params.put("email", email);
		params.put("firstName", firstName);
		params.put("lastName", lastName);

		HttpResponse<String> response = handlePOSTRequest("sub-account/create", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> create(String name, String email, String firstName, String lastName, String phoneNumber)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("name", name);
		params.put("email", email);
		params.put("firstName", firstName);
		params.put("lastName", lastName);
		params.put("phoneNumber", phoneNumber);

		HttpResponse<String> response = handlePOSTRequest("sub-account/create", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> update(String id, Map<String, String> meta) throws Exception {
		JSONObject params = new JSONObject();
		params.put("id", id);
		params.put("meta", new JSONObject(meta));

		HttpResponse<String> response = handlePOSTRequest("sub-account/update", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> update(String id, Map<String, String> meta, String firstName, String lastName)
			throws Exception {
		JSONObject params = new JSONObject();
		params.put("id", id);
		params.put("meta", new JSONObject(meta));
		params.put("firstName", firstName);
		params.put("lastName", lastName);

		HttpResponse<String> response = handlePOSTRequest("sub-account/update", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> update(String id, Map<String, String> meta, String firstName, String lastName,
			String phoneNumber) throws Exception {
		JSONObject params = new JSONObject();
		params.put("id", id);
		params.put("meta", new JSONObject(meta));
		params.put("firstName", firstName);
		params.put("lastName", lastName);
		params.put("phoneNumber", phoneNumber);

		HttpResponse<String> response = handlePOSTRequest("sub-account/update", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public Map<String, Object> getDetails(String id) throws Exception {
		HttpResponse<String> response = handleGETRequest("sub-account/get?id=" + id);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	public List<Object> getUserSubAccounts() throws Exception {
		HttpResponse<String> response = handleGETRequest("sub-account/list");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> delete(String id) throws Exception {
		HttpResponse<String> response = handleDELETERequest("sub-account/delete?id=" + id);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

}
