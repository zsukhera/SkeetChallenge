using UnityEngine;
using StarterAssets;

public class gun : MonoBehaviour
{
    private StarterAssetsInputs input;
    private bool wasFirePressed;
    private  recoil recoilscript;
    void Start()
    {
        //input = FindObjectOfType<StarterAssetsInputs>();
        recoilscript = GetComponent<recoil>();
        Debug.Log(FindObjectsOfType<StarterAssetsInputs>().Length);
    }

    void HandleFireInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Update()
    {
        HandleFireInput();
    }

    void Fire()
    {
        Debug.Log("Bang!");
        recoilscript.AddRecoil();
        
    }
}