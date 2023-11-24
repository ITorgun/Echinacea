using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StrongGun : MonoBehaviour, IShootable
{
    [SerializeField] private Image _image;
    [SerializeField] private float _damage;
    [SerializeField] private int _ammoPullModifier;
    [SerializeField] private float _pullingDelay;

    private Coroutine _pulling;
    public IMagazine Magazine { get; private set; }

    public Image Image => _image;

    private bool _isShooting;

    [Inject]
    private void Construct(IMagazine magazine)
    {
        Magazine = magazine;
    }

    private void OnDisable()
    {
        if (_pulling != null)
        {
            StopCoroutine(_pulling);
        }

        _isShooting = false;
    }

    public void Shoot()
    {
        if (_isShooting)
            return;

        _pulling = StartCoroutine(PullingAmmo());
    }

    private IEnumerator PullingAmmo()
    {
        _isShooting = true;

        for (int i = 0; i < _ammoPullModifier; i++)
        {
            IAmmo ammo = Magazine.PullAmmo();
            ammo.IncreaseInitialStats(_damage);
            yield return new WaitForSeconds(_pullingDelay);
        }

        _isShooting = false;
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
