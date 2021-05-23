using ComplaintLoggingSystem.DataModels;
using ComplaintLoggingSystem.Helpers;
using ComplaintLoggingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Services
{

    public static class TodoListServiceExtensions
    {
        public static void AddTodoListService(this IServiceCollection services, IConfiguration configuration)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            services.AddHttpClient<IComplaintDetailsSystem, ComplaintDetailsSystem>();
        }
    }

    public class ComplaintDetailsSystem : ServiceAgent, IComplaintDetailsSystem
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient _httpClient;
        private readonly string _TodoListScope = string.Empty;
        private readonly string _TodoListBaseAddress = string.Empty;
        private readonly ITokenAcquisition _tokenAcquisition;

        public ComplaintDetailsSystem(ITokenAcquisition tokenAcquisition, IConfiguration configuration, IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory) : base(httpClientFactory, tokenAcquisition, configuration, UserConstants.CORELIBRARYHTTPCLIENT)
        {
            // this._httpClient = httpClient;
            this._tokenAcquisition = tokenAcquisition;
            this._contextAccessor = contextAccessor;
            this._TodoListScope = configuration["TodoList:TodoListScope"];
            this._TodoListBaseAddress = configuration["TodoList:TodoListBaseAddress"];
        }

        public async Task<string> CreateComplaintDetail(ComplaintDetailForCreationData complaintDetailForCreationData)
        {
            try
            {
                var complaintDetailsUrl = $"complaintDetails";
                await PostData<string>(complaintDetailsUrl, complaintDetailForCreationData);
                return Response.Success.ToString();
            }
            catch
            {
                return Response.Failure.ToString();
            }
        }

        public async Task<string> DeleteComplaintDetail(Guid complaintId)
        {
            try
            {
                var complaintDetailsUrl = $"complaintDetails/{complaintId}";
                await DeleteData<string>(complaintDetailsUrl);
                return Response.Success.ToString();
            }
            catch
            {
                return Response.Failure.ToString();
            }

        }

        public async Task<ComplaintCompleteDetailData> GetComplaintDetail(Guid id)
        {
            var complaintDetailsUrl = $"complaintDetails/{id}/ComplaintDetail";
            var response = await GetData<ComplaintCompleteDetailData>(complaintDetailsUrl);
            return response;
        }

        public async Task<List<ComplaintDetailsData>> GetComplaintDetails(string emailId)
        {

            var complaintDetailsUrl = $"complaintDetails/{emailId}";
            var response = await GetData<List<ComplaintDetailsData>>(complaintDetailsUrl);
            return response;
        }




        public async Task<string> UpdateComplaintDetail(Guid complaintId, ComplaintDetailForUpdationData complaintDetailForCreationData)
        {
            try
            {
                var complaintDetailsUrl = $"complaintDetails/{complaintId}";
                await PutData<string>(complaintDetailsUrl, complaintDetailForCreationData);
                return Response.Success.ToString();
            }
            catch
            {
                return Response.Failure.ToString();
            }
        }


    }
}
