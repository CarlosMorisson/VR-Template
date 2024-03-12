using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.XR.Content.Interaction;
using Photon.Pun;

public class VehicleCamera : MonoBehaviour
{



    public Transform target;

    public float smooth = 0.3f;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float Angle = 20;
    public PhotonView view;
    public LayerMask lineOfSightMask = 0;

    public CarUIClass CarUI;
    public Transform DriverPos;
    public XRKnob Steer;
    public XRLever Gear;
    private float yVelocity = 0.0f;
    private float xVelocity = 0.0f;
    [HideInInspector]
    public int Switch;

    private int gearst = 0;
    private float thisAngle = -150;
    private float restTime = 0.0f;


    private Rigidbody myRigidbody;



    public VehicleControl carScript;



    [System.Serializable]
    public class CarUIClass
    {

        public Image tachometerNeedle;
        public Image barShiftGUI;

        public Text speedText;
        public Text GearText;

    }


    


    ////////////////////////////////////////////// TouchMode (Control) ////////////////////////////////////////////////////////////////////


    private int PLValue = 0;


    public void PoliceLightSwitch()
    {

        if (!target.gameObject.GetComponent<PoliceLights>()) return;

        PLValue++;

        if (PLValue > 1) PLValue = 0;

        if (PLValue == 1)
            target.gameObject.GetComponent<PoliceLights>().activeLight = true;

        if (PLValue == 0)
            target.gameObject.GetComponent<PoliceLights>().activeLight = false;


    }





    public void CarAccelForward(float amount)
    {
        carScript.accelFwd = amount;
    }

    public void CarAccelBack(float amount)
    {
        carScript.accelBack = amount;
    }

    public void CarSteer(float amount)
    {
        carScript.steerAmount = amount;
    }

    public void CarHandBrake(bool HBrakeing)
    {
        carScript.brake = HBrakeing;
    }

    public void CarShift(bool Shifting)
    {
        carScript.shift = Shifting;
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    

    public void RestCar()
    {

        if (restTime == 0)
        {
            myRigidbody.AddForce(Vector3.up * 500000);
            myRigidbody.MoveRotation(Quaternion.Euler(0, transform.eulerAngles.y, 0));
            restTime = 2.0f;
        }

    }


    public void RotateSteer()
    {
        Debug.Log(Steer.value);
        CarSteer(Steer.value);

    }
    public void Xlr8()
    {
        if (Gear.value == false)
        {
            CarAccelForward(0);
            CarAccelBack(-1);
        }
        else
        {
            CarAccelForward(1);
            CarAccelBack(0);
        }
    }

    public void ShowCarUI()
    {


        /*
        gearst = carScript.currentGear;
        CarUI.speedText.text = ((int)carScript.speed).ToString();




        if (carScript.carSetting.automaticGear)
        {

            if (gearst > 0 && carScript.speed > 1)
            {
                CarUI.GearText.color = Color.green;
                CarUI.GearText.text = gearst.ToString();
            }
            else if (carScript.speed > 1)
            {
                CarUI.GearText.color = Color.red;
                CarUI.GearText.text = "R";
            }
            else
            {
                CarUI.GearText.color = Color.white;
                CarUI.GearText.text = "N";
            }

        }
        else
        {

            if (carScript.NeutralGear)
            {
                CarUI.GearText.color = Color.white;
                CarUI.GearText.text = "N";
            }
            else
            {
                if (carScript.currentGear != 0)
                {
                    CarUI.GearText.color = Color.green;
                    CarUI.GearText.text = gearst.ToString();
                }
                else
                {

                    CarUI.GearText.color = Color.red;
                    CarUI.GearText.text = "R";
                }
            }

        }





        thisAngle = (carScript.motorRPM / 20) - 175;
        thisAngle = Mathf.Clamp(thisAngle, -180, 90);

        CarUI.tachometerNeedle.rectTransform.rotation = Quaternion.Euler(0, 0, -thisAngle);
        CarUI.barShiftGUI.rectTransform.localScale = new Vector3(carScript.powerShift / 100.0f, 1, 1);*/

    }



    void Start()
    {
        if (view.IsMine)
        {
            carScript = (VehicleControl)target.GetComponent<VehicleControl>();

            myRigidbody = target.GetComponent<Rigidbody>();
        }

    }




    void Update()
    {
        if (view.IsMine)
        {
            Xlr8();
            if (!target) return;

            this.transform.position = DriverPos.transform.position;
            carScript = (VehicleControl)target.GetComponent<VehicleControl>();

            if (Input.GetKeyDown(KeyCode.G))
            {
                RestCar();
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                PoliceLightSwitch();
            }


            if (restTime != 0.0f)
                restTime = Mathf.MoveTowards(restTime, 0.0f, Time.deltaTime);

            ShowCarUI();
        }

    }



    float AdjustLineOfSight(Vector3 target, Vector3 direction)
    {


        RaycastHit hit;

        if (Physics.Raycast(target, direction, out hit, distance, lineOfSightMask.value))
            return hit.distance;
        else
            return distance;

    }


}
