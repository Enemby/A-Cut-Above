//add some "juice" and screenshake to the game
var cameraDrift : float = 0.016;
var screenshake : float = 0.005;
var returnSpeed : float = 0.015;
//Balancing stuff, TOUCH CAREFULLY
var zoomSpeed : float = 0.01;
var spinSpeed : float = 0.1;
//misc vars
var hit : boolean = false;
var shakeTime : float = 0.2;
private var timer : float = 0;
private var player : GameObject;
function Start(){
	player = GameObject.FindGameObjectWithTag("Player");
}
function Update(){
	hitCheck();
	this.transform.position = Vector3.MoveTowards(this.transform.position,Vector3.zero,returnSpeed);
	if(hit == true){
		timer+=Time.deltaTime;
		this.transform.position = this.transform.position +Random.insideUnitSphere * screenshake;
		if(timer >= shakeTime){
			hit = false;
			timer = 0;
		}
	}
	this.transform.position = Vector3.MoveTowards(this.transform.position,player.transform.position,cameraDrift);
	Zoom();
	this.transform.position.z = -10;
	Quit();
}
function Zoom(){
	if(this.GetComponent("Camera").orthographicSize > 0.8){
		this.GetComponent("Camera").orthographicSize -=zoomSpeed;
	}
}
function hitCheck(){
	hit = player.GetComponent("player").hit;
}
function Quit(){
	if(Input.GetKey("escape")){
		Application.Quit();
	}
}