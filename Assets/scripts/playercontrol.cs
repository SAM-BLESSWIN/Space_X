using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playercontrol : MonoBehaviour
{
    [Header("general")]
    [Tooltip("ms^-1")] [SerializeField] float speed = 15f;
    [Tooltip("m")] [SerializeField] float xrange = 5f;
    [Tooltip("m")][SerializeField] float yrange = 3f;

    [Header("position")]
    [SerializeField] float positionpitchfactor = -5f;
    [SerializeField] float positionyowfactor = 3f;

    [Header("control")]
    [SerializeField] float controlpitchfactor = -25f;
    [SerializeField] float controlrollfactor = -15f;

    [SerializeField] GameObject[] guns;

    float xthrow, ythrow;

    bool control = true;
    // Update is called once per frame
    void Update()
    {
        if (control)
        {
            translation();
            rotation();
            firing();
        }
    }
    void playerdead()
    {
        control = false;
    }
    private void rotation()
    {
        float pitch=transform.localPosition.y*positionpitchfactor + ythrow*controlpitchfactor;
        float yow=transform.localPosition.x*positionyowfactor;
        float roll=xthrow*controlrollfactor;
        transform.localRotation = Quaternion.Euler(pitch,yow,roll);
    }

    private void translation()
    {
        xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float offsetxvalue = xthrow * speed * Time.deltaTime;
        float xvalue = transform.localPosition.x + offsetxvalue;
        float xclamp = Mathf.Clamp(xvalue, -xrange, +xrange);

        ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        float offsetyvalue = ythrow * speed * Time.deltaTime;
        float yvalue = transform.localPosition.y + offsetyvalue;
        float yclamp = Mathf.Clamp(yvalue, -yrange, +yrange);

        transform.localPosition = new Vector3(xclamp, yclamp, transform.localPosition.z);
    }
    
    void firing()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            firecontrol(true);
        }
        else
        {
            firecontrol(false);
        }
    }

    private void firecontrol(bool fire)
    {
        foreach (GameObject gun in guns)
        {
            var emisioncontrol = gun.GetComponent<ParticleSystem>().emission;
            emisioncontrol.enabled = fire;
        }
    }
}
