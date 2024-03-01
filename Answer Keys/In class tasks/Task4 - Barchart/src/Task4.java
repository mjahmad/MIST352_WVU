// This program creates barcharts for 5 stores using ONE loop.
import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Task4 {
	/**
	 * @param args
	 * @throws FileNotFoundException 
	 * @throws IOException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub
		int store1=1900,store2=1200,store3=900,store4=500,store5=100;
		String strStore1="Store 1:",strStore2="Store 2:",strStore3="Store 3:",strStore4="Store 4:",strStore5="Store 5:";
		int intAllStores = (store1+store2+store3+store4+store5)/100;
		System.out.println(intAllStores);
		int intCounter=0;
		for (intCounter =0; intCounter < intAllStores; intCounter++)
		//while(intCounter <=intAllStores)
		{
			if (intCounter < store1/100)
				strStore1+="*";
			if (intCounter < store2/100)
				strStore2+="*";
			if (intCounter < store3/100)
				strStore3+="*";
			if (intCounter < store4/100)
				strStore4+="*";
			if (intCounter < store5/100)
				strStore5+="*";
			if (intCounter == intAllStores -1)
			{
				System.out.println(strStore1);
				System.out.println(strStore2);
				System.out.println(strStore3);
				System.out.println(strStore4);
				System.out.println(strStore5);
			}
			//intCounter++;
		}	
		
		
		

	}
}
