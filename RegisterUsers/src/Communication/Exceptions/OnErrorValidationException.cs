namespace Communication.Exceptions;

public class OnErrorValidationException : ShopFastException {
    public IList<string> ErrorMessages { get; private set; }
    public OnErrorValidationException(IList<string> errorMessages) : base(string.Empty)
        => ErrorMessages = errorMessages;
}
