# Computer-Game 
This is a computer game project conducting recently.
This game is based on a adventure story, the player is in a dark cave.
The aim of the player is escaping from the cave!
In this game you can use all sorts of tools to realize funtion, such as making a trap, eat food and lighten the torch.
![Image](https://github.com/xuanye233/Computer-Game/blob/master/img-folder/sccene1.png)

update:
3.20:
1.if u want to make sth visiable in every players' screen, u need to make it as a prefab, and use PhotonNetwork.Instantiate() to create it.(with the component named photonview)
3.21£º
only masterclient can use photonnetwork.destroy to destroy a object.
if other clients want to do so, they need to use PRC to tell the master client, and the master would help the clients to destroy the object. Then synchronize the scene.