namespace TestContainer;

using Container;
using NUnit.Framework;

[TestFixture]
public class ContainerTests
{

    [TestCase("MSCU1234566", ExpectedResult = true)]
    [TestCase("HDMU9876547", ExpectedResult = true)]
    [TestCase("CAXU5432166", ExpectedResult = true)]
    public bool ContainerNumber_WhenGivenValidContainerNumber_ReturnsExpectedResult(string containerNumber)
    {
        var result = new ContainerNumber(containerNumber);

        return result.ToString() == containerNumber.ToUpper();
    }

    [TestCase("ABCD1234", "Argument is too short")]
    [TestCase("MSCA1234567", "4th character is not a valid Product group (U, J, or Z)")]
    [TestCase("MSCU12A4567", "Characters 5-10 must be digits")]
    [TestCase("MSCU1234568", "Check digit is not correct")]
    public void ContainerNumber_WhenGivenInvalidContainerNumber_ThrowsArgumentException(string containerNumber, string expectedMessage)
    {
        Assert.Throws<ArgumentException>(() => new ContainerNumber(containerNumber),
            $"Expected an {nameof(ArgumentException)} with the message '{expectedMessage}' to be thrown.");
    }
}