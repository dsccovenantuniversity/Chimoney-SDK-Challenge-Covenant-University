package io.chimoney.chimoney;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

import java.util.Iterator;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;

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
	Iterator<JsonNode> parseJSONData(HttpResponse<String> response) throws Exception {
		ObjectMapper objectMapper = new ObjectMapper();
		JsonNode rootNode = objectMapper.readTree(response.body());

		return rootNode.path("data").elements();
	}
}
