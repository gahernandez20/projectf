namespace ProjectF.Core;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumLabel(string label) : Attribute
{
    public string Label
    {
        get;
    } = label;
}