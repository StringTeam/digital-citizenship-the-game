using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

namespace ST
{
    public class PlayerDragScript : MonoBehaviour
    {
        //Variables for the Player character and some of the attached systems
        private Vector3 _dragOffset;
        [SerializeField] private float _speed = 1.9f;
        private Rigidbody2D rb;

        public TextMeshProUGUI Score;
        public TextMeshProUGUI FinalScore;
        public TextMeshProUGUI Message;
        public TextMeshProUGUI TimerText;

        public TextMeshProUGUI _answer1;
        public TextMeshProUGUI _answer2;
        public TextMeshProUGUI _answer3;

        public TextMeshProUGUI answer1;
        public TextMeshProUGUI answer2;
        public TextMeshProUGUI answer3;

        public int MazeScore = 25;

        public GameObject ShakeCamera;

        public GameObject Sparks;
        public Transform ParticleSystemTransform;

        private float Timer = 0;
        public int _Timer = 0;

        public string Question;
        public string RightAnswer;
        public string Answer1;
        public string Answer2;

        [SerializeField] private GameObject LevelOver;
        public bool levelover = false;


        // private float Speed;
        // private bool RestoreTime = false;

        //Sets a framerate for the application on Wake up, i limit it here basicly so the computer won't run the game too fast, but so that up to 240hz monitor can still benefit.
        void Awake()
        {
            Application.targetFrameRate = 240;
        }


        //Method when the Player character begins running its script
        private void Start()
        {
            Message.text = "Aika alkaa kun kosketat pelihahmoasi!"; //Shows a message at the topbar message text object
            Score.text = MazeScore.ToString() + " Pisteet";  //Shows the score of the player in the topbar text object
            rb = GetComponent<Rigidbody2D>();
            CinemachineShake.Instance.ShakeCamera(0.1f, .0001f); //To fix the shakinesss of the cam that i've no idea what caused it
            Time.timeScale = 0.0f; //Freezes the game at start, so you can get your bearings first
            GenerateQuestion();
        }


        private void Update()
        {
            Timer += Time.deltaTime;
            int _Timer = (int)Math.Floor(Timer);
            TimerText.text = _Timer.ToString() + " Aika";
        }

        void GenerateQuestion()
        {
            var num = Random.Range(1, 1);
            if (num == 1)
            {
                Question = "Mik‰ tekee 'Space' n‰pp‰in kirjoittaessa teksti‰?";
                RightAnswer = " Tyhj‰n v‰lin";
                Answer1 = " Rivivaihdon";
                Answer2 = " Tyhj‰n rivin";
                var num2 = Random.Range(1, 3);
                if (num2 == 1)
                {
                    _answer1.text = RightAnswer;
                    _answer2.text = Answer1;
                    _answer3.text = Answer2;
                    answer1.text += RightAnswer;
                    answer2.text += Answer1;
                    answer3.text += Answer2;
                }
                else if (num2 == 2)
                {
                    _answer2.text = RightAnswer;
                    _answer1.text = Answer2;
                    _answer3.text = Answer1;
                    answer2.text += RightAnswer;
                    answer1.text += Answer2;
                    answer3.text += Answer1;
                }

                else if (num2 == 3)
                {
                    _answer2.text = Answer2;
                    _answer1.text = Answer1;
                    _answer3.text = RightAnswer;
                    answer2.text += Answer2;
                    answer1.text += Answer1;
                    answer3.text += RightAnswer;
                }
            }
        }
        //This is to test if HitStop effect would work nicely with collision, but i decided it was a detriment in this game to the gameplay experience
        /* 
             if(RestoreTime)
             {
                 if(Time.timeScale < 1f)
                 {
                     Time.timeScale += Time.deltaTime * Speed;
                 }
                 else
                 {
                     Time.timeScale = 1f;
                     RestoreTime = false;
                 }
             }
         }

         public void StopTime(float ChangeTime, int RestoreSpeed, float Delay)
         {
             Speed = RestoreSpeed;

             if(Delay > 0)
             {
                 StopCoroutine(StartTimeAgain(Delay));
                 StartCoroutine(StartTimeAgain(Delay));

             }
             else
             {
                 RestoreTime = true;
             }

             Time.timeScale = ChangeTime;
         }

         IEnumerator StartTimeAgain(float amt)
         {
             yield return new WaitForSecondsRealtime(amt);
             RestoreTime = true;
         } */


