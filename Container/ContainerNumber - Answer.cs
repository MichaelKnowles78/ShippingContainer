namespace Container;

/// <summary>
/// Here for reference ... not to be placed in repo!
/// </summary>
public class ContainerNumber_Answer
{
    private readonly Dictionary<char, byte> _characterWeights = new()
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
    private string _product;
    private string _registration;
    private readonly byte _checkDigit;
    private readonly string _number;

    public override string ToString()
    {
        return _number;
    }

    public ContainerNumber(string containerNumber)
    {
        _number = containerNumber.ToUpper();
        if (_number.Length < 11)
        {
            throw new ArgumentException("Argument is too short", nameof(containerNumber));
        }

        if (_number[3] != 'U' && _number[3] != 'J' && _number[3] != 'Z')
        {
            throw new ArgumentException("4th character is not a valid Product group (U, J, or Z)", nameof(containerNumber));
        }

        for (int i = 4; i < 10; i++)
        {
            if (!char.IsDigit(_number[i]))
            {
                throw new ArgumentException("Characters 5-10 must be digits", nameof(containerNumber));
            }
        }

        _owner = _number[..3];
        _product = _number.Substring(3, 1);
        _registration = _number.Substring(4, 6);
        _checkDigit = Convert.ToByte(_number.Substring(10, 1));

        if (!IsValidCheckDigit())
        {
            throw new ArgumentException("Check digit is not correct", nameof(containerNumber));
        }
    }

    private bool IsValidCheckDigit()
    {
        int calculatedDigit = 0;
        

        int power = 1;
        for (int i = 0; i < _number.Length-1; i++)
        {
            calculatedDigit += power * _characterWeights.GetValueOrDefault(_number[i]);
            power *= 2;
        }

        int temp2 = calculatedDigit / 11 * 11;
        calculatedDigit -= temp2;

        return calculatedDigit == _checkDigit;
    }
}