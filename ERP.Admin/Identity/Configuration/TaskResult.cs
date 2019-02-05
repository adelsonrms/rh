using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Presentation.Api.Identity.LoginManager
{
    public class TaskResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<int, Exception> Errors { get; set; }
        public dynamic Data { get; set; }
        public void SetResultInfo(bool success, string info, object data)
        {
            Success = success;
            Message = info;
            Data = data;
        }
        public void AddError(Exception ex)
        {
            this.Errors = this.Errors ?? new Dictionary<int, Exception>();
            this.Errors.Add(this.Errors.Count, ex);
        }

        internal static TaskResult Create() => new TaskResult();
    }
}