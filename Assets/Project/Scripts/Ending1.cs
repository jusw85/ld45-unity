using UnityEngine;

public class Ending1 : MonoBehaviour
{
    [SerializeField] private float antigrav = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.gravity = new Vector2(0, antigrav);
    }
}