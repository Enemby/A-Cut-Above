var myPlayer : GameObject;
var myFadeElement : UI.Image; //Our blackUI thing.
function Start(){
	myPlayer = GameObject.FindGameObjectWithTag("Player");
}
function Update(){
	var healthAlpha = myPlayer.GetComponent("player").health *0.01;
	healthAlpha-=1;
	healthAlpha = Mathf.Abs(healthAlpha);
	if(healthAlpha > 0.9){
		healthAlpha = 0.9;
	}
	myFadeElement.color = new Color(0,0,0,healthAlpha);
}