using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using Error = ErrorOr.Error;

namespace RentalManagement.Api.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    public class ApiController : ControllerBase
    {
        [NonAction]
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0) return Problem();

            return errors.All(error => error.Type == ErrorType.Validation)
                ? GetValidationProblem(errors)
                : GetProblem(errors[0]);
        }

        private IActionResult GetProblem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status403Forbidden,
                _ => Enum.IsDefined(typeof(HttpStatusCode), (int)error.Type)
                    ? (int)error.Type
                    : StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Code);
        }

        private IActionResult GetValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors) modelStateDictionary.AddModelError(error.Code, error.Description);

            return ValidationProblem(modelStateDictionary);
        }
    }
}
