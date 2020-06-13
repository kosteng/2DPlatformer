using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerDataBase", menuName = "Player Database")]

public class PlayerDatabase : ScriptableObject
{
    public float MoveSpeed = 2.5f;
    public float JumpForce = 10f;
}
