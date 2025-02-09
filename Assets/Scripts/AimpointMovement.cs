using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class AimpointMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeedHor;
        [SerializeField] private float movementSpeedVert;
        [SerializeField] private InputActionReference playerInputHor;
        [SerializeField] private InputActionReference playerInputVert;
        private CinemachineOrbitalTransposer _cinemachineOrbitalTransposer;

        private void Start()
        {
            _cinemachineOrbitalTransposer = FindObjectOfType<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }

        public void Update()
        {
            Vector2 movementDelta = playerInputHor.action.ReadValue<Vector2>() * (movementSpeedHor * Time.deltaTime);
            float verticalMovementDelta =
                playerInputVert.action.ReadValue<Vector2>().y * (movementSpeedVert * Time.deltaTime);
            float yFreezer = transform.position.y;
            transform.Translate(movementDelta.x, 0, movementDelta.y, _cinemachineOrbitalTransposer.transform);
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yFreezer, transform.position.z),
                quaternion.identity); //TODO temporary solution
            _cinemachineOrbitalTransposer
                .m_FollowOffset.z += verticalMovementDelta * 0.03f;
            _cinemachineOrbitalTransposer.m_FollowOffset.y -= verticalMovementDelta;
        }
    }
}