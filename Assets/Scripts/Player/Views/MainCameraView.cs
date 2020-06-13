using UnityEngine;

public class MainCameraView : MonoBehaviour
{

    public PlayerCharacterView Target;
    private const float offsetZ = -10f;

    public void OnUpdate()
    {
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, offsetZ);
    }
}
