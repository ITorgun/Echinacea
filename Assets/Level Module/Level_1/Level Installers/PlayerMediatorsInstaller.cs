using UnityEngine;
using Zenject;

namespace Assets.LevelModule.Level_1
{
    public class PlayerMediatorsInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _playerPanelTransform;

        [SerializeField] private PlayerMediator _playerMediator;
        [SerializeField] private SliderHealthViewer _playerHealthViewer;

        [SerializeField] private RectTransform _weaponRectTransform;
        [SerializeField] private ShootableImageViewer _shootableImageViewer;
        [SerializeField] private MagazineImageViewer _magazineImageViewer;
        [SerializeField] private PlayerWalletViewer _walletViewer;

        private RectTransform _playerPanel;

        private PlayerAttackImageViewer _imageGunViewer;

        public override void InstallBindings()
        {
            InstantiatePlayerPanel();

            InstallHealthViewer();

            //InstallAttackViewer();
            InstallWeaponViewer();
            InstallWalletViewer();

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
            Container.Bind<IImageViewer>().WithId("ShootableViewer").FromInstance(shootableViewer);

            MagazineImageViewer magazineViewer = Container
                .InstantiatePrefabForComponent<MagazineImageViewer>(_magazineImageViewer, weaponViewerTransform);
            Container.Bind<IImageViewer>().WithId("MagazineViewer").FromInstance(magazineViewer);

            WeaponImageViewer weaponViewer = Container.InstantiateComponent<WeaponImageViewer>(weaponViewerTransform.gameObject);
            Container.BindInterfacesAndSelfTo<WeaponImageViewer>().FromInstance(weaponViewer).AsSingle();
        }

        private void InstallWalletViewer()
        {
            PlayerWalletViewer walletViewer = Container.InstantiatePrefabForComponent<PlayerWalletViewer>(_walletViewer, _playerPanel);
            Container.BindInterfacesAndSelfTo<PlayerWalletViewer>().FromInstance(walletViewer).AsSingle();
        }

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
}