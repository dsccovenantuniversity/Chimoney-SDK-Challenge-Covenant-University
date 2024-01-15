package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

public class Info extends Base {
	public Info(Chimoney chimoney) {
		super(chimoney);
	}

	public List<Object> getListAirtimeCountries() throws Exception {
		HttpResponse<String> response = handleGETRequest("v0.2/info/airtime-countries");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	public Map<String, Object> getListAssets() throws Exception {
		HttpResponse<String> response = handleGETRequest("v0.2/info/assets");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();

	}

}
