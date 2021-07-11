using Engine.Mediators;
using Units.Controllers;
using UnityEngine;
using Zenject;

namespace InputControls.CameraControls
{
    public class CameraController : IUpdatable, IInitializable
    {
        private CameraView _cameraView;
        private readonly CharacterMovementController _characterMovementController;
        private float _offet = 7f;

        public CameraController(CameraView cameraView, CharacterMovementController characterMovementController)
        {
            _cameraView = cameraView;
            _characterMovementController = characterMovementController;
        }

        public void Update(float deltaTime)
        {

            _cameraView.transform.position = new Vector3(
                _characterMovementController.CharacterModel.View.transform.position.x,
                _characterMovementController.CharacterModel.View.transform.position.y + _offet,
                -10f); 
        }

        public void Initialize()
        {
            //todo фабрика плачет
            _cameraView = Object.Instantiate(_cameraView, new Vector3(0f, -5f, -10f), Quaternion.identity);
        }
    }
}