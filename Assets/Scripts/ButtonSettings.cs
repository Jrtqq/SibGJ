using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}