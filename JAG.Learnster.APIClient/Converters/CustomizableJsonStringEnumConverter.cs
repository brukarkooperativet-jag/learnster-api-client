using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Converters
{
    // TODO: [REFACTORING] Use default JsonStringEnumConverter after EnumMember implementation
    /// <summary>
    /// Convert EnumMember string names to enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class CustomizableJsonStringEnumConverter<TEnum> : JsonConverter<TEnum>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly ConcurrentDictionary<Type, object> CachedEnumMappings = new();
        private CachedEnumValues<TEnum> _cachedEnumValues;

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsEnum)
            {
                _cachedEnumValues = SetupMappingDictionaries(typeToConvert);
                return true;
            }

            if (typeToConvert.IsGenericType && typeToConvert.GenericTypeArguments[0].IsEnum)
            {
                _cachedEnumValues = SetupMappingDictionaries(typeToConvert.GenericTypeArguments[0]);
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public override TEnum Read(ref Utf8JsonReader reader,
                                   Type typeToConvert,
                                   JsonSerializerOptions options)
        {
            var type = reader.TokenType;
            if (type == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                if (_cachedEnumValues.StringToEnum.TryGetValue(stringValue, out var enumValue))
                {
                    return enumValue;
                }
            }
            else if (type == JsonTokenType.Number)
            {
                var numValue = reader.GetInt32();
                _cachedEnumValues.NumberToEnum.TryGetValue(numValue, out var enumValue);
                return enumValue;
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer,
                                   TEnum value,
                                   JsonSerializerOptions options)
        {
            writer.WriteStringValue(_cachedEnumValues.EnumToString[value]);
        }
        
        private CachedEnumValues<TEnum> SetupMappingDictionaries(Type typeToConvert)
        {
            var mapping = (CachedEnumValues<TEnum>) CachedEnumMappings.GetOrAdd(typeToConvert, type =>
            {
                var enumValues = new CachedEnumValues<TEnum>();

                foreach (var value in Enum.GetValues(type).Cast<TEnum>())
                {
                    var enumMemberName = value.ToString();
                
                    var enumMember = type.GetMember(enumMemberName!)[0];
                    var memberAttribute = enumMember
                        .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                        .Cast<EnumMemberAttribute>()
                        .FirstOrDefault();

                    enumValues.StringToEnum.Add(enumMemberName, value);
                    var num = Convert.ToInt32(type.GetField("value__")?.GetValue(value));
                
                    if (memberAttribute?.Value != null)
                    {
                        enumValues.EnumToString.Add(value, memberAttribute.Value);
                        enumValues.StringToEnum.Add(memberAttribute.Value, value);
                        enumValues.NumberToEnum.Add(num, value);
                    }
                    else
                    {
                        enumValues.EnumToString.Add(value, value.ToString());
                    }
                }
            
                CachedEnumMappings.TryAdd(typeToConvert, enumValues);
                return enumValues;
            });

            return mapping;
        }
        
        internal class CachedEnumValues<TCachedEnum>
        {
            public Dictionary<TCachedEnum, string> EnumToString { get; } = new();
            public Dictionary<string, TCachedEnum> StringToEnum { get; }= new();
            public Dictionary<int, TCachedEnum> NumberToEnum { get; } = new();
        }
    }
}