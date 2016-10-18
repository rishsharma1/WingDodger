# WingDodger
Microsoft Surface game for COMP30019

# Project Details

## Group Members
* Mingdong Tan, 722981
* Rishabh Sharma, 694739

# Demonstration
https://www.youtube.com/watch?v=apBK2_G89DQ&feature=youtu.be


# What the application does?

## Description
Wing dodger is a game about dodging elements in the terrain and surviving as long as possible, to achieve the highest score possible. You control a stealth bomber, moving it left and right as you progress through the landscape. The obstacles are generated randomly, where it encourages the player to dodge the obstacles and show off their flying skills. The game will end when the player crashes into one of the obstacles. The score will keep track of the player's ability, and as you get a higher score the game gets harder as you progress.  

# How to use it?

## Controls

### Accelerometer: plane movement
To move the plane left and right tilt the Microsoft surface left and right.
Note: The plane will stay in its tilted position upon being tilted, unless it is corrected by the player again to go back to an upright position. This is an intentional game mechanic, to give the player a more sense of control of the plane.

### Touch Hold: slow speed
To slow the speed of the plane, the player can touch hold (see youtube video) the screen to slow the plane speed, giving them more time to respond and maneuver through the landscape.

### Touch: Main-Menu, Pause-Menu, Pause Button
The UI elements can be interacted by touch easily.


# Making the game

## Game Objects
The game objects in the landscape are taken from the standard assets available in Unity.
The plane is a model we got from the interent, and is made from a mesh.

## Landscape
The landscape is generated procedurally, basing it off one tile. The tile is 10 by 10 and we apply the perlin noise function to it giving it a 'terrain' look. Then we instantiate a certain amount of tiles around the player's position, and when the player updates its position we updated the tiles ahead, so it feels like an infinte landscape. To improve effeciency we make sure to delete tiles that have been past.

## Graphics

### Shaders

* Phong shading:
We used phong shading on the tree models, where we get the vector coming from the light, the vector coming from the viewer's direction, calculate the half vector by adding the light direction vector and view ditrection vector. We then calculate the diffuse, ambient and specular components and add them to produce the final color on the tree's surface.

* Toon shading:
We also used toon shading on the landscape and the plane model. Our main effect with toon shading is the outlining of the edges with a main solid material colour. For each vertex we calculate the the direction of the normal, get the vertex's position in the world, and the vector from the object to the camera. We can then use this information to ensure the outlining stays the same no matter where the camera moves. We finally then get the total light by combining an ambient component and multiplying it by the thickness value. 

### Shadows
We have added shadow volumes using Unity's built in shadow maps in the shaders of the objects. Currently the trees should cast a shadow on the terrain and on any other tree's around it.

### Particle Effect
We use the unity's particle system to generate an explosion when the player crashes into the trees.

## Camera Motion
We calculate an intital offset between the camera's position and the player's position. We then update the camera's position by adding the current position of the player to the offset.


# References

## Assets

### Textures
* Smoke: http://www.vectorhq.com/psd/cartoon-smoke-psd-440442
* Pause Button: http://www.iconarchive.com/show/windows-8-icons-by-icons8/Media-Controls-Pause-icon.html

## Code References
* Infinite Terrain Generation: https://www.youtube.com/watch?v=dycHQFEz8VI
* Cell-Shading: https://www.youtube.com/watch?v=3qBDTh9zWrQ
* Phong-Shdaing: Reference from project 1
