import java.util.Scanner;  // Needed for keyboard input

/**
 * Chapter 5
 * Programming Challenge 5: Hotel Occupancy
 */

public class HotelOccupancy
{
   public static void main(String[] args)
   {
      int floors;          // Number of floors
      int totalRooms;      // Total number of rooms
      int rooms;           // Rooms on a floor
      int totalOccupied;   // Total rooms occupied
      int occupied;        // Occupied rooms on a floor
      int vacantRooms;     // Number of vacant rooms
      double occupancy;    // Occupancy rate

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Initialize accumulators.
      totalRooms = 0;
      totalOccupied = 0;
      
      // Get the number of floors.
      System.out.print("How many floors does the " +
                       "hotel have? ");
      floors = keyboard.nextInt();

      // Validate the input.
      while (floors < 1)
      {
         System.out.print("Invalid. Enter 1 or more: ");
         floors = keyboard.nextInt();
      }
      
      // Get the number of rooms and number of occupied
      // rooms on each floor.
      for (int i = 0; i < floors; i++)
      {
         // Get the number of rooms on a floor.
         System.out.print("How many rooms does floor " +
                          (i + 1) + " have? ");
         rooms = keyboard.nextInt();
         
         // Validate the input.
         while (rooms < 10)
         {
            System.out.print("Invalid. Enter 10 or more: ");
            rooms = keyboard.nextInt();
         }
         
         totalRooms += rooms;

         // Get the number of occupied rooms on a floor.
         System.out.print("How many occupied rooms does floor " +
                          (i + 1) + " have? ");
         occupied = keyboard.nextInt();
         
         // Validate the input.
         while (occupied > rooms)
         {
            System.out.print("Invalid. Must be " + rooms +
                             " or less. Re-enter: ");
            occupied = keyboard.nextInt();
         }
         
         totalOccupied += occupied;
      }
      
      // Calculate the number of vacant rooms.
      vacantRooms = totalRooms - totalOccupied;
      
      // Calculate the occupancy rate.
      occupancy = (double)totalOccupied / totalRooms;
      
      // Display the results.
      System.out.println("Number of rooms: " + totalRooms);
      System.out.println("Occupied rooms: " + totalOccupied);
      System.out.println("Vacant rooms: " + vacantRooms);
      System.out.println("Occupancy rate: " + occupancy);
   }
}
