var spawnTime : float = 1;
var intensitySpeed : float = 0.1;
var escalate : boolean = false; //increase spawn rate over time?
var myEnemy : GameObject;
var spawnRange : float = 10;
private var myPlayer;
private var timer : float = 0;
private var intensityTimer: float = 0;
function Start(){
	myPlayer = GameObject.FindGameObjectWithTag("Player");
}
function Update(){
	if(escalate == true){
		if(intensityTimer < 1){
			intensityTimer+=Time.deltaTime*0.001;
		}
		if(intensityTimer > 1){
			intensityTimer = 1;
		}
	}
	else{
		intensityTimer = 0;
	}
	if(timer <= spawnTime){
		timer+=Time.deltaTime;
		timer+=intensityTimer;
	}
	else{
		SpawnEnemy();
		timer = 0;
	}
}
function SpawnEnemy(){
	var randomCircle = Random.insideUnitCircle.normalized * spawnRange;
	var spawnPos : Vector3 = Vector3(randomCircle.x,randomCircle.y,0);
	var spawnedEnemy = Instantiate(myEnemy,spawnPos,Quaternion.identity);
	if(Vector3.Distance(spawnedEnemy.transform.position,myPlayer.transform.position) < 0.2){
		Destroy(spawnedEnemy.gameObject);
	}
}