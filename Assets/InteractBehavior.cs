using UnityEngine;
using System.Collections;

public class InteractBehavior : MonoBehaviour
{
    public Texture2D crosshairImage;
    public float interactDistance = float.MaxValue;
    private Vector3 lastHitPoint;
    private bool hasHitObject;

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }

    // Use this for initialization
    void Start()
    {
        hasHitObject = false;
    }

    public void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Gizmos.DrawRay(ray);

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*GameObject.FindGameObjectWithTag("Button").GetComponent<PressButton>().Press();
            //*/
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Button"))
                {
                    hit.collider.GetComponent<PressButton>().Press();
                }
                else if(hit.collider.CompareTag("ButtonPart"))
                {
                    hit.collider.GetComponentInParent<PressButton>().Press();
                }
            }
            //*/
        }
        print(transform.position + " " + transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            print(hit.collider.tag);
            lastHitPoint = hit.point;
            //Gizmos.DrawSphere(hit.point, 3f);
        }
    }
}
