package control;

import java.sql.CallableStatement;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;

import boundary.UsersRequest;
import entity.Consts;
import entity.Place;
import entity.Trip;
import entity.Hotel;
import entity.Resturant;
import entity.review;
import entity.User;
import entity.UserRequest;

public class TripLogic {
	private static TripLogic _instanceTrip;

	public TripLogic() {
	}

	public static TripLogic getInstance() {
		if (_instanceTrip == null)
			_instanceTrip = new TripLogic();
		return _instanceTrip;
	}
/*-----------------------------GET FUNCTIONS -------------------------*/
	@SuppressWarnings("unchecked")
	public ArrayList<Trip> getTrip() {
		ArrayList<Trip> results = new ArrayList<Trip>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_TRIP);
					ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					int i = 1;
					results.add(new Trip(rs.getInt(i++), rs.getDate(i++),
							rs.getDate(i++), (rs.getInt(i++)),(rs.getInt(i++))));// need to check
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return results;
	}
	/*---------------------------------------get speicific trip-----------------------------------------------*/
	public Trip specificTrip(Integer tripId)
	{
		Trip results = new Trip();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SPC_TRIP);) {
				stmt1.setInt(1, tripId);
		           ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                Trip trip = new Trip(
			                        rs.getInt(i++),
			                        rs.getDate(i++),
			                        rs.getDate(i++),
			                        rs.getInt(i++), rs.getInt(i++));
			                // Add the Place ID  to the results list
			                results=trip;
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	    return results;
		
	}
	/*-------------------------------trip numbers-----------------------------------------*/
	public ArrayList<Integer> GetTripNumbers() {
	    ArrayList<Integer> results = new ArrayList<>();

	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_GET_TRIP_NUMBERS);
	             ResultSet rs = stmt.executeQuery()) {
	            while (rs.next()) {
	                int i = 1;
	                Integer rst =rs.getInt(i++);
	                        
	                results.add(rst);
	            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
	        e.printStackTrace();
	    }
	    return results;
	}
	/*--------------------------------get trips of specific creator----------------------------------------------------*/
	public ArrayList<Trip> GetTripByCreator(Integer creatorID)
	{
		ArrayList<Trip> results = new ArrayList<Trip>();
		    
		    try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_TRIP_BYUSER);) {
					stmt1.setInt(1, creatorID);
			           ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                Trip trip = new Trip(
				                        rs.getInt(i++),
				                        rs.getDate(i++),
				                        rs.getDate(i++),
				                        rs.getInt(i++), rs.getInt(i++));
				                // Add the Place ID  to the results list
				                results.add(trip);
				            }
		        }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		    return results;
	}
	/*------------------------------------------------------------------------*/
	@SuppressWarnings("unchecked")
	public ArrayList<Hotel> getHotels() {
	    ArrayList<Hotel> results = new ArrayList<>();

	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Hotels);
	             ResultSet rs = stmt.executeQuery()) {
	            while (rs.next()) {
	                int i = 1;
					Hotel h = new Hotel(
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++));
	                results.add(h);
	            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
	        e.printStackTrace();
	    }
	    return results;
	}
	public ArrayList<review> getReviews() {
	    ArrayList<review> results = new ArrayList<>();

	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Reviews);
	             ResultSet rs = stmt.executeQuery()) {
	            while (rs.next()) {
	                int i = 1;
	                review r = new review(
	                        rs.getInt(i++),
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++),
	                        rs.getInt(i++));
	                        

	                results.add(r);
	            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
	        e.printStackTrace();
	    }
	    return results;
	}
	public ArrayList<Place> getPlaces() {
	    
	    ArrayList<Place> results = new ArrayList<>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_Sel_place);
	             ResultSet rs = stmt.executeQuery()) {
	            
	            // Iterate over the result set and create Place objects
	            while (rs.next()) {
	                // Retrieve data from the result set and create a Place object
	                int i = 1;
	                Place place = new Place(
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++));
	                System.out.println("place="+place.toString());
	                // Add the Place object to the results list
	                results.add(place);
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


	@SuppressWarnings("unchecked")
	public ArrayList<Resturant> getResturant() {
	    ArrayList<Resturant> results = new ArrayList<>();

	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Resturant);
	             ResultSet rs = stmt.executeQuery()) {
	            while (rs.next()) {
	                int i = 1;
	                Resturant rst = new Resturant(
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++),
	                        rs.getString(i++),
	                        rs.getString(i++),
	                        rs.getInt(i++),
	                        rs.getString(i++));
	                        
	                results.add(rst);
	            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
	        e.printStackTrace();
	    }
	    return results;
	}
	/*------------------------------PlacesInTrip only place number----------------------------------------*/
	public ArrayList<Integer> getPlacesInTrip(Integer tripNumber)
	{
		ArrayList<Integer> results = new ArrayList<Integer>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_GET_TRIP_PLACES);) {
				stmt1.setInt(1, tripNumber);
		           ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                // Add the Place ID  to the results list
			                results.add(rs.getInt(i));
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	    return results;
	}
