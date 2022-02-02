using UnityEngine;
using UnityEngine.UI;

public class Cube_Manipulation : MonoBehaviour
{
    public float rotationSpeed;                                                                         //Set Manual Rotation Speed of Cube
    public Vector3 sizeChange;                                                                          //Set Manual Value of Size Change of Cube 
    public Text countDownTimerText;                                                                     //UI Element of CountDown Timer
    public Text elapsedTimerText;                                                                       //UI Element of Elapsed Timer
    public Text inGameCheckText;                                                                        //UI Element of inGame Check
    public float timeRemaining;                                                                         //Set Manual Value of Total Remaining Game Time
    public bool isGameStarted = false;                                                                  //Ingame check

    private float horizontalInput;
    private float verticalInput;
    private float timeToDisplay = 0;


    private void Start()
    {
        isGameStarted = true;
    }

    void Update()
    {
        if (isGameStarted)
        {
            //Getting Input of Keyboard Keys
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //Rotating transform according to key input
            transform.Rotate(Vector3.forward * Time.deltaTime * verticalInput * rotationSpeed);
            transform.Rotate(Vector3.right * Time.deltaTime * horizontalInput * rotationSpeed);

            //Changing size on spacebar press
            if (Input.GetKey("space"))
            {
                transform.localScale = transform.localScale + sizeChange;
            }
            else
            {
                if (transform.localScale != new Vector3(1, 1, 1))
                    transform.localScale = transform.localScale - sizeChange;
            }

            inGameCheckText.text = "Yes";
        }
        else
            inGameCheckText.text = "No";

    }

    private void FixedUpdate()
    {
        if(isGameStarted)
        {
            DisplayTime();
            inGameCheckText.text = "Yes";
        }
        else
            inGameCheckText.text = "No";
    }


    void DisplayTime()
    {
        if (timeRemaining > 0)
        {
            //Calculations for CountDown Timer
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            countDownTimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);

            //Calculations for Elapsed Timer
            timeToDisplay += Time.deltaTime;
            float mins = Mathf.FloorToInt(timeToDisplay / 60);
            float sec = Mathf.FloorToInt(timeToDisplay % 60);

            elapsedTimerText.text = string.Format("{00:00}:{01:00}", mins, sec);
        }
        else
        {
            countDownTimerText.text = "Time has ended";
            timeRemaining = 0;
            isGameStarted = false;
        }
        

        
    }
}
