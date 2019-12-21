var startColor : Color;
var hitColor : Color;
var myRenderer;
var timer : float = 0;
var hit :boolean = false;
var player : GameObject;
var enemySpeed : float = 0.1;
var lungeDistance : float = 2;
var animateTimer : float = 0;
var sprites : Sprite[];
var animateDelay : float = 0.1;
var mySprite : int = 0;
var lunging : boolean = false;
private var health = 2;
function Start(){
	myRenderer = this.GetComponent("SpriteRenderer");
	startColor = myRenderer.color;
	player = GameObject.FindGameObjectWithTag("Player");
}
function Update () {
	animateSprites();
	if(hit == true){
		timer+=Time.deltaTime*4;
		if(timer >= 1){
			timer = 0;
			hit = false;
		}
		myRenderer.color = Color.Lerp(myRenderer.color, hitColor,timer);
	}
	else{
		myRenderer.color = startColor;
	}
	if(Vector3.Distance(this.transform.position,player.transform.position) <= lungeDistance){
		lunging = true;
		this.transform.up = player.transform.position - this.transform.position;
		this.transform.position = Vector3.MoveTowards(this.transform.position,player.transform.position,enemySpeed*4);
	}
	else{
		lunging = false;
		this.transform.up = player.transform.position - this.transform.position;
		this.transform.position = Vector3.MoveTowards(this.transform.position,player.transform.position,enemySpeed);
	}
}
function animateSprites(){
	animateTimer+=Time.deltaTime;
	if(lunging == false){
		if(animateTimer >= animateDelay){
			if(mySprite+1 < sprites.Length){
				mySprite +=1;
			}
			else{
				mySprite = 0;
			}
			this.GetComponent("SpriteRenderer").sprite = sprites[mySprite];
			animateTimer = 0;
		}
	}
	else{
		if(animateTimer >= animateDelay*0.5){
			if(mySprite+1 < sprites.Length){
				mySprite +=1;
			}
			else{
				mySprite = 0;
			}
			this.GetComponent("SpriteRenderer").sprite = sprites[mySprite];
			animateTimer = 0;
		}
	}
}
function Hit(){
	hit = true;
	health-=1;
	if(health <= 0){
		player.BroadcastMessage("EnemyKilled");
		Destroy(this.gameObject);
	}
}