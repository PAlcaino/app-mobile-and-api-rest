using api_rest_debts.Models;
using apirestdebs.dataccess;
using apirestdebs.dataccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest_debts
{
    public static class DebtsFunctions
    {
        [FunctionName(nameof(GetDebtsAsync))]
        public static async Task<IActionResult> GetDebtsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/debts")] HttpRequest req,
            ILogger log)
        {
            var storageHelper = new StorageHelper("connectionString");

            var debts = await storageHelper.GetItemsAsync();

            if (debts is null || !debts.Any())
                return new NotFoundObjectResult(new ServiceResponse(
                    new Error("NotFound", "No se encontraron entidades.")));

            var json = JsonConvert.SerializeObject(debts);
            var debtsJsons = JsonConvert.DeserializeObject<IEnumerable<DebtEntity>>(json);

            return new OkObjectResult(new ServiceResponse<IEnumerable<DebtEntity>>(debts));
        }

        [FunctionName(nameof(GetDebtsByIdAsync))]
        public static async Task<IActionResult> GetDebtsByIdAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/debts/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            bool isValidId = Guid.TryParse(id, out Guid idResult);

            if (!isValidId)
                return new BadRequestObjectResult(new ServiceResponse(
                    new Error("BadParamError", $"El Parámetro Id es inválido.")));

            var storageHelper = new StorageHelper("connectionString");

            var debt = await storageHelper.GetItemByIdAsync(idResult);

            if (debt is null)
                return new NotFoundObjectResult(new ServiceResponse(
                    new Error("NotFound", $"El objeto de tipo {nameof(DebtEntity)} " +
                    $"no fue encontrado con el id: '{id}'")));

            return new OkObjectResult(new ServiceResponse<DebtEntity>(debt));
        }

        [FunctionName(nameof(CreateDebtAsync))]
        public static async Task<IActionResult> CreateDebtAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/debts")] HttpRequest req, ILogger log)
        {
            var json = await req.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json))
                return new BadRequestObjectResult(new ServiceResponse
                {
                    Error = new Error("EmptyBody", "The Body is empty"),
                    Success = false
                });

            var entity = JsonConvert.DeserializeObject<DebtEntity>(json);
            if (entity.Amount <= 0)
                return new BadRequestObjectResult(new ServiceResponse
                {
                    Error = new Error("ZeroAmount", $"The property {nameof(DebtEntity.Amount)} of the debt cant less than zero"),
                    Success = false
                });
            else if (entity.UserId == Guid.Empty)
                return new BadRequestObjectResult(new ServiceResponse
                {
                    Error = new Error("EmptyIdUser", "The Body is empty"),
                    Success = false
                });


            var storageHelper = new StorageHelper("connectionString");
            bool wasCreated = await storageHelper.CreateDebtAsync(entity);
            if (!wasCreated)
                return new BadRequestObjectResult(new ServiceResponse
                {
                    Error = new Error($"{nameof(DebtEntity)}NotCreated", "The entity wasnt created."),
                    Success = false
                });

            return new OkObjectResult(new ServiceResponse
            {
                Success = true,
                Message = "The Debt was created succesfully!. :D"
            });
        }
    }
}
