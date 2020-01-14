using System;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ItemLog : Attribute
    {
        private string Name;

        private int Position;

        private Type Type;

        private string RegexPattern;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="position">Position in layout, separated by |</param>
        /// <param name="type">Data type</param>
        /// <param name="pattern">Pattern of regular expression to read attribute</param>
        public ItemLog(string name, int position, Type type, string pattern)
        {
            Name = name;
            Position = position;
            Type = type;
            RegexPattern = pattern;
        }
    }
}
