using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Float")]
public class SoFloat : ScriptableObject
{
#if UNITY_EDITOR
    [SerializeField] [Multiline] private string developerDescription;
#endif
    [SerializeField] private float defaultValue;
    private float value;

    public float DefaultValue => defaultValue;

    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }

    private void OnEnable()
    {
        value = defaultValue;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}