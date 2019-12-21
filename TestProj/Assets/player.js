var speed : float = 0.1;
var moving : boolean = false;
var hit : boolean = false;
var gameOverObj : GameObject;
private var startColor : Color;
private var myRenderer;
private var timer : float = 0;
private var slashTimer : float = 0.1;
private var hitEnemy = false;
var rushTime : float = 1.1; //How fast we accelerate while dashing
var health : float = 3;
var hitColor : Color;
function Start(){
	myRenderer = this.GetComponent("SpriteRenderer");
	startColor = myRenderer.color;
}
function EnemyKilled(){ //If we killed a guy, do stuff.
	if(health < 100){
		health+=5;
	}
	if(health > 100){
		health = 100;
	}
}
function Update () {
	var myCam = GameObject.Find("Main Camera").GetComponent("Camera");
	var mousePos = Input.mousePosition;
	var myVector = myCam.ScreenToWorldPoint(Vector3(mousePos.x,mousePos.y,10));
	if(Input.GetButtonDown("Fire1")){
		moving = true;
		slashTimer = speed;
	/*
		var myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		myCube.transform.position = myVector;
		myCube.transform.localScale *=0.1;
	*/
	}
	if(moving == true){
		this.transform.position = Vector3.MoveTowards(this.transform.position,myVector,slashTimer);
		slashTimer += Time.deltaTime* rushTime;
		if(Vector3.Distance(this.transform.position,myVector) <= 0.025){
			moving = false;
		}
		if(hitEnemy == true){
			this.GetComponent("TrailRenderer").enabled = true;
			this.GetComponent("ParticleSystem").enableEmission = true;
		}
		else{
			this.GetComponent("TrailRenderer").enabled = false;
			this.GetComponent("ParticleSystem").enableEmission = false;
		}
	}
	else{
		hitEnemy = false;
	}
	this.transform.up = myVector - this.transform.position;
	this.transform.rotation.eulerAngles.x = 0;
	hitLogic();
}
function Hit(){
	hit = true;
	health-=1;
}
function hitLogic(){
	if(hit == true){
		timer+=Time.deltaTime*4;
		if(timer >= 1){
			timer = 0;
			hit = false;
			if(health <= 0){
				Destroy(this.gameObject);
				gameOverObj.active = true;
			}
		}
		myRenderer.color = Color.Lerp(myRenderer.color, hitColor,timer);
	}
	else{
		myRenderer.color = startColor;
	}
}
function OnTriggerEnter2D(other : Collider2D){
	if(moving == true){
		if(other.gameObject.tag == "Enemy"){
			hitEnemy = true;
			other.gameObject.BroadcastMessage("Hit");
			Debug.Log("Enemy Hit");
		}
	}
	else{
		if(other.gameObject.tag == "Enemy"){
			Hit();
		}
	}
}
function OnTriggerStay2D(other : Collider2D){
	if(moving == false){
		if(other.gameObject.tag == "Enemy"){
			Hit();
		}
	}
}