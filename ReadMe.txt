----Retrospective----
I think my solution for this game has met all the design rules and important code related aspects.
on Top of the asked for requirements I have added:
	- 3 Difficulty options
	- Second mole type: KingMole
	- Holes are randomly positioned each game
	- Direct connection from start screen to Highscore list 

each difficulty spawns moles with a different lifetime and spawn interval, the amount of holes also increase with difficulty.
Score is based on how fast you click the moles.
In the KingMole Mode, a King Mole with his cronies with spawn at a certain frequency. All of them can be bopped and the King mole gives more points.
Holes are spawned completely random first and then are pushed away from each other through a interative algorithm. 

The assignment is very solid and gives enough space for creativity, it allowed me to show some good design idea's and patterns.
I have spend basically no time on the art but luckily the assignment says that that doesn't matter :D
I made 4 designs during the process of building this Game. the first and last still share a good amount of similarities which is nice.

I think I might have gone a bit too far with with the seperation beween UI and state logic. 
The logic has a very small pressence in the scene which made it a bit tricky to connect the UI and Logic in a nice way.
My solution is pretty decent and it works well but for a bigger project, a rethink might be necessary.

Near the end I ran a little short on time to work on this assignment.
Because of this the Mole King functionality isn't implemented as well as I would like it to be, it's not bad or horrible though ;)
EDIT: I changed this quickly after sleeping on it and I like it a lot more now

I also didn't really have time to implement the Unit tests that I had planned, 
it would have been nice to run some tests on the hole positioner logic and object pools.
There is a very small chance that I have some time tonight (Monday 17-06) to make some unit tests but I doubt it.

----Time-Log---- 

Tuesday 11-06 20:00 - 22:30
	- Initial project setup and first build to android phone
	- Made a quick design for the overall Architecture

Wednesday 12-06 19:00 - 21:00 | 21:00 - 00:00
	- Created UI for all screens
	- ScreenSwitcher logic written, working on screen logic
	- Event Manager created through observer pattern

Thursday 13-06 08:00 - 10:00 | 17:30 - 19:00 | 21:00 - 00:00
	- Working on the screenswitcher logic
	- Added data streamer logic for Timer etc
	- All UI works only the highscore list needs to be filled
	
Friday 14-06 15:00 - 17:00  
	- Finished Object pooling
	- Started on game logic 
	- Simple implementation of game settings & difficulty settings
	- Improved Project Structure

Sunday 16-06 10:00 - 15:00 | 20:00 - 23:00
	- Created second design
	- Created MoleSystem and NormalSpawner functionality
	- Added objectPool for components that are attached to gameobjects
	- started on the database logic
	- Refined second design into third design
	- Reworked GameData & GameRunner
	- Created Saving&Loading functionality
	- Started on Filling the HighScore list

Monday 17-06 7:00 - 10:00 | 15:00 - 17:00
	- Highscore list works
	- ElementGetter logic & randomElementGetter added to objecPool
	- Refined the hole spawning algorithm
	- King Mole mode working
	- Created Last design

----General Thoughts & methodology----

Designing code architecture & UML
	I prefer to create quick simple sketches over full UML Diagrams.
	You can spend a lot of time making a great initial design but a lot of the time, the finished product doesn't resemble the initial design that much.
	Faster iteration is in my opinion better and you're less likely to get attached to your initial design.
	If a full UML is necessary, I prefer to write it closer to the end when the design should be pretty stable.

ScreenSwitcher
	Currently keeps one instance of each screen after they have been created. reusing them is good but it does mean that I need to reset them.
	It would also work without storing any of the instances within ScreenSwitcher and destroying screens when we switch to the next screen.
	Edit: The states no longer hold any data that would need to be reset when going to that state a second time so that drawback is gone.
	the fact that these states don't have a pressence in the scene makes it a bit more difficult to connect the UI.

Project Hierarchy
	I like to group Assets together that belong to the same Object/Functionality/system, not by asset Type. 
	It's more maintainable when the project grows larger and easier to navigate/find what you're looking for.

	- Object 1			vs			- object Icons
	  -- Icon1						  --Icon1
	  -- Script1						  --Icon2
	  -- Material1						- Object Scripts
	- Object 2						  --Script1
	  -- Icon2						  --Script2
	  -- Script2						- Object Materials
	  -- Material2						  --Material1
								  --Material2
Object Pools
	I think the object pools were a nice idea and they allowed me to solve some issues in a creative way.
	A simple extensions allows the pool to choose a random Hole to spawn each mole which I though was quite nice.

Event Manager
	I'm a big fan of the observers pattern but sometimes I might rely on it a little too much.
	I'm on the line about how I solved my last minute issues around the KingMole functionality through the event manager.
	I think it might have been better to give Mole, MoleKing and the holes a way to free their own instance in the objectpool but that needs some further though






