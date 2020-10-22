using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetworthDomain.Enums
{
    /// <summary>
    /// The base type for creating an <see cref="AbstractEnumeration"/>
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// public class PaymentType : AbstractEnumeration
    /// {
    ///     public static readonly PaymentType DebitCard = new PaymentType(0);
    ///     public static readonly PaymentType CreditCard = new PaymentType(1);
    ///     private PaymentType(int value, [CallerMemberName] string name = null) : base(value, name)
    ///     {
    ///     }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public abstract class AbstractEnumeration : IComparable
    {
        /// <summary>
        /// Gets the <see cref="string"/> Enumeration name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="int"/> Enumeration value.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Creates instance of type <see cref="AbstractEnumeration" />.
        /// </summary>
        /// <remarks>
        /// This constructor should not be called from the derived class.
        /// It is helpful in doing JSON Serialization or mapping through automapper.
        /// </remarks>
        protected AbstractEnumeration()
        {
        }

        /// <summary>
        /// Creates instance of type <see cref="AbstractEnumeration" />.
        /// </summary>
        /// <param name="value">The Enumeration value.</param>
        /// <param name="name">The Enumeration name.</param>
        protected AbstractEnumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }


        ///<inheritdoc/>
        public override string ToString() => Name;

        /// <summary>
        /// Gets all the instances of <typeparamref name="TEnumeration"/>.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="AbstractEnumeration"/>.</typeparam>
        /// <returns>The list of <typeparamref name="TEnumeration"/></returns>
        public static IEnumerable<TEnumeration> GetAll<TEnumeration>() where TEnumeration : AbstractEnumeration
        {
            var fields = typeof(TEnumeration).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<TEnumeration>();
        }

        ///<inheritdoc />
        public override bool Equals(object obj)
        {
            if (!(obj is AbstractEnumeration otherValue))
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        ///<inheritdoc />
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Gets the instance of <typeparamref name="TEnumeration"/> from value or name.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="AbstractEnumeration"/>.</typeparam>
        /// <param name="valueOrName">The <typeparamref name="TEnumeration"/> value or name.</param>
        /// <param name="enumeration">The <typeparamref name="TEnumeration"/> instance.</param>
        /// <returns>
        /// <c>true</c> if the instance <see cref="AbstractEnumeration"/> contains <typeparamref name="TEnumeration"/> with the specified name;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryGetFromValueOrName<TEnumeration>(string valueOrName, out TEnumeration enumeration)
            where TEnumeration : AbstractEnumeration
        {
            return TryParse(item => item.Name == valueOrName, out enumeration) ||
                   int.TryParse(valueOrName, out var value) &&
                   TryParse(item => item.Value == value, out enumeration);
        }

        /// <summary>
        /// Gets the instance of <typeparamref name="TEnumeration"/> from value.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="AbstractEnumeration"/>.</typeparam>
        /// <returns>The <typeparamref name="TEnumeration"/> instance.</returns>
        /// <exception cref="InvalidOperationException">"<paramref name="value"/> is not valid"</exception> 
        public static TEnumeration FromValue<TEnumeration>(int value) where TEnumeration : AbstractEnumeration
        {
            var matchingItem = Parse<TEnumeration, int>(value, "nameOrValue", item => item.Value == value);
            return matchingItem;
        }

        /// <summary>
        /// Gets the instance of <typeparamref name="TEnumeration"/> from name.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="AbstractEnumeration"/>.</typeparam>
        /// <param name="name"></param>
        /// <returns>The <typeparamref name="TEnumeration"/> instance.</returns>
        /// <exception cref="InvalidOperationException">"<paramref name="name"/> is not valid"</exception> 
        public static TEnumeration FromName<TEnumeration>(string name) where TEnumeration : AbstractEnumeration
        {
            var matchingItem = Parse<TEnumeration, string>(name, "name", item => item.Name == name);
            return matchingItem;
        }

        /// <summary>
        /// Compares the instance of <see cref="AbstractEnumeration"/> with another object of <see cref="AbstractEnumeration"/> 
        /// </summary>
        /// <param name="other">The <see cref="AbstractEnumeration"/> value to compared</param>
        /// <returns> 
        /// An integer that indicates whether the current instance of <see cref="AbstractEnumeration"/> precedes, follows,
        /// or occurs in the same position in the sort order as the other <see cref="AbstractEnumeration"/>.
        /// </returns>
        public int CompareTo(object other) => Value.CompareTo(((AbstractEnumeration)other).Value);

        private static bool TryParse<TEnumeration>(Func<TEnumeration, bool> predicate, out TEnumeration enumeration)
            where TEnumeration : AbstractEnumeration
        {
            enumeration = GetAll<TEnumeration>().FirstOrDefault(predicate);
            return enumeration != null;
        }

        private static TEnumeration Parse<TEnumeration, TIntOrString>(TIntOrString nameOrValue, string description, Func<TEnumeration, bool> predicate)
            where TEnumeration : AbstractEnumeration
        {
            var matchingItem = GetAll<TEnumeration>().FirstOrDefault(predicate);
            if (matchingItem == null)
            {
                throw new InvalidOperationException($"'{nameOrValue}' is not a valid {description} in {typeof(TEnumeration)}");
            }

            return matchingItem;
        }
    }
}
