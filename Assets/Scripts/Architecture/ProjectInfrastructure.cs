public class ProjectInfrastructure 
{
    private MonoBehaviourConteiner _monoBehaviourConteiner;
    private readonly PlayerController _playerController;
    private readonly PlayerModel _playerModel;

    public ProjectInfrastructure (MonoBehaviourConteiner monoBehaviourConteiner)
    {
        _monoBehaviourConteiner = monoBehaviourConteiner;
        _playerModel = new PlayerModel();
        _playerController = new PlayerController(_monoBehaviourConteiner.PlayerDatabase, 
                                                 _monoBehaviourConteiner.PlayerFactory, 
                                                 _monoBehaviourConteiner.MainCameraFactory);
    }

    public void Start()
    {
        _playerController.Start();
    }

    public void Update(float deltaTime)
    {
        _playerController.Update(deltaTime);
    }

    public void FixedUpdate (float deltaTime)
    {
        _playerController.FixedUpdate();
    }
}
