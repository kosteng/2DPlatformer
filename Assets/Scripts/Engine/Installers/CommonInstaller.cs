using Characters.Controllers;
using Engine.Mediators;
using Engine.UI.Canvas;
using Extensions.Pool;
using InputControls;
using InputControls.CameraControls;
using InputControls.InpitClicker;
using Inventory;
using Items.ResourceItems;
using UI.BottomPanel;
using Units.Controllers;
using Zenject;

namespace Engine.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Characters();
            Mediators();
            InputControls();
            InventorySystem();
            Items();
            Ui();
        }


        private void Characters()
        {
            Container.BindInterfacesAndSelfTo<CharacterMovementController>().AsSingle();
            Container.BindInterfacesTo<CharacterAnimationSwitcher>().AsSingle();
        }
        
        private void Mediators()
        {
            Container.BindInterfacesTo<UnityEventMediator>().AsSingle().NonLazy();
        }
        
        private void InputControls()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesTo<InputClicker>().AsSingle();
            Container.BindInterfacesTo<PlayerInputControls>().AsSingle();
        }
        
        private void InventorySystem()
        {
            Container.BindInterfacesTo<InventoryPresenter>().AsSingle();
            Container.BindInterfacesTo<InventoryCellFactory>().AsSingle();
            Container.BindInterfacesTo<InventoryCellBuilder>().AsSingle();
        }
        
        private void Items()
        {
            Container.BindInterfacesAndSelfTo<Items.InteractableItemController>().AsSingle();
            Container.BindInterfacesTo<Items.InteractItemFactory>().AsSingle();
            Container.BindInterfacesTo<ResourceItemsTransfer>().AsSingle();
        }

        private void Ui()
        {
            Container.BindInterfacesTo<CanvasContainer>().AsSingle();
            Container.BindInterfacesTo<UI.UiAttachSystem.UiAttachSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
        }
    }
}
