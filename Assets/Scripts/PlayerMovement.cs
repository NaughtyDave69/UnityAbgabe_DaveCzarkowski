using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb; // RigidBoy vom Player
    public float movespeed; // speed des Players
    private float x, y; // x,y Achse
    public Animator anim; // animator

    public Transform weapon; // die Waffe
    public float offset; // die "Echte" Maus und die ingame Maus war bei der rotation nicht auf einer höhe ich habe es damit ausgeglichen
    public Transform shotPoint;// an dieser stelle werden die "Projektile" abgeschossen
    public GameObject projectiles; // die Projektile
    public float timeBetweenShots; // die zeitspanne zwischen den schüssen (benutze ich eighentlich nicht mehr)
    private float nextshotTime; //der Zeitpunkt des nächsten Schusses
    
    
       private void Update()
    {      /* X,y erfassen wird zu dem Playerinput zusammengefasst und normalisiert damit die bewegungen konstant bleiben
            * dann wird es mit movespeed multipliziert um daraus moveforce zu bekommen und damit beweg man dann den Player
            */

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector2 PlayerInput = new Vector2(x, y).normalized;
        Vector2 moveforce = PlayerInput * movespeed;
        rb.velocity = moveforce;

        if (x!= 0 || y !=0) // für die Animationen 
        {
            anim.SetFloat("x", x);

            anim.SetFloat("y", y);
        }
        /* berechnet den Winkel zwischen Waffe und dem Mauszeiger in Grad dazu wird die richtung zwischen der waffe uns der position der Maus ermittelt
         * daraus wird der winkel mit "Mathf.Atan2" berechnet dann wird die Rotation auf die weapon angewendet und der offset dabei berücksichtigt  */
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f , angle + offset);

        /* wenn die linke maustaste gedrückt wird und genügend Zeit seit dem letzten schuss vergangen ist wird die zeit bis zum nächsten schuss
         * aktualisiert und es wird das "Projektil" an der stelle des schusspunktes instanziiert */
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextshotTime)
            {
                nextshotTime = Time.time + timeBetweenShots;
                Instantiate(projectiles, shotPoint.position, shotPoint.rotation);
            }
        }
       

     

    }



}
