using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Catalog.Api.Features.Courses.GetAll;
using Microservice.Catalog.Api.Features.Courses.GetById;

namespace Microservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCaourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("/api/courses").WithTags("Courses")
                    .CreateCourseGroupItemEndpoind()
                    .GetAllCourseGroupItemEndpoind()
                    .GetByIdCourseGroupItemEndpoind();

        }
    }
}
