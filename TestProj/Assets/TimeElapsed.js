private var myText;
function Start(){
	myText = GetComponent("Text");
}
function Update(){
	if(Time.timeScale != 0){
		var myTime : int = Time.timeSinceLevelLoad;
		myText.text = "Time Elapsed: "+ myTime;
	}
}