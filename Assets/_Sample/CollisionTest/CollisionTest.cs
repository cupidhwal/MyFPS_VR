using UnityEngine;

namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        // 필드
        #region Variables
        private float moveX;
        private Renderer rend;
        private Rigidbody rb;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start()
        {
            rend = GetComponent<Renderer>();
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        void Update()
        {
            MoveInput();
        }
        #endregion

        // 메서드
        #region Methods
        void MoveInput()
        {
            moveX = Input.GetAxisRaw("Horizontal");
        }

        void Move()
        {
            rb.AddForce(moveX * Vector3.right, ForceMode.VelocityChange);
        }
        #endregion

        // 이벤트 메서드
        #region Event Methods
        private void OnCollisionEnter(Collision collision) => rb.AddForce(3 * Vector3.left, ForceMode.VelocityChange);

        private void OnTriggerEnter(Collider other) => rend.material.color = Color.red;

        private void OnTriggerStay(Collider other) => rb.AddForce(Vector3.right, ForceMode.VelocityChange);

        private void OnTriggerExit(Collider other) => rend.material.color = Color.white;
        #endregion
    }
}