package io.chimoney.chimoney;

import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import org.json.JSONObject;

/**
 * The Wallet class is a wrapper for the Wallet module of the Chimoney API.
 * 
 */
public class Wallet extends Base {

	/**
	 * Represents the types of wallets in Chimoney.
	 * Possible values are: chi, momo, and airtime.
	 */
	enum Types {
		chi, momo, airtime
	}

	/**
	 * Constructs a new Wallet object with the specified Chimoney instance.
	 * 
	 * @param chimoney the Chimoney instance associated with this Wallet object
	 */
	public Wallet(Chimoney chimoney) {
		super(chimoney);
	}

	/**
	 * Retrieves a list of wallets associated with the user.
	 *
	 * @return a list of wallets
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> listWallets() throws ChimoneyException {
		return listWallets(null);
	}

	/**
	 * Retrieves a list of wallets associated with the user.
	 *
	 * @param subAccount the sub-account to retrieve wallets for
	 * @return a list of wallets
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public List<Object> listWallets(String subAccount) throws ChimoneyException {
		JSONObject paramsJson = null;

		if (subAccount != null) {
			paramsJson = new JSONObject();
			paramsJson.put("subAccount", subAccount);
		}

		HttpResponse<String> response = handlePOSTRequest("wallets/list", paramsJson);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONArray("data").toList();
	}

	/**
	 * Retrieves the wallet information for the specified wallet ID.
	 *
	 * @param walletID the ID of the wallet to retrieve
	 * @return a map containing the wallet information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getWallet(String walletID) throws ChimoneyException {
		return getWallet(walletID, null);
	}

	/**
	 * Retrieves the wallet information for the specified wallet ID and sub-account.
	 *
	 * @param walletID   the ID of the wallet to retrieve
	 * @param subAccount the sub-account associated with the wallet
	 * @return a map containing the wallet information
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> getWallet(String walletID, String subAccount) throws ChimoneyException {
		JSONObject params = new JSONObject();
		params.put("walletID", walletID);

		if (subAccount != null)
			params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("wallets/lookup", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}

	/**
	 * Transfers funds to a wallet.
	 *
	 * @param receiver   the receiver's wallet address
	 * @param valueInUSD the value to transfer in USD
	 * @return a map containing the transferred funds details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> transferToWallet(String receiver, int valueInUSD) throws ChimoneyException {
		return transferToWallet(receiver, valueInUSD, null, null);
	}

	/**
	 * Transfers funds to a wallet.
	 *
	 * @param receiver   the receiver's wallet address
	 * @param valueInUSD the value to transfer in USD
	 * @param subAccount the sub-account to transfer funds to
	 * @return a map containing the transferred funds details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> transferToWallet(String receiver, int valueInUSD, String subAccount)
			throws ChimoneyException {
		return transferToWallet(receiver, valueInUSD, subAccount, null);
	}

	/**
	 * Transfers funds to a wallet.
	 *
	 * @param receiver   the receiver's wallet address
	 * @param valueInUSD the value to transfer in USD
	 * @param subAccount the sub-account to transfer funds to
	 * @param walletType the type of wallet. Leave blank except you fully understand
	 *                   the different wallet types
	 * @return a map containing the transferred funds details
	 * @throws ChimoneyException if an error is returned by the Chimoney API
	 */
	public Map<String, Object> transferToWallet(String receiver, int valueInUSD, String subAccount, Types walletType)
			throws ChimoneyException {
		JSONObject params = new JSONObject();
		params.put("receiver", receiver);
		params.put("valueInUSD", valueInUSD);

		if (walletType != null)
			params.put("wallet", walletType.toString());

		if (subAccount != null)
			params.put("subAccount", subAccount);

		HttpResponse<String> response = handlePOSTRequest("wallets/transfer", params);
		JSONObject jo = parseJSONData(response);

		return jo.getJSONObject("data").toMap();
	}
}