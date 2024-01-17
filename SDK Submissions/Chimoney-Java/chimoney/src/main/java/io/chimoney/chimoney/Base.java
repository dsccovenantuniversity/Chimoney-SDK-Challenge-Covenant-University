package io.chimoney.chimoney;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

import org.json.JSONArray;
import org.json.JSONObject;

class Base {
	private Chimoney chimoney;
	HttpClient client = HttpClient.newHttpClient();

	Base(Chimoney chimoney) {
		this.chimoney = chimoney;
	}

	HttpResponse<String> handleGETRequest(String path) throws Exception {
		HttpRequest request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() + path))
				.header("X-API-KEY", chimoney.getAPIKey()).header("accept", "application/json").GET()
				.build();
		return client.send(request, HttpResponse.BodyHandlers.ofString());
	}

	HttpResponse<String> handlePOSTRequest(String path, JSONObject params) throws Exception {
		var bodyPublisher = params != null ? HttpRequest.BodyPublishers.ofString(params.toString())
				: HttpRequest.BodyPublishers.noBody();
		HttpRequest request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() +
				path)).header("X-API-KEY", chimoney.getAPIKey()).header("accept", "application/json")
				.header("Content-Type", "application/json")
				.POST(bodyPublisher).build();

		return client.send(request, HttpResponse.BodyHandlers.ofString());
	}

	JSONObject parseJSONData(HttpResponse<String> response) {
		// System.out.println(response.body());
		return new JSONObject(response.body());
	}
}