//	public ArrayList<review> getFullREviewInTrip(Integer tripNumber)
//	{
//		ArrayList<review> results = new ArrayList<review>();
//	    
//	    try {
//	        // Load the UCanAccess JDBC driver
//	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
//	        // Establish connection, execute query, and retrieve results
//	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
//	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACE_IN_TRIP);) {
//				stmt1.setInt(1, tripNumber);
//		           ResultSet rs =stmt1.executeQuery();
//		        	   
//			            while (rs.next()) {
//			                // Retrieve data from the result set and create a Place object
//			                int i = 1;
//			                review rev = new review(
//			                        rs.getInt(i++),
//			                        rs.getInt(i++),
//			                        rs.getString(i++),
//			                        rs.getInt(i++),
//			                        rs.getInt(i++));
//			                // Add the Place object to the results list
//			                results.add(rev);
//			            }
//	        }
//	    } catch (ClassNotFoundException | SQLException e) {
//			e.printStackTrace();
//		}
//	    return results;
//	}
	public ArrayList<review> getReviewsNotInTrip(Integer tripNumber)
	{
		ArrayList<review> results = new ArrayList<review>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_Review_NOTIN_TRIP);) {
				stmt1.setInt(1, tripNumber);
		           ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                review place = new review(
			                        rs.getInt(i++),
			                        rs.getInt(i++),
			                        rs.getString(i++),
			                        rs.getInt(i++),
			                        rs.getInt(i++));
			                // Add the Place object to the results list
			                results.add(place);
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	    return results;
	}
	/*------------------------------------PlacesInTrip only full-------------------------------------------------*/
	public ArrayList<Place> getFullPlacesInTrip(Integer tripNumber)
	{
		ArrayList<Place> results = new ArrayList<Place>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACE_IN_TRIP);) {
				stmt1.setInt(1, tripNumber);
		           ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                Place place = new Place(
			                        rs.getInt(i++),
			                        rs.getString(i++),
			                        rs.getString(i++),
			                        rs.getInt(i++),
			                        rs.getString(i++),
			                        rs.getString(i++));
			                // Add the Place object to the results list
			                results.add(place);
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	    return results;
	}
	/*------------------------------PlacesNotInTrip----------------------------------------*/
	public ArrayList<Place> getPlacesNotInTrip(Integer tripNumber)
	{
		ArrayList<Place> results = new ArrayList<Place>();
	    
	    try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_NOT_IN_TRIP_FULL);) {
				stmt1.setInt(1, tripNumber);
		           ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                Place place = new Place(
			                        rs.getInt(i++),
			                        rs.getString(i++),
			                        rs.getString(i++),
			                        rs.getInt(i++),
			                        rs.getString(i++),
			                        rs.getString(i++));
			                // Add the Place object to the results list
			                results.add(place);
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
	    return results;
	}
	/*--------------------------------- place reccomedations---------------------------------------------------*/
	public  ArrayList<Place> getPlaceReccomedations(Integer tripNumber,Integer maxDistance)
	{
		ArrayList<Place> results = new ArrayList<Place>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACE_REECOMEDATION_TRIP);) {
					stmt1.setInt(1, tripNumber);
					stmt1.setInt(2, maxDistance);
					stmt1.setInt(3, tripNumber);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                Place place = new Place(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(place);
				            }
		        }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*---------------------------------------------get user requsts for trip-----------------------------------------------------------------*/
	public ArrayList<UserRequest> getRequestForTrip(Integer tripNumber)
	{
		System.out.println("tripNumber="+tripNumber);
		ArrayList<UserRequest> requests= new ArrayList<UserRequest>();
		try {
	        // Load the UCanAccess JDBC driver
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        // Establish connection, execute query, and retrieve results
	        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
	        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_REQUEST_FOR_TRIP);) {
				stmt1.setInt(1, tripNumber);
		         ResultSet rs =stmt1.executeQuery();
		        	   
			            while (rs.next()) {
			                // Retrieve data from the result set and create a Place object
			                int i = 1;
			                UserRequest req = new UserRequest(
			                        rs.getInt(i++),
			                        rs.getInt(i++),
			                        rs.getString(i++));
			                // Add the Place object to the results list
			                requests.add(req);
			            }
	        }
	    } catch (ClassNotFoundException | SQLException e) {
			e.printStackTrace();
		}
		return requests;
	}
	/*-----------------------------------------filters-----------------------------------------------------------*/
	
	/*--------------------------------------------fliter by price---------------------------------------------------------------*/
	public  ArrayList<Place> getPlaceByPriceLevel(Integer tripNumber)
	{
		ArrayList<Place> results = new ArrayList<Place>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACES_BY_PRICE);) {
					stmt1.setInt(1, tripNumber);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                Place place = new Place(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(place);
				            }
		        }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*-------------------------------------------filter by specific style only--------------------------------------------*/
	public  ArrayList<Place> getPlaceByAccomedationStyle(Integer tripNumber,String accStyle)
	{
		ArrayList<Place> results = new ArrayList<Place>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACES_BY_ACCOMEDATION);) {
		        	//System.out.println("enter");
				
					stmt1.setInt(2, tripNumber);
					stmt1.setString(1, accStyle);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                Place place = new Place(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(place);
				            }
		        }
		        catch (SQLException e) {
		            System.err.println("SQLException: " + e.getMessage());
		            System.err.println("SQLState: " + e.getSQLState());
		            System.err.println("VendorError: " + e.getErrorCode());
		        }
		    } catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*-----------------------------------------places by kitchen-------------------------------------------------------*/
	public  ArrayList<Place> getPlaceByKitchen(Integer tripNumber,String kitchen)
	{
		ArrayList<Place> results = new ArrayList<Place>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_PLACES_BY_KITCHEN);) {
		        	//System.out.println("enter");
				
					stmt1.setInt(2, tripNumber);
					stmt1.setString(1, kitchen);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                Place place = new Place(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(place);
				            }
		        }
		        catch (SQLException e) {
		            System.err.println("SQLException: " + e.getMessage());
		            System.err.println("SQLState: " + e.getSQLState());
		            System.err.println("VendorError: " + e.getErrorCode());
		        }
		    } catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*----------------------------------------Users In Trip----------------------------------------*/
	public ArrayList<User> getUsersInTrip(Integer tripNumber)
	{
		ArrayList<User> results = new ArrayList<User>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USERS_IN_TRIP);) {
		        	//System.out.println("enter");
				
					stmt1.setInt(1, tripNumber);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;// with no pass
				                User use = new User(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(use);
				            }
		        }
		        catch (SQLException e) {
		            System.err.println("SQLException: " + e.getMessage());
		            System.err.println("SQLState: " + e.getSQLState());
		            System.err.println("VendorError: " + e.getErrorCode());
		        }
		    } catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*----------------------------------------Users not In Trip----------------------------------------*/
	public ArrayList<User> getUsersNotInTrip(Integer tripNumber)
	{
		ArrayList<User> results = new ArrayList<User>();
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_NOT_TRIP);) {
		        	//System.out.println("enter");
				
					stmt1.setInt(1, tripNumber);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				                int i = 1;
				                User use = new User(
				                        rs.getInt(i++),
				                        rs.getString(i++),
				                        rs.getString(i++),
				                        rs.getString(i++));
				                // Add the Place object to the results list
				                results.add(use);
				            }
		        }
		        catch (SQLException e) {
		            System.err.println("SQLException: " + e.getMessage());
		            System.err.println("SQLState: " + e.getSQLState());
		            System.err.println("VendorError: " + e.getErrorCode());
		        }
		    } catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
		
		  return results;
	}
	/*----------------------------------get count request not done in specific trip-----------------------------------------------------*/
	public Integer CountRequestsForTrip(Integer tripNumber)
	{
		Integer counter=0;// no requests
		  try {
		        // Load the UCanAccess JDBC driver
		        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
		        // Establish connection, execute query, and retrieve results
		        try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
		        	PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_Count_Request);) {
		        	//System.out.println("enter");
				
					stmt1.setInt(1, tripNumber);
			         ResultSet rs =stmt1.executeQuery();
			        	   
				            while (rs.next()) {
				                // Retrieve data from the result set and create a Place object
				            	counter++;
				            }
		        }
		        catch (SQLException e) {
		            System.err.println("SQLException: " + e.getMessage());
		            System.err.println("SQLState: " + e.getSQLState());
		            System.err.println("VendorError: " + e.getErrorCode());
		        }
		    } catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
		
		
		
		return counter;
	}
