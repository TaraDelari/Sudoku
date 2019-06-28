using System.Collections.Generic;

namespace SudokuService.Models
{
    public class Result
    {
        string _error;
        public bool IsSuccess { get; set; }
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                if (value != null)
                {
                    IsSuccess = false;
                    _error = value;
                }

            }
        }

        public Result()
        {
            IsSuccess = true;
        }

    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}