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
	

----General Thoughts & methodology----

Designing code architecture & UML
	I prefer to create quick simple sketches over full UML Diagrams.
	You can spend a lot of time making a great initial design but a lot of the time, the finished product doesn't resemble the initial design that much.
	Faster iteration is in my opinion better and you're less likely to get attached to your initial design.
	If a full UML is necessary, I prefer to write it closer to the end when the design should be pretty stable.

ScreenSwitcher
	Currently keeps one instance of each screen after they have been created. reusing them is good but it does mean that I need to reset them.
	It would also work without storing any of the instances within ScreenSwitcher and destroying screens when we switch to the next screen.
	I might want so data to carry over between states so I'm sticking to the first solution

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




