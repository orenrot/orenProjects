package control;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;

import entity.Consts;
import entity.Trip;
import entity.User;
import entity.UserRequest;
import entity.review;

public class UserLogic {
	private static UserLogic _instanceUser;

	public UserLogic() {
	}

	public static UserLogic getInstance() {
		if (_instanceUser == null)
			_instanceUser = new UserLogic();
		return _instanceUser;
	}
	/*-----------------------------GET FUNCTIONS -------------------------*/
	public boolean getUserTruePassword(Integer userId,String password){//true if found else false
		User user ;
		//System.out.println(userId+ " pass="+password);
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_CAN_ENTER);) {
				stmt1.setInt(1, userId);
				stmt1.setString(2, password);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
						int i = 1;
						//System.out.println("enterd user="+rs.getInt(i++));
						return true;
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
	    return false;
	}
	/*----------------------------check if email exsits----------------------------------------*/
	public boolean getEmail(String email){//true if found else false
		User user ;
		System.out.println(email);
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_USER_EMAIL);) {
				stmt1.setString(1, email);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
						int i = 1;
						//System.out.println("enterd user="+rs.getInt(i++));
						return true;
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
	    return false;
	}
	/*-----------------------------------------------------------------------------------------*/
	public String UserEmail(Integer userId)
	{
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_Email_BY_ID);) {
					stmt1.setInt(1, userId);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
						int i = 1;
						return rs.getString(i++);//return the email
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
	    return null;
	}
	public Integer getLastId()
	{
		Integer lastId=0;
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_LAST_ID);) {
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 lastId=rs.getInt(i);
		        	// results.add(new Trip(rs.getInt(i++), rs.getString(i++), rs.getInt(i++), rs.getDate(i++),
						//		rs.getDate(i++), (rs.getInt(i++))));// need to check
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return lastId+1;//1 not found so 1 can be or the last will be this number
	}
	/*-------------------------------------------get if vp------------------------------------------------------*/
	public boolean IsVPOfCultre(Integer userID)//is vp culture
	{
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_VP_CULTURE);) {
				stmt1.setInt(1, userID);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
						int i = 1;
						//System.out.println("enterd user="+rs.getInt(i++));
						return true;
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
	    return false;
	}
	/*----------------------------------get if vice percident-----------------------------------------------------------------*/
	public boolean IsVicePresident(Integer userID)//is vp culture
	{
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_VicePresident);) {
				stmt1.setInt(1, userID);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
						int i = 1;
						//System.out.println("enterd user="+rs.getInt(i++));
						return true;
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
	    return false;
	}
	/*---------------------------------------trips in---------------------------------------------------------*/
	public ArrayList<Integer> canWriteReview(Integer userId)
	{
		LocalDate currentDate = LocalDate.now();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        String formattedDate = currentDate.format(formatter);

        // Parse the formattedDate to LocalDate and then convert to java.sql.Date
        LocalDate parsedDate = LocalDate.parse(formattedDate, formatter);
        Date sqlDate = Date.valueOf(parsedDate);
		ArrayList<Integer> result= new ArrayList<Integer>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_TRIP_IN);) {
				stmt1.setInt(1, userId);
				stmt1.setDate(2, sqlDate);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 result.add((rs.getInt(i++)));// add trip that user in
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return result;
		
	}
	
	/*------------------------------get trip request that user in-------------------------------------*/
	public  ArrayList<Trip> requestForTripIn(Integer userId)
	{
		ArrayList<Trip> results = new ArrayList<Trip>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_REQUEST_IN_TRIP);) {
				stmt1.setInt(1, userId);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 results.add(new Trip(rs.getInt(i++), rs.getDate(i++),
								rs.getDate(i++), (rs.getInt(i++))));// need to check
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return results;
	}
	/*------------------------------get trip request that user not in-------------------------------------*/
	public  ArrayList<Trip> requestForTripNotIn(Integer userId)
	{
		ArrayList<Trip> results = new ArrayList<Trip>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_USER_REQUEST_OUT_TRIP);) {
				stmt1.setInt(1, userId);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 results.add(new Trip(rs.getInt(i++), rs.getDate(i++),
								rs.getDate(i++), (rs.getInt(i++))));// need to check
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return results;
	}
	/*----------------------------------------------get request for the user to join------------------------------------------------------------*/
	public ArrayList<Integer> requestToJoin(Integer userId,String Email)// i think we need only email need to check
	{
		ArrayList<Integer> results = new ArrayList<Integer>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_REQUEST_ForUser);) {
				stmt1.setInt(1, userId);
				stmt1.setString(2, Email);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 results.add(rs.getInt(i));
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return results;
	}
	/*----------------------------------------------get request for the user to join full info--------------------------------------------------------------*/
	public ArrayList<UserRequest> requestToJoinFullInfo(Integer TripId)// i think we need only email need to check
	{
		ArrayList<UserRequest> results = new ArrayList<UserRequest>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_USER_REQUEST_FULL_TRIP);) {
				stmt1.setInt(1, TripId);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 results.add( new UserRequest(rs.getInt(i++),rs.getInt(i++),rs.getString(i++),rs.getInt(i++),rs.getString(i++)));
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return results;
	}
	/*------------------------------insert request to specific trip user-------------------------------------*/
	public boolean addRequestToUser(Integer userId,Integer tripNumber,String desribe,String email)
	{
		Integer status=0;
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_USER_REQUEST)) { 
	            stmt.setInt(1, userId);
	            stmt.setInt(2, tripNumber);
	            stmt.setString(3, desribe);
	            stmt.setInt(4, status);//0 not yet done the Reference
	            stmt.setString(5, email);
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
	/*---------------------------------------------update request---------------------------------------------------------*/
	public boolean updateRequestToUser(Integer userId,Integer tripNumber,String email)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_USER_REQUSET)) { 
	            stmt.setInt(1, userId);
	            stmt.setInt(2, tripNumber);
	            stmt.setString(3, email);
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
	/*--------------------------------------------------add user-------------------------------------------------------------------*/
	public boolean InsertUser(User user)
	{
	     try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_USER)) { 
	            stmt.setInt(1, user.getUserId());
	            stmt.setString(2, user.getFirstName());
	            stmt.setString(3, user.getLastName());
	            stmt.setString(4, user.getEmail());
	            stmt.setString(5, user.getPassword());
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
