using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeBulletsButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private BulletsViewer _viewer;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonPressed);
    }

    public void OnButtonPressed()
    {
        _viewer.Show();
    }
    
}
