using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float ConstantValue;
    public SoFloat Variable;

    public FloatReference()
    {
    }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value => UseConstant ? ConstantValue : Variable.Value;

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}