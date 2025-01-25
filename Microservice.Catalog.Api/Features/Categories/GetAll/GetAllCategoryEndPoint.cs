using MediatR;
using Microservice.Catalog.Api.Features.Categories.Create;
using Microservice.Catalog.Api.Features.Categories.Dtos;
using Microservice.Catalog.Api.Repositories;
using Microservice.Shared;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;
   
    public class GetAllCategoryQueryHandler (AppDbContext context): IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
      
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync();
            var categoryDtos = categories.Select(x => new CategoryDto(x.Id, x.Name)).ToList();
            return (ServiceResult<List<CategoryDto>>)ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);
        }
    }


    public static class GetAllCategoryEndPoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoind(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ( IMediator mediator) =>
                        (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());
            return group;

        }
    }
}
