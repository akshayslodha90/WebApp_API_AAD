using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/complaintDetails")]
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

        [HttpGet("{emailId}")]
        public ActionResult<IEnumerable<ComplaintDetailDto>> GetComplaintDetails(
            [FromRoute] string emailId)
        {
            var complaintDetailsFromRepo = _complaintDetailRepository.GetComplaintDetails(emailId);
            return Ok(_mapper.Map<IEnumerable<ComplaintDetailDto>>(complaintDetailsFromRepo));
        }

        [HttpGet("{complaintId}/ComplaintDetail", Name = "GetComplaintDetail")]
        public IActionResult GetComplaintDetail(Guid complaintId)
        {
            var complaintDetailFromRepo = _complaintDetailRepository.GetComplaintDetail(complaintId);

            if (complaintDetailFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ComplaintCompleteDetailDto>(complaintDetailFromRepo));
        }

        [HttpPost]
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

        [HttpPut("{complaintId}")]
        public IActionResult UpdateComplaintDetail(Guid complaintId,
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

        [HttpDelete("{complaintId}")]
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