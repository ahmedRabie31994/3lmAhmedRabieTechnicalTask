using AhmedRabieTechnicalTask.Domain.Core.Enums;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Models
{
    public class ExecutionResponse<T>
    {
        public ExecutionResponse()
        {

        }
        public ExecutionResponse(string lang = "ar")
        {
            this.Lang = lang;
            this.Message = lang == "ar" ? "تم بنجاح" : "Done Successfully";
        }
        ResponsState _state;
        string Lang;
        public virtual ResponsState State
        {
            get { return _state; }
            set
            {
                _state = value;
                if (_state != ResponsState.Success && string.IsNullOrEmpty(this.Message))
                {
                    this.Message = this.Lang == "ar" ? " حدث  خطأ" : "Error has occurred";
                }
            }
        }
        #region props.
        public T Result { get; set; }
        public virtual List<MetaPair> DetailedMessages { get; set; }
        public virtual string MessageCode { get; set; }
        public virtual string Message { get; set; } = "تم بنجاح";
        Exception _exception;

        public virtual Exception Exception
        {
            get
            {

                return _exception;
            }
            set
            {
                _exception = value;
                //To Do Very Important
                //if (this.Message == "تم بنجاح" && _exception != null)
                //{
                //    this.Message = this.Lang == "ar" ? "  حدث  خطأ فى الخادم" : "Exception has occurred";

                //    var context = new GlamourContext();
                //    var dbSet = context.Set<ExceptionLog>();
                //    ExceptionLog entity = new ExceptionLog()
                //    {
                //        Message = _exception.Message,
                //        StackTrace = _exception.StackTrace,
                //        AddedDate = DateTime.Now
                //    };
                //    dbSet.Add(entity);
                //    context.SaveChanges();
            }

        }
        public ValidationResult ValidationResult { get; set; }

    }
    #endregion

}