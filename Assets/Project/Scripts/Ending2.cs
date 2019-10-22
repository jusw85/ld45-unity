using System.Collections;
using System.Collections.Generic;
using Jusw85.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending2 : MonoBehaviour
{
    [SerializeField] private GameObject finalGate;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(CoroutineUtils.DelaySeconds(() =>
        {
            finalGate.SetActive(true);
//            SceneManager.LoadScene("End");
            Physics2D.gravity = new Vector2(0, -9.81f);
        }, 2f));
    }
}
