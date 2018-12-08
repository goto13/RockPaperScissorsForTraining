using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Task3
{
    public enum HandShape
    {
        [Japanese("グー"), English("Rock")]
        Rock = 1,
        [Japanese("パー"), English("Paper")]
        Paper = 2,
        [Japanese("チョキ"), English("Scissors")]
        Scissors = 3
    }

    // 属性など
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JapaneseAttribute : Attribute
    {
        public string Value { get; private set; }

        public JapaneseAttribute(string value)
        {
            Value = value;
        }
    }

    // 属性など
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class EnglishAttribute : Attribute
    {
        public string Value { get; private set; }

        public EnglishAttribute(string value)
        {
            Value = value;
        }
    }

    public static class HandShapeExtensions
    {
        private static readonly Dictionary<HandShape, EnglishAttribute> enCache;
        private static readonly Dictionary<HandShape, JapaneseAttribute> jpCache;

        static HandShapeExtensions()
        {
            var type = typeof(HandShape);
            var lookup = type.GetFields()
                .Where(fi => fi.FieldType == type)
                .SelectMany(fi => fi.GetCustomAttributes(false),
                    (fi, Attribute) => new { HandShape = (HandShape)fi.GetValue(null), Attribute })
                .ToLookup(a => a.Attribute.GetType());

            jpCache = lookup[typeof(JapaneseAttribute)].ToDictionary(a => a.HandShape, a => (JapaneseAttribute)a.Attribute);
            enCache = lookup[typeof(EnglishAttribute)].ToDictionary(a => a.HandShape, a => (EnglishAttribute)a.Attribute);
        }

        public static string ToJapaneseName(this HandShape hand)
        {
            return jpCache[hand].Value;
        }

        public static string ToEnglishName(this HandShape hand)
        {
            return enCache[hand].Value;
        }

    }
}
