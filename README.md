# unity_eos_fps
Unity + Epic Online Services multiplayer game  

## Sorry: Game cannot be published  
I was developing it so that many people on the net could play it.
However, I noticed it when it was released.
**Publishing of Epic Online Services games is not yet permitted.**  
Therefore, if you log in to the game with an account other than the development team, it will be repelled.  
  
Unfortunately, we can't play with everyone right now, we can only build and test.  
I will report any progress. 😢  

## Addressing a bug in the lobby search  
As of July 23, 2020, the EOS lobby search is buggy.
P2P communication cannot be started unless you are in the same lobby,  
As a workaround, I made a simple lobby search server with Glitch.  
It is an API that only holds and delivers the lobby ID  
[eos-lobby](https://glitch.com/~eos-lobby)  
  
## Devised  
Calling the SDK was constantly increasing the amount of code, so I wrote more extension methods and organized them.  

* Replaced so that it can be called with only the argument
* The return value is UniTask and the callback is received by async.

## build  
### Author environment  
**OS:** Windows 10 Pro  
**Unity:** Unity 2020.1.0f1  

### 1. Project checkout from Github

### 2. Register at the Epic Online Services Developer Portal
1. Creating a new product  
2. Enter all 3 items in Epic Account Services to configure  
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/671642/07e2d16a-b588-0f5d-676c-a3e619e2d957.png)
3. Open the project with Unity and write the contents of Product Settings to Assets/ScriptableObjects/EOSSettings.asset

### 3. Create a server with Glitch
1. Open [eos-lobby](https://glitch.com/~eos-lobby) and use "View Sorce" -> "Remix Edit" to clone to your account  
2. Set the secret key and value in .env  
  * **Variable Name:** SECRET  
  * **Valiable Value:** An appropriate character string
![image.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/671642/809d0a83-2bfb-f3ec-9200-1b2817e1f122.png)  
3. Write to Assets/ScriptableObjects/EOSSettings.asset of Unity project  
  * **Api Url :** https://[Project name after cloning].glitch.me/kvs  
  * **Api Securet :** String set in SECRET of .env

### 4. Build
Build with Windows Standalone  
