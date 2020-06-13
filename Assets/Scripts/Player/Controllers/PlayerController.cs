public class PlayerController
{
    private readonly PlayerCharacterView _playerCharacterView;
    private readonly MainCameraView _mainCameraView;
    private readonly PlayerDatabase _playerDatabase;

    public PlayerController (PlayerDatabase playerDatabase, PlayerFactory playerFactory, MainCameraFactory mainCameraFactory)
    {
        _playerDatabase = playerDatabase;
        _mainCameraView = mainCameraFactory.Create();
        _playerCharacterView = playerFactory.Create();
        _mainCameraView.Target = _playerCharacterView;
    }

    public void Start()
    {
        SetData();
    }
    
    public void Update(float deltaTime)
    {
        _playerCharacterView.Move();
        _mainCameraView.OnUpdate();
    }

    public void FixedUpdate()
    {
        _playerCharacterView.Jump();
    }

    private void SetData()
    {
        _playerCharacterView.moveSpeed = _playerDatabase.MoveSpeed;
        _playerCharacterView.jumpForce = _playerDatabase.JumpForce;
    }
}
