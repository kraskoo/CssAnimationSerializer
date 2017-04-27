namespace Interpretators
{
    using System.Text;
    using Interfaces;

    public class Context : IContext
    {
        private readonly StringBuilder builder;

        public Context(StringBuilder builder)
        {
            this.builder = builder;
        }

        public Context() : this(new StringBuilder())
        {
        }

        public void Append(string representation)
        {
            builder.Append(representation);
        }

        public static implicit operator string(Context context)
        {
            return context.builder.ToString();
        }
    }
}