        /*  private void FixedUpdate()
          {
              if (Input.GetKey(KeyCode.Mouse0))
                  MouseDrag();
          } */

        //Method for handling collision with the walls and other objects that hinder player movement
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))                        //Checks the collision against Wall tag
            {
                //   StopTime(0.001f, 20, 0.001f);
                ParticleSystem Particle = Sparks.GetComponent<ParticleSystem>();    //Creates a new particle variable from the particle child object attached to the Player character
                Vector2 collisionPoint = other.contacts[0].point;                   //Gets the point of collision, to pinpoint accurately where i want the particles to play
                ParticleSystemTransform.position = new Vector3(collisionPoint.x, collisionPoint.y, ParticleSystemTransform.position.z); //Moves the particle systems Transform to the point of collision
                Particle.Play();                                                    //Tells the particle system to play the particles
                CinemachineShake.Instance.ShakeCamera(20f, .2f);                    //Camerashake that uses a static instance from a script attached to the Cinemachine camera
                MazeScore--;                                                        //Reduces the Score variable by 1 each time player hits a wall or some other object
                Message.text = "Osuit sein‰‰n! V‰hennet‰‰n pisteit‰, ‰l‰ h‰sl‰‰, keskity!"; //Changes the message on the Topbar message object when there's collision
                Score.text = MazeScore.ToString() + " Pisteet";                     //Updates the score on the topbar score object
            }
        }


        void OnParticleCollision(GameObject other)
        {
            if (other.tag == "Wall")                        //Checks the collision against Wall tag
            {
                Debug.Log("Hit the laser");
                CinemachineShake.Instance.ShakeCamera(20f, .2f);                    //Camerashake that uses a static instance from a script attached to the Cinemachine camera
                MazeScore--;                                                        //Reduces the Score variable by 1 each time player hits a wall or some other object
                Message.text = "Osuit Laseriin! V‰hennet‰‰n pisteit‰, ‰l‰ h‰sl‰‰, keskity!"; //Changes the message on the Topbar message object when there's collision
                Score.text = MazeScore.ToString() + " Pisteet";                     //Updates the score on the topbar score object
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Vastaus1"))
            {
                var TargetText = other.gameObject.GetComponent<TextMeshProUGUI>();
                for (int i = 30; i > Timer; i += 10)
                {
                    MazeScore -= 1;
                    if(MazeScore < 0)
                    {
                        MazeScore = 0;
                    }
                }
                if (TargetText.text == RightAnswer)
                {
                    MazeScore += 5;
                }
                levelover = true;
                Time.timeScale = 0.0f;
                LevelOver.SetActive(true);
                Score.text = MazeScore.ToString() + " Pisteet";
                FinalScore.text += MazeScore.ToString();
            }
        }

        void OnMouseDown()                                      //When the player presses the left mousebutton down this method plays
        {
            if (!levelover)
            {
                if (Time.timeScale < 1f)                            //Unfreezes the time if the time is stopped, this is to unfreeze it from the startup freeze
                {
                    Time.timeScale = 1f;
                }
                Message.text = Question;                            //Updates the Question text to the TopBar message object
            }                                                // _dragOffset = transform.position - GetMousePos();
        }

        void OnMouseDrag()                                      //When player is dragging the object this method plays
        {
            if (!levelover)
            {
                Vector2 dir = GetMousePos() - transform.position;   //Saves the direction of the mouse position subtracted by the position of the Player object, to a Vector 2 variable
                                                                    // transform.position = transform.position + new Vector3(0, -1f, 0);
                rb.velocity = dir * _speed;                         //Gives the Player objects rigidBody velocity to the direction saved in the dir variable, and how fast from the _speed variable

                //  rb.position = Vector2.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed + Time.deltaTime); //This was used to move the Player object by RigidBody positioning, but using this method limits how fast it can move, because after 1.9 speed it starts ignoring colliders
            }
        }

        Vector3 GetMousePos()                                                   //Vector 3 type method for getting the mouseposition from the camera
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Saves the position of the mouse cursor on the camera to a Vector3 variable
            return mousePos;                                                    //Returns the Vector3 variable to where the method was called
        }

    }
}
