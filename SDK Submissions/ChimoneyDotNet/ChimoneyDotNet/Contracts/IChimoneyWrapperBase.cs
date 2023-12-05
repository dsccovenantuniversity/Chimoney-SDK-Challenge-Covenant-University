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
    /// <param name="subAccout">Subaccount if any.</param>
    /// <returns><seealso cref="Response{T}"/> where <see cref="T"/> is <see cref="TransactionDetail"/></returns>
    Task<Response<TransactionDetail>> GetTransactionDetailByIssueId(string issueId, string? subAccount = null);

    /// <summary>
    /// Get all transactions by an account.
    /// </summary>
    /// <param name="subAccount">Subaccount if any.</param>
    /// <returns><seealso cref="Response{T}"/> where T is <see cref="IEnumerable{TransactionDetail}"/> </returns>
    Task<Response<IEnumerable<TransactionDetail>>> GetAllTransactionsByAccount(string? subAccount = null);

    /// <summary>
    /// Get single transaction detail
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <param name="subAccount">Subaccount if any</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="TransactionDetail"/></returns>
    Task<Response<TransactionDetail>> GetSingleTransactionDetail(string id, string? subAccount = null);

    /// <summary>
    /// Account Transfer
    /// </summary>
    /// <param name="accountTransfer">Account Transfer Object</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="TransferDetail"/></returns>
    Task<Response<TransferDetail>> AccountTransfer(AccountTransfer accountTransfer);

    /// <summary>
    /// Deletes an unpaid Transaction.
    /// </summary>
    /// <param name="chiRef">Transaction reference</param>
    /// <param name="subAccount">Subaccount if any</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="Transaction"/></returns>
    Task<Response<Transaction>> DeleteTransfer(string chiRef, string? subAccount = null);

    #endregion 

    #region Info

    /// <summary>
    /// Get list of all supported airtime countries
    /// </summary>
    /// <returns><see cref="Response{T}"/> where T is <see cref="string[]"/></returns>
    Task<Response<string[]>> GetSupportedAirtimeCountries();

    /// <summary>
    /// Get list of all assets
    /// </summary>
    /// <returns><see cref="Response{T}"/> where T is <see cref="BenefitsData"/></returns>
    Task<Response<BenefitsData>> GetAllAssets();

    /// <summary>
    /// Get list of all assets
    /// </summary>
    /// <param name="countryCode">Country Code sybmol e.g NG, GH, US</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="BenefitsData"/></returns>
    Task<Response<BenefitsData>> GetAllAssets(string countryCode);

    /// <summary>
    /// Get list of supported banks and bank code
    /// </summary>
    /// <param name="countryCode">Country Code sybmol e.g NG, GH, US</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="(IEnumerable{Bank})"/></returns>
    Task<Response<IEnumerable<Bank>>> GetSupportedBanks(string countryCode);

    /// <summary>
    /// Get list of bank branches and branch code.
    /// </summary>
    /// <param name="bankCode">bankCode code from <see cref="GetSupportedBanks(string)"/></param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="{IEnumerable{BankBranch}}"/></returns>
    Task<Response<IEnumerable<BankBranch>>> GetBankBranches(string bankCode);

    /// <summary>
    /// Get exhange rates
    /// </summary>
    /// <returns><see cref="Response{T}"/> where T is <see cref="Dictionary{string,decimal}"/></returns>
    // use Dictionary<string,decimal> for data field
    Task<Response<Dictionary<string, decimal>>> GetExchangeRates();

    /// <summary>
    /// Convert local currency amount to USD
    /// </summary>
    /// <param name="originCurrency">Currency symbol e.g NGN, USD.</param>
    /// <param name="amountInOriginCurrency">amount to be converted.</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="ConversionToUSD"/></returns>
    Task<Response<ConversionToUSD>> ConvertLocalCurrencyToUSD(string originCurrency, decimal amountInOriginCurrency);

    /// <summary>
    /// Get list of all supported mobile money codes
    /// </summary>
    /// <returns><see cref="Response{T}"/> where T is <see cref="(IEnumerable{MobileMoneyCode})"/></returns>
    Task<Response<IEnumerable<MobileMoneyCode>>> GetSupportedMobileMoneyCodes();

    /// <summary>
    /// Get USD amount in Local Currency
    /// </summary>
    /// <param name="destinationCurrency">currency symbol e.g NGN, KES.</param>
    /// <param name="amountInUSD">amount in usd</param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="USDToLocalConversion"/></returns>
    Task<Response<USDToLocalConversion>> GetUSDAmountInLocal(string destinationCurrency, decimal amountInUSD);

    /// <summary>
    /// verify a bank account number or multiple bank account numbers
    /// </summary>
    /// <param name="bankAccount"></param>
    /// <returns><see cref="Response{T}"/> where T is <see cref="(IEnumerable{BankAccount})"/></returns>
    Task<Response<IEnumerable<BankAccount>>> VerifyBankAccounts(IEnumerable<BankAccount> bankAccounts);

    #endregion

    #region Payments

    /// <summary>
    /// Initiate a payment request
    /// </summary>
    /// <param name="paymentRequest">The Payment Request Object</param>
    /// <returns><see cref="PaymentResponse{T}"/> where T is <see cref="PaymentInfo"/></returns>
    Task<PaymentResponse<PaymentInfo>> InitiatePaymentRequest(PaymentRequest paymentRequest);

    /// <summary>
    /// Verify a payment
    /// </summary>
    /// <param name="transactionId">Transaction Id (issueID)</param>
    /// <param name="subAccount">Subaccount if any</param>
    /// <returns><see cref="PaymentResponse{T}"/> where T is <see cref="PaymentVerification"/></returns>
    Task<PaymentResponse<PaymentVerification>> VerifyPayment(string transactionId, string? subAccount = null);

    /// <summary>
    /// Simulate a card or other status change. Accepted include ["failed", "expired", "fraud"]. Only works in staging
    /// </summary>
    /// <param name="issueId">The transaction Id (IssueID)</param>
    /// <param name="status">Status to change to</param>
    /// <param name="subAccount">Subaccount if any</param>
    /// <returns><see cref="PaymentResponse{T}"/> where T is <see cref="PaymentVerification"/></returns>
    /// 
    Task<PaymentResponse<PaymentVerification>> Simulate(string issueId, Status status, string? subAccount = null);
    //TODO add enum for status
    #endregion

    #region Payout

    Task<Response<>> PayoutAirtime(PayoutAirtime payoutAirtime);

    #endregion
}