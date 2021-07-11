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
            var row = Random.Range(1, 10);
            var col = Random.Range(1, 10);
            for (int i = 0; i < row; i++)
            {
                var block = CreateBlock(_levelBlocksDatabase.Blocks[0]);
                block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y, 10f);
                block.transform.position = prevPrefab + new Vector3(  70, 0, 0);
                prevPrefab = block.transform.position;
                prevPrefab = new Vector3(prevPrefab.x, 0f, 0f);
                for (int j = 0; j < col; j++)
                {
                    block = CreateBlock(_levelBlocksDatabase.Blocks[0]);
                    block.transform.position = prevPrefab + new Vector3( 0,  -10, 0);
                    prevPrefab = block.transform.position;
                }
            }
        }
    }
}