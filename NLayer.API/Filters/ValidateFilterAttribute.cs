using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) // hata var mı yok mu kontrol- true geliyorsa hata yok false geliyorsa hata var
            {
            
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();//hataları aldık
                context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));


            }
        }

    }
}
