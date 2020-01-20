using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte;
using System.Linq;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO
{
    public class LogBase
    {
        public LogBase(string provider) =>
            Provider = provider;

        public LogBase() { }

        [Log("provider", 0)]
        public string Provider { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as LogBase;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return ToString().Equals(compareTo.ToString());
        }

        public static bool operator ==(LogBase a, LogBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(LogBase a, LogBase b) =>
            !(a == b);

        public override int GetHashCode() =>
            (GetType().GetHashCode() * 907) + ToString().GetHashCode();

        public override string ToString()
        {
            var values = GetType().GetProperties()
                .OrderBy(p => p.CustomAttributes.Select(c => (int)c.ConstructorArguments[1].Value).FirstOrDefault())
                .Select(p => p.GetValue(this)).ToArray();

            return string.Join(' ', values).Trim();
        }
    }
}
