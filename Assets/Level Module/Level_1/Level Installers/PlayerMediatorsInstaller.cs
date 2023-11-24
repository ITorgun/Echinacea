using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerMediatorsInstaller : MonoInstaller
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _playerPanelTransform;

    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private SliderHealthViewer _playerHealthViewer;
    
    [SerializeField] private RectTransform _weaponRectTransform;
    [SerializeField] private ShootableImageViewer _shootableImageViewer;
    [SerializeField] private MagazineImageViewer _magazineImageViewer;

    private RectTransform _playerPanel;

    private PlayerAttackImageViewer _imageGunViewer;

    public override void InstallBindings()
    {
        InstantiatePlayerPanel();

        InstallHealthViewer();

        //InstallAttackViewer();
        InstallWeaponViewer();

        InstallViewerMediator();
        InstallInputMediator();
        InstallPlayerMediator();
    }

    private void InstantiatePlayerPanel()
    {
        _playerPanel = Container
            .InstantiatePrefabForComponent<RectTransform>(_playerPanelTransform, _canvas.transform);
    }

    private void InstallHealthViewer()
    {
        SliderHealthViewer healthViewer = Container
            .InstantiatePrefabForComponent<SliderHealthViewer>(_playerHealthViewer, _playerPanel);

        Container.BindInterfacesAndSelfTo<SliderHealthViewer>().FromInstance(healthViewer).AsSingle();
    }

    private void InstallWeaponViewer()
    {
        RectTransform weaponViewerTransform = Container
            .InstantiatePrefabForComponent<RectTransform>(_weaponRectTransform, _playerPanel);

        ShootableImageViewer shootableViewer = Container
            .InstantiatePrefabForComponent<ShootableImageViewer>(_shootableImageViewer, weaponViewerTransform);
        Container.BindInterfacesAndSelfTo<ShootableImageViewer>().FromInstance(shootableViewer).AsSingle();

        MagazineImageViewer magazineViewer = Container
            .InstantiatePrefabForComponent<MagazineImageViewer>(_magazineImageViewer, weaponViewerTransform);
        Container.BindInterfacesAndSelfTo<MagazineImageViewer>().FromInstance(magazineViewer).AsSingle();

        Container.Bind<IImageViewer>().WithId("ShootableViewer").FromInstance(magazineViewer);
        Container.Bind<IImageViewer>().WithId("MagazineViewer").FromInstance(magazineViewer);

        WeaponImageViewer weaponViewer = Container.InstantiateComponent<WeaponImageViewer>(weaponViewerTransform.gameObject);
        Container.BindInterfacesAndSelfTo<WeaponImageViewer>().FromInstance(weaponViewer).AsSingle();

        //PlayerAttackImageViewer attackImageViewer = Container.InstantiateComponent<PlayerAttackImageViewer>(_playerPanel.gameObject);
        //Container.BindInterfacesAndSelfTo<PlayerAttackImageViewer>().FromInstance(attackImageViewer).AsSingle();
    }

    //private void InstallWeaponViewer()
    //{
    //    RectTransform playerAttack = Container
    //        .InstantiatePrefabForComponent<RectTransform>(_weaponRectTransform, _playerPanel);

    //    RectTransform weaponRect = Container.InstantiatePrefabForComponent<RectTransform>(_weaponRectTransform, playerAttack.transform);

    //    ShootableImageViewer shootableViewer = Container
    //        .InstantiatePrefabForComponent<ShootableImageViewer>(_shootableImageViewer, weaponRect);
    //    Container.BindInterfacesAndSelfTo<ShootableImageViewer>().FromInstance(shootableViewer).AsSingle();

    //    MagazineImageViewer magazineViewer = Container
    //        .InstantiatePrefabForComponent<MagazineImageViewer>(_magazineImageViewer, weaponRect);
    //    Container.BindInterfacesAndSelfTo<MagazineImageViewer>().FromInstance(magazineViewer).AsSingle();

    //    Container.Bind<IImageViewer>().WithId("ShootableViewer").FromInstance(shootableViewer);
    //    Container.Bind<IImageViewer>().WithId("MagazineViewer").FromInstance(magazineViewer);

    //    WeaponImageViewer weaponViewer = Container.InstantiateComponent<WeaponImageViewer>(weaponRect.gameObject);
    //    Container.BindInterfacesAndSelfTo<WeaponImageViewer>().FromInstance(weaponViewer).AsSingle();

    //    PlayerAttackImageViewer attackImageViewer = Container.InstantiateComponent<PlayerAttackImageViewer>(playerAttack.gameObject);
    //    Container.BindInterfacesAndSelfTo<PlayerAttackImageViewer>().FromInstance(attackImageViewer).AsSingle();
    //}

    private void InstallViewerMediator()
    {
        Container.BindInterfacesAndSelfTo<PlayerViewerMediator>().AsSingle();
    }

    private void InstallInputMediator()
    {
        Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle();
    }

    private void InstallPlayerMediator()
    {
        PlayerMediator mediator = Container.InstantiatePrefabForComponent<PlayerMediator>(_playerMediator);
        Container.BindInterfacesAndSelfTo<PlayerMediator>().FromInstance(mediator).AsSingle().NonLazy();
    }
}
