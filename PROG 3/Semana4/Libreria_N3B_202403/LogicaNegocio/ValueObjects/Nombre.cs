
namespace LogicaNegocio.ValueObjects
{
    
    public partial record Nombre
    {
        public string Value { get; init; }

        public Nombre(string value)
        {
            Value = value;
        }
    }
}
