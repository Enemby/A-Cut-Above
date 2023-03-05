//smoothly transition music from scene to scene
var levelIndex : int = 0;
var mySoundIndex : AudioClip[];
var gameplayMusic : AudioClip[];
var myGameplayIndex : int = 0;
var myAudioSource;
public var masterVolume : float = 1;
function Start () {
	DontDestroyOnLoad(transform.gameObject);
	myAudioSource = this.GetComponent(AudioSource);
	if(PlayerPrefs.HasKey("MasterVolume")){
		masterVolume = PlayerPrefs.GetFloat("MasterVolume");
	}
}

function Update () {
	levelIndex = Application.loadedLevel;
	if(mySoundIndex[0] != null){
		GameplayMusicLogic();
		PlayMusic();
	}
}
function PlayMusic(){//If there's not a track playing, play a track.
	if(myAudioSource.isPlaying == false){
		if(levelIndex <2 ){
			myAudioSource.clip = mySoundIndex[levelIndex];
		}
		else{
			myGameplayIndex+=1;
		}
		myAudioSource.Play();
	}
	else{
		if(levelIndex < 2){
			if(myAudioSource.clip.name != mySoundIndex[levelIndex].name){
				myAudioSource.volume*=0.9;
				if(myAudioSource.volume <0.1){
					myAudioSource.clip = mySoundIndex[levelIndex];
					myAudioSource.volume = 1;
					myAudioSource.Play();
				}
			}
		}
		else{
			if(myAudioSource.clip.name != gameplayMusic[myGameplayIndex].name){
				myAudioSource.volume*=0.9;
				if(myAudioSource.volume <0.1){
					myAudioSource.clip = gameplayMusic[myGameplayIndex];
					myAudioSource.volume = 1;
					myAudioSource.Play();
				}
			}
		}
	}
}
function GameplayMusicLogic(){
	if(myGameplayIndex> gameplayMusic.Length-1){
		myGameplayIndex = 0;
	}
}