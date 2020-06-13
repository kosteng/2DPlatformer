using UnityEngine;
public class PlayerController
{
    private readonly PlayerCharacterView _playerCharacterView;
    private readonly MainCameraView _mainCameraView;
    private readonly PlayerDatabase _playerDatabase;
    private readonly BulletController _bulletController;

    public PlayerController (PlayerDatabase playerDatabase, 
                             PlayerFactory playerFactory, 
                             MainCameraFactory mainCameraFactory, 
                             BulletController bulletController)
    {
        _playerDatabase = playerDatabase;
        _mainCameraView = mainCameraFactory.Create();
        _playerCharacterView = playerFactory.Create();
        _mainCameraView.Target = _playerCharacterView;
        _bulletController = bulletController;
    }

    public void Start()
    {
        SetData();
    }
    
    public void Update(float deltaTime)
    {
        _playerCharacterView.Move();
        _mainCameraView.OnUpdate();
        if (Input.GetKeyDown(KeyCode.F))
            _bulletController.Shoot();
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
