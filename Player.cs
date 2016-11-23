using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private VoiceRec.VoiceClass recognizer;
    private string word;

    void Start()
    {
        recognizer = new VoiceRec.VoiceClass();
        string[] str = { "left", "right", "down", "up" };
        recognizer.initRecog(str);

    }

    void Update ()
	{
	void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
        word = recognizer.getWord();
        float x = 0.0F;
        float y = 0.0F;
        if (word != null && word != "")
        {
            switch (word)
            {
                case "left":
                    x = -1.0F;
                    break;
                case "right":
                    x = 1.0F;
                    break;
                case "down":
                    y = -1.0F;
                    break;
                case "up":
                    y = 1.0F;
                    break;
            }
        }
		
        Vector2 direction = new Vector2 (x, y).normalized;
		Move (direction);
	}
	
	void Move (Vector2 direction)
	{
		//Find the screen limits to the player's movement
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		//Get the player's current position
		Vector2 pos = transform.position;
        //Calculate the proposed position
        /* Keyboard position
        pos += direction  * speed * Time.deltaTime;
         */
        pos += direction * speed * 10 * Time.deltaTime;
        //Ensure that the proposed position isn't outside of the limits
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		//Update the player's position
		transform.position = pos;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		//Get the layer of the collided object
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		//If the player hit an enemy bullet or ship...
		if( layerName == "Bullet (Enemy)" || layerName == "Enemy")
		{
			//...and the object was a bullet...
			if(layerName == "Bullet (Enemy)" )
				//...return the bullet to the pool...
			    ObjectPool.current.PoolObject(c.gameObject) ;
			//...otherwise...
			else
				//...deactivate the enemy ship
				c.gameObject.SetActive(false);

			//Tell the manager that we crashed
			Manager.current.GameOver();
			//Trigger an explosion
			Explode();
			//Deactivate the player
			gameObject.SetActive(false);
		}
	}
}
