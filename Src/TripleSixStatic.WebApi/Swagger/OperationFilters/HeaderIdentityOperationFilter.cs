using TripleSix.Static.Common;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TripleSix.Core.WebApi.Swagger;

namespace TripleSix.Static.WebApi.Swagger
{
    public class HeaderIdentityOperationFilter : HeaderIdentityOperationFilter<Identity>
    {
        public override void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            base.Apply(operation, context);

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    In = ParameterLocation.Header,
            //    Name = nameof(Identity.ClientId).ToKebabCase(),
            //    Description = "mã định danh phiên truy cập",
            //    Schema = new OpenApiSchema
            //    {
            //        Type = "string",
            //        Nullable = true,
            //    },
            //});
        }
    }
}
