using System;
using System.Collections;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public IEnumerator DoAfterSeconds(float delay, Action op)
    {
        yield return new WaitForSeconds(delay);
        op();
    }
}