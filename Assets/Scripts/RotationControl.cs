using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public Rigidbody theBall;
    public float accelerationMultiplier = 0.5f;
    public float ballGravity = 1.0f;
    public float smoothTime = 0.0f;

    private Vector3 targetAcceleration, currentAcceleration, velocity;
    private float myRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotamos el objeto para que su eje z apunte en la direccion del acelerómetro
        //transform.LookAt(transform.position + Input.acceleration);

        //Restringir la direccion de la aceleracion al plano xy
        targetAcceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, 0.0f);

        //Suavizamos la direccion de la aceleracion
        currentAcceleration = Vector3.SmoothDamp(currentAcceleration, targetAcceleration, ref velocity, smoothTime);

        //Girar el objeto en la direccion de la aceleración
        transform.LookAt( (transform.position - currentAcceleration), Vector3.forward);

        //Empujamos a la bola en la direccion del acelerómetro (restringido)
        theBall.AddForce(currentAcceleration * ballGravity);
    }
}
