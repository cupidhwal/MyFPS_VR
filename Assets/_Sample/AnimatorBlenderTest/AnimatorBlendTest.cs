using UnityEngine;

namespace Sample
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        // 필드
        #region Variables
        // 이동
        [SerializeField] private float moveSpeed = 5f;

        // 입력값
        private float moveX;
        private float moveY;

        // 컴포넌트
        private Animator animator;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            Move();

            MoveAni();
        }
        #endregion

        // 메서드
        #region Methods
        // 이동 입력과 실행을 관장하는 메서드
        void Move()
        {
            // 앞뒤좌우 입력 처리
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            // 이동 방향, 속도
            Vector3 dir = new(moveX, 0, moveY);
            transform.Translate(moveSpeed * Time.deltaTime * dir.normalized, Space.World);
        }

        // 이동 애니메이션을 관장하는 메서드
        void MoveAni()
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }
        #endregion
    }
}

#region Dummy
/*
// 필드
        #region Variables
        // 이동
        [SerializeField] private float moveSpeed = 5f;

        // 입력값
        private float moveX;
        private float moveY;

        // 컴포넌트
        private Animator animator;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            Move();

            MoveAni();
        }
        #endregion

        // 메서드
        #region Methods
        // 이동 입력과 실행을 관장하는 메서드
        void Move()
        {
            // 앞뒤좌우 입력 처리
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");

            // 이동 방향, 속도
            Vector3 dir = new(moveX, 0, moveY);
            transform.Translate(moveSpeed * Time.deltaTime * dir.normalized, Space.World);
        }

        // 이동 애니메이션을 관장하는 메서드
        void MoveAni()
        {
            // 임시 변수
            int moveS;

            if (moveY != 0)
                switch (moveY > 0)
                {
                    case true:
                        moveS = 1;
                        break;

                    case false:
                        moveS = 2;
                        break;
                }

            else if (moveX != 0)
                switch (moveX > 0)
                {
                    case true:
                        moveS = 3;
                        break;

                    case false:
                        moveS = 4;
                        break;
                }

            else
                moveS = 0;

            animator.SetInteger("MoveState", moveS);
        }
        #endregion
 */
#endregion