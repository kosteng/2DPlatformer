using Items.ResourceItems;
using System;
using UnityEngine;

namespace Items.InteractItems
{
    [CreateAssetMenu(menuName = "DatabasesSO/InteractItemsDatabase")]

    public class InteractItemsDatabase : ScriptableObject
    {
        public InteractItemsData[] InteractItemsData;
    }
    
[Serializable]
    public class InteractItemsData
    {
        [SerializeField] private EInteractItemType _type;
        [SerializeField] private InteractableItemView _itemView;

        public EInteractItemType Type => _type;
        public InteractableItemView ItemView => _itemView;
    }
}
