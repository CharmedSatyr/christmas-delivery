using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;

        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;
        internal GameObject _gameController;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _gameController = GameObject.Find("GameController");
            if (_gameController == null)
            {
                Debug.Log("TokenInstance::Unable to find GameController");
            }
            else
            {
                Debug.Log("TokenInstance::Found gameController" + _gameController.name);
                
                Component[] components = _gameController.GetComponents(typeof(Component));
                for (int i = 0; i < components.Length; i++)
                {
                    Debug.Log(components[i].ToString());
                }
                
            }

            if (this.tag == "Candies")
            {
                //Candies are only a single frame, so there's no animation
                //The idleAnimation[] is full of single frame of a single kind of candy
                
                
                Debug.Log("candy found");
                Debug.Log("sprites Length:" + sprites.Length);
                Debug.Log("idleAnimation Length: " + idleAnimation.Length);

                //if(randomAnimationStartTime)
                    
                frame = Random.Range(0, idleAnimation.Length);

                Debug.Log("random candy index: " + frame);

                for (int x = 0; x < idleAnimation.Length; x++)
                {
                    if (x != frame)
                    {
                        idleAnimation[x] = idleAnimation[frame];
                    }
                }

                sprites = idleAnimation;

            } else
            {
                //this is the default template code
                if (randomAnimationStartTime)
                    frame = Random.Range(0, sprites.Length);

                sprites = idleAnimation;
            }

           
        }

        void OnTriggerEnter2D(Collider2D other)
        {


            _gameController.GetComponent<Platformer.Mechanics.Timer>().AddTime();

            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }


        //When the player collects the item
        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            //disable the gameObject and remove it from the controller update list.
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;

           

            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerTokenCollision>();
            ev.token = this;
            ev.player = player;

            
        }
    }
}