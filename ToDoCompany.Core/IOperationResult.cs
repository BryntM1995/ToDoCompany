using System;

namespace ToDoCompany.Core
{
    public interface IOperationResult
    {
        bool IsSuccess { get; set; }
        string OperationMessage { get; set; }

    }

    public class OperationResult : IOperationResult
    {
        public bool IsSuccess { get; set; }
        public string OperationMessage { get; set; }

        public OperationResult(bool isSuccess, string operationMessage = "")
        {
            IsSuccess = isSuccess;
            OperationMessage = operationMessage;
        }
        public OperationResult()
        {

        }
    }
}
