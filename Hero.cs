using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleHttpCaller
{
    internal class Hero
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("birth_year")]
        public string? Birthyear { get; set; }
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
        [JsonPropertyName("height")]
        public string? Height { get; set; }

        public override string ToString()
        {
            return $"Name: {Name,10}\nBirthyear: {Birthyear,10}\nGender: {Gender,10}\nHeight: {Height,10}";
        }
    }
}
