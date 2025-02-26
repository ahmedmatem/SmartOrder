using Microsoft.AspNetCore.Mvc;
using SmartOrder.Data.Models;
using SmartOrder.Services.Data;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.Infrastructure.Extensions;

namespace SmartOrder.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }
            return true;
        }
    }
}
