namespace Sauron.OntologyAPI.Domain.Models
{
    /// <summary>
    /// <c>OntologyClass</c> represents a domain class/type inside the ontology. This resource is identified via an ID,
    /// it has a name, and a collection of properties.
    /// Its goal it's to represent a shape of data, behaving like a blueprint
    /// on how to aggregate data, not as a direct form (for that see <see cref="OntologyClassInstance"/>)
    /// </summary>
    public sealed class OntologyClass
    {
        private const int NameMaxLength = 25;

        public Guid Id
        {
            get;
            init
            {
                // Validation logic for the class name:
                // - Do not allow empty/null GUID
                if(value == Guid.Empty)
                    throw new ArgumentException("Ontology class ID empty/null is not allowed");
                
                field = value;
            }
        }
        public string Name
        {
            get;
            set
            {
                // Validation logic for the class name:
                // - Do not allow empty names
                // - Do not exceed 25 characters
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("An ontology class must have a name assigned");
                if(value.Length > NameMaxLength)
                    throw new ArgumentException($"An ontology class name must not exceed {NameMaxLength} characters");

                field = value;
            }
        }
        public ICollection<OntologyClassProperty> Properties { get; init; }

        public OntologyClass(string className) : this(Guid.NewGuid(), className) { }
        public OntologyClass(Guid classId, string className) : this(classId, className, []){ }
        public OntologyClass(Guid classId, string className, ICollection<OntologyClassProperty> classProperties)
        {
            Id = classId;
            Name = className;
            Properties = classProperties;
        }
    }
}