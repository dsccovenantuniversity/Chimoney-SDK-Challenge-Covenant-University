package io.chimoney.chimoney;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

import org.json.JSONObject;

class Base {

	private Chimoney chimoney;
	HttpClient client = HttpClient.newHttpClient();

	Base(Chimoney chimoney) {
		this.chimoney = chimoney;
	}

	HttpResponse<String> handleGETRequest(String path) throws Exception {
		HttpRequest request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() + path))
				.header("X-API-KEY", chimoney.getAPIKey()).GET()
				.build();
		return client.send(request, HttpResponse.BodyHandlers.ofString());
	}

	/*
	 * HttpResponse<String> handlePOSTRequest(String path) throws Exception {
	 * HttpRequest request = HttpRequest.newBuilder(URI.create(baseURL +
	 * path)).header("X-API-KEY", API_KEY).POST().build();
	 * return client.send(request, HttpResponse.BodyHandlers.ofString());
	 * }
	 */

	JSONObject parseJSONData(HttpResponse<String> response) {
		return new JSONObject(response.body());
	}
}
