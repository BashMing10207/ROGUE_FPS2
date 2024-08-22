using System;

internal class NativeHeaderAttribute : Attribute
{
    private string v;

    public NativeHeaderAttribute(string v)
    {
        this.v = v;
    }
}