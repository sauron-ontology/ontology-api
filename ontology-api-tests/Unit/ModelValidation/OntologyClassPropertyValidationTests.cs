using Sauron.OntologyAPI.Domain.Models;

[Category("Unit")]
public class OntologyClassPropertyValidationTests
{
    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the label is null
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_NullLabel()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty(null, "isEmployed", OntologyClassPropertyDataType.BoolProperty);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the label is blank
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_BlankLabel()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty("", "isEmployed", OntologyClassPropertyDataType.BoolProperty);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the label is whitespace
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_WhitespaceLabel()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty(new string('a', 30), "isEmployed", OntologyClassPropertyDataType.BoolProperty);
        });
    }


    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the predicate is null
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_NullPredicate()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty("label", null, OntologyClassPropertyDataType.BoolProperty);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the predicate is blank
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_BlankPredicate()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty("label", "", OntologyClassPropertyDataType.BoolProperty);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClassProperty</c> object creation fails if the predicate is whitespace
    /// </summary>
    [Test]
    public void TestOCPropertyValidation_WhitespacePredicate()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClassProperty("label", new string('a', 30), OntologyClassPropertyDataType.BoolProperty);
        });
    }

}