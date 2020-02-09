public class PlayerController
{
    private readonly PlayerCharacterView _playerCharacterView;
    private readonly PlayerModel _playerModel;

    public PlayerController (PlayerCharacterView playerCharacterView)
    {
        _playerModel = new PlayerModel();
        _playerCharacterView = playerCharacterView;
    }

    public void Start()
    {
        SetData();
    }

    
    public void Update()
    {
        _playerCharacterView.Move();
    }

    public void FixedUpdate()
    {
        _playerCharacterView.Jump();
    }
    private void SetData()
    {
        _playerCharacterView.moveSpeed = _playerModel.moveSpeed;
        _playerCharacterView.jumpForce = _playerModel.jumpForce;
    }
}
