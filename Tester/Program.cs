using System;
using Haukcode.TaxifyDotNet;
using Haukcode.TaxifyDotNet.Models;

namespace Haukcode.Tester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new TaxifyClient("<<ENTER API KEY HERE>>");

            var result = client.VerifyAddressAsync(
                street1: "10531 4S Commons Dr.",
                street2: "Suite 556",
                city: "San Diego",
                region: "CA",
                postalCode: "92127").Result;

            var response = client.GetCodesAsync(CodeTypes.Customer).Result;
            response = client.GetCodesAsync(CodeTypes.Item).Result;

            var calcResult = client.CalculateTaxAsync(
                    documentKey: "TEST-456",
                    destinationAddress: new Address
                    {
                        City = "Orlando",
                        Region = "FL",
                        Country = "US",
                        PostalCode = "32811",
                        Street1 = "4305 Vineland Road"
                    },
                    lines: new TaxLineDetail[]
                    {
                        new TaxLineDetail
                        {
                            ActualExtendedPrice = 100
                        }
                    }
                ).Result;

            client.CommitOrderAsync(documentKey: calcResult.DocumentKey).Wait();
            client.DeleteOrderAsync(documentKey: calcResult.DocumentKey).Wait();

            var storeResult = client.StoreOrderAsync(
                    documentKey: "TEST-123",
                    destinationAddress: new Address
                    {
                        City = "Orlando",
                        Region = "FL",
                        Country = "US",
                        PostalCode = "32811",
                        Street1 = "4305 Vineland Road"
                    },
                    lines: new TaxLineDetail[]
                    {
                        new TaxLineDetail
                        {
                            ActualExtendedPrice = 200
                        }
                    }
                ).Result;

            client.DeleteOrderAsync(documentKey: "TEST-123").Wait();
        }
    }
}
