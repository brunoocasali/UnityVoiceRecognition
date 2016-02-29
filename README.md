# UnityVoiceRecognition
Unity Voice Recognition for Unity 5.4.0.B2 and above; for Windows with voice recognition capabilities only.

# How to Use

1. Make sure you are using Unity beta version of 5.4.0.B2 and above. Also, this only works in Windows with voice recognition capabilities. Windows 7 and Windows 10 will work, but if you are using a non-English version of Windows 7 it might not support voice recognition. Also, make sure your microphone is up and running.
  

2. Include VoiceRec.dll in your Plugins folder in Unity project
3. Modify example.cs according to your needs use the script in the game. 
      By itself, example.cs will recognize "left", "right", "up", "down" and print a log.

# Also included

1. Also included is a modification of a script in a sample 2D Unity game found here: https://www.assetstore.unity3d.com/en/#!/content/18684.
2. Replace Player.cs in 2D Scrolling Shooter with Player.cs provided and it will move with voice recognition instead of keyboard commands:
    Say "left" to make the shooter move left, "right" for moving right, "up" for up, "down" for down.
2D sample is by Unity, under Apache License.

# VoiceRecDLL

1. The solution/project files for VoiceRecDLL is also included in /VoiceRecDLL.

