using System.Collections;
using UnityEngine;

public class recoil : MonoBehaviour
{
    public GameObject gun;
    public float recoilDistance = 0.1f;   // Distance to move backwards
    public float recoilAngle = 5f;        // Upward rotation in degrees
    public float recoilSpeed = 20f;       // Speed of kick back
    public float returnSpeed = 10f;       // Speed of returning

    public GameObject AudioManager;
    public GameObject shell;

    private Vector3 originalLocalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        gun = GameObject.FindWithTag("gun");
        originalLocalPosition = gun.transform.localPosition;
        originalRotation = gun.transform.localRotation;
    }

    public void AddRecoil()
    {
        StopAllCoroutines();
        Debug.Log("adding recoil");
        StartCoroutine(RecoilAnimation());
    }

    IEnumerator RecoilAnimation()
    {
        //// Store current transform
        //originalLocalPosition = gun.transform.localPosition;
        //originalRotation = gun.transform.localRotation;

        // Target recoil transform
        Vector3 recoilPosition = originalLocalPosition - Vector3.forward * recoilDistance;
        Quaternion recoilRotation = originalRotation * Quaternion.Euler(-recoilAngle, 0f, 0f);

        // Kick back
        while (
            Vector3.Distance(gun.transform.localPosition, recoilPosition) > 0.001f ||
            Quaternion.Angle(gun.transform.localRotation, recoilRotation) > 0.1f)
        {
            gun.transform.localPosition = Vector3.Lerp(
                gun.transform.localPosition,
                recoilPosition,
                recoilSpeed * Time.deltaTime);

            gun.transform.localRotation = Quaternion.Slerp(
                gun.transform.localRotation,
                recoilRotation,
                recoilSpeed * Time.deltaTime);

            yield return null;
        }

        // Return to original transform
        while (
            Vector3.Distance(gun.transform.localPosition, originalLocalPosition) > 0.001f ||
            Quaternion.Angle(gun.transform.localRotation, originalRotation) > 0.1f)
        {
            gun.transform.localPosition = Vector3.Lerp(
                gun.transform.localPosition,
                originalLocalPosition,
                returnSpeed * Time.deltaTime);

            gun.transform.localRotation = Quaternion.Slerp(
                gun.transform.localRotation,
                originalRotation,
                returnSpeed * Time.deltaTime);

            yield return null;
        }

        // Snap exactly to the original transform
        gun.transform.localPosition = originalLocalPosition;
        gun.transform.localRotation = originalRotation;
    }
}