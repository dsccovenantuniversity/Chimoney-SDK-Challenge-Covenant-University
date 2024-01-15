package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.ArrayList;
import java.util.Iterator;

import com.fasterxml.jackson.databind.JsonNode;

public class ChimoneyInfo extends Base {
	public ChimoneyInfo(Chimoney chimoney) {
		super(chimoney);
	}

	public ArrayList<String> getListAirtimeCountries() throws Exception {
		HttpResponse<String> response = handleGETRequest("v0.2/info/airtime-countries");
		Iterator<JsonNode> jsonData = parseJSONData(response);
		ArrayList<String> array = new ArrayList<String>();

		while (jsonData.hasNext()) {
			array.add(jsonData.next().asText());
		}

		return array;
	}

}
