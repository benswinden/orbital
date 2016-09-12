﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ImageGizmo : MonoBehaviour {

    public int imageNumber;             /// 0 - 4

    public bool startActivated;

    public Material matBlack;
    public Material matGreen;

    public List<MeshRenderer> thingsToChangeColor;

    public List<Sprite> possibleImages;

    public Sprite image;

    Animation animation;    

    public bool activated { get; set; }

    string animationName;
    
    

    void Awake() {

        animation = GetComponent<Animation>();
    }

    void Start() {

        if (image == null && possibleImages.Count > 0)
            image = possibleImages[Random.Range(0, possibleImages.Count)];


        if (animation) {
            animationName = animation.clip.name;
            animation[animationName].speed = 1;
        }

        if (startActivated)
            Toggle();
    }

    void Update() {

    }

    public void Toggle() {
        
        if (activated) {
                
            //foreach (MeshRenderer obj in thingsToChangeColor) {

            //    obj.material = matBlack;
            //}

            //Manager.worldUI.worldImageHolder.startAnimation(imageNumber);
            //Manager.worldUI.worldImageHolder.gameObject.SetActive(false);

            //activated = false;
            
            //if (animation)
            //    animation[animationName].speed = 1; 
         
        }
        else {

            if (Manager.rea.FPMode)
                Manager.rea.toggleMode();

            foreach (MeshRenderer obj in thingsToChangeColor) {

                obj.material = matGreen;
            }

            Manager.worldUI.worldImageHolder.gameObject.SetActive(true);
            Manager.worldUI.worldImageHolder.startAnimation(imageNumber);            
            Manager.worldUI.worldImageHolder.GetComponentInChildren<SpriteRenderer>().sprite = image;

            activated = true;

            StartCoroutine("wait");

            if (animation)
                animation.Stop();
        }        
    }

    IEnumerator wait() {

        yield return new WaitForSeconds(0.2f);

        GetComponent<Gizmo>().hoverExit();
        Manager.worldUI.removeGizmo(GetComponent<Gizmo>());
        GetComponent<Gizmo>().follower.GetComponent<Follower>().kill();
    }

    void OnDisable() {

        //foreach (MeshRenderer obj in thingsToChangeColor) {

        //    obj.material = matBlack;
        //}

        //Manager.worldUI.worldImageHolder.SetActive(false);

        //activated = false;

        //if (animation)
        //    animation[animationName].speed = 1; 
    }

    void OnEnable() {

    }
}