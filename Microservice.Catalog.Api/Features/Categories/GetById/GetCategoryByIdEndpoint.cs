namespace Microservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;


    public class GetCategoryByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (hasCategory is null)
            {
                return ServiceResult<CategoryDto>.Error("Category not found", $"The category with id {request.Id} was not found", System.Net.HttpStatusCode.NotFound);
            }

            var categoryDto = mapper.Map<CategoryDto>(hasCategory);
            return (ServiceResult<CategoryDto>)ServiceResult<CategoryDto>.SuccessAsOk(categoryDto);
        }
    }



    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoind(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator,Guid id) =>
                        (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult());
            return group;

        }

    }
}
