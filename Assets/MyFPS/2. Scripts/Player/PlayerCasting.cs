using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFPS
{
    // 정면에 있는 충돌체와의 거리 구하기
    public class PlayerCasting : MonoBehaviour
    {
        #region Variables
        private bool isCursorOn = false;

        private Controls control;

        public static float distanceFromTarget = Mathf.Infinity;
        [SerializeField] private float toTarget;

        public Transform cameraTransform;
        #endregion

        #region Life Cycle
        private void Update()
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out RaycastHit hit))
            {
                distanceFromTarget = hit.distance;
            }

            toTarget = distanceFromTarget;
        }

        private void Awake()
        {
            control = new Controls();
        }

        private void OnEnable()
        {
            control.Player.CursorModifier.started += OnCursorSwitchStarted;
            control.Player.CursorModifier.canceled += OnCursorSwitchCanceled;

            control.Player.CursorModifier.Enable();
        }

        private void OnDisable()
        {
            control.Player.CursorModifier.Disable();

            control.Player.CursorModifier.started -= OnCursorSwitchStarted;
            control.Player.CursorModifier.canceled -= OnCursorSwitchCanceled;
        }
        #endregion

        #region CursorControl
        public void OnCursorSwitchStarted(InputAction.CallbackContext _) => isCursorOn = CursorSwitch(!isCursorOn);
        public void OnCursorSwitchCanceled(InputAction.CallbackContext _) => isCursorOn = CursorSwitch(!isCursorOn);

        private bool CursorSwitch(bool isCursorOn)
        {
            if (isCursorOn)
            {
                // 마우스 커서 해제
                Cursor.lockState = CursorLockMode.Confined;

                return true;
            }

            else
            {
                // 마우스 커서 잠금
                Cursor.lockState = CursorLockMode.Locked;

                return false;
            }
        }
        #endregion

        // Gizmo 그리기 : 카메라 위치에서 앞의 충돌체까지 레이저를 쏘는 선 그리기
        private void OnDrawGizmos()
        {
            float distance;
            float maxDistance = 100f;
            bool isHit = Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out RaycastHit hit, maxDistance);

            Gizmos.color = Color.red;

            switch (isHit)
            {
                case true:
                    distance = hit.distance;
                    break;

                case false:
                    distance = maxDistance;
                    break;
            }

            Gizmos.DrawRay(cameraTransform.position, cameraTransform.forward * distance);
        }
    }
}