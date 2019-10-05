using UnityEngine;

public class Thinker : MonoBehaviour
{
    [SerializeField] private Brain brain;

    private void Update()
    {
        brain.Think(this);
    }
}