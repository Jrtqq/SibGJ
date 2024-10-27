using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food")]
public class Food : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _healthGain;
}
