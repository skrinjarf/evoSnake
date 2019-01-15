This is a project were we create snake game client and a genetic programming ai algorithm which plays it.
All the code is written in C#
Contributors: Ante Buterin, Filip Skrinjar

Detected bugs:
unhandled exception when snake dies in test mode

Tasks for grabs:
- Battling agains AI snake (together since this highly depends on all 
our tasks)

Done so far: 
- basic evolution algorithm for training snakes (needs to be perfected)
- Perfect evolution algortihm for training snakes
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
- Build level progressions system
- Level completion item
- Set predefined number of lives for game
- Set predefined number of pauses for game
- Serialize whole game state so it can be saved even when user exits app
- Info window for all items
- Design at least 10 levels
