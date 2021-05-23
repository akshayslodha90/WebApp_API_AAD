using AutoMapper;
using ComplaintLoggingSystem.Helpers;
using ComplaintLoggingSystem.Models;
using ComplaintLoggingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ComplaintLoggingSystem.Controllers
{
    [Authorize]
    public class ComplaintDetailsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IComplaintDetailsSystem _complaintDetailsSystem;

        public ComplaintDetailsController(IComplaintDetailsSystem complaintDetailsSystem, IMapper mapper)
        {
            _complaintDetailsSystem = complaintDetailsSystem;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }
        // GET: ComplaintDetails
        public ActionResult Index()
        {
            var complaintDetails = _complaintDetailsSystem.GetComplaintDetails(emailId: UserToolBox.GetEmailId()).Result;
            return View(_mapper.Map<List<ComplaintDetailsDomain>>(complaintDetails));
        }

        // GET: ComplaintDetails/Details/5
        public ActionResult Details(Guid id)
        {
            var complaintDetails = _complaintDetailsSystem.GetComplaintDetail(id).Result;
            return View(_mapper.Map<ComplaintCompleteDetailDomain>(complaintDetails));
        }

        // GET: ComplaintDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplaintDetailForCreationDomain collection)
        {
            string response = string.Empty;

            if (ModelState.IsValid)
            {
                var complaintDetailData = _mapper.Map<DataModels.ComplaintDetailForCreationData>(collection);
                response = _complaintDetailsSystem.CreateComplaintDetail(complaintDetailData).Result;

            }

            return NotifyUser(response);
        }

        private ActionResult NotifyUser(string response)
        {
            if (response == Models.Response.Success.ToString())
                return RedirectToAction(nameof(Index));
            else
                this.ModelState.AddModelError(string.Empty, UserConstants.ErrorMessage);
            return View();
        }

        // GET: ComplaintDetails/Edit/5
        public ActionResult Edit(Guid id)
        {
            var complaintDetails = _complaintDetailsSystem.GetComplaintDetail(id).Result;
            return View(_mapper.Map<ComplaintDetailForUpdationDomain>(complaintDetails));
        }

        // POST: ComplaintDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ComplaintDetailForUpdationDomain collection)
        {
            string response = string.Empty;

            if (ModelState.IsValid)
            {
                var complaintDetailData = _mapper.Map<DataModels.ComplaintDetailForUpdationData>(collection);
                response = _complaintDetailsSystem.UpdateComplaintDetail(id, complaintDetailData).Result;
            }

            return NotifyUser(response);
        }

        [HttpGet]
        // GET: ComplaintDetails/Delete/5
        public ActionResult Delete(Guid id)
        {

            var complaintDetails = _complaintDetailsSystem.GetComplaintDetail(id).Result;
            return View(_mapper.Map<ComplaintCompleteDetailDomain>(complaintDetails));
        }

        // POST: ComplaintDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ComplaintCompleteDetailDomain complaintDetail)
        {
            string response = string.Empty;
            response = _complaintDetailsSystem.DeleteComplaintDetail(id).Result;

            return NotifyUser(response);
        }
    }
}