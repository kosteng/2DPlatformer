using System.CodeDom.Compiler;
using UnityEngine;

namespace LevelGeneration
{
    public interface ILevelGenerator
    {
        void Generate();
    }
    public class LevelGenerator : ILevelGenerator
    {
        private readonly LevelBlocksDatabase _levelBlocksDatabase;

        public LevelGenerator(LevelBlocksDatabase levelBlocksDatabase)
        {
            _levelBlocksDatabase = levelBlocksDatabase;
        }

        private GameObject CreateBlock(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }
        public void Generate()
        {
            var prevPrefab = Vector3.zero;
            var row = Random.Range(0, 100);
            var col = Random.Range(0, 100);
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    var block = CreateBlock(_levelBlocksDatabase.Blocks[0]);
                    block.transform.position += prevPrefab + new Vector3( i * 10, j * 10, 0);
                    prevPrefab =  block.transform.position;
                }
            }
        }
    }
}