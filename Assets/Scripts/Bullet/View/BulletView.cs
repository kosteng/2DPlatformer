using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 0.5f);
    }
}
