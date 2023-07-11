using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigbodyRB;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite; 

    [SerializeField, Range(0, 10)] private float moveSpeed;


    //properties for making footprints on steps
    [SerializeField] private GameObject footPrintPrefab;
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform footPrintParent;
    [SerializeField] private AudioSource footPrintAudio;
    [SerializeField] private AudioClip leftFootAudio;
    [SerializeField] private AudioClip rightFootAudio;
    private bool isRightFoot = false;

    private bool isEquipped = false;

    // Start is called before the first frame update
    void Start()
    {
        isEquippedStateChange();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate() {

        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        Vector2 playerInputVector = new Vector2(horizontalSpeed, verticalSpeed);
        rigbodyRB.velocity = playerInputVector * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed) + Mathf.Abs(verticalSpeed)); 

        if (horizontalSpeed != 0) {
            checkFacingDirection(horizontalSpeed);
        }


    }

    void checkFacingDirection(float horizontalSpeed) {

        //flip if facing left and moving right
        if (sprite.flipX && horizontalSpeed > 0) {
            sprite.flipX = !sprite.flipX;
        }

        //flip if facing right and moving left
        if (!sprite.flipX && horizontalSpeed < 0) {
            sprite.flipX = !sprite.flipX;
        }
    }

    void moveFootPrint() {
        
        //if right foot assign transform to right foot transform
        Transform foot = isRightFoot ? rightFoot : leftFoot;
        GameObject footprint = Instantiate(footPrintPrefab,  new Vector3(foot.position.x, foot.position.y, 0), Quaternion.identity, footPrintParent);
        footprint.GetComponent<SpriteRenderer>().sortingLayerName = "FootSteps";
        FootPrintAudio();

        isRightFoot = !isRightFoot;
    }

    void FootPrintAudio() {
        if (isRightFoot) {
            footPrintAudio.PlayOneShot(rightFootAudio, .6f);
        } else {
            footPrintAudio.PlayOneShot(leftFootAudio, .6f);
        }
    }

    void isEquippedStateChange() {
        isEquipped = !isEquipped;
        animator.SetBool("isEquipped", isEquipped); 
    }

}