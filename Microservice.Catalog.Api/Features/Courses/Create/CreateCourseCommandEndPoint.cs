using Microservice.Catalog.Api.Features.Categories.Create;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Microservice.Catalog.Api.Features.Courses.Create
{
    public static class CreateCourseCommandEndPoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoind(this RouteGroupBuilder group)
        {

            group.MapPost("/",
                     async (CreateCourseCommand command, IMediator mediator) =>
                         (await mediator.Send(command)).ToGenericResult())
                 .WithName("CreateCourse")
                 .Produces<Guid>(StatusCodes.Status201Created)
                 .Produces(StatusCodes.Status404NotFound)
                 .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                 .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                 .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return group;

        }
    }
}
