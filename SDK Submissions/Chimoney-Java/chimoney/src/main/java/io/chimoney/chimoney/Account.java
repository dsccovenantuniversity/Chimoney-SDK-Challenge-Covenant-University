package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

/**
 * The Account class is a wrapper for the Account module of the Chimoney API.
 * 
 */
public class Account extends Base {

	/**
	 * Constructs a new Account object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with the account
	 */
	public Account(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Retrieves a list of transactions by issue ID.
	 *
	 * @param issueID the issueID of the transaction
	 * @return a list of transactions
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getTransactionsByIssueID(String issueID) throws ChimoneyException {
		return getTransactionsByIssueID(issueID, null);
	}

	/**
	 * Retrieves a list of transactions by issue ID and sub-account.
	 *
	 * @param issueID    the issue ID of the transactions to retrieve
	 * @param subAccount the sub-account associated with the transactions
	 * @return a list of transactions as objects
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getTransactionsByIssueID(String issueID, String subAccount) throws ChimoneyException {
		JSONObject jsonParams = new JSONObject();

		if (subAccount != null)
			jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/issue-id-transactions?issueID=" + issueID,
				jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves the profile information for a user.
	 * Specify either userID or linkCode. If both are specified, userID will be
	 * used.
	 *
	 * @param userID   the ID of the user
	 * @param linkCode the link code associated with the user
	 * @return a map containing the profile information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getProfile(String userID, String linkCode) throws ChimoneyException {
		return getProfile(userID, linkCode, null);
	}

	/**
	 * Retrieves the profile information for a user and sub-account.
	 * Specify either userID or linkCode. If both are specified, userID will be
	 * used.
	 *
	 * @param userID     the ID of the user
	 * @param linkCode   the link code associated with the user
	 * @param subAccount the sub-account associated with the user
	 * @return a map containing the profile information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getProfile(String userID, String linkCode, String subAccount) throws ChimoneyException {
		JSONObject jsonParams = new JSONObject();
		if (userID != null)
			jsonParams.put("userID", userID);
		else if (linkCode != null)
			jsonParams.put("linkCode", linkCode);
		else
			throw new ChimoneyException("Either userID or linkCode must be specified.");

		if (subAccount != null)
			jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/public-profile", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Retrieves a list of transactions for this account.
	 *
	 * @return a list of transactions for this account
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getTransactionsByAccount() throws ChimoneyException {
		return getTransactionsByAccount(null);
	}

	/**
	 * Retrieves a list of transactions for a specific sub-account.
	 *
	 * @param subAccount the subAccount for which to retrieve transactions
	 * @return a list of transactions as objects
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> getTransactionsByAccount(String subAccount) throws ChimoneyException {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transactions", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves a transaction from this account by the transaction ID.
	 *
	 * @param id The ID of the transaction to retrieve.
	 * @return A map containing the transaction data.
	 * @throws ChimoneyException If an error is returned by the Chimoney API
	 */
	public Map<String, Object> getTransaction(String id) throws ChimoneyException {
		return getTransaction(id, null);
	}

	/**
	 * Retrieves a transaction from this account by the transaction ID.
	 *
	 * @param id         The ID of the transaction to retrieve.
	 * @param subAccount The sub-account associated with the transaction.
	 * @return A map containing the transaction data.
	 * @throws ChimoneyException If an error is returned by the Chimoney API
	 */
	public Map<String, Object> getTransaction(String id, String subAccount) throws ChimoneyException {
		JSONObject jsonParams = new JSONObject();

		if (subAccount != null)
			jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transaction?id=" + id, jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Transfers funds from this account to the specified receiver.
	 *
	 * @param receiver   the ID of the recipient of the funds
	 * @param valueInUSD the amount to transfer in USD
	 * @return a map containing the details of the transfer
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> accountTransfer(String receiver, int valueInUSD) throws ChimoneyException {
		return accountTransfer(receiver, valueInUSD, null, null);
	}

	/**
	 * Transfers funds from this account to the specified receiver.
	 *
	 * @param receiver   the ID of the recipient of the funds
	 * @param valueInUSD the amount to transfer in USD
	 * @param wallet     the wallet type to use for the transfer
	 * @return a map containing the details of the transfer
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> accountTransfer(String receiver, int valueInUSD, Wallet.Types wallet)
			throws ChimoneyException {
		return accountTransfer(receiver, valueInUSD, wallet, null);
	}

	/**
	 * Transfers funds from this account to the specified receiver.
	 *
	 * @param receiver   the ID of the recipient of the funds
	 * @param valueInUSD the amount to transfer in USD
	 * @param wallet     the wallet type to use for the transfer
	 * @param subAccount the sub-account to use for the transfer
	 * @return a map containing the response data from the transfer operation
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> accountTransfer(String receiver, int valueInUSD, Wallet.Types wallet, String subAccount)
			throws ChimoneyException {
		JSONObject jsonParams = new JSONObject();
		jsonParams.put("receiver", receiver);
		jsonParams.put("valueInUSD", valueInUSD);

		if (wallet != null)
			jsonParams.put("wallet", wallet.toString());

		if (subAccount != null)
			jsonParams.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("accounts/transfer", jsonParams);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Deletes an unpaid transaction with the specified chiRef.
	 *
	 * @param chiRef the reference of the transaction to be deleted
	 * @return a map containing the result of the deletion operation
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> deleteUnpaidTransaction(String chiRef) throws ChimoneyException {
		return deleteUnpaidTransaction(chiRef, null);
	}

	/**
	 * Deletes an unpaid transaction with the specified chiRef.
	 *
	 * @param chiRef     the reference of the transaction to be deleted
	 * @param subAccount the subAccount associated with the transaction
	 * @return a map containing the data of the deleted transaction
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> deleteUnpaidTransaction(String chiRef, String subAccount)
			throws ChimoneyException {
		String ext = subAccount != null ? "&subAccount=" + subAccount : "";
		HttpResponse<String> response = handleDELETERequest(
				"accounts/delete-unpaid-transaction?chiRef=" + chiRef + ext);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}
