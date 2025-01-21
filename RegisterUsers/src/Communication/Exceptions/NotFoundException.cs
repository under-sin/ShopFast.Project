namespace Communication.Exceptions;

public class NotFoundException(string message) : ShopFastException(message) { }
