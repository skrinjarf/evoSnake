This is a project were we create snake game client and a genetic programming ai algorithm which plays it.
All the code is written in C#
Contributors: Ante Buterin, Filip Skrinjar

Tasks for grabs:
- Perfect evolution algortihm for training snakes
- Build level progressions system (maybe even level editor if there is time)
- Level completion item
- Info window for all items
- Battling agains AI snake
- Set predefined number of pauses for game
- Set predefined number of lives for game

Level Progression System:
- Build config files which hold info about level which loads on level 
start (DONE)
- Build simple progression from one level to another when one is won 
(DONE)
- What happens when you click 'Next Level' after last level ???
- Make somehow option to choose from all unlocked levels because now you 
can only play last unlocked level
- Design reasonable number of levels (1 - 20)
- Make UI element which indicates name of level you are currently 
playing (DONE)

Done so far: 
- basic evolution algorithm for training snakes (needs to be perfected)
- simple gameplay for snake game (this could be granulated but you get the feeling for what that means; just checkout this commit - 1a46ab1640afa7e03abcadfd7ead92ba8922a215)
- Moving snake by multiple fields (arrow + num key)
- Moving snake to edge of board (arrow + shift key)
- Moving snake to edge of its body (arrow + ctrl)
- Snake length modifier item
- Snake direction modifier item
- Reverse controls item
- Points pick up items (give you both positive/negative points)
- Implement wall obstacle logic
- Places where snake can go through its body
- Settings where user can set above mentioned controls
