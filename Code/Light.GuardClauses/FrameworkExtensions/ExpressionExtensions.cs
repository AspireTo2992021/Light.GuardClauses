﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Light.GuardClauses.FrameworkExtensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="Expression" /> instances.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        ///     Extracts the <see cref="PropertyInfo" /> from a expression of the shape "object => object.Property".
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression where the property info will be extracted from.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="expression" /> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     Throw when the <paramref name="expression" /> is not of the shape "object => object.Property".
        /// </exception>
        public static PropertyInfo ExtractProperty<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            expression.MustNotBeNull(nameof(expression));

            var memberExpression = expression.Body as MemberExpression;
            if (!(memberExpression?.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("The specified expression is not valid. Please use an expression like the following one: o => o.Property", nameof(expression));

            return propertyInfo;
        }
    }
}