using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class PlayerAttackImageViewer : MonoBehaviour
{
    private IWeaponImageViewer _shootableViewer;

    [Inject]
    public void Constructor(IWeaponImageViewer shootableViewer)
    {
        _shootableViewer = shootableViewer;
    }

    public void OnShootableSwitched(IShootable shootable)
    {
        _shootableViewer.OnShootableSwitched(shootable, shootable.Magazine);
    }
}
