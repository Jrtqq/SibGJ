using UnityEngine;

public class Initializer : MonoBehaviour
{
    private void Awake()
    {
        GlobalInfo.Init(new PlayerStats());
    }
}