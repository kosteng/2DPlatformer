using Characters;
using System.Collections.Generic;
using System.Linq;
using Engine.Mediators;
using Items.InteractItems;
using Items.InteractItems.Interfaces;
using Items.ResourceItems;
using LevelGeneration;
using System;
using UnityEngine;
using static UnityEngine.Object;

namespace Items
{
    public class InteractableItemController : IUpdatable, IDisposable
    {
        private readonly IInteractItemFactory _itemFactory;
        private readonly InteractableItemView _itemView;
        private List<IInteractableItem> _items;
        public IInteractableItem InteractableItem;
        private CharacterModel _characterModel;

        public InteractableItemController(IInteractItemFactory itemFactory, ILevelGenerator levelGenerator)
        {
            _itemFactory = itemFactory;
            levelGenerator.Generate();
            var interactObjects = FindObjectsOfType<InteractableItemView>() as IInteractableItem[];
            _items = interactObjects.ToList();
            foreach (var Item in _items.Where(item => item.ItemType == EInteractItemType.StartLevel))
            {
                InteractableItem = Item;
                break;
            }

            foreach (var item in _items)
            {
                item.OnPlayerTriggered += OnPlayerInteract;
            }

            Debug.Log(_items.Count);
        }

        public void SetPlayer(CharacterModel characterModel)
        {
            _characterModel = characterModel;
        }

        private void OnPlayerInteract(IInteractableItem item)
        {
            switch (item.ItemType)
            {
                case EInteractItemType.StartLevel:
                    break;

                case EInteractItemType.FinishLevel:
                    break;

                case EInteractItemType.Portal:
                    if (Input.GetKeyDown(KeyCode.F))
                        _characterModel.View.transform.position = new Vector2(item.InPortal.transform.position.x,
                            item.InPortal.transform.position.y);
                    break;

                case EInteractItemType.PortalIn:
                    if (Input.GetKeyDown(KeyCode.F))
                        _characterModel.View.transform.position = new Vector2(item.InPortal.transform.position.x,
                            item.InPortal.transform.position.y);
                    break;

                case EInteractItemType.PortalOut:
                    break;

                case EInteractItemType.PortalDeath:
                    if (Input.GetKeyDown(KeyCode.F))
                        _characterModel.View.transform.position = new Vector2(InteractableItem.Transform.position.x,
                            InteractableItem.Transform.position.y);
                    break;

                case EInteractItemType.Coin:
                    _characterModel.ResourcesStorage.AddResource(EResourceItemType.Gold, 1);
                    Destroy(item.Transform.gameObject);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Update(float deltaTime)
        {
        }

        public void Dispose()
        {
            foreach (var item in _items)
            {
                item.OnPlayerTriggered -= OnPlayerInteract;
            }
        }
    }
}