/*---------------------ADD/REMOVE/UPDATE FUNCTIONS---------------------------*/
	public boolean addTrip(Integer tripId, Date startDate, Date endDate,Integer CreatorID,Integer status) {
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_TRIP)) {
				//System.out.println((java.sql.Date) startDate);
// Set parameters for the stored procedure or SQL statement
				java.sql.Date sqlDate = new java.sql.Date(startDate.getTime());
				java.sql.Date sqlDateEnd = new java.sql.Date(endDate.getTime());
				int i = 1;
				stmt.setInt(i++, tripId);
				stmt.setDate(i++,   sqlDate);
				stmt.setDate(i++,   sqlDateEnd);
				stmt.setInt(i++, CreatorID);
				stmt.setInt(i++, status);
// Execute the statement
				stmt.executeUpdate();
				return true;

			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return false;
	}
	/*------------------------------------add place to trip-----------------------------------------------------------*/
	public boolean addPlaceToTrip(Integer tripID,Integer placeId)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_PLACE_TO_TRIP)) { 
	            stmt.setInt(1, tripID);
	            stmt.setInt(2, placeId);
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
	
//	public boolean addReviewToTrip(Integer tripID,Integer ReviewID)
//	{
//	     try{
//	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
//	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
//	        try (Connection conn = DriverManager.getConnection(connStr);
//	             CallableStatement stmt = conn.prepareCall(Consts.SQL_AddReview_to_Trip)) { 
//	            stmt.setInt(1, tripID);
//	            stmt.setInt(2, ReviewID);
//	            stmt.executeUpdate();
//	            return true;
//	        } catch (SQLException e) {
//	            e.printStackTrace();
//	            return false;
//	        }
//	    } catch (ClassNotFoundException e) {
//	        e.printStackTrace();
//	    }
//		return false;
//	}
	public boolean addReviewToTrip(int reviewID, int score, String comment, int placeID, int userId, int tripNumber,Date writeTime) {
	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             PreparedStatement stmt = conn.prepareStatement(Consts.SQL_INS_Reviews)) {
	        	java.sql.Date sqlDate = new java.sql.Date(writeTime.getTime());
	            stmt.setInt(1, reviewID);
	            stmt.setInt(2, score);
	            stmt.setString(3, comment);
	            stmt.setInt(4, placeID);
	            stmt.setInt(5, userId); // Set userId
	            stmt.setInt(6, tripNumber); // Set tripNumber
	            stmt.setDate(7,  sqlDate); // Set date
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


	/*-----------------------------------------remove place from trip-----------------------------------------------------------------------*/
	public boolean removePlaceToTrip(Integer tripID,Integer placeId)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_DEL_PLACE_IN_TRIP)) { 
	            stmt.setInt(1, tripID);
	            stmt.setInt(2, placeId);
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
	/*---------------------------------------add user to trip -------------------------------------------------------------------------------------------------*/
	public boolean addUserToTrip(Integer tripID,Integer UserId)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        System.out.println("trip="+tripID+" user="+UserId);
	        try (Connection conn = DriverManager.getConnection(connStr);
	            CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_USER_TO_TRIP)) { 
	        	System.out.println("enterd?");
	            stmt.setInt(1, tripID);
	            stmt.setInt(2, UserId);
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
	/*---------------------------------------remove user from trip SQL_INS_USER_TO_TRIP-------------------------------------------------------------------------------------------------*/
	public boolean removeUserFromTrip(Integer tripID,Integer UserId)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_DEL_USER_IN_TRIP)) { 
	            stmt.setInt(1, tripID);
	            stmt.setInt(2, UserId);
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
	/*------------------------------------------------------------------------------------------------------------------------*/
	public boolean removeTrip(Integer tripID) {//need to change
	    try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_DEL_Trip)) { 
	            stmt.setInt(1, tripID);
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
	/*-----------------------------------update trip status----------------------------------------------------*/
	public boolean updateTripStatus(Integer tripId, Integer status) {
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_TRIP_STATUS)) {
				int i = 1;
				stmt.setInt(i++, status); // can't be null
				stmt.setInt(i++, tripId); // can't be null
			
				stmt.executeUpdate();
				return true;
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return false;
	}
