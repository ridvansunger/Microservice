using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndPoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoind(this RouteGroupBuilder group)
        {
            //https://localhost:5001/api/categories
            group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);


                return result.ToGenericResult();
            }).AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            //üsteki kodun kısalması
            //group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
            //            (await mediator.Send(command)).ToGenericResult())
            //    .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();


            return group;

        }
    }
}