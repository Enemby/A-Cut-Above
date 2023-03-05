var fadeSpeed : float = 0.1;
var delay : float = 1;
var image : boolean = false;
var text : boolean = false;
private var timer : float = 0;
function Update () {
	if(timer < delay){
		timer+=Time.deltaTime;
	}
	else{
		if(image == true){
			this.GetComponent("Image").color.a+=fadeSpeed;
		}
		if(text == true){
			this.GetComponent("Text").color.a+=fadeSpeed;
		}
	}
}