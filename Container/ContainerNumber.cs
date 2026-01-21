using System.Runtime.CompilerServices;

namespace Container;

public class ContainerNumber
{
    private static readonly Dictionary<char, byte> _characterWeights = new()
    {
        {'A',10 },
        {'B',12 },
        {'C',13 },
        {'D',14 },
        {'E',15 },
        {'F',16 },
        {'G',17 },
        {'H',18 },
        {'I',19 },
        {'J',20 },
        {'K',21 },
        {'L',23 },
        {'M',24 },
        {'N',25 },
        {'O',26 },
        {'P',27 },
        {'Q',28 },
        {'R',29 },
        {'S',30 },
        {'T',31 },
        {'U',32 },
        {'V',34 },
        {'W',35 },
        {'X',36 },
        {'Y',37 },
        {'Z',38 },
        {'0',0 },
        {'1',1 },
        {'2',2 },
        {'3',3 },
        {'4',4 },
        {'5',5 },
        {'6',6 },
        {'7',7 },
        {'8',8 },
        {'9',9 }
    };

    private string _owner;
    private static char _equipmentCategory;
    private static string _serialNumber;
    private static byte _checkDigit;

    public override string ToString()
    {
        return _owner + _equipmentCategory + _serialNumber + _checkDigit;

        throw new NotImplementedException();
    }

    public ContainerNumber(string containerNumber)
    {
        _owner = containerNumber[0..3];
        _equipmentCategory = containerNumber[3];

        if (ValidateContainerNumber(containerNumber))
            return;

        throw new NotImplementedException();
    }

    public static bool ValidateContainerNumber(string containerNumber)
    {
        // Here we validate the length of the container number.
        if (containerNumber.Length == 11)
        {
            ValidateEquipmentCategory(containerNumber);
            return true;
        }

        throw new ArgumentException("Argument is too short");
    }

    public static void ValidateEquipmentCategory(string containerNumber)
    {
        // Here we validate the equipment category group character.
        if (_equipmentCategory == 'U' || _equipmentCategory == 'J' || _equipmentCategory == 'Z')
        {
            ValidateSerialNumber(containerNumber);
            return;
        }

        throw new ArgumentException("4th character is not a valid equipment category group (U, J, or Z)");
    }

    public static void ValidateSerialNumber(string containerNumber)
    {
        // Here we validate the serial number part of the container number.
        _serialNumber = containerNumber[4..10];

        if (_serialNumber.All(char.IsDigit))
        {
            ValidateCheckDigit(containerNumber);
            return;
        }

        throw new ArgumentException("Characters 5-10 must be digits");
    }

    public static void ValidateCheckDigit(string containerNumber)
    {
        // Here we calculate the Check Digit character based on the formula for the ISO 6346.
        _checkDigit = byte.Parse(containerNumber[10].ToString());
        var checkDigitCalculated = 0;
        int sum = 0;

        for (int i = 0; i < containerNumber.Length - 1; i++)
        {
            foreach (var character in _characterWeights)
            {
                if (containerNumber[i] == character.Key)
                {
                    int weight = character.Value;
                    int position = i;
                    double power = Math.Pow(2, position);
                    var product = weight * (int)power;
                    sum += product;
                }
            }
        }

        var divisionByEleven = sum / 11;
        checkDigitCalculated = (byte)(sum - (divisionByEleven * 11));

        // In case we get a 10 as a result, the check digit is going to be 0.
        if (checkDigitCalculated != 10 && checkDigitCalculated != _checkDigit)
        {
            throw new ArgumentException("Check digit is not correct");
        }
    }
}