using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;

namespace CourseLibrary.API.Services
{
    public class ComplaintDetailRepository : IComplaintDetailRepository, IDisposable
    {
        private readonly CourseLibraryContext _context;

        public ComplaintDetailRepository(CourseLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public IEnumerable<ComplaintDetail> GetComplaintDetails(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }

            return _context.ComplaintDetails
                        .Where(c => c.EmailAddress == emailAddress)
                        .OrderBy(c => c.LastModifiedDate).ToList();
        }

        public void AddComplaintDetail(ComplaintDetail complaintDetail)
        {
            if (complaintDetail == null)
            {
                throw new ArgumentNullException(nameof(complaintDetail));
            }

            // the repository fills the id (instead of using identity columns)
            complaintDetail.Id = Guid.NewGuid();

            _context.ComplaintDetails.Add(complaintDetail);
        }

        public void UpdateComplaintDetail(ComplaintDetail complaintDetail)
        {
            if (complaintDetail == null)
            {
                throw new ArgumentNullException(nameof(complaintDetail));
            }

            _context.ComplaintDetails.Update(complaintDetail);
        }

        public void DeleteComplaintDetail(ComplaintDetail complaintDetail)
        {
            if (complaintDetail == null)
            {
                throw new ArgumentNullException(nameof(complaintDetail));
            }

            _context.ComplaintDetails.Remove(complaintDetail);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ComplaintDetail GetComplaintDetail(Guid complaintId)
        {
            if (complaintId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(complaintId));
            }

            return _context.ComplaintDetails.FirstOrDefault(a => a.Id == complaintId);
        }

        public bool ComplaintExists(Guid complaintId)
        {
            if (complaintId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(complaintId));
            }

            return _context.ComplaintDetails.Any(a => a.Id == complaintId);
        }
    }
}
