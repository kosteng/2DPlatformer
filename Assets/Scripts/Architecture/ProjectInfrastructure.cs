public class ProjectInfrastructure 
{
    private MonoBehaviourConteiner _monoBehaviourConteiner;
    private readonly PlayerController _playerController;
    private readonly PlayerModel _playerModel;
    private readonly Pool<BulletView> _bulletPool;
    private readonly BulletController _bulletController;
    public ProjectInfrastructure (MonoBehaviourConteiner monoBehaviourConteiner)
    {
        _monoBehaviourConteiner = monoBehaviourConteiner;
        _playerModel = new PlayerModel();
        _bulletPool = new Pool<BulletView>(_monoBehaviourConteiner.BulletFactory);
        _bulletController = new BulletController(_bulletPool);
        _playerController = new PlayerController(_monoBehaviourConteiner.PlayerDatabase, 
                                                 _monoBehaviourConteiner.PlayerFactory, 
                                                 _monoBehaviourConteiner.MainCameraFactory,
                                                 _bulletController);
  
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
