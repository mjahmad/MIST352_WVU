import javafx.application.Application;
import javafx.stage.Stage;

/**
 * A simple JavaFX GUI application
 */

public class MyFirstGUI extends Application
{
   public static void main(String[] args)
   {
      // Launch the application.
      launch(args);
   }
   
   @Override
   public void start(Stage stage)
   {
      // Set the window's title.
      stage.setTitle("My First JavaFX Application");
      
      // Show the window.
      stage.show();
   }
}