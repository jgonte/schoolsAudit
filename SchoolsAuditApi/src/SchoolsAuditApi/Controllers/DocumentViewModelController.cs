using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolsAudit.Repository;
using SchoolsAudit.ViewModels;

namespace SchoolsAudit.Controllers
{
    [Route("api/documents")]
    public class DocumentViewModelController : Controller
    {
        public IDocumentViewModelRepository Repository { get; set; }

        public DocumentViewModelController(IDocumentViewModelRepository repository)
        {
            Repository = repository;
        }

        #region Documents operations

            [HttpPost]
            public IActionResult Create(DocumentViewModel document)
            {
                if (document == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Repository.Create(document);

                return new CreatedAtRouteResult("GetDocuments", new 
                {
                    Controller = "Documents",
                    id = document.Id
                }, document);
            }

            [HttpPut]
            public IActionResult Update(DocumentViewModel document)
            {
                if (document == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!Repository.Update(document))
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

            [HttpDelete("{documentId}")]
            public IActionResult Delete(int? documentId)
            {
                if (!Repository.Delete(documentId))
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

            [HttpGet("{documentId}", Name = "GetDocument")]
            public IActionResult GetById(int? documentId)
            {
                var item = Repository.GetById(documentId);

                if (item == null)
                {
                    return NotFound();
                }

                return new ObjectResult(item);
            }

            [HttpGet]
            public IEnumerable<DocumentViewModel> GetAll()
            {
                return Repository.GetAll();
            }

        #endregion

    }
}