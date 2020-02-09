public class ProjectInfrastructure 
{
    private MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
    private readonly PlayerController _playerController;
    public ProjectInfrastructure (MonoBehaviourServiceLocator monoBehaviourServiceLocator)
    {
        _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        _playerController = new PlayerController(monoBehaviourServiceLocator.PlayerCharacterView);
    }

    public void Start()
    {
        _playerController.Start();
    }

    public void Update(float deltaTime)
    {
        _playerController.Update();
    }

    public void FixedUpdate (float deltaTime)
    {
        _playerController.FixedUpdate();
    }
}
