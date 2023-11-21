using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using UnityEngine;
using Zenject;

public class StrongGun : MonoBehaviour, IShootable
{
    [SerializeField] private float _damage;
    [SerializeField] private int _ammoPullModifier;
    [SerializeField] private float _pullingDelay;

    private Coroutine _delaying;
    private Coroutine _pulling;
    public IMagazine Magazine { get; private set; }

    [Inject]
    private void Construct(IMagazine magazine)
    {
        Magazine = magazine;
    }

    private void OnDisable()
    {
        if (_delaying != null)
        {
            StopCoroutine(_delaying);
        }
    }

    public void Shoot()
    {
        _pulling = StartCoroutine(PullingAmmo());
    }

    private IEnumerator PullingAmmo()
    {
        for (int i = 0; i < _ammoPullModifier; i++)
        {
            IAmmo ammo = Magazine.PullAmmo();
            ammo.IncreaseInitialStats(_damage);
            yield return new WaitForSeconds(_pullingDelay);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
