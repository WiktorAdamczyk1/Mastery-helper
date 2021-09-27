# Mastery-helper

Live version is available at https://mastery-helper.herokuapp.com/

Mastery-helper is a blazor server application that uses League of Legends API to help players track and compare their progress on achieving mastery with every League of Legends champion.

## Functionalities

*  Browse information about champions with the ability to sort and filter.
*  Leaderboard with information about chosen summoners to easily compare their progress.
*  Aram helper that only shows progress of chosen champions, to help quickly find the champion with lowest mastery score.
*  Calculate amount of games/days left to achieve level 5 mastery on every champion.

## Endpoints

*  /player/{region}/{SummonerName} - Player information
*  /Leaderboard
