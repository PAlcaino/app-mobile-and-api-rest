using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using apirestdebs.dataccess;
using apirestdebs.dataccess.Entities;
using System.Linq;
using api_rest_debts.Models;
using System.Collections.Generic;

namespace api_rest_debts
{
    public static class DebtsFunctions
    {
        [FunctionName(nameof(GetDebts))]
        public static async Task<IActionResult> GetDebts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/debts")] HttpRequest req,
            ILogger log)
        {
            var storageHelper = new StorageHelper("connectionString");

            var debts = await storageHelper.GetItemsAsync();

            if (debts is null || !debts.Any())
                return new NotFoundObjectResult(new ServiceResponse(
                    new Error("NotFound", "No se encontraron entidades.")));

            return new OkObjectResult(new ServiceResponse<IEnumerable<DebtEntity>>(debts));
        }

        [FunctionName(nameof(GetDebtsById))]
        public static async Task<IActionResult> GetDebtsById(
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
                    new Error("NotFound",$"El objeto de tipo {nameof(DebtEntity)} " +
                    $"no fue encontrado con el id: '{id}'")));

            return new OkObjectResult(new ServiceResponse<DebtEntity>(debt));
        }
    }
}
