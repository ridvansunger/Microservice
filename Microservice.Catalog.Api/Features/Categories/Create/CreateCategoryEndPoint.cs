using MediatR;
using Microservice.Shared.Extensions;

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
            });

            //üsteki kodun kısalması
            //group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>(await mediator.Send(command)).ToGenericResult());


            return group;

        }
    }
}