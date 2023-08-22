import java.util.Scanner;

/**
 * This program calculates the number of soccer teams  
 * that a youth league may create from the number of   
 * available players. Input validation is demonstrated 
 * with while loops.
 */

public class SoccerTeams
{
   public static void main(String[] args)
   {
      final int MIN_PLAYERS = 9,  // Maximum players per team
                MAX_PLAYERS = 15; // Minimum players per team
      int players,          // Number of available players
          teamSize,         // Number of players per team
          teams,            // Number of teams
          leftOver;         // Number of left over players

      // Create a scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the number of players per team.
      System.out.print("Enter the number of players " +
                       "per team: ");
      teamSize = keyboard.nextInt();
      
      // Validate the input.
      while (teamSize < MIN_PLAYERS || teamSize > MAX_PLAYERS)
      {
          System.out.println("You should have at least " +
                             MIN_PLAYERS +
                             " but no more than " +
                             MAX_PLAYERS + " per team.");
          System.out.print("Enter the number of players " +
                           "per team: ");
          teamSize = keyboard.nextInt();
      }

      // Get the available number of players.
      System.out.print("Enter the available number of players: ");
      players = keyboard.nextInt();
      
      // Validate the input.
      while (players < 0)
      {
          System.out.println("Please do not enter a negative " +
                             "number.");
          System.out.print("Enter the available number " +
                           "of players: ");
          players = keyboard.nextInt();
      }
 
      // Calculate the number of teams.
      teams = players / teamSize; 

      // Calculate the number of left over players.
      leftOver = players % teamSize;

      // Display the results.
      System.out.println("There will be " + teams + " teams " +
                         "with " + leftOver +
                         " players left over.");
   }
}

