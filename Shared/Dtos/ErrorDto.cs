using System.Collections.Generic;

namespace Shared.Dtos
{
    public class ErrorDto
    {
        public List<string> Error { get; set; }

        public bool IsShow { get; set; }

        public ErrorDto()
        {
            Error = new List<string>();
        }

        public ErrorDto(List<string> errors, bool ısShow)
        {
            Error = errors;
            IsShow = ısShow;
        }

        public ErrorDto(string error, bool ısShow)
        {
            Error.Add(error);
            IsShow = ısShow;
        }

    }
}
