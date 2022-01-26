// Copyright 2021, Infima Games. All Rights Reserved.

using System.Linq;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class Movement : MovementBehaviour
    {
        /// <summary>
        /// A helper for assistance with smoothing the movement.
        /// </summary>
        private class SmoothVelocity
        {
            /// <summary>
            /// Value Getter.
            /// </summary>
            public Vector3 Value { get; private set; }

            /// <summary>
            /// Current Velocity. Used for proper SmoothDamp use.
            /// </summary>
            private Vector3 currentVelocity;

            /// <summary>
            /// Updates the value!
            /// </summary>
            /// <param name="target">Target value.</param>
            /// <param name="smoothTime">How smooth the motion should be.</param>
            /// <returns></returns>
            public Vector3 Update(Vector3 target, float smoothTime) => Value = Vector3.SmoothDamp(Value,
                target, ref currentVelocity, smoothTime);
        }
        
        #region FIELDS SERIALIZED

        [Header("Audio Clips")]
        
        [Tooltip("The audio clip that is played while walking.")]
        [SerializeField]
        private AudioClip audioClipWalking;

        [Tooltip("The audio clip that is played while running.")]
        [SerializeField]
        private AudioClip audioClipRunning;

        [Header("Speeds")]

        [SerializeField]
        private float speedWalking = 5.0f;
        
        [Tooltip("How fast the player moves while aiming.")]
        [SerializeField]
        private float speedAiming = 3.0f;

        [Tooltip("How fast the player moves while running."), SerializeField]
        private float speedRunning = 9.0f;
        
        [Header("Walking Multipliers")]
        
        [Tooltip("How fast the character moves forward."), SerializeField]
        private float walkingMultiplierForward = 1.0f;

        [Tooltip("How fast the character moves sideways.")]
        [SerializeField]
        private float walkingMultiplierSideways = 0.8f;

        [Tooltip("How fast the character moves backwards.")]
        [SerializeField]
        private float walkingMultiplierBackwards = 0.8f;
        
        [Header("Interpolation")]

        [Tooltip("Approximately the amount of time it will take for the player to reach maximum running or walking speed.")]
        [SerializeField]
        private float movementSmoothness = 0.125f;

        #endregion

        #region PROPERTIES

        //Velocity.
        private Vector3 Velocity
        {
            //Getter.
            get => rigidBody.velocity;
            //Setter.
            set => rigidBody.velocity = smoothVelocity.Update(value, movementSmoothness);
        }

        #endregion

        #region FIELDS

        /// <summary>
        /// Attached Rigidbody.
        /// </summary>
        private Rigidbody rigidBody;
        /// <summary>
        /// Attached CapsuleCollider.
        /// </summary>
        private CapsuleCollider capsule;
        /// <summary>
        /// Attached AudioSource.
        /// </summary>
        private AudioSource audioSource;
        
        /// <summary>
        /// Velocity Smoothing Helper. Basically does what it says, it helps us make the velocity smoother.
        /// </summary>
        private SmoothVelocity smoothVelocity;
        
        /// <summary>
        /// True if the character is currently grounded.
        /// </summary>
        private bool grounded;

        /// <summary>
        /// Player Character.
        /// </summary>
        private CharacterBehaviour playerCharacter;
        /// <summary>
        /// The player character's equipped weapon.
        /// </summary>
        private WeaponBehaviour equippedWeapon;
        
        /// <summary>
        /// Array of RaycastHits used for ground checking.
        /// </summary>
        private readonly RaycastHit[] groundHits = new RaycastHit[8];

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        protected override void Awake()
        {
            //Get Player Character.
            playerCharacter = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        }

        /// Initializes the FpsController on start.
        protected override  void Start()
        {
            //Rigidbody Setup.
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            //Cache the CapsuleCollider.
            capsule = GetComponent<CapsuleCollider>();

            //Audio Source Setup.
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipWalking;
            audioSource.loop = true;
            
            //Create our smooth velocity helper. Will be useful to get some smoother motion.
            smoothVelocity = new SmoothVelocity();
        }

        /// Checks if the character is on the ground.
        private void OnCollisionStay()
        {
            //Bounds.
            Bounds bounds = capsule.bounds;
            //Extents.
            Vector3 extents = bounds.extents;
            //Radius.
            float radius = extents.x - 0.01f;
            
            //Cast. This checks whether there is indeed ground, or not.
            Physics.SphereCastNonAlloc(bounds.center, radius, Vector3.down,
                groundHits, extents.y - radius * 0.5f, ~0, QueryTriggerInteraction.Ignore);
            
            //We can ignore the rest if we don't have any proper hits.
            if (!groundHits.Any(hit => hit.collider != null && hit.collider != capsule)) 
                return;
            
            //Store RaycastHits.
            for (var i = 0; i < groundHits.Length; i++)
                groundHits[i] = new RaycastHit();

            //Set grounded. Now we know for sure that we're grounded.
            grounded = true;
        }
			
        protected override void FixedUpdate()
        {
            //Move.
            MoveCharacter();
            
            //Unground.
            grounded = false;
        }

        /// Moves the camera to the character, processes jumping and plays sounds every frame.
        protected override  void Update()
        {
            //Get the equipped weapon!
            equippedWeapon = playerCharacter.GetInventory().GetEquipped();
            
            //Play Sounds!
            PlayFootstepSounds();
        }

        #endregion

        #region METHODS

        private void MoveCharacter()
        {
            #region Calculate Movement Velocity

            //Get Movement Input!
            Vector2 frameInput = playerCharacter.GetInputMovement();
            //Calculate local-space direction by using the player's input.
            var movement = new Vector3(frameInput.x, 0.0f, frameInput.y);
            
            //Running speed calculation.
            if(playerCharacter.IsRunning())
                movement *= speedRunning;
            else
            {
                //Aiming speed calculation.
                if (playerCharacter.IsAiming())
                    movement *= speedAiming;
                else
                {
                    //Multiply by the normal walking speed.
                    movement *= speedWalking;
                    //Multiply by the sideways multiplier, to get better feeling sideways movement.
                    movement.x *= walkingMultiplierSideways;
                    //Multiply by the forwards and backwards multiplier.
                    movement.z *= (frameInput.y > 0 ? walkingMultiplierForward : walkingMultiplierBackwards);
                }
            }

            //World space velocity calculation. This allows us to add it to the rigidbody's velocity properly.
            movement = transform.TransformDirection(movement);
            //Multiply by the weapon movement speed multiplier. This helps us modify speeds based on the weapon!
            if (equippedWeapon != null)
                movement *= equippedWeapon.GetMultiplierMovementSpeed();

            #endregion
            
            //Update Velocity.
            Velocity = new Vector3(movement.x, 0.0f, movement.z);
        }

        /// <summary>
        /// Plays Footstep Sounds. This code is slightly old, so may not be great, but it functions alright-y!
        /// </summary>
        private void PlayFootstepSounds()
        {
            //Check if we're moving on the ground. We don't need footsteps in the air.
            if (grounded && rigidBody.velocity.sqrMagnitude > 0.1f)
            {
                //Select the correct audio clip to play.
                audioSource.clip = playerCharacter.IsRunning() ? audioClipRunning : audioClipWalking;
                //Play it!
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            //Pause it if we're doing something like flying, or not moving!
            else if (audioSource.isPlaying)
                audioSource.Pause();
        }

        #endregion

        #region GETTERS

        public override float GetMultiplierForward() => walkingMultiplierForward;
        public override float GetMultiplierSideways() => walkingMultiplierSideways;
        public override float GetMultiplierBackwards() => walkingMultiplierBackwards;

        #endregion
    }
}