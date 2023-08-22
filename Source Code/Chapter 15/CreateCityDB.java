import java.sql.*;

/**
  This program creates the CityDB database.                                    *
*/
 
public class CreateCityDB
{
   public static void main(String[] args) throws Exception
   {
		String sql;
      final String DB_URL = "jdbc:derby:CityDB;create=true";
      
      // Create a connection to the database.
      Connection conn = DriverManager.getConnection(DB_URL);
            
      // Create a Statement object.
      Statement stmt = conn.createStatement();
            
      try
      {    
                     
         // Create the City table.
         System.out.println("Creating the City table...");
         stmt.execute("CREATE TABLE City ("    +
                      "CityName CHAR(25) NOT NULL PRIMARY KEY, "   +
                      "Population DOUBLE)");
							 
         // Add some rows to the new table.
         sql = "INSERT INTO City VALUES" +
               "('Beijing', 12500000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Buenos Aires', 13170000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Cairo', 14450000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Calcutta', 15100000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Delhi', 18680000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Jakarta', 18900000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Karachi', 11800000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Lagos', 13488000)";
         stmt.executeUpdate(sql);
			
         sql = "INSERT INTO City VALUES" +
               "('London', 12875000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Los Angeles', 15250000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Manila', 16300000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Mexico City', 20450000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Moscow', 15000000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Mumbai', 19200000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('New York City', 19750000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Osaka', 17350000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Sao Paulo', 18850000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Seoul', 20550000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Shanghai', 16650000)";
         stmt.executeUpdate(sql);

         sql = "INSERT INTO City VALUES" +
               "('Tokyo', 32450000)";
         stmt.executeUpdate(sql);
      }
      catch(Exception ex)
      {
         System.out.println("ERROR: " + ex.getMessage());
      }
      finally
      {
         // Close the resources.
         stmt.close();     
         conn.close();
         System.out.println("Done");
      }
   } 
}
