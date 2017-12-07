using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Haukcode.TaxifyDotNet
{
    public class TaxifyClient : IDisposable
    {
        private bool disposedValue = false;
        private readonly string apiKey;
        private HttpClient httpClient;
        private const string BaseUrl = "https://ws.taxify.co/taxify/1.1/core/JSONService.asmx/";

        public TaxifyClient(string apiKey)
        {
            this.apiKey = apiKey;
            var handler = new HttpClientHandler();
            {
            };

            this.httpClient = new HttpClient(handler);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.httpClient?.Dispose();
                    this.httpClient = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private Models.Security GetSecurity()
        {
            return new Models.Security
            {
                Password = this.apiKey
            };
        }

        private async Task<TResponse> PostRequest<TRequest, TResponse>(string requestName, TRequest request) where TResponse : Messages.BaseResponse
        {
            string postContent = JsonConvert.SerializeObject(request);

            var result = await this.httpClient.PostAsync($"{BaseUrl}{requestName}", new StringContent(postContent, Encoding.UTF8, "application/json"));

            result.EnsureSuccessStatusCode();

            var responseContent = await result.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<Messages.ResponseRoot<TResponse>>(responseContent).d;

            if (responseObject.Errors?.Length > 0)
            {
                var errors = responseObject.Errors;
                if (errors.Any(x => x.IsWarning == false))
                    throw new TaxifyException(errors);
            }

            return responseObject;
        }

        public async Task<Models.VerifyAddress> VerifyAddressAsync(
            string street1,
            string street2,
            string city,
            string region,
            string postalCode,
            string country = "US")
        {
            var request = new Messages.VerifyAddressRoot
            {
                Request = new Messages.VerifyAddressRequest
                {
                    Security = new Models.Security
                    {
                        Password = this.apiKey
                    },
                    City = city,
                    Country = country,
                    PostalCode = postalCode,
                    Region = region,
                    Street1 = street1,
                    Street2 = street2
                }
            };

            var responseContent = await PostRequest<Messages.VerifyAddressRoot, Messages.VerifyAddressResponse>("VerifyAddress", request);

            return responseContent.Address;
        }

        public async Task<string[]> GetCodesAsync(CodeTypes codeType)
        {
            var request = new Messages.GetCodesRoot
            {
                Request = new Messages.GetCodesRequest
                {
                    Security = GetSecurity(),
                    CodeType = codeType
                }
            };

            var responseContent = await PostRequest<Messages.GetCodesRoot, Messages.GetCodesResponse>("GetCodes", request);

            return responseContent.Codes;
        }

        public async Task<Messages.CalculateTaxResponse> CalculateTaxAsync(
            Models.TaxLineDetail[] lines,
            Models.Address destinationAddress,
            Models.Address originAddress = null,
            string documentKey = null,
            string customerTaxabilityCode = null,
            string customerRegistrationNumber = null,
            DateTime? taxDate = null,
            string[] tags = null,
            Models.Discount[] discounts = null,
            Models.TaxRequestOption[] options = null,
            decimal? overrideTaxCollectedAmount = null)
        {
            var request = new Messages.CalculateTaxRoot
            {
                Request = new Messages.CalculateTaxRequest
                {
                    Security = new Models.Security
                    {
                        Password = this.apiKey
                    },
                    DestinationAddress = destinationAddress,
                    Lines = lines,
                    OriginAddress = originAddress,
                    DocumentKey = documentKey,
                    CustomerTaxabilityCode = customerTaxabilityCode,
                    CustomerRegistrationNumber = customerRegistrationNumber,
                    TaxDate = taxDate,
                    Tags = tags,
                    Discounts = discounts,
                    Options = options,
                    IsCommitted = false,
                    OverrideTaxCollectedAmount = overrideTaxCollectedAmount
                }
            };

            var responseContent = await PostRequest<Messages.CalculateTaxRoot, Messages.CalculateTaxResponse>("CalculateTax", request);

            return responseContent;
        }

        public async Task<Messages.CalculateTaxResponse> StoreOrderAsync(
            string documentKey,
            Models.TaxLineDetail[] lines,
            Models.Address destinationAddress,
            Models.Address originAddress = null,
            string customerTaxabilityCode = null,
            string customerRegistrationNumber = null,
            DateTime? taxDate = null,
            string[] tags = null,
            Models.Discount[] discounts = null,
            Models.TaxRequestOption[] options = null,
            decimal? overrideTaxCollectedAmount = null)
        {
            var request = new Messages.CalculateTaxRoot
            {
                Request = new Messages.CalculateTaxRequest
                {
                    Security = new Models.Security
                    {
                        Password = this.apiKey
                    },
                    DestinationAddress = destinationAddress,
                    Lines = lines,
                    OriginAddress = originAddress,
                    DocumentKey = documentKey,
                    CustomerTaxabilityCode = customerTaxabilityCode,
                    CustomerRegistrationNumber = customerRegistrationNumber,
                    TaxDate = taxDate,
                    Tags = tags,
                    Discounts = discounts,
                    Options = options,
                    IsCommitted = true,
                    OverrideTaxCollectedAmount = overrideTaxCollectedAmount
                }
            };

            var responseContent = await PostRequest<Messages.CalculateTaxRoot, Messages.CalculateTaxResponse>("CalculateTax", request);

            return responseContent;
        }

        public async Task DeleteOrderAsync(string documentKey)
        {
            var request = new Messages.CancelTaxRoot
            {
                Request = new Messages.CancelTaxRequest
                {
                    Security = new Models.Security
                    {
                        Password = this.apiKey
                    },
                    DocumentKey = documentKey
                }
            };

            await PostRequest<Messages.CancelTaxRoot, Messages.CancelTaxResponse>("CancelTax", request);
        }

        public async Task CommitOrderAsync(string documentKey, string commitedDocumentKey = null)
        {
            var request = new Messages.CommitTaxRoot
            {
                Request = new Messages.CommitTaxRequest
                {
                    Security = new Models.Security
                    {
                        Password = this.apiKey
                    },
                    DocumentKey = documentKey,
                    CommitedDocumentKey = commitedDocumentKey
                }
            };

            await PostRequest<Messages.CommitTaxRoot, Messages.CommitTaxResponse>("CommitTax", request);
        }
    }
}
