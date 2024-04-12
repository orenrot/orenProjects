package control;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;

import org.json.simple.JsonArray;
import org.json.simple.JsonObject;
import org.json.simple.Jsoner;

import entity.Consts;
import entity.Trip;
import entity.review;

public class Revivewlogic {
	private static Revivewlogic _instanceReview;

	public static Revivewlogic getInstance() {
		if (_instanceReview == null)
			_instanceReview = new Revivewlogic();
		return _instanceReview;
	}
	/*---------------------------------------------------------------------------------------------------*/
	public ArrayList<review> UserReviews(Integer userID) 
	{
		ArrayList<review> results = new ArrayList<review>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_SEL_USER_Reivews);) {
				stmt1.setInt(1, userID);
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 results.add(new review(rs.getInt(i++), rs.getInt(i++),rs.getString(i++),rs.getInt(i++)
		        			 ,rs.getInt(i++),rs.getInt(i++),rs.getDate(i++)));// need to check
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		return results;
	}
	/*------------------------------------------next reviewId---------------------------------------------------------*/
	public Integer nextReviewId()
	{
		Integer reviewId=0;
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt1 = conn.prepareStatement(Consts.SQL_LAST_ReviewsID);) {
		           ResultSet rs =stmt1.executeQuery();	 
		         while (rs.next()) {//has value
		        	 int i=1;
		        	 reviewId=((rs.getInt(i++)));// add trip that user in
					}
			        
		       }
		    } catch (ClassNotFoundException | SQLException e) {
				e.printStackTrace();
			}
		reviewId++;//for nextId
		return reviewId;
	}
	//public boolean canWriteReview(Date )
	/*--------------------------------------------add review------------------------------------------------------------------------------------------*/
	public boolean addReview(Integer reviewID,Integer score,String comment,Integer placeId,Integer userId,Integer tripNumber) {
			try {
				Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
				try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
						CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_Reviews)) {
	
					// Set parameters for the stored procedure or SQL statement
					int i = 1;
					stmt.setInt(i++, reviewID);
					stmt.setInt(i++, score);
					stmt.setString(i++, comment);
					stmt.setInt(i++, placeId);
					stmt.setInt(i++, userId);
					stmt.setInt(i++, tripNumber);
	
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
	/*---------------------------------------reviewId-------------------------------------------------------------*/
	public boolean removeReview(long revieID) {
	    try {
	        Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        String sql = Consts.SQL_DEL_Reviews; // Assuming TripID is the unique identifier for trips
	        try (Connection conn = DriverManager.getConnection(connStr);
	             PreparedStatement stmt = conn.prepareStatement(sql)) {
	            stmt.setLong(1, revieID);
	            int affectedRows = stmt.executeUpdate();
	            if (affectedRows == 1) {
	                return true; // One trip deleted successfully
	            } else {
	                System.out.println("No trip found with ID: " + revieID);
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
	/*---------------------------------update review-------------------------------------------------------------*/
	public boolean editReview(Integer reviewID, Integer score, String comment, Date timeWrite){
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_ReviewSpecific)) {
				int i = 1;
	        	java.sql.Date sqlDate = new java.sql.Date(timeWrite.getTime());
				stmt.setString(i++, comment); // can't be null
				stmt.setDate(i++, sqlDate); // can't be null
				stmt.setInt(i++, score); // can't be null
				stmt.setInt(i++, reviewID); // can't be null

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
	/*------------------------------------------delete review by tripId------------------------------------------------------------------------*/
	public boolean deleteReviewByID(Integer tripID)
	{
		 try{
	    	 Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
	        String connStr = Consts.CONN_STR; // Replace with your actual connection string
	        try (Connection conn = DriverManager.getConnection(connStr);
	             CallableStatement stmt = conn.prepareCall(Consts.SQL_DEL_Reviews_BY_TRIP_ID)) { 
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
	/*---------------------------------------json------------------------------------------------------*/
	public void exportReviewsToJSON() {
 	   try {
            Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
            try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
                    PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Reviews);
                    ResultSet rs = stmt.executeQuery()) {
         	   JsonArray reviews = new JsonArray();
                while (rs.next()) {
             	   JsonObject review = new JsonObject();
             	   
             	   for (int i = 1; i < rs.getMetaData().getColumnCount(); i++)
             	   {
             		  String columnName = rs.getMetaData().getColumnName(i);
             		    String columnValue = rs.getString(i);
             		    
             		    if (columnName.equals("UserId")) {// limit to one letter
             		        if (columnValue.length() > 1) {
             		            columnValue = columnValue.substring(0, 1); // Limiting UserId to one letter
             		        }
             		    }
             		    
             		    review.put(columnName, columnValue);//added the substring
             	   }
             		  // review.put(rs.getMetaData().getColumnName(i), rs.getString(i));
             	   
             	   
             	   reviews.add(review);
                }
                
         	   JsonObject doc = new JsonObject();
         	   doc.put("Revivews_info", reviews);
                
                File file = new File("json/reviews.json");
                file.getParentFile().mkdir();
                
                try (FileWriter writer = new FileWriter(file)) {
             	   writer.write(Jsoner.prettyPrint(doc.toJson()));
             	   writer.flush();
                    System.out.println("reviews data exported successfully!");
                } catch (IOException e) {
             	   e.printStackTrace();
                }
            } catch (SQLException | NullPointerException e) {
                e.printStackTrace();
            }
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }	
 }
}
