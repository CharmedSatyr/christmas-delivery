using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        public DeliveryInstance gift;
        public Vector3 giftOffset;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;

        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            base.Update();

            DisableOnGameOver();

            if (!controlEnabled)
            {
                move.x = 0;
                move.y = 0;
                return;
            }

            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropGift();
            }
        }

        protected override void ComputeVelocity()
        {
            if (move.x > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else if (move.x < -0.01f)
            {
                spriteRenderer.flipX = true;
            }

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            animator.SetFloat("velocityY", Mathf.Abs(velocity.y) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        private void DropGift()
        {
            Instantiate(gift, transform.position + giftOffset, Quaternion.identity);
        }

        private void DisableOnGameOver()
        {
            if (GameController.IsGameOver())
            {
                controlEnabled = false;
            }
        }

        public void Enable()
        {
            controlEnabled = true;
        }
    }
}