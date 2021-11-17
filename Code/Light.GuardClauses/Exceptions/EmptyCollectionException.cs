﻿using System;
using System.Runtime.Serialization;

namespace Light.GuardClauses.Exceptions;

/// <summary>
/// This exception indicates that a collection has no items.
/// </summary>
[Serializable]
public class EmptyCollectionException : InvalidCollectionCountException
{
    /// <summary>
    /// Creates a new instance of <see cref="EmptyCollectionException" />.
    /// </summary>
    /// <param name="parameterName">The name of the parameter (optional).</param>
    /// <param name="message">The message of the exception (optional).</param>
    public EmptyCollectionException(string? parameterName = null, string? message = null) : base(parameterName, message) { }

    /// <inheritdoc />
    protected EmptyCollectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}