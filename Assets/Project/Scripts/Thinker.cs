using UnityEngine;

public class Thinker : MonoBehaviour
{
    [SerializeField] private Brain brain;

    private void Update()
    {
        if (brain != null)
        {
            brain.Think(this);   
        }
    }
}