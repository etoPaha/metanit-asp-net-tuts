namespace N_3_7_2_ServicesMultiRegistration.Core;

public class ValueStorage : IGenerator, IReader
{
    private int _value;
    public int GenerateValue()
    {
        _value = new Random().Next();
        return _value;
    }

    public int ReadValue() => _value;
}