/*	public boolean editTrip(Integer tripId, Integer reviewId, Integer rating, Date startDate,
			Date endDate, ArrayList<Integer> additionalTravelers) {
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_TRIP)) {
				int i = 1;

				stmt.setLong(i++, tripId); // can't be null
				stmt.setLong(i++, reviewId); // can't be null
				stmt.setLong(i++, rating); // can't be null
				java.sql.Array array = conn.createArrayOf("INTEGER", additionalTravelers.toArray());
				stmt.setArray(i++, array);
				if (startDate != null)
					stmt.setDate(i++, new java.sql.Date(startDate.getTime()));
				else
					stmt.setNull(i++, java.sql.Types.DATE);
				if (endDate != null) {
					stmt.setDate(i++, new java.sql.Date(endDate.getTime()));
					stmt.setNull(i++, java.sql.Types.VARCHAR);
					}
				else
					stmt.setNull(i++, java.sql.Types.VARCHAR);
				stmt.setLong(i++, tripId);

				stmt.executeUpdate();
				return true;
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return false;
	}
	
	public boolean addPlace(Integer placeId, String priceLevel, String nameOfPlace, String description, String city,
	String urlLandmark) {
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_place)) {

// Set parameters for the stored procedure or SQL statement
				int i = 1;
				stmt.setInt(i++, placeId);
				stmt.setString(i++, priceLevel);
				stmt.setString(i++, nameOfPlace);
				stmt.setString(i++,description);
				stmt.setString(i++,city);
				stmt.setString(i++,urlLandmark);

// Execute the statement
				stmt.executeUpdate();
				return true;

			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return false;
	}
	public boolean removeplace(long placeID) {
	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        String sql = Consts.SQL_DEL_Place; // Assuming TripID is the unique identifier for trips
	        try (Connection conn = DriverManager.getConnection(connStr);
	             PreparedStatement stmt = conn.prepareStatement(sql)) {
	            stmt.setLong(1, placeID);
	            int affectedRows = stmt.executeUpdate();
	            if (affectedRows == 1) {
	                return true; // One trip deleted successfully
	            } else {
	                System.out.println("No trip found with ID: " + placeID);
	                return false;
	            }
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    } catch (ClassNotFoundException e) {
	        e.printStackTrace();
	        return false;
	    }
	}
	
	/*-----------------------------------*/
/*	public boolean editPlace(Integer placeId, String priceLevel, String nameOfPlace, String description, String city,
			String urlLandmark){
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_Place)) {
				int i = 1;

				stmt.setLong(i++, placeId); // can't be null
				stmt.setString(i++, priceLevel); // can't be null
				stmt.setString(i++, nameOfPlace); // can't be null
				stmt.setString(i++, description); // can't be null
				stmt.setString(i++, city); // can't be null
				stmt.setString(i++, urlLandmark); // can't be null
					stmt.setNull(i++, java.sql.Types.VARCHAR);
					stmt.setLong(i++, placeId);

				stmt.executeUpdate();
				return true;
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return false;
	}*/

}
