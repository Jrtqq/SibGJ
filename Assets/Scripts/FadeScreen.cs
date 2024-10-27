using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Image _fade;

    private bool _isBusy = false;

    public static FadeScreen Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Fade(Action onComplete = null, float fadeFactor = 1)
    {
        if (_isBusy == false)
        {
            _isBusy = true;
            _fade.gameObject.SetActive(true);

            Color visibility = new(_fade.color.r, _fade.color.g, _fade.color.b, 0);

            while (_fade.color.a < 1)
            {
                visibility.a += fadeFactor * Time.deltaTime;
                _fade.color = visibility;

                yield return null;
            }

            _isBusy = false;
            onComplete?.Invoke();
        }
    }

    public IEnumerator Show(Action onComplete = null, float showFactor = 1)
    {
        if (_isBusy == false)
        {
            _fade.gameObject.SetActive(true);
            _isBusy = true;

            Color visibility = new(_fade.color.r, _fade.color.g, _fade.color.b, 1);

            while (_fade.color.a > 0)
            {
                visibility.a -= showFactor * Time.deltaTime;
                _fade.color = visibility;

                yield return null;
            }

            _isBusy = false;
            _fade.gameObject.SetActive(false);
            onComplete?.Invoke();
        }
    }
}
