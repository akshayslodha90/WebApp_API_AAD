using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/complaintDetails")]
    [Produces("application/json")]
    public class ComplaintDetailsController : ControllerBase
    {
        private readonly IComplaintDetailRepository _complaintDetailRepository;
        private readonly IMapper _mapper;

        public ComplaintDetailsController(IComplaintDetailRepository complaintDetailRepository,
            IMapper mapper)
        {
            _complaintDetailRepository = complaintDetailRepository ??
                throw new ArgumentNullException(nameof(complaintDetailRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// GetComplaintDetails
        /// </summary>
        /// <remarks>Use this endpoints to get compliant details for the login user. Ideally UI team to get email from claims</remarks>
        /// <param name="emailId">email address</param>
        /// <returns>List of Complaint Details</returns>
        [HttpGet("{emailId}")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ComplaintDetailDto>> GetComplaintDetails(
            [FromRoute] string emailId)
        {
            var complaintDetailsFromRepo = _complaintDetailRepository.GetComplaintDetails(emailId);
            return Ok(_mapper.Map<IEnumerable<ComplaintDetailDto>>(complaintDetailsFromRepo));
        }

        /// <summary>
        /// GetComplaintDetail
        /// </summary>
        /// <remarks>Use this endpoints to get compliant detail for the unique identifier. Unique Identifier can be get from GetComplaintDetails operation</remarks>
        /// <param name="complaintId">Unique Identifier of Compliant</param>
        /// <returns>Detail of Complaint base on unique identifier</returns>
        [HttpGet("{complaintId}/ComplaintDetail", Name = "GetComplaintDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ComplaintCompleteDetailDto> GetComplaintDetail(Guid complaintId)
        {
            var complaintDetailFromRepo = _complaintDetailRepository.GetComplaintDetail(complaintId);

            if (complaintDetailFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ComplaintCompleteDetailDto>(complaintDetailFromRepo));
        }

        /// <summary>
        /// CreateComplaintDetail
        /// </summary>
        /// <remarks>Use this endpoints to create compliant details</remarks>
        /// <param name="complaintdetail">Details of Compliant Object</param>
        /// <returns>Success on creation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ComplaintDetailDto> CreateComplaintDetail(ComplaintDetailForCreationDto complaintdetail)
        {
            var complaintDetailEntity = _mapper.Map<Entities.ComplaintDetail>(complaintdetail);
            _complaintDetailRepository.AddComplaintDetail(complaintDetailEntity);
            _complaintDetailRepository.Save();

            var complaintDetailToReturn = _mapper.Map<ComplaintDetailDto>(complaintDetailEntity);
            return CreatedAtRoute("GetComplaintDetail",
                new { complaintId = complaintDetailToReturn.Id },
                complaintDetailToReturn);
        }

        /// <summary>
        /// UpdateComplaintDetail
        /// </summary>
        /// <remarks>Use this endpoint to update compliant details</remarks>
        /// <param name="complaintId">Unique Identifier of Compliant</param>
        /// <param name="complaintDetail">Updated Compliant Detail Object</param>
        /// <returns>Success on update</returns>
        [HttpPut("{complaintId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateComplaintDetail(Guid complaintId,
            ComplaintDetailForUpdateDto complaintDetail)
        {
            if (!_complaintDetailRepository.ComplaintExists(complaintId))
            {
                return NotFound();
            }
            var complaintDetailFromRepo = _complaintDetailRepository.GetComplaintDetail(complaintId);
            _mapper.Map(complaintDetail, complaintDetailFromRepo);

            _complaintDetailRepository.UpdateComplaintDetail(complaintDetailFromRepo);

            _complaintDetailRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// DeleteComplaintDetail
        /// </summary>
        /// <remarks>Use this endpoint to delete the compliant</remarks>
        /// <param name="complaintId">Unique Identifier of Compliant</param>
        /// <returns>Sucess on deletion</returns>
        [HttpDelete("{complaintId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteComplaintDetail(Guid complaintId)
        {
            var complaintDetailFromRepo = _complaintDetailRepository.GetComplaintDetail(complaintId);

            if (complaintDetailFromRepo == null)
            {
                return NotFound();
            }

            _complaintDetailRepository.DeleteComplaintDetail(complaintDetailFromRepo);

            _complaintDetailRepository.Save();

            return NoContent();
        }
    }
}