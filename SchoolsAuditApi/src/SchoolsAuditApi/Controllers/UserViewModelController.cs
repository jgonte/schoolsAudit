using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolsAudit.Repository;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Controllers
{
    [Route("api/users")]
    public class UserViewModelController : Controller
    {
        public IUserViewModelRepository Repository { get; set; }

        public UserViewModelController(IUserViewModelRepository repository)
        {
            Repository = repository;
        }

        #region Users operations

        #endregion

        #region Schools operations

        #endregion

        #region Documents operations

            [HttpPost("{userId}")]
            public IActionResult AddDocument(int? userId, DocumentViewModel document)
            {
                if (document == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!Repository.AddDocument(userId, document))
                {
                    return NotFound();
                }

                return new CreatedAtRouteResult("AddDocument", new 
                {
                    Controller = "Documents",
                    id = document.Id
                }, document);
            }

            [HttpDelete("{userId}")]
            public IActionResult RemoveDocument(int? userId, int? documentId)
            {
                if (!Repository.RemoveDocument(userId, documentId))
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

        #endregion

    }
}