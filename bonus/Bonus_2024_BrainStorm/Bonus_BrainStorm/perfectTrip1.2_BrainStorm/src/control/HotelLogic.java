package control;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import entity.Consts;
import entity.Place;
import entity.Hotel;
public class HotelLogic extends PlaceLogic {
	private static HotelLogic _instanceHotel;
	
	public static HotelLogic getInstance() {
		if (_instanceHotel == null)
			_instanceHotel = new HotelLogic();
		return _instanceHotel;
	}
	
	public ArrayList<Hotel> getHotel() {
		ArrayList<Hotel> results = new ArrayList<Hotel>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Hotels);
					ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					int i = 1;
					results.add(new Hotel(rs.getInt(i++), rs.getString(i++), rs.getString(i++), rs.getInt(i++),
							rs.getString(i++), (rs.getString(i++)),(rs.getInt(i++))));// need to check
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return results;
	}
	public  ArrayList<String> getKitchenStyle() 
	{  
			ArrayList<String> results = new ArrayList<String>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_KITCHEN);
	             ResultSet rs = stmt.executeQuery()) {
	            
	            // Iterate over the result set and create Place objects
	            while (rs.next()) {
	                // Retrieve data from the result set and create a Place object
	                int i = 1;
	                results.add( rs.getString(i++));
	            }
	        }
	    } catch (ClassNotFoundException e) {
	        // Handle ClassNotFoundException (driver not found)
	        e.printStackTrace();
	        System.err.println("UCanAccess JDBC driver not found");
	    } catch (SQLException e) {
	        // Handle SQLException (database access error)
	        e.printStackTrace();
	        System.err.println("Error accessing database: " + e.getMessage());
	    } catch (Exception e) {
	        // Handle other exceptions
	        e.printStackTrace();
	        System.err.println("Unexpected error: " + e.getMessage());
	    }
	    return results;
	} 
	/*-------------------------------insert hotel-------------------------------------------------------*/
	public boolean InsertHotel(Integer hotelId,Integer starRating)
	{
		
		 try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_Hotels)) { 
	            stmt.setInt(1, hotelId);
	            stmt.setInt(2, starRating);
	            stmt.executeUpdate();
	            return true;
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    } catch (ClassNotFoundException e) {
	        e.printStackTrace();
	    }
		return false;		
	}
	public boolean UpdateHotel(Integer hotelId,Integer starRating)
	{
		
		 try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_Hotels)) { 
	            stmt.setInt(1, starRating);
	            stmt.setInt(2, hotelId);
	            stmt.executeUpdate();
	            return true;
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    } catch (ClassNotFoundException e) {
	        e.printStackTrace();
	    }
		return false;		
	}
	/*------------------------------------insert hotel style----------------------------------------------------------*/
	public boolean InsertHotelStyle(Integer hotelId,String accoumedation )
	{
		
		 try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_HOTEL_Style)) { 
	            stmt.setString(1, accoumedation);
	            stmt.setInt(2, hotelId);
	            stmt.executeUpdate();
	            return true;
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    } catch (ClassNotFoundException e) {
	        e.printStackTrace();
	    }
		return false;		
	}
}
