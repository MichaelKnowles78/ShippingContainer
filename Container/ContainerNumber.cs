namespace Container;

public class ContainerNumber
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
    private string categoryIdentifier;
    private string _serialNumber;
    private byte _checkDigit;

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    public ContainerNumber(string containerNumber)
    {
        throw new NotImplementedException();
    }
}