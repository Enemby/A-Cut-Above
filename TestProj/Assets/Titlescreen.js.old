var delay : float = 0;
var levelIndex : int = 1;
private var timer : float = 0;
function Update(){
	if(timer < delay){
		timer+=Time.deltaTime;
	}
	else{
		if(Input.anyKeyDown){
			Application.LoadLevel(levelIndex);
		}
	}
}