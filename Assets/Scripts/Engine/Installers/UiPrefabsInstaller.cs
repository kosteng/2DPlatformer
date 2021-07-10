using Engine.UI;
using Inventory;
using UI.BottomPanel;
using UnityEngine;
using Zenject;

namespace Engine.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/Installers/UiPrefabsInstaller")]
    public class UiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CanvasView _canvasView;
        [SerializeField] private BottomPanelView _bottomPanelView;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private TransferPopupView _transferPopupView;
        
        public override void InstallBindings()
        {
            Container.Bind<CanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();
            Container.Bind<BottomPanelView>().FromComponentInNewPrefab(_bottomPanelView).AsSingle();
            Container.Bind<InventoryView>().FromComponentInNewPrefab(_inventoryView).AsSingle();
            Container.Bind<TransferPopupView>().FromComponentInNewPrefab(_transferPopupView).AsSingle();
        }
    }
}