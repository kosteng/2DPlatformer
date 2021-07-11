using Items.InteractItems.Interfaces;
using System;
using UnityEngine;

namespace Items.InteractItems
{
    public class InteractableItemView : MonoBehaviour, IInteractableItem
    {
        [SerializeField] private EInteractItemType _itemType;
        [SerializeField] private Transform _inPortal;
        
        public event Action<IInteractableItem> OnPlayerTriggered;
        public EInteractItemType ItemType => _itemType;
 
        public Transform Transform => transform;
        public Transform InPortal => _inPortal;


        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerTriggered?.Invoke(this);
            }
        }
        
    }
}