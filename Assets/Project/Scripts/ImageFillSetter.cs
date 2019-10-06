using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillSetter : MonoBehaviour
{
    [SerializeField] private FloatReference variable = default(FloatReference);
    [SerializeField] private FloatReference maxValue = default(FloatReference);
    [SerializeField] private Image image = default(Image);

    private void Update()
    {
        image.fillAmount = Mathf.Clamp01(variable.Value / maxValue.Value);
    }
}