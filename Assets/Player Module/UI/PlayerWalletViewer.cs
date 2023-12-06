using Assets.Playable_Entity_Module;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWalletViewer : MonoBehaviour, IViewable
{
    [SerializeField] private TMP_Text _text;

    private const string text = "Wallet: ";

    public void OnValueChanged(int value)
    {
        _text.text = text + value.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(true);
    }

    public void Show()
    {
        gameObject.SetActive(false);
    }
}
