using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float minZ = -55f , maxZ = 55f , rotateSpeed = 5f , moveSpeed = 5f , minY = -2.5f;
    private float rotateAngle , initialMoveSpeed , initialY;
    private bool rotateRight , canRotate , moveDown;
    private RopeRenderer ropeRenderer;
    [SerializeField] HookScript hookScript;

    void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        initialY = transform.position.y;
        initialMoveSpeed = moveSpeed;
        canRotate = true;
    }

    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate(){
        if(canRotate){
            if(rotateRight){
                rotateAngle += rotateSpeed * Time.deltaTime;
            }else{
                rotateAngle -= rotateSpeed * Time.deltaTime;
            }
            transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
            if(rotateAngle >= maxZ){
                rotateRight = false;
            }
            else if(rotateAngle <= minZ){
                rotateRight = true;
            }
        }
    }

    void GetInput(){
        if(Input.GetMouseButtonDown(0) && !(hookScript.itemAttached)){
            moveSpeed = initialMoveSpeed;
            canRotate = false;
            moveDown = true;
            SoundManager.instance.RopeStrechSound(true);
        }
    }

    void MoveRope(){
        if(!canRotate){
            Vector3 temp = transform.position;
            if(moveDown){
                temp -= transform.up * moveSpeed * Time.deltaTime;
            }
            else{
                temp += transform.up * moveSpeed * Time.deltaTime;
            }
            transform.position = temp;
            if(temp.y <= minY){
                moveDown = false;
            }
            if(temp.y >= initialY){
                canRotate = true;
                ropeRenderer.RenderLine(temp , false);
                moveSpeed = initialMoveSpeed;
                SoundManager.instance.RopeStrechSound(false);   

            }
            ropeRenderer.RenderLine(temp , true);
        }
    }

    public void HookAttachedItem(){
        moveDown = false;
    }
}
