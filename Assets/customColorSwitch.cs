using UnityEngine;

public class customColorSwitch : MonoBehaviour
{
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color gazedAtColor;

    private MeshRenderer myRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = inactiveColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter()
    {
        GazeAt(true);
    }

    public void OnPointerExit()
    {
        GazeAt(false);
    }

    public void GazeAt(bool gazing)
    {
        if (gazing)
        {
            myRenderer.material.color = gazedAtColor;
        }
        else
        {
            myRenderer.material.color = inactiveColor;
        }
    }
}
