using UnityEngine;
using System.Collections;
using ScriptableObjectArchitecture;

public class CameraFollow : MonoBehaviour
{

    public Vector3Variable targetPos;
    public float offsetX;
    public float offsetY;

    private Vector3 offset;

    private void Awake() {
        UpdateOffset();
    }

    private void LateUpdate() {
        transform.position = targetPos.Value + offset;
//        Debug.Log(targetPos);
    }

    private void OnValidate() {
        UpdateOffset();
    }

    private void UpdateOffset() {
        offset = new Vector3(offsetX, offsetY, -10);
    }

}
