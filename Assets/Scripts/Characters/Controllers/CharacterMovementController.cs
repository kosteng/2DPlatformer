using Characters;
using Engine.Mediators;
using InputControls;
using InputControls.InpitClicker;
using Items;
using Items.ResourceItems;
using UnityEngine;

namespace Units.Controllers
{
    //todo класс фактически стал полностью контроллировать перса, нужно переделать
    public class CharacterMovementController : IUpdatable
    {
        private readonly IInputClicker _inputClicker;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly ICharacterAnimationSwitcher _characterAnimationSwitcher;
        private readonly InteractableItemController _interactableItemController;

        private readonly CharacterModel _characterModel;
        private Vector3 _pointDestination;
        private Vector2 _direction;
        private bool _isLeft;

        public Transform UnitViewTransform => _characterModel.View.transform;
        public CharacterModel CharacterModel => _characterModel;
        public CharacterMovementController(
            CharactersDatabase charactersDatabase,
            IInputClicker inputClicker,
            IPlayerInputControls playerInputControls,
            ICharacterAnimationSwitcher characterAnimationSwitcher,
            ResourceItemsDatabase resourceItemsDatabase,
            InteractableItemController interactableItemController)
        {
            _inputClicker = inputClicker;
            _playerInputControls = playerInputControls;
            _characterAnimationSwitcher = characterAnimationSwitcher;
            _interactableItemController = interactableItemController;

            _characterModel = new CharacterModel(resourceItemsDatabase);
            
            //todo нужна фабрика
            if (_characterModel.View == null)
                _characterModel.View = Object.Instantiate(charactersDatabase.CharacterModels[0].View);
            _characterModel.View.transform.position = new Vector2(_interactableItemController.InteractableItem.Transform.position.x, 
                _interactableItemController.InteractableItem.Transform.position.y + 1f);
            
            _interactableItemController.SetPlayer(_characterModel);
        }

        private float _speed = 1;
        private float _jumpForce = 4f;

        public void Update(float deltaTime)
        {
            Move();
            Jump();
        }
        public void Jump()
        {
            if ((Input.GetKeyDown(KeyCode.Space)))
            {
                if (!_characterModel.View.IsJumped)
                {
                    Jumping();
                }
            }
        }

        private void Jumping()
        {
            if (!_characterModel.View.IsJumped)
            {
                _characterModel.View.IsJumped = true;
                _characterModel.View.Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
 
        public void Move()
        {
            _direction.x = Input.GetAxis("Horizontal") * _speed;
            if (_direction.x > 0)
            {
                MoveToRight();
            }

            if (_direction.x < 0)
            {
                MoveToLeft();
            }
        }
        
        private void MoveToRight()
        {
            _characterModel.View.transform.Translate(Time.deltaTime * _direction.x * _speed, 0, 0);
            _characterModel.View.transform.rotation = Quaternion.Euler(0,0,0);
            _isLeft = false;
        }

        private void MoveToLeft()
        {
            _characterModel.View.transform.Translate(Time.deltaTime * -_direction.x * _speed, 0, 0);
            _characterModel.View.transform.rotation = Quaternion.Euler(0, 180, 0);
            _isLeft = true;
        }
    }
}

// if(Input.GetKey(KeyCode.D))
//     _characterModel.View.Rigidbody2D.velocity = Vector2.right;
// if(Input.GetKey(KeyCode.A))
//     _characterModel.View.Rigidbody2D.velocity = Vector2.left;
// if(Input.GetKeyDown(KeyCode.Space))
//     _characterModel.View.Rigidbody2D.AddForce(new Vector2(0f,_jumpForce));
//   _characterModel.IsMoving =
//       _characterModel.View.NavMeshAgent.remainingDistance > _characterModel.View.NavMeshAgent.stoppingDistance;
//      CheckTargetForMove();
   
// if (_characterModel.IsMoving)
//     CheckStopState();
//
// _characterAnimationSwitcher.UpdateAnimation(_characterModel);
// SetMovementState();
// CheckInteract();

//  private void CheckTargetForMove()
//  {
//      if (_inputClicker.Click(ref _characterModel.InteractableItemTarget, ref _pointDestination))
//          MoveToPoint(_pointDestination);
//  }
//
//  private void SetMovementState()
//  {
//      _characterModel.CharacterCurrentState = _characterModel.IsMoving ? ECharacterState.Move : ECharacterState.Idle;
//  }
//
//  private void MoveToPoint(Vector3 point)
//  {
//      _characterModel.View.transform.LookAt(point);
//      _pointDestination = point;
//  //    _characterModel.View.NavMeshAgent.SetDestination(_pointDestination);
//  }
//
//  private void CheckStopState()
//  {
// //     _characterModel.View.NavMeshAgent.isStopped = !_characterModel.IsMoving;
//  }
//
//  private void CheckInteract()
//  {
//    //  _characterModel.CharacterCurrentState =
//          // _characterModel.InteractableItemTarget != null && _characterModel.View.NavMeshAgent.remainingDistance < 1.3f // todo вынести в конфиг
//          //     ? ECharacterState.Interact
//          //     : _characterModel.CharacterCurrentState;
//  }