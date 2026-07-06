using UnityEngine;
using StarterAssets;
using System.Collections;

public class gun : MonoBehaviour
{
    private GameObject audioManager;
    private StarterAssetsInputs input;
    private bool wasFirePressed;
    private  recoil recoilscript;
    [Header ("Useable Objects")]
    public GameObject muzzleflash;
    void Start()
    {
        //input = FindObjectOfType<StarterAssetsInputs>();
        recoilscript = GetComponent<recoil>();
        Debug.Log(FindObjectsOfType<StarterAssetsInputs>().Length);
        //muzzleflash = GameObject.Find("muzzleFlash");
        //since muzzle flash is initially set as false
        //we cannot use FindWithTag()
        if (!muzzleflash)
            Debug.Log("Did not find muzzleflash");
        muzzleflash.SetActive(false);

        //audio manager
        audioManager = GameObject.FindWithTag("audioMan");
    }

    void HandleFireInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            StartCoroutine(muzzleFlash());
        }
    }


    IEnumerator muzzleFlash()
    {
        Debug.Log("Muzzle flash on");
        muzzleflash.SetActive(true);
        audioManager.GetComponent<audioScript>().playFireSound();
        yield return new WaitForSeconds(0.05f);
        muzzleflash.SetActive(false);
        Debug.Log("Muzzle flash off");
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