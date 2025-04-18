using UnityEngine;

namespace KinematicCharacterController.Examples
{
    public class ExamplePlayer : MonoBehaviour
    {
        public Transform Character;
        public ExampleCharacterCamera CharacterCamera;

        public float Speed = 5.0f;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";

        private const string MovementHorizontal = "Horizontal";
        private const string MovementVertical = "Vertical";

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Tell camera to follow transform
            CharacterCamera.SetFollowTransform(Character);

            // Ignore the character's collider(s) for camera obstruction checks
            CharacterCamera.IgnoredColliders.Clear();
            CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            RotateCharacterBasedOnCamera();

            HandleMovement();
        }

        private void LateUpdate()
        {
            HandleCameraInput();
        }

        private void HandleMovement()
        {
            float moveHorizontal = Input.GetAxisRaw(MovementHorizontal);
            float moveVertical = Input.GetAxisRaw(MovementVertical);

            Vector3 playerForward = Character.forward;
            Vector3 playerRight = Vector3.Cross(Vector3.up, playerForward);
            // Note that this is NOT normalized - it takes into account the amount of input on each axis
            Vector3 movementDirection = playerForward * moveVertical + playerRight * moveHorizontal;

            Character.position += movementDirection * Time.deltaTime * Speed;
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                lookInputVector = Vector3.zero;
            }

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            float scrollInput = -Input.GetAxis(MouseScrollInput);
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            CharacterCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

            // Handle toggling zoom level
            if (Input.GetMouseButtonDown(1))
            {
                CharacterCamera.TargetDistance = (CharacterCamera.TargetDistance == 0f) ? CharacterCamera.DefaultDistance : 0f;
            }
        }

        private void RotateCharacterBasedOnCamera()
        {
            if(CharacterCamera != null)
            {
                // Rotate only around the Y Axis, so that the camera is directly behind the player
                float cameraRotation = CharacterCamera.transform.rotation.eulerAngles.y;
                Character.rotation = Quaternion.AngleAxis(cameraRotation, Vector3.up);
            }
        }
    }
}