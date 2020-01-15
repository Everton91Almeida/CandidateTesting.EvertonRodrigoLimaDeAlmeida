using System;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Log : Attribute
    {
        private string Name;

        private int FromPosition;

        private int Order;

        private Type Type;

        private string ReadPattern;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="fromPosition">Position in layout, separated by |</param>
        /// <param name="order">Position in resultant layout</param>
        /// <param name="type">Data type</param>
        /// <param name="readPattern">Pattern of regular expression to read attribute</param>
        public Log(string name, int order, int fromPosition, Type type, string readPattern)
        {
            Name = name;
            FromPosition = fromPosition;
            Order = order;
            Type = type;
            ReadPattern = readPattern;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="order">Position in resultant layout</param>
        public Log(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
