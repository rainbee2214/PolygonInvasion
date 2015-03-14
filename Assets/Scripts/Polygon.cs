using UnityEngine;
using System.Collections;

public class Polygon : MonoBehaviour 
{
	[Range(-100f, 100f)]
	float currentRotationSpeed;
	[Range(-0.99f, 0.99f)]
	float currentVelocity;
	float currentDelay;

	public Material[] materials;
	public Color[] colors;
	Color currentColor;
	Material currentMaterial;
	string currentDirection;

	float hVelocity;
	float vVelocity;
	Vector2 currentPosition;
	float startTime;

	bool frozen = true;

	float maxHealth = 10f;
	float currentHealth;

	float lastVelocity;
	bool changeMaterial;

	void Start()
	{
		SetMaterials();
	}
	//Defaults
	public void ConfigurePolygon()
	{
		ConfigurePolygon("line", "right", "red", 0.1f, 1f, 100f);
	}

	public void ConfigurePolygon(float delay)
	{
		ConfigurePolygon("line", "right", "red", 0.15f, delay, 100f);
	}

	public void ConfigurePolygon
		(string material, 
		 string direction, 
		 string color, 
		 float velocity, 
		 float delay, 
		 float rotation)
	{
		SetMaterials();
		startTime = Time.time;
		SetHealth();
		SetDelay(delay);
		SetColor(color);
		SetMaterial(material);
		SetVelocity(velocity);
		SetDirection(direction);
		SetRotationSpeed(rotation);
		currentPosition = transform.parent.position;
	}

	void Update () 
	{
		//SetMaterial("line");

		if (changeMaterial) 
		{
			Material[] temp = gameObject.GetComponent<Renderer>().materials;
			temp[0] = currentMaterial;
			gameObject.GetComponent<Renderer>().materials = temp;

			changeMaterial = false;
		}
	}

	void FixedUpdate()
	{
		if (Time.time > startTime + currentDelay && !frozen)
		{
			transform.Rotate(Vector3.forward * Time.deltaTime * currentRotationSpeed);
			if (lastVelocity != currentVelocity) SetDirection(currentDirection);
			currentPosition += new Vector2(hVelocity, vVelocity);
			gameObject.transform.position = currentPosition;
		}
		else
		{
			gameObject.transform.position = currentPosition;
		} 
	}

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Buffer")
		{
            SetDirection(other.name);
		}
        else if (other.tag == "Bullet" && !frozen)
		{
            other.gameObject.GetComponent<Bullet>().ResetBullet();
            LoseHealth(other.gameObject.GetComponent<Bullet>().power);
		}
        else if (!frozen && other.tag == "Laser")
		{
            LoseHealth(other.gameObject.GetComponentInParent<Laser>().GetPower());
		}
        else if (other.tag == "EndOfLevel")
        {
            Debug.Log("Hit end of level");
            ResetPolygon();
            transform.parent.GetComponent<PolygonEmitter>().ResetPolygon(int.Parse(this.name.Substring(0, 2)));
        }
	}

	public void LoseHealth(float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			ResetPolygon();
			transform.parent.GetComponent<PolygonEmitter>().ResetPolygon(int.Parse(this.name.Substring(0,2)));
		}
	}
	
	public void ResetPolygon()
	{
		currentPosition = GameController.OUT_OF_VIEW;
		frozen = true;
	}

	public void FreezePolygon()
	{
		frozen = true;
	}
	
	public void UnFreezePolygon()
	{
		frozen = false;
	}

	public void SetColor(string color)
	{
		switch(color)
		{
		case "Red": case "red": currentColor = colors[0]; break;
		case "Orange": case "orange": currentColor = colors[1]; break;
		case "Yellow": case "yellow": currentColor = colors[2]; break;
		case "Green": case "green": currentColor = colors[3]; break;
		case "Indigo": case "indigo": currentColor = colors[4]; break;
		case "Violet": case "violet": currentColor = colors[5]; break;
		case "Purple": case "purple": currentColor = colors[6]; break;
		case "Pink": case "pink": currentColor = colors[7]; break;
		default: break;
		}
	}
	
	public void SetColor(int colorIndex)
	{
		if (colorIndex <= colors.Length)currentColor = colors[0];
	}
	
	public void SetColor(Color color)
	{
		currentColor = color;
	}

	public void SetMaterial(string material)
	{
		switch(material)
		{
		case "Line": case "line": currentMaterial = materials[0]; break;
		case "Triangle": case "triangle": currentMaterial = materials[1]; break;
		case "Square": case "square": currentMaterial = materials[2]; break;
		case "Pentagon": case "pentagon": currentMaterial = materials[3]; break;
		case "Hexagon": case "hexagon": currentMaterial = materials[4]; break;
		case "Heptagon": case "heptagon": currentMaterial = materials[5]; break;
		case "Octagon": case "octagon": currentMaterial = materials[6]; break;
		case "Circle": case "circle": currentMaterial = materials[7]; break;
		default: break;
		}

		changeMaterial = true;
	}

	public void SetMaterial (int materialIndex)
	{
		currentMaterial = materials[materialIndex];

		changeMaterial = true;
	}

	public void SetDirection(string direction)
	{
		switch(direction)
		{
		case "right":
		{
			currentDirection = "right";
			vVelocity = 0f;
			hVelocity = currentVelocity;
			break;
		}
		case "left":
		{
			currentDirection = "left";
			vVelocity = 0f;
			hVelocity = -currentVelocity;
			break;
		}
		case "up":
		{
			currentDirection = "up";
			hVelocity = 0f;
			vVelocity = currentVelocity;
			break;
		}
		case "down":
		{
			currentDirection = "down";
			hVelocity = 0f;
			vVelocity = -currentVelocity;
			break;
		}
		default: break;
		}
		lastVelocity = currentVelocity;
	}

	public void SetRotationSpeed(float rotationSpeed)
	{
		currentRotationSpeed = rotationSpeed;
	}
	
	public void SetHealth()
	{
		currentHealth = maxHealth;
	}
	
	public void SetDelay(float delay)
	{
		currentDelay = delay;
	}

	public void SetVelocity(float velocity)
	{
		currentVelocity = velocity;
	}

	public string GetDirection()
	{
		return currentDirection;
	}

	public float GetDelay()
	{
		return currentDelay;
	}

	public float GetVelocity()
	{
		return currentVelocity;
	}

	void SetMaterials()
	{
		materials = new Material[8];
		materials[0] = Instantiate (Resources.Load("Materials/Line", typeof(Material))) as Material;
		materials[1] = Instantiate (Resources.Load("Materials/Triangle", typeof(Material))) as Material;
		materials[2] = Instantiate (Resources.Load("Materials/Square", typeof(Material))) as Material;
		materials[3] = Instantiate (Resources.Load("Materials/Pentagon", typeof(Material))) as Material;
		materials[4] = Instantiate (Resources.Load("Materials/Hexagon", typeof(Material))) as Material;
		materials[5] = Instantiate (Resources.Load("Materials/Heptagon", typeof(Material))) as Material;
		materials[6] = Instantiate (Resources.Load("Materials/Octagon", typeof(Material))) as Material;
		materials[7] = Instantiate (Resources.Load("Materials/Circle", typeof(Material))) as Material;
	}
}
