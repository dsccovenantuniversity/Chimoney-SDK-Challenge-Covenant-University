using ChimoneyDotNet.Models;
using ChimoneyDotNet.Responses;

namespace ChimoneyDotNet;

/// <summary>
/// Interface for methods to access API endpoints
/// </summary>
public interface IChimoneyWrapperBase
{
    #region Account
    /// <summary>
    /// Get transaction details by issue Id
    /// </summary>
    /// <param name="issueId">IssueID of the transaction</param>
    /// <returns>An instance of TransactionResponse</returns>
    Task<Response<TransactionDetail>> GetTransactionDetailByIssueId(string issueId);

    /// <summary>
    /// Get transaction details by issue Id
    /// </summary>
    /// <param name="issueId">IssueID of the transaction</param>
    /// <param name="subAccout">Subaccount if any.</param>
    /// <returns>An instance of TransactionResponse</returns>
    Task<Response<TransactionDetail>> GetTransactionDetailByIssueId(string issueId, string subAccout);

    /// <summary>
    /// Get all transactions by an account.
    /// </summary>
    /// <param name="subAccount">Subaccount if any.</param>
    /// <returns>An array of type TransactionResponse</returns>
    Task<Response<IEnumerable<TransactionDetail>>> GetAllTransactionsByAccount(string subAccount);

    /// <summary>
    /// Get all transactions by an account.
    /// </summary>
    /// <returns>An array of type TransactionResponse</returns>
    Task<Response<IEnumerable<TransactionDetail>>> GetAllTransactionsByAccount();

    /// <summary>
    /// Get single transaction detail
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <returns>An instance of TransactionResponse</returns>
    Task<Response<TransactionDetail>> GetSingleTransactionDetail(string id);

    /// <summary>
    /// Get single transaction detail
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <param name="subAccount">Subaccount</param>
    /// <returns>An instance of TransactionResponse</returns>
    Task<Response<TransactionDetail>> GetSingleTransactionDetail(string id, string subAccount);

    /// <summary>
    /// Account Transfer
    /// </summary>
    /// <param name="accountTransfer">Account Transfer Object</param>
    /// <returns></returns>
    Task<Response<TransferDetail>> AccountTransfer(AccountTransfer accountTransfer);

    /// <summary>
    /// Deletes an unpaid Transaction
    /// </summary>
    /// <param name="chiRef">Transaction reference</param>
    /// <returns></returns>
    Task<Response<Transaction>> DeleteTransfer(string chiRef);

    /// <summary>
    /// Deletes an unpaid Transaction.
    /// </summary>
    /// <param name="chiRef">Transaction reference</param>
    /// <param name="subAccount">Subaccount</param>
    /// <returns></returns>
    Task<Response<Transaction>> DeleteTransfer(string chiRef, string subAccount);

    #endregion 

    #region Info

    /// <summary>
    /// Get list of all supported airtime countries
    /// </summary>
    /// <returns></returns>
    Task<Response<string[]>> GetSupportedAirtimeCountries();

    /// <summary>
    /// Get list of all assets
    /// </summary>
    /// <returns><see cref="AssetsResponse"/></returns>
    Task<Response<BenefitsData>> GetAllAssets();

    /// <summary>
    /// Get list of all assets
    /// </summary>
    /// <param name="countryCode">Country Code sybmol e.g NG, GH, US</param>
    /// <returns><see cref="AssetsResponse"/></returns>
    Task<Response<BenefitsData>> GetAllAssets(string countryCode);

    /// <summary>
    /// Get list of supported banks and bank code
    /// </summary>
    /// <param name="countryCode">Country Code sybmol e.g NG, GH, US</param>
    /// <returns><see cref="BankListResponse"/></returns>
    Task<Response<IEnumerable<Bank>>> GetSupportedBanks(string countryCode);

    /// <summary>
    /// Get list of bank branches and branch code.
    /// </summary>
    /// <param name="bankCode">bankCode code from <see cref="GetSupportedBanks(string)"/></param>
    /// <returns><see cref="Response{IEnumerable{BankBranch}}"/></returns>
    Task<Response<IEnumerable<BankBranch>>> GetBankBranches(string bankCode);

    /// <summary>
    /// Get exhange rates
    /// </summary>
    /// <returns><see cref="ExchangeRatesResponse"/></returns>
    // use Dictionary<string,decimal> for data field
    Task<Response<Dictionary<string,decimal>>> GetExchangeRates();

    /// <summary>
    /// Convert local currency amount to USD
    /// </summary>
    /// <param name="originCurrency">Currency symbol e.g NGN, USD.</param>
    /// <param name="amountInOriginCurrency">amount to be converted.</param>
    /// <returns><see cref="Response{ConversionToUSD}"/></returns>
    Task<Response<ConversionToUSD>> ConvertLocalCurrencyToUSD(string originCurrency, decimal amountInOriginCurrency);

    /// <summary>
    /// Get list of all supported mobile money codes
    /// </summary>
    /// <returns></returns>
    Task<Response<IEnumerable<MobileMoneyCode>>> GetSupportedMobileMoneyCodes();

    /// <summary>
    /// Get USD amount in Local Currency
    /// </summary>
    /// <param name="destinationCurrency">currency symbol e.g NGN, KES.</param>
    /// <param name="amountInUSD">amount in usd</param>
    /// <returns><see cref="USDToLocalConversionResponse"/></returns>
    Task<Response<USDToLocalConversion>> GetUSDAmountInLocal(string destinationCurrency, decimal amountInUSD);

    /// <summary>
    /// verify a bank account number or multiple bank account numbers
    /// </summary>
    /// <param name="bankAccount"></param>
    /// <returns><see cref="Response{IEnumerable{BankAccount}}"/></returns>
    Task<Response<IEnumerable<BankAccount>>> VerifyBankAccounts(IEnumerable<BankAccount> bankAccounts);

    #endregion

    #region Payments

    Task<Response<>> InitiatePaymentRequest(PaymentRequest paymentRequest);

    #endregion
}