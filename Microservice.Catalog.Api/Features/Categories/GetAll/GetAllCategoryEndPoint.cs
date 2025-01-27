using AutoMapper;
using MediatR;
using Microservice.Catalog.Api.Features.Categories.Dtos;
using Microservice.Catalog.Api.Repositories;
using Microservice.Shared;
using Microservice.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;
   
    public class GetAllCategoryQueryHandler (AppDbContext context,IMapper mapper): IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
      
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken);
            var categoryDtos = mapper.Map<List<CategoryDto>>(categories);
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
