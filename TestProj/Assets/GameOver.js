function Start () {
	Time.timeScale = 0;
}

function Update () {
	if(Input.anyKeyDown){
		if(!Input.GetKeyDown(KeyCode.Mouse0)){
			Time.timeScale = 1;
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}