namespace Sauron.OntologyAPI.Domain.Models
{
    /// <summary>
    /// Enum containing all the data types that an <c>OntologyClassProperty</c> can assume
    /// </summary>
    public enum OntologyClassPropertyDataType
    {
        IntegerProperty,
        FloatProperty,
        StringProperty,
        BoolProperty
    }


    /// <summary>
    /// <c>OntologyClassProperty</c> represents a triple of label, predicate and data type
    /// that tells which data type is attached to a specfic label. It is meant to be used as
    /// the type that describes <see cref="OntologyClass"/> properties.
    /// </summary>
    public class OntologyClassProperty
    {
        private const int LabelMaxLength = 25;
        private const int PredicateMaxLength = 25;
    
        public string Label
        {
            get;
            set
            {
                // Validation logic for the property label name:
                // - Do not allow empty label names
                // - Do not allow label names that are longer than 25 characters
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A class property must have a label assigned");
                if (value.Length > LabelMaxLength)
                    throw new ArgumentException($"A class property ");
                field = value;
            }
        }
        public string Predicate
        {
            get;
            set
            {
                // Validation logic for the property predicate:
                // - Do not allow empty predicates
                // - Do not allow predicates that are longer than 25 characters
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A class property must have a predicate");
                if (value.Length > PredicateMaxLength)
                    throw new ArgumentException($"A predicate must not exceed {PredicateMaxLength} characters");

                field = value;
            }
        }
        public OntologyClassPropertyDataType DataType
        {
            get;
            set;
        }

        public OntologyClassProperty(string propertyLabel, string propertyPredicate, OntologyClassPropertyDataType propertyDataType)
        {
            Label = propertyLabel;
            Predicate = propertyPredicate;
            DataType = propertyDataType;
        }
    }
}