﻿using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Catalog.Api.Features.Courses.Dtos;
using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Courses.GetAll
{

    public record GetAllCoursesQuery() : IRequestByServiceResult<List<CourseDto>>;

    public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken);

            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }


            var courseDtos = mapper.Map<List<CourseDto>>(courses);
            return (ServiceResult<List<CourseDto>>)ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);

        }
    }


    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoind(this RouteGroupBuilder group)
        {

            group.MapGet("/",
                     async (IMediator mediator) =>
                         (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                 .WithName("GetAllCourses");

            return group;

        }

    }
}
