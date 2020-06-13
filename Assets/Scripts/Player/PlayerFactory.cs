using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    [SerializeField] private PlayerCharacterView _playerPrefab;
    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private Transform _parent;

    public PlayerCharacterView Create ()
    {
        var player = Instantiate(_playerPrefab, _playerStartPosition.position, Quaternion.identity);
        SetParent(player);
        return player;
    }
    
    private void SetParent(PlayerCharacterView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}

