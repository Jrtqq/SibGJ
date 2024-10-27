using UnityEngine;

public static class GlobalInfo
{
    public static PlayerStats Player { get; private set; }

    public static bool IsMorning = false; //потом поменять значение на true

    public static void Init(PlayerStats player)
    {
        Player ??= player;
    }
}
