namespace ontology_api_tests;

using Sauron.OntologyAPI.Domain.Models;

[Category("Unit")]
public class OntologyClassValidationTests
{
    /// <summary>
    /// In this test is verified that the <c>OntologyClass</c> object creation fails if the name is null
    /// </summary>
    [Test]
    public void TestOCValidation_NullClassName()
    {
        // Arrange
        Guid classId = Guid.NewGuid();
        String? className = null;

        // Act+Assert
        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClass(className);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClass</c> object creation fails if the name is blank
    /// </summary>
    [Test]
    public void TestOCValidation_BlankClassName()
    {
        Guid classId = Guid.NewGuid();
        String? className = "";

        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClass(className);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClass</c> object creation fails if the name is whitespace
    /// </summary>
    [Test]
    public void TestOCValidation_WhitespaceClassName()
    {
        Guid classId = Guid.NewGuid();
        String? className = "            ";

        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClass(className);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClass</c> object creation fails if the name is
    /// longer than 25 characters long
    /// </summary>
    [Test]
    public void TestOCValidation_OverflowingClassName()
    {
        Guid classId = Guid.NewGuid();
        String? className = new string('a', 35);

        Assert.Throws<ArgumentException>(() =>
        {
            new OntologyClass(className);
        });
    }

    /// <summary>
    /// In this test is verified that the <c>OntologyClass</c> object creation succeeds, simulating an ideal scenario, by
    /// checking its state after the creation.
    /// </summary>
    [Test]
    public void TestOCValidation_IdealScenario()
    {
        OntologyClass testClass = new OntologyClass("Company");

        Assert.That(testClass, Is.Not.EqualTo(null));
        Assert.That(testClass.Name, Is.Not.Empty);
        Assert.That(testClass.Properties.Count, Is.EqualTo(0));
    }
}
