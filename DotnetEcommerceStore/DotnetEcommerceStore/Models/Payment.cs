using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using DotnetEcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    
    public class Payment
    {
        private IConfiguration Configuration { get; set; }

        public Payment(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Run()
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = Configuration["AuthorizeNetName"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = Configuration["AuthorizeNetTransKey"]
            };

            creditCardType creditCard = new creditCardType
            {
                cardNumber = Configuration["CreditCardNumber"],
                expirationDate = Configuration["ExpirationDate"]
            };

            customerAddressType billingAddress = GetAddress();

            paymentType paymentType = new paymentType { Item = creditCard };

            transactionRequestType transReqType = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 123.45m,
                payment = paymentType,
                billTo = billingAddress
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transReqType
            };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if (response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    //out transaction was successful.
                    return "OK";
                }
                else
                {
                    // it was not successful
                }
            }

            return "Not OK";
        }

        


        customerAddressType GetAddress()
        {
            customerAddressType address = new customerAddressType()
            {
                firstName = "John",
                lastName = "Doe",
                address = "123 6ft Deep Lane",
                city = "Hellsgate",
                zip = "91206"
            };

            return address;
        }

        private lineItemType[] GetLineItems(List<CheckoutItems> products)
        {
            lineItemType[] items = new lineItemType[products.Count];

            int count = 0;
            foreach (var item in items)
            {
                items[count] = new lineItemType
                {
                    itemId = "1",
                    name = "Name of item",
                    quantity = 2,
                    unitPrice = 3.25m
                };
            }

            return items;
        }
    }
    
}
