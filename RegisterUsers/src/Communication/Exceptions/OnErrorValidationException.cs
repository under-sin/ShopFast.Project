using System;

namespace Communication.Exceptions;

public class OnErrorValidationException : RegisterUserException {
    public IList<string> ErrorMessages { get; private set; }
    public OnErrorValidationException(IList<string> errorMessages) : base(string.Empty)
        => ErrorMessages = errorMessages;
}
