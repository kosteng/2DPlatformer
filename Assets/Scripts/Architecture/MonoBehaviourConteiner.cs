using UnityEngine;

public class MonoBehaviourConteiner : MonoBehaviour
{
    // prefabs
    public PlayerCharacterView PlayerCharacterView;
    public MainCameraView MainCameraView;
    public BulletView BulletView;

    //Factories
    public PlayerFactory PlayerFactory;
    public MainCameraFactory MainCameraFactory;
    public BulletFactory BulletFactory;

    // Databases
    public PlayerDatabase PlayerDatabase;

}
