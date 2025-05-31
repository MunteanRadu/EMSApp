﻿namespace EMSApp.Domain.Exceptions;

/// <summary>
/// Throw when a domain invariant is violated.
/// </summary>
public class DomainException : Exception
{
    public DomainException() { }

    public DomainException(string message) : base(message) { }

    public DomainException(string message, Exception innerException) : base(message, innerException) { }
}
