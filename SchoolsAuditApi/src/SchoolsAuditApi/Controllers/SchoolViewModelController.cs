using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolsAudit.Repository;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Controllers
{
    [Route("api/schools")]
    public class SchoolViewModelController : Controller
    {
        public ISchoolViewModelRepository Repository { get; set; }

        public SchoolViewModelController(ISchoolViewModelRepository repository)
        {
            Repository = repository;
        }

        #region Schools operations

            [HttpPost]
            public IActionResult Create(SchoolViewModel school)
            {
                if (school == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Repository.Create(school);

                return new CreatedAtRouteResult("GetSchools", new 
                {
                    Controller = "Schools",
                    id = school.Id
                }, school);
            }

            [HttpPut]
            public IActionResult Update(SchoolViewModel school)
            {
                if (school == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!Repository.Update(school))
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

            [HttpDelete("{schoolId}")]
            public IActionResult Delete(int? schoolId)
            {
                if (!Repository.Delete(schoolId))
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

            [HttpGet("{schoolId}", Name = "GetSchool")]
            public IActionResult GetById(int? schoolId)
            {
                var item = Repository.GetById(schoolId);

                if (item == null)
                {
                    return NotFound();
                }

                return new ObjectResult(item);
            }

            [HttpGet]
            public IEnumerable<SchoolViewModel> GetAll()
            {
                return Repository.GetAll();
            }

        #endregion

    }
}