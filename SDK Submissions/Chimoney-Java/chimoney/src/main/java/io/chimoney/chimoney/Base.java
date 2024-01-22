package io.chimoney.chimoney;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

import org.json.JSONObject;

class Base {
	private Chimoney chimoney;
	private HttpClient client = HttpClient.newHttpClient();

	Base(Chimoney chimoney) {
		this.chimoney = chimoney;
	}

	HttpResponse<String> handleGETRequest(String path) throws ChimoneyException {
		HttpRequest request;
		HttpResponse<String> response = null;

		try {
			request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() + path))
					.header("X-API-KEY", chimoney.getAPIKey()).header("accept", "application/json").GET()
					.build();
			response = client.send(request, HttpResponse.BodyHandlers.ofString());
		} catch (ChimoneyException e) {
			throw e;
		} catch (Exception e) {
			e.printStackTrace();
			System.exit(1);
		}
		return response;
	}

	HttpResponse<String> handlePOSTRequest(String path, JSONObject params) throws ChimoneyException {
		HttpRequest request;
		HttpResponse<String> response = null;

		var bodyPublisher = params != null ? HttpRequest.BodyPublishers.ofString(params.toString())
				: HttpRequest.BodyPublishers.noBody();
		try {
			request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() +
					path)).header("X-API-KEY", chimoney.getAPIKey()).header("accept", "application/json")
					.header("Content-Type", "application/json")
					.POST(bodyPublisher).build();
			response = client.send(request, HttpResponse.BodyHandlers.ofString());
		} catch (ChimoneyException e) {
			throw e;
		} catch (Exception e) {
			e.printStackTrace();
			System.exit(1);
		}
		return response;
	}

	HttpResponse<String> handleDELETERequest(String path) throws ChimoneyException {
		HttpRequest request;
		HttpResponse<String> response = null;

		try {
			request = HttpRequest.newBuilder(URI.create(chimoney.getBaseURL() + path))
					.header("X-API-KEY", chimoney.getAPIKey()).header("accept", "application/json").DELETE()
					.build();
			response = client.send(request, HttpResponse.BodyHandlers.ofString());
		} catch (ChimoneyException e) {
			throw e;
		} catch (Exception e) {
			e.printStackTrace();
			System.exit(1);
		}
		return response;
	}

	JSONObject parseJSONData(HttpResponse<String> response) throws ChimoneyException {
		JSONObject obj = new JSONObject(response.body());

		if (obj.has("error")) {
			String msg = "Error code " + response.statusCode() + " - " + obj.getString("error");
			throw new ChimoneyException(msg);
		}

		return obj;
	}
}
