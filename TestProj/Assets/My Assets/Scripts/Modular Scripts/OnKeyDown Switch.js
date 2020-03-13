//iterate through a list of disabled objects. Once we've reached the end of the list, load a scene
var myObjects : GameObject[];
var myIndex : int = 0;
var myScene : String;
function Update(){
	if(Input.anyKeyDown){
		IterateObjects();
	}
}
function IterateObjects(){
	if(myIndex < myObjects.Length-1){
		myIndex+=1;
		myObjects[myIndex-1].active = false;
		myObjects[myIndex].active = true;
	}
	else{
		Application.LoadLevel(myScene);
	}
}