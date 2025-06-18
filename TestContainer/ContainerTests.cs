namespace TestContainer;

using Container;
using NUnit.Framework;

[TestFixture]
public class ContainerTests
{
    [TestCase("ABCU1234", "Argument is too short")]
    [TestCase("BBUA1234567", "4th character is not a valid equipment category group (U, J, or Z)")]
    [TestCase("MSCUZ2A4567", "Characters 5-10 must be digits")]
    [TestCase("MSCU1Z34567", "Characters 5-10 must be digits")]
    [TestCase("MSCU12Z4567", "Characters 5-10 must be digits")]
    [TestCase("MSCU123Z567", "Characters 5-10 must be digits")]
    [TestCase("MSCU1234Z67", "Characters 5-10 must be digits")]
    [TestCase("MSCU12345Z7", "Characters 5-10 must be digits")]
    [TestCase("MSCU1234568", "Check digit is not correct")]
    public void ContainerNumber_WhenGivenInvalidContainerNumber_ThrowsArgumentException(string containerNumber, string expectedMessage)
    {
        var ex = Assert.Throws<ArgumentException>(() => new ContainerNumber(containerNumber),
            $"Expected an {nameof(ArgumentException)} with the message '{expectedMessage}' to be thrown.");
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [TestCase("MSCU1234566")]
    [TestCase("HDMJ9876540")]
    [TestCase("CAXZ5432160")]
    public void ContainerNumber_WhenGivenValidContainerNumber_ReturnsExpectedResult(string containerNumber)
    {
        var result = new ContainerNumber(containerNumber);

        Assert.That(result.ToString(), Is.EqualTo(containerNumber.ToUpper()));
    }
}