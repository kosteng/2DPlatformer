using UnityEngine;

namespace LevelGeneration
{
    [CreateAssetMenu(fileName = "LevelBlocksDatabase", menuName = "LevelBlocksDatabase", order = 0)]
    public class LevelBlocksDatabase : ScriptableObject
    {
        [SerializeField] private GameObject[] _blocks;
        public GameObject[] Blocks => _blocks;
    }
}