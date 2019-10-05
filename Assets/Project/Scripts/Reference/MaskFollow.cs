using UnityEngine;
using System.Collections;

public class MaskFollow : MonoBehaviour {

    private GameObject _target;
    public GameObject target {
        get { return _target; }
        set {
            _target = value;
            dudeController = target.GetComponent<DudeController>();
        }
    }

    public float offsetX;
    public float offsetY;

    private DudeController dudeController;

    private Vector3 offset;

    private void Awake() {
        UpdateOffset();
    }

    private void LateUpdate() {
        if (!dudeController.isFrozen)
            transform.position = target.transform.position + offset;
    }

    private void OnValidate() {
        UpdateOffset();
    }

    private void UpdateOffset() {
        offset = new Vector3(offsetX, offsetY, -5);
    }

}
