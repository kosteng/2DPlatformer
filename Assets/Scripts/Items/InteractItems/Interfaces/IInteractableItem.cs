using System;
using UnityEngine;

namespace Items.InteractItems.Interfaces
{
    public interface IInteractableItem
    {
        EInteractItemType ItemType { get; } 
        Transform Transform { get; }
        Transform InPortal { get; }
        event Action<IInteractableItem> OnPlayerTriggered;
    }
}
