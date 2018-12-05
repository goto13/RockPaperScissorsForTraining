### Create CUI application (in less than 2 week)

####1st Task: Create a Rock?paper?scissors game
*Rock-paper-scissors is like this. (https://en.wikipedia.org/wiki/Rock%E2%80%93paper%E2%80%93scissors)

- User can input a number. 1: Rock, 2: Paper, 3: Scissors
- CPU will output a number from 1 to 3 randomly.
- If the numbers are same, user and cpu will replay a game. The output number can be changed.
- If either of them are win, the game will ask a question whether the game is over. User can input a number. 1: exit game, 2: continue game

So the image of the execution in console is like following.

> Start of Rock?paper?scissors game.
> What's your hand shape? (1: Rock, 2: Paper, 3: Scissors)
> 1  (<- This number was input by user in console.)
> You Lose!
> Your hand shape : Rock
> CPU hand shape: Paper
> Do you want to continue? (1: Continue game, 0: Exit game)
> 1
> What's your hand shape? (1: Rock, 2: Paper, 3: Scissors)
> 3  (<- This number was input by user in console.)
> Tied!
> Your hand shape : Scissors
> CPU hand shape: Scissors
> What's your hand shape? (1: Rock, 2: Paper, 3: Scissors)
> 2  (<- This number was input by user in console.)
> You win!
> Your hand shape : Paper
> CPU hand shape: Rock
> Do you want to continue? (1: Continue game, 0: Exit game)
> 0
> (The game is finished.)

####What we want to check is following.  

- Whether the judge of win-lose is correct.
- Whether the process of replay is implemented correctly.
- Whether the process of continue is implemented correctly.
- Whether the process of exit is implemented correctly.

### 2nd Task: Update the Game so that You can add Players
Update the game so that user can change the number of players.  
You can implement as the number of users can be changed, and also as the the number of cpus can be changed. And of course, you can implement as the number of users and cpus can be changed.  
The judgement can be done by some rule. As an example, like following.  
(https://boardgamegeek.com/boardgame/99675/massive-multiplayer-rock-paper-scissors)  

####What we want to check is following.  

- Same point of check as 1st task even if the number of players grew.
 - Whether the judge of win-lose is correct.
 - Whether the process of replay is implemented correctly.
 - Whether the process of continue is implemented correctly.
 - Whether the process of exit is implemented correctly.
- Whether the magic number is not contained in the program code. *Magic number is like this.(https://en.wikipedia.org/wiki/Magic_number_(programming))

### 3rd Task: Update the Code as the Code Analysis tool says
Update the code as static analysis tool.  
At first, download the file of ruleset for sonarqube.  
Next, add the add-in of "SonarLint for Visual Studio 2017" by following.

1. Open the Visual Studio 2017.
1. From the top bar of Visual Studio 2017, select Tools > Extensions and Updates...
1. In the Extensions and Updates dialog, select the Online from left pain. 
1. In the right-top search box, input SonarLint.
1. You will find the SonarLint for Visual Studio 2017. Click the Install button.
1. Close the Visual Studio 2017. After closing Visual Studio 2017, the installation will be started.

After installation of the add-in, set up the setting for code analysis like following.

1. In the Visual Studio window, select the target csproject from Solution Explorer and right-click and select "Property".
1. In the target project property, select "Code Analysis".
1. Select < Browse... > from the drop down list of Run this rule set:, and select the file of Sonarlint ruleset file.

####What we want to check is following.  

- Same point of check as 1st task even if the number of players grew.
 - Whether the judge of win-lose is correct.
 - Whether the process of replay is implemented correctly.
 - Whether the process of continue is implemented correctly.
 - Whether the process of exit is implemented correctly.
- Whether all the warning from SonarLint is cleared.

### 4th Task: Update the Game so that you can save the result in DB
Update the game to save the result in database.
Please use the SQL Server or SQL Database.
User can see the total score.
example)
> User1 win!
> User1 hand shape : Paper
> CPU hand shape: Rock
> User1 score:
> win : 10,  lose: 13, win rate: 0.43478260869
> Do you want to continue? (1: Continue game, 0: Exit game)
> 0
> (The game is finished.)

####What we want to check is following.  

- Same point of check as 1st task even if the number of players grew.
 - Whether the judge of win-lose is correct.
 - Whether the process of replay is implemented correctly.
 - Whether the process of continue is implemented correctly.
 - Whether the process of exit is implemented correctly.