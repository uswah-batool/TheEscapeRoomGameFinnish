using TMPro;
using UnityEngine;

public class customPainting : MonoBehaviour
{
    public RadialProgressBar canvasScript;
    //private MeshRenderer myRenderer;
    private bool gazeChange = false;
    private float myTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeChange)
        {
            myTimer += Time.deltaTime;
            if (myTimer >= 3f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void OnPointerEnter()
    {
        canvasScript.StartProgress(); // Start showing progress bar
        GazeAt(true);
        
    }

    public void OnPointerExit()
    {
        canvasScript.StopProgress(); // Hide progress bar
        GazeAt(false);
    }

    public void GazeAt(bool gazing)
    {
        if (gazing)
        {
            gazeChange = true;
        }
        else
        {
            myTimer = 0f;
            gazeChange = false;
        }
    }
}
