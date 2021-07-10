using Characters;
using Inventory;
using Items.InteractItems;
using Items.ResourceItems;
using Units.Views;
using UnityEngine;
using Zenject;

namespace Engine.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/Installers/DatabasePrefabsInstaller")]
    public class DatabasePrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private InteractItemsDatabase _interactItemsDatabase;
        [SerializeField] private ResourceItemsDatabase _resourceItemsDatabase;
        [SerializeField] private CharactersDatabase _charactersDatabase;
        [SerializeField] private CharacterView _player;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private InventoryCellView _inventoryCell;
        
        public override void InstallBindings()
        {
            Inputs();
            Inventory();
            Items();
            Characters();
        }
        
        private void Inputs()
        {
            Container.BindInstance(_cameraView);
        }

        private void Inventory()
        {
            Container.BindInstance(_inventoryCell);
        }

        private void Items()
        {
            Container.BindInstance(_interactItemsDatabase);
            Container.BindInstance(_resourceItemsDatabase);
        }

        private void Characters()
        {
            Container.BindInstance(_player);
            Container.BindInstance(_charactersDatabase);
        }
    }
}