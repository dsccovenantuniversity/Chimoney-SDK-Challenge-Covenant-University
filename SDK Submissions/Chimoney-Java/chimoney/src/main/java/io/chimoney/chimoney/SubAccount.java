package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

/**
 * The SubAccount class is a wrapper for the SubAccount module of the Chimoney
 * API.
 * 
 */
public class SubAccount extends Base {

	/**
	 * Constructs a new SubAccount object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with this SubAccount object
	 */
	SubAccount(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Create a sub-account.
	 *
	 * @param name the name of the sub-account
	 * @return a map containing the data of the created sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> create(String name) throws ChimoneyException {
		return create(name, null, null, null, null);
	}

	/**
	 * Create a sub-account.
	 *
	 * @param name  the name of the sub-account
	 * @param email the email address of user
	 * @return a map containing the data of the created sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> create(String name, String email) throws ChimoneyException {
		return create(name, email, null, null, null);
	}

	/**
	 * Create a sub-account.
	 *
	 * @param name      the name of the sub-account
	 * @param firstName the first name of user
	 * @param lastName  the last name of user
	 * @return a map containing the data of the created sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> create(String name, String firstName, String lastName) throws ChimoneyException {
		return create(name, null, firstName, lastName, null);
	}

	/**
	 * Create a sub-account.
	 *
	 * @param name      the name of the sub-account
	 * @param email     the email address of user
	 * @param firstName the first name of user
	 * @param lastName  the last name of user
	 * @return a map containing the data of the created sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> create(String name, String email, String firstName, String lastName)
			throws ChimoneyException {
		return create(name, email, firstName, lastName, null);
	}

	/**
	 * Create a sub-account.
	 *
	 * @param name        the name of the sub-account
	 * @param email       the email address of user
	 * @param firstName   the first name of user
	 * @param lastName    the last name of user
	 * @param phoneNumber the phone number of the sub-account starting with a
	 *                    <b>+</b> and country code
	 * @return a map containing the data of the created sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> create(String name, String email, String firstName, String lastName, String phoneNumber)
			throws ChimoneyException {
		JSONObject params = new JSONObject();
		params.put("name", name);

		if (email != null)
			params.put("email", email);

		if (firstName != null)
			params.put("firstName", firstName);

		if (lastName != null)
			params.put("lastName", lastName);

		if (phoneNumber != null)
			params.put("phoneNumber", phoneNumber);

		HttpResponse<String> response = handlePOSTRequest("sub-account/create", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Update a sub-account.
	 *
	 * @param id   the ID of the sub-account to update
	 * @param meta the metadata to store any number of user information.
	 *             Check the Chimoney API docmentation for more information
	 * @return a map containing the updated sub-account data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> update(String id, Map<String, String> meta) throws ChimoneyException {
		return update(id, meta, null, null, null);
	}

	/**
	 * Update a sub-account.
	 *
	 * @param id        the ID of the sub-account to update
	 * @param meta      the metadata to store any number of user information.
	 *                  Check the Chimoney API docmentation for more information
	 * @param firstName the new first name for the sub-account
	 * @param lastName  the new last name for the sub-account
	 * @return a map containing the updated sub-account data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> update(String id, Map<String, String> meta, String firstName, String lastName)
			throws ChimoneyException {
		return update(id, meta, firstName, lastName, null);
	}

	/**
	 * Update a sub-account.
	 *
	 * @param id          the ID of the sub-account to update
	 * @param meta        the metadata to store any number of user information.
	 *                    Check the Chimoney API docmentation for more information
	 * @param phoneNumber the new phone number for the sub-account starting with a
	 *                    <b>+</b> and country code
	 * @return a map containing the updated sub-account data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> update(String id, Map<String, String> meta, String phoneNumber)
			throws ChimoneyException {
		return update(id, meta, null, null, phoneNumber);
	}

	/**
	 * Update a sub-account.
	 *
	 * @param id          the ID of the sub-account to update
	 * @param meta        the metadata to store any number of user information.
	 *                    Check the Chimoney API docmentation for more information
	 * @param firstName   the new first name for the sub-account
	 * @param lastName    the new last name for the sub-account
	 * @param phoneNumber the new phone number for the sub-account starting with a
	 *                    <b>+</b> and country code
	 * @return a map containing the updated sub-account data
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> update(String id, Map<String, String> meta, String firstName, String lastName,
			String phoneNumber) throws ChimoneyException {
		JSONObject params = new JSONObject();
		params.put("id", id);
		params.put("meta", new JSONObject(meta));

		if (firstName != null)
			params.put("firstName", firstName);

		if (lastName != null)
			params.put("lastName", lastName);

		if (phoneNumber != null)
			params.put("phoneNumber", phoneNumber);

		HttpResponse<String> response = handlePOSTRequest("sub-account/update", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Retrieves the details of a sub-account with the specified ID.
	 *
	 * @param id the ID of the sub-account
	 * @return a map containing the details of the sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getDetails(String id) throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("sub-account/get?id=" + id);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Retrieves a list of sub-accounts associated with this user.
	 *
	 * @return a list of sub-accounts
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getUserSubAccounts() throws ChimoneyException {
		HttpResponse<String> response = handleGETRequest("sub-account/list");
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Deletes a sub-account with the specified ID.
	 *
	 * @param id the ID of the sub-account to delete
	 * @return a map containing the data of the deleted sub-account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> delete(String id) throws ChimoneyException {
		HttpResponse<String> response = handleDELETERequest("sub-account/delete?id=" + id);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

}
