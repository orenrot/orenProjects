package control;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;

import entity.Consts;
import entity.Resturant;

public class ResturantLogic extends PlaceLogic {
private static ResturantLogic _instanceResturant;
	
	public static ResturantLogic getInstance() {
		if (_instanceResturant == null)
			_instanceResturant = new ResturantLogic();
		return _instanceResturant;
	}
	/*--------------------get Resturant------------------------------------*/
	public ArrayList<Resturant> getResturant() {
		ArrayList<Resturant> results = new ArrayList<Resturant>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_Resturant);
					ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					int i = 1;
					results.add(new Resturant(rs.getInt(i++), rs.getString(i++), rs.getString(i++),  rs.getInt(i++),
							rs.getString(i++), (rs.getString(i++)),(rs.getInt(i++)), (rs.getString(i++))));// need to check
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return results;
	}
	/*----------------------------get all style from database----------------------------------------*/
	public ArrayList<String> getStyles() {
		ArrayList<String> results = new ArrayList<String>();
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					PreparedStatement stmt = conn.prepareStatement(Consts.SQL_SEL_KITCHEN);
					ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					int i = 1;
					results.add(rs.getString(i++));// need to check
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		return results;
	}
	/*------------------------------------------------------------------------------------------------*/
	public boolean InsertResturant(Integer placeId,Integer starRating,String style)
	{

		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_INS_Resturant)) {
				int i = 1;
				stmt.setInt(i++, placeId); // can't be null
				stmt.setInt(i++, starRating); // can't be null
				stmt.setString(i++, style); // can't be null
				
				
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
	/*-----------------------------------------------------------------------------------------------*/
	public boolean editResturantStyle(Integer placeId,String style) {
		try {
			Class.forName("net.ucanaccess.jdbc.UcanaccessDriver");
			try (Connection conn = DriverManager.getConnection(Consts.CONN_STR);
					CallableStatement stmt = conn.prepareCall(Consts.SQL_UPD_ResturantStyle)) {
				int i = 1;
				//System.out.println(placeId+" style="+ style);
				stmt.setString(i++, style); // can't be null
				stmt.setInt(i++, placeId); // can't be null
				
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
}
