# WingDodger
Microsoft Surface game for COMP30019

# Type of application
I plan to make a 3D game where you control a plane from a 3rd person view and the objective is to dodge elements in the terrain and survive as long as possible to maximise the score. Players will also be encouraged to collect special collectables that will increase the score by a large amount but at the cost of a risk. Upon crashing into a terrain object the game will end and a score will be posted.


# Hardware inputs
I plan to use the accelerometer to move the plane left and right as a means to dodge inncoming terrain objects. The touch screen will be used for evasive maneuvers, where different touch patterns will perform different evasive maneuvers. The general motivation behind the addition of evasive maneuvers is to give the player a more faster option to avoid obstacles. This would come handy in situations where the player is to late to move left or right.


# Visualisation
All objects in the world will be 3D and will have lighting and appropriate shaders applied to it. I will be looking to get a low poly/cartoonish look by combing flat shading (low poly) and toon shading. The camera will be placed behind the plane and follow it until impact. Upon impacting, I plan to use some particle effects to signify a crash and an end to the game. As the player progresses the terrain will change and procedurally get harder to dodge objects in it.

The number of polygons in the game should not be too high in the earlier stages, but may increase as the terrain gets harder to maneuver. But overall it should be relatively low as the intended art style of the game is low polygon.

# Milestones

1. Create relevant models for terrain and plane
2. Generate random terrain with increasing difficulty and feasibility
3. Implementing plane movements using accelerometer
4. Implementing touch evasive maneuvers
5. Add terrain models appropriately into the terrain
6. Create a collision mechanic for the plane
7. Create point system
8. Creating menu and UI that is responsive with the surface
9. Adding leaderboards and highscores
10. Submit

