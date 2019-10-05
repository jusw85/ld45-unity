using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] private string spellName;
    [SerializeField] private KeyCode key;
    [SerializeField] private Sprite icon;
    [SerializeField] private float cooldown;
    [SerializeField] private int cost;
    [SerializeField] private FloatVariable fv;

    public string SpellName => spellName;

    public KeyCode Key => key;

    public Sprite Icon => icon;

    public float Cooldown => cooldown;

    public int Cost => cost;
}