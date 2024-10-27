using System.Linq;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _hub;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _map;

    [Header("Campfire")]
    [SerializeField] private Food _rawFood;
    [SerializeField] private Food _roastedFood;

    public void OnShopButton()
    {
        _hub.SetActive(false);
        _shop.SetActive(true);
    }

    public void OnMapButton()
    {
        _hub.SetActive(false);
        _map.SetActive(true);
    }

    public void OnCampfireButton()
    {
        if (GlobalInfo.IsMorning == false)
        {
            if (GlobalInfo.Player.Food.Contains(_rawFood))
            {
                GlobalInfo.Player.RemoveFood(_rawFood);
                GlobalInfo.Player.AddFood(_roastedFood);

                string playerInventoryDebug = "";
                for (int i = 0; i < GlobalInfo.Player.Food.Count; i++)
                {
                    playerInventoryDebug += GlobalInfo.Player.Food[i];
                }
                Debug.Log("удаление сырой еды и добавление жаренной, инвентарь: " + playerInventoryDebug);
            }
        }
    }

    public void OnRestButton()
    {
        if (GlobalInfo.IsMorning == false)
        {
            StartCoroutine(FadeScreen.Instance.Fade(() => StartCoroutine(FadeScreen.Instance.Show())));
            GlobalInfo.IsMorning = true;

            foreach(Creature pet in GlobalInfo.Player.Pets)
            {
                pet.Sleep();
            }

            Debug.Log("питомцы восстановили здоровье, наступило утро");
        }
    }